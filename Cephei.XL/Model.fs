namespace Cephei.XL

open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections.Generic
open System.Collections
open System

// Summary:  interface that functions will use to foreard events to Excel
type IValueRTD = 
    abstract UpdateValue : string -> string -> obj -> unit
    abstract UpdateRange : string -> string -> obj[,] -> unit

// Summary: bridge to convert observable events to an updatd value
type RTDObserver<'T> (rtd : IValueRTD, cell : ICell<'T>, format : 'T -> string -> obj, layout : string) as this =

    let _rtd = rtd
    let _mnemonic = cell.Mnemonic
    let _holder = cell.Subscribe(this)
    let _format = format
    let _layout = layout
    do _rtd.UpdateValue _mnemonic _layout (_format cell.Value layout)

    interface IObserver<'T> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : 'T) = 
                _rtd.UpdateValue _mnemonic _layout (_format value layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()


// Summary: bridge to convert observable events to an updatd values
type RTDRangeObserver<'T> (rtd : IValueRTD, cell : ICell<Generic.List<'T>>, format : Generic.List<'T> -> string -> obj[,], layout : string) as this =

    let _rtd = rtd
    let _mnemonic = cell.Mnemonic
    let _holder = cell.Subscribe(this)
    let _format = format
    let _layout = layout
    do _rtd.UpdateRange _mnemonic _layout (_format cell.Value layout)

    interface IObserver<Generic.List<'T>> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : Generic.List<'T>) = 
            _rtd.UpdateRange _mnemonic _layout (_format value layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()

// Summary: bridge to convert observable events to am model update
type RTDModelObserver<'t> (rtd : IValueRTD, model : ICell<'t>, format : ICell<'t> -> string -> obj[,], layout : string) as this =

    let _rtd = rtd
    let _mnemonic = model.Mnemonic
    let _model = model
    let _holder = (model :?> Model).Subscribe(this)
    let _format = format
    let _layout = layout
    do _rtd.UpdateValue _mnemonic _layout (_format _model layout)

    interface IObserver<ICell> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : ICell) = 
                _rtd.UpdateRange _mnemonic _layout (_format _model layout)

    interface IDisposable with
        member this.Dispose () =
            _holder.Dispose ()


