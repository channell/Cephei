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
module RateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RateHelper", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "double")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toCell<double> quote "quote" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.RateHelper 
                                                            _quote.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateHelper>) l

                let source () = Helper.sourceFold "Fun.RateHelper" 
                                               [| _quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_RateHelper1", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "Quote")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toHandle<Quote> quote "quote" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.RateHelper1 
                                                            _quote.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateHelper>) l

                let source () = Helper.sourceFold "Fun.RateHelper1" 
                                               [| _quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RateHelper2", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.RateHelper2 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateHelper>) l

                let source () = Helper.sourceFold "Fun.RateHelper2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RateHelper> format
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
    [<ExcelFunction(Name="_RateHelper_earliestDate", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".EarliestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_impliedQuote", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".ImpliedQuote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_latestDate", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".LatestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_latestRelevantDate", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".LatestRelevantDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_maturityDate", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_pillarDate", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".PillarDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_quote", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_RateHelper.source + ".Quote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RateHelper_quoteError", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".QuoteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_quoteIsValid", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".QuoteIsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_quoteValue", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".QuoteValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_registerWith", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
        ! \warning Being a pointer and not a shared_ptr, the term structure is not guaranteed to remain allocated for the whole life of the rate helper. It is responsibility of the programmer to ensure that the pointer remains valid. It is advised that this method is called only inside the term structure being bootstrapped, setting the pointer to <b>this</b>, i.e., the term structure itself.
    *)
    [<ExcelFunction(Name="_RateHelper_setTermStructure", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        ([<ExcelArgument(Name="ts",Description = "YieldTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let _ts = Helper.toCell<YieldTermStructure> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).SetTermStructure
                                                            _ts.cell 
                                                       ) :> ICell
                let format (o : RateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".SetTermStructure") 

                                               [| _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
                                ;  _ts.cell
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
    [<ExcelFunction(Name="_RateHelper_unregisterWith", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_update", Description="Create a RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RateHelper",Description = "RateHelper")>] 
         ratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RateHelper = Helper.toCell<RateHelper> ratehelper "RateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((RateHelperModel.Cast _RateHelper.cell).Update
                                                       ) :> ICell
                let format (o : RateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RateHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RateHelper.cell
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
    [<ExcelFunction(Name="_RateHelper_Range", Description="Create a range of RateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<RateHelper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<RateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<RateHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
