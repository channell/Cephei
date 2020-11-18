(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module OISRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_impliedQuote", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".ImpliedQuote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Quote")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "OvernightIndex")>] 
         overnightIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _fixedRate = Helper.toHandle<Quote> fixedRate "fixedRate" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.OISRateHelper 
                                                            _settlementDays.cell 
                                                            _tenor.cell 
                                                            _fixedRate.cell 
                                                            _overnightIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OISRateHelper>) l

                let source () = Helper.sourceFold "Fun.OISRateHelper" 
                                               [| _settlementDays.source
                                               ;  _tenor.source
                                               ;  _fixedRate.source
                                               ;  _overnightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _tenor.cell
                                ;  _fixedRate.cell
                                ;  _overnightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OISRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_setTermStructure", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : OISRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".SetTermStructure") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_swap", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).Swap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedSwap>) l

                let source () = Helper.sourceFold (_OISRateHelper.source + ".Swap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OISRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Observer interface
    *)
    [<ExcelFunction(Name="_OISRateHelper_update", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : OISRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_OISRateHelper_earliestDate", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".EarliestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        The latest date at which discounts are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_OISRateHelper_latestDate", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".LatestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The latest date at which data are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_OISRateHelper_latestRelevantDate", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".LatestRelevantDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! instrument's maturity date
    *)
    [<ExcelFunction(Name="_OISRateHelper_maturityDate", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! pillar date
    *)
    [<ExcelFunction(Name="_OISRateHelper_pillarDate", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".PillarDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! BootstrapHelper interface
    *)
    [<ExcelFunction(Name="_OISRateHelper_quote", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_OISRateHelper.source + ".Quote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OISRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_quoteError", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".QuoteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_quoteIsValid", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".QuoteIsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_quoteValue", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".QuoteValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_registerWith", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OISRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OISRateHelper_unregisterWith", Description="Create a OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OISRateHelper",Description = "OISRateHelper")>] 
         oisratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OISRateHelper = Helper.toCell<OISRateHelper> oisratehelper "OISRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OISRateHelperModel.Cast _OISRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OISRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OISRateHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OISRateHelper.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_OISRateHelper_Range", Description="Create a range of OISRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OISRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OISRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<OISRateHelper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<OISRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<OISRateHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
