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
  This class assumes that the reference date does not change between calls of setTermStructure().
  </summary> *)
[<AutoSerializable(true)>]
module BondHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BondHelper_bond", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).Bond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold (_BondHelper.source + ".Bond") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning Setting a pricing engine to the passed bond from external code will cause the bootstrap to fail or to give wrong results. It is advised to discard the bond after creating the helper, so that the helper has sole ownership of it.
    *)
    [<ExcelFunction(Name="_BondHelper", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="bond",Description = "Reference to bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="useCleanPrice",Description = "Reference to useCleanPrice")>] 
         useCleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toHandle<Quote> price "price" 
                let _bond = Helper.toCell<Bond> bond "bond" true
                let _useCleanPrice = Helper.toCell<bool> useCleanPrice "useCleanPrice" true
                let builder () = withMnemonic mnemonic (Fun.BondHelper 
                                                            _price.cell 
                                                            _bond.cell 
                                                            _useCleanPrice.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BondHelper>) l

                let source = Helper.sourceFold "Fun.BondHelper" 
                                               [| _price.source
                                               ;  _bond.source
                                               ;  _useCleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _bond.cell
                                ;  _useCleanPrice.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BondHelper_impliedQuote", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".ImpliedQuote") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        RateHelper interface
    *)
    [<ExcelFunction(Name="_BondHelper_setTermStructure", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let _t = Helper.toCell<YieldTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".SetTermStructure") 
                                               [| _BondHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_useCleanPrice", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_useCleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).UseCleanPrice
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".UseCleanPrice") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_earliestDate", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".EarliestDate") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_latestDate", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".LatestDate") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_latestRelevantDate", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".LatestRelevantDate") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_maturityDate", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".MaturityDate") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_pillarDate", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".PillarDate") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_quote", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_BondHelper.source + ".Quote") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BondHelper_quoteError", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".QuoteError") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_quoteIsValid", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".QuoteIsValid") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_quoteValue", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".QuoteValue") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_registerWith", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".RegisterWith") 
                                               [| _BondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_unregisterWith", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".UnregisterWith") 
                                               [| _BondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_BondHelper_update", Description="Create a BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondHelper",Description = "Reference to BondHelper")>] 
         bondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BondHelper = Helper.toCell<BondHelper> bondhelper "BondHelper" true 
                let builder () = withMnemonic mnemonic ((_BondHelper.cell :?> BondHelperModel).Update
                                                       ) :> ICell
                let format (o : BondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BondHelper.source + ".Update") 
                                               [| _BondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BondHelper_Range", Description="Create a range of BondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BondHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BondHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BondHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BondHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BondHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BondHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
