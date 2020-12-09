namespace Cephei.XL

open System;
open System.Threading
open System.Collections.Generic
open System.Collections.Concurrent
open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open System.Collections
open Cephei.QL
open Cephei.Cell
open System.Threading.Tasks
open Serilog

type ModelRTD () as this =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new ConcurrentDictionary<ExcelRtdServer.Topic, string>()
    let _topicIndex             = new ConcurrentDictionary<string, ExcelRtdServer.Topic list>()

    let _subscription           = Model._state.Value.Model.Subscribe(this :> IObserver<ICell>)

    do AppDomain.CurrentDomain.SetData("RTDServer", this)

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =

        let mnemonic =  if topicInfo.[0].Contains("/") then topicInfo.[0].Substring(0,topicInfo.[0].IndexOf('/')) else topicInfo.[0]
        let hc = topicInfo.[1]

        System.Diagnostics.Debug.Print ("ModelRTD ConnectData " + mnemonic + " " + hc);

        let dispatch () : unit = 
            try
                _topics.[topic] <- mnemonic
                if _topicIndex.ContainsKey (mnemonic) then 
                    _topicIndex.[mnemonic] <- [topic] @ _topicIndex.[mnemonic]
                else
                    _topicIndex.[mnemonic] <- [topic]

                Model.add mnemonic 
                topic.UpdateValue mnemonic
            with 
            | e -> topic.UpdateValue ("#" + e.Message)
        Cephei.Cell.Cell.Dispatch (Action(dispatch)) 
            
        mnemonic :> obj

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =

        if  _topics.ContainsKey(topic) then 
            let mnemonic = _topics.[topic]
            System.Diagnostics.Debug.Print ("ModelRTD DisconnectData " + mnemonic );
            let dispatch () : unit = 
                try
                    _topics.TryRemove (topic) |> ignore
                    if _topicIndex.ContainsKey(mnemonic) then 
                        let nl = _topicIndex.[mnemonic] |> List.filter (fun t -> not (t = topic))
                        if nl = [] then 
                            _topicIndex.TryRemove mnemonic |> ignore
                            Model.remove mnemonic
                        else 
                                _topicIndex.[mnemonic] <- nl

                        _topics.TryRemove (topic) |> ignore
                with 
                | e -> Log.Error (e, e.Message)

            Cephei.Cell.Cell.Dispatch (Action(dispatch)) 

    interface IObserver<ICell> with

        member this.OnCompleted () =
            ignore 0
        member this.OnError (error : Exception) = 
            ignore 0

        member this.OnNext (c : ICell) = 
            if c.State = CellState.Error && not (c.Error = null) && _topicIndex.ContainsKey(c.Mnemonic) then
                if c.Error :? CalculationException then
                    _topicIndex.[c.Mnemonic]
                    |> List.iter (fun i -> i.UpdateValue ("#" + c.Error.Message))
                else
                    _topicIndex.[c.Mnemonic]
                    |> List.iter (fun i -> i.UpdateValue ("#" + (new CalculationException(c.Error)).Message))
            
    interface IValueRTD with 
        member this.UpdateValue (mnemonic : string) (layout : string) (value : obj) = 
            if _topicIndex.ContainsKey (mnemonic) then
                let topics = _topicIndex.[mnemonic]
                let apply (t : ExcelRtdServer.Topic) = t.UpdateValue (value)
                List.iter apply topics

        member this.UpdateRange (mnemonic : string) (layout : string) (value : obj[,]) = 
            raise (new NotImplementedException ())

type ValueRTD () as this =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new ConcurrentDictionary<ExcelRtdServer.Topic, KeyValuePair<string, string>>()
    let _topicIndex             = new ConcurrentDictionary<Generic.KeyValuePair<string, string>, ExcelRtdServer.Topic list>()
    let _subscriptions          = new ConcurrentDictionary<Generic.KeyValuePair<string, string>, IDisposable> ()
    let _value                  = new ConcurrentDictionary<string, obj> ()
    let _retry                  = new ConcurrentQueue<KeyValuePair<KeyValuePair<string, string>,ExcelRtdServer.Topic>> ()
    let _relink                 = new ConcurrentQueue<KeyValuePair<KeyValuePair<string, string>,ExcelRtdServer.Topic>> ()
    let _timer                  = new System.Timers.Timer (2000.0);

    let _RTDModel               = AppDomain.CurrentDomain.GetData("RTDServer") :?> IValueRTD

    let kvp (k : 'k) (v : 'v) = new KeyValuePair<'k,'v>(k,v)

    let updateValue (topic : ExcelRtdServer.Topic) mnemonic (value : obj) = 