// Summary: bridge to convert observable events to am model update
type RTDModelRangeObserver<'t> (rtd : IValueRTD, models : ICell<Generic.List<ICell<'t>>>, format : Generic.List<ICell<'t>> -> string -> obj[,], layout : string) as this =

    let _rtd = rtd
    let _mnemonic = models.Mnemonic
    let _models = models.Value
    let _holders = Seq.map (fun (i : ICell<'t>) -> (i :?> Model).Subscribe(this)) _models |> Seq.toArray
    let _format = format
    let _layout = layout
    do _rtd.UpdateValue _mnemonic _layout (_format _models layout)

    interface IObserver<ICell> with
        member this.OnCompleted () : unit =
            ignore 1

        member this.OnError (e : Exception) =
            _rtd.UpdateValue _mnemonic _layout (("#" + e.Message) :> obj)

        member this.OnNext (value : ICell) = 
                _rtd.UpdateRange _mnemonic _layout (_format _models layout)

    interface IDisposable with
        member this.Dispose () =
            _holders |> Array.iter (fun i -> i.Dispose ()) 

// Summary: Specification for an  RTD obj subscription
type spec = { mnemonic : string; creator : (unit ->ICell); subscriber : (IValueRTD -> ICell -> string -> IDisposable) ; source : string; hash : int}

module Model =

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)

    let private _model                  = new Model ()
//    let private _hash                   = new Dictionary<string, string> ()
    let private _source                 = new Dictionary<string, string> ()
    let private _subscriber             = new Dictionary<string, (IValueRTD -> ICell -> string -> IDisposable)> ()
    let private _ranges                 = new Dictionary<Generic.KeyValuePair<string, string>, obj[,]> ()

    let private _rtd                    = new Dictionary<string, spec> ()

    let IsInFunctionWizard () = 
        ExcelDnaUtil.IsInFunctionWizard()


    // Register a functor to create a cell if requried
    let specify (spec : spec) : obj =

        _rtd.[spec.mnemonic] <- spec
        XlCall.RTD ("Cephei.XL.ModelRTD", null, spec.mnemonic, spec.hash.ToString()) 

    // Register and get the value of a single obj
    let value (mnemonic : string) : obj =

        XlCall.RTD ("Cephei.XL.ValueRTD", null, mnemonic, "") 

    // Register and get the value from a range
    let range (mnemonic : string) (layout : string) : obj[,] =
        let k = kv mnemonic layout

        let rr = (XlCall.RTD ("Cephei.XL.ValueRTD", null, mnemonic, layout)).ToString()
        if _ranges.ContainsKey(k) then
            _ranges.[k]
        else 
            Array2D.create<obj> 1 1 "#NoValue"

    let add (s: string) = 
    
        if _rtd.ContainsKey(s) then
            let sub = _rtd.[s]
            let c = sub.creator()
            c.Mnemonic <- sub.mnemonic
            _model.[sub.mnemonic] <- c
            _source.[sub.mnemonic] <- sub.source
            _subscriber.[sub.mnemonic] <- sub.subscriber
            _rtd.Remove s |> ignore

    let remove s = 
    
        if _model.ContainsKey(s) then
            let cell = _model.[s]
            let mutable cell2 = cell
            if _model.TryRemove (s, ref cell2) then
                if not (cell = null) then
                    cell.Dependants|> Seq.iter (fun d -> d.OnChange (CellEvent.Link, cell, DateTime.Now, null ))
                _source.Remove s |> ignore
                _subscriber.Remove s |> ignore


    let subscribe (rtd : IValueRTD) (mnemonic : string) (layout : string) = 

        if _subscriber.ContainsKey (mnemonic) then 

            let f = _subscriber.[mnemonic]
            let c = _model.[mnemonic]
            let d = f rtd c layout
            d
        else
            null :> IDisposable

    let cell mnemonic = 
        _model.[mnemonic]

    let contains mnemonic = 
        _model.ContainsKey mnemonic

    // Summary : Add a cansting cell
    let addCast (c : ICell<'t>) (source : string) =
        _model.[c.Mnemonic] <- c
        _source.[c.Mnemonic] <- source
        c

    (*
        Handle array subscriptions
    *)
    let setRange m l o =
        _ranges.[kv m l] <- o

    let clearRange s =
        _ranges |> 
        Seq.filter (fun i -> i.Key.Key = s) |>
        Seq.toList |>
        List.iter (fun i -> _ranges.Remove( i.Key) |> ignore) 

type ModelRTD ()  =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new Dictionary<ExcelRtdServer.Topic, string>()
    let _topicIndex             = new Dictionary<string, ExcelRtdServer.Topic list>()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =
        
        let mnemonic = topicInfo.[0]
        let hc = topicInfo.[1]

        System.Diagnostics.Debug.WriteLine ("ModelRTD ConnectData " + mnemonic + " " + hc);

        _topics.[topic] <- mnemonic
        if _topicIndex.ContainsKey (mnemonic) then 
            _topicIndex.[mnemonic] <- [topic] @ _topicIndex.[mnemonic]
        else
            _topicIndex.[mnemonic] <- [topic]

        Model.add mnemonic //hc
        mnemonic :> obj
  

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =
        let mnemonic = _topics.[topic]

        System.Diagnostics.Debug.WriteLine ("ModelRTD DisconnectData " + mnemonic);

        _topics.Remove (topic) |> ignore
        let nl = _topicIndex.[mnemonic] |> List.filter (fun t -> not (t = topic))
        if nl = [] then 
            _topicIndex.Remove mnemonic |> ignore
            Model.remove mnemonic
        else 
                _topicIndex.[mnemonic] <- nl

        _topics.Remove (topic) |> ignore

            
type ValueRTD ()  =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new Dictionary<ExcelRtdServer.Topic, KeyValuePair<string, string>>()
    let _topicIndex             = new Dictionary<Generic.KeyValuePair<string, string>, ExcelRtdServer.Topic list>()
    let _subscriptions          = new Dictionary<Generic.KeyValuePair<string, string>, IDisposable> ()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =
        
        let mnemonic = topicInfo.[0]
        let layout = topicInfo.[1]

        let kv = new KeyValuePair<string,string>(mnemonic, layout);

        System.Diagnostics.Debug.WriteLine ("ValueRTD ConnectData " + mnemonic + " " + layout);

        if _topicIndex.ContainsKey (kv) then 
            _topics.[topic] <- kv
            _topicIndex.[kv] <- [topic] @ _topicIndex.[kv]
            let cell = Model.cell mnemonic
            cell.Box
        else
            _topics.[topic] <- kv
            _topicIndex.[kv] <- [topic]
            let listener = Model.subscribe this mnemonic layout
            if not (listener = (null :> IDisposable)) then 
                _subscriptions.[kv] <- listener
                let cell = Model.cell mnemonic
                cell.Box
            else
                "#NotValue" :> obj

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =
        let kv = _topics.[topic]

        System.Diagnostics.Debug.WriteLine ("ValueRTD DisconnectData " + kv.Key +  kv.Value);

        _topics.Remove (topic) |> ignore
        let nl = _topicIndex.[kv] |> List.filter (fun t -> not (t = topic))
        if nl = [] then 
            _topicIndex.Remove kv|> ignore
            _subscriptions.[kv].Dispose ()
            _subscriptions.Remove kv|> ignore
            Model.clearRange kv.Key
        else 
            _topicIndex.[kv] <- nl

    interface IValueRTD with 
        member this.UpdateValue (mnemonic : string) (layout : string) (value : obj) = 
            let kv = new KeyValuePair<string,string> (mnemonic, layout)
            if _topicIndex.ContainsKey (kv) then
                let topics = _topicIndex.[kv]
                let apply (t : ExcelRtdServer.Topic) = t.UpdateValue (value)
                List.iter apply topics

        member this.UpdateRange (mnemonic : string) (layout : string) (value : obj[,]) = 
            let kv = new KeyValuePair<string,string> (mnemonic, layout)
            if _topicIndex.ContainsKey (kv) then
                Model.setRange  mnemonic layout value
                let topics = _topicIndex.[kv]
                let apply (t : ExcelRtdServer.Topic) = t.UpdateValue (mnemonic)
                List.iter apply topics
