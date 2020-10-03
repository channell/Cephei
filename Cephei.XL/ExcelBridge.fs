namespace Cephei.XL

open System;
open System.Collections.Generic
open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open System.Collections
open Cephei.QL

type ModelRTD ()  =
    inherit ExcelDna.Integration.Rtd.ExcelRtdServer ()

    let _topics                 = new Dictionary<ExcelRtdServer.Topic, string>()
    let _topicIndex             = new Dictionary<string, ExcelRtdServer.Topic list>()

    override this.ConnectData (topic : ExcelRtdServer.Topic, topicInfo : IList<string>, newValues : bool byref) =
        
        let mnemonic = topicInfo.[0]
        let hc = topicInfo.[1]

        _topics.[topic] <- mnemonic
        if _topicIndex.ContainsKey (mnemonic) then 
            _topicIndex.[mnemonic] <- [topic] @ _topicIndex.[mnemonic]
        else
            _topicIndex.[mnemonic] <- [topic]

        Model.add mnemonic //hc
        mnemonic :> obj
  

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =
        let mnemonic = _topics.[topic]

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

        if _topicIndex.ContainsKey (kv) then 
            _topics.[topic] <- kv
            _topicIndex.[kv] <- [topic] @ _topicIndex.[kv]
            let cell = Model.cell mnemonic
            if cell.Box :? IEnumerable  && not (cell.Box :? IEnumerable) then 
                cell.Mnemonic :> obj
            else
                cell.Box
        else
            _topics.[topic] <- kv
            _topicIndex.[kv] <- [topic]
            let listener = Model.subscribe this mnemonic layout
            if not (listener = (null :> IDisposable)) then 
                _subscriptions.[kv] <- listener
                let cell = Model.cell mnemonic
                if Model.hasRange mnemonic layout then
                    mnemonic :> obj
                else
                    cell.Box
            else
                "#NotValue" :> obj

    override this.DisconnectData (topic : ExcelRtdServer.Topic) =
        let kv = _topics.[topic]

        _topics.Remove (topic) |> ignore
        let nl = _topicIndex.[kv] |> List.filter (fun t -> not (t = topic))
        if nl = [] then 
            _topicIndex.Remove kv|> ignore
            if _subscriptions.ContainsKey(kv) then _subscriptions.[kv].Dispose ()
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