(* not needed after change too post event notifcation
        if value :? string && (value :?> string).StartsWith("#") then 
            let c = Model.cell mnemonic
            if c.IsSome then
                c.Value.OnChange(Cephei.Cell.CellEvent.Link, c.Value, c.Value, DateTime.Now, null);
                _RTDModel.UpdateValue mnemonic ""  (mnemonic)
*)
        topic.UpdateValue value

    let subscribe (kv : KeyValuePair<KeyValuePair<string, string>,ExcelRtdServer.Topic>) = 
        let listener = Model.subscribe this kv.Key.Key kv.Key.Value
        if not (listener = (null :> IDisposable)) then 
            _subscriptions.[kv.Key] <- listener
            if Model.hasRange kv.Key.Key kv.Key.Value then
                kv.Value.UpdateValue kv.Key
                false
            elif _value.ContainsKey(kv.Key.Key) then
                kv.Value.UpdateValue _value.[kv.Key.Key]
                false
            else
                let c = Model.cell kv.Key.Key
                if c.IsSome then
                    c.Value.OnChange(Cephei.Cell.CellEvent.Link, c.Value, c.Value, DateTime.Now, null);
//                    _RTDModel.UpdateValue kv.Key.Key ""  kv.Key.Key
                true
        else
            true
    
    let tick (e : System.Timers.ElapsedEventArgs) : unit = 
        let mutable v : KeyValuePair<KeyValuePair<string, string>,ExcelRtdServer.Topic> = new KeyValuePair<KeyValuePair<string, string>,ExcelRtdServer.Topic> (KeyValuePair<string, string>(null,null), null)
        while _retry.TryDequeue(ref v) do
            if not (v.Key.Key = null) && (v.Value.Value :? string) then
                if subscribe v then
                    _retry.Enqueue v

    do  _timer.Elapsed.Add tick
        _timer.AutoReset <- true
        _timer.Enabled <- true
        _timer.Start ()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =

        let mnemonic =  if topicInfo.[0].Contains("/") then topicInfo.[0].Substring(0,topicInfo.[0].IndexOf('/')) else topicInfo.[0]
        let layout = topicInfo.[1]

        System.Diagnostics.Debug.Print ("ValueRTD ConnectData " + mnemonic + " " + layout);

        let dispatch () : unit = 
            let kv = new KeyValuePair<string,string>(mnemonic, layout);
            try
                if _topicIndex.ContainsKey (kv) then 
                   _topics.[topic] <- kv
                   _topicIndex.[kv] <- [topic] @ _topicIndex.[kv]
                   if _value.ContainsKey(mnemonic) then
                       topic.UpdateValue _value.[mnemonic]
                   else
                       topic.UpdateValue mnemonic 
                else
                    _topics.[topic] <- kv
                    _topicIndex.[kv] <- [topic]
                    let retry = kvp kv topic 
                    if subscribe retry then 
                        _retry.Enqueue(retry)
            with
            | e -> updateValue topic mnemonic ("#" + ((new Cephei.Cell.CalculationException(e)).Message))
        Task.Run (dispatch) |> ignore
        "#..." + mnemonic :> obj

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =
        
        let dispatch () : unit = 
            let kv = _topics.[topic]
            System.Diagnostics.Debug.Print ("ValueRTD DisconnectData " + kv.Value);

            _topics.TryRemove (topic) |> ignore
            let nl = _topicIndex.[kv] |> List.filter (fun t -> not (t = topic))
            if nl = [] then 
                _topicIndex.TryRemove kv|> ignore
                if _subscriptions.ContainsKey(kv) then _subscriptions.[kv].Dispose ()
                _subscriptions.TryRemove kv|> ignore
                Model.clearRange kv.Key
            else 
                _topicIndex.[kv] <- nl
        Cell.Dispatch (new Action (dispatch))

    interface IValueRTD with 
        member this.UpdateValue (mnemonic : string) (layout : string) (value : obj) = 
            let kv = new KeyValuePair<string,string> (mnemonic, layout)
            if _topicIndex.ContainsKey (kv) then
                let topics = _topicIndex.[kv]
                _value.[mnemonic] <- value
                let apply (t : ExcelRtdServer.Topic) = t.UpdateValue (value)
                List.iter apply topics

        member this.UpdateRange (mnemonic : string) (layout : string) (value : obj[,]) = 
            let kv = new KeyValuePair<string,string> (mnemonic, layout)
            if _topicIndex.ContainsKey (kv) then
                Model.setRange  mnemonic layout value
                let topics = _topicIndex.[kv]
                let apply (t : ExcelRtdServer.Topic) = t.UpdateValue (mnemonic)
                List.iter apply topics
