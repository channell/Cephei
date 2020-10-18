namespace Cephei.XL

open System;
open System.Collections.Generic
open System.Collections.Concurrent
open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open System.Collections
open Cephei.QL
open System.Threading.Tasks

type ModelRTD ()  =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new ConcurrentDictionary<ExcelRtdServer.Topic, string>()
    let _topicIndex             = new ConcurrentDictionary<string, ExcelRtdServer.Topic list>()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =
        
        let mnemonic = topicInfo.[0]
        let hc = topicInfo.[1]

        System.Diagnostics.Debug.Print ("ModelRTD ConnectData " + mnemonic + " " + hc);

        let dispatch () : unit = 
            _topics.[topic] <- mnemonic
            if _topicIndex.ContainsKey (mnemonic) then 
                _topicIndex.[mnemonic] <- [topic] @ _topicIndex.[mnemonic]
            else
                _topicIndex.[mnemonic] <- [topic]

            Model.add mnemonic 
            topic.UpdateValue mnemonic

        Task.Run (dispatch) |> ignore
        mnemonic :> obj
  

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =

        if _topics.ContainsKey(topic) then 
            let mnemonic = _topics.[topic]
            System.Diagnostics.Debug.Print ("ModelRTD DisconnectData " + mnemonic );
            let dispatch () : unit = 
                _topics.TryRemove (topic) |> ignore
                if _topicIndex.ContainsKey(mnemonic) then 
                    let nl = _topicIndex.[mnemonic] |> List.filter (fun t -> not (t = topic))
                    if nl = [] then 
                        _topicIndex.TryRemove mnemonic |> ignore
                        Model.remove mnemonic
                    else 
                            _topicIndex.[mnemonic] <- nl

                    _topics.TryRemove (topic) |> ignore

            Task.Run (dispatch) |> ignore
            
type ValueRTD ()  =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new ConcurrentDictionary<ExcelRtdServer.Topic, KeyValuePair<string, string>>()
    let _topicIndex             = new ConcurrentDictionary<Generic.KeyValuePair<string, string>, ExcelRtdServer.Topic list>()
    let _subscriptions          = new ConcurrentDictionary<Generic.KeyValuePair<string, string>, IDisposable> ()
    let _value                  = new ConcurrentDictionary<string, obj> ()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =

        let mnemonic = topicInfo.[0]
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
                    let listener = Model.subscribe this mnemonic layout
                    if not (listener = (null :> IDisposable)) then 
                        _subscriptions.[kv] <- listener
                        if Model.hasRange mnemonic layout then
                            topic.UpdateValue mnemonic 
                        elif _value.ContainsKey(mnemonic) then
                            topic.UpdateValue _value.[mnemonic]
                        else
                            try
                                topic.UpdateValue ((Model.cell mnemonic).Value.Box.ToString())
                            with
                            | e -> topic.UpdateValue ("#" + e.Message :> obj)
                    else
                        topic.UpdateValue "#NotValue"
            with
            | e -> topic.UpdateValue ("#" + e.Message)
        Task.Run (dispatch) |> ignore
        mnemonic :> obj

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
        Task.Run (dispatch) |> ignore

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
