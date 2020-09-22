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
  swap paying Libor against BMA coupons
  </summary> *)
[<AutoSerializable(true)>]
module BMASwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_bmaLeg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_bmaLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).BmaLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BMASwap.source + ".BmaLeg") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_bmaLegBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_bmaLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).BmaLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".BmaLegBPS") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_bmaLegNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_bmaLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).BmaLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".BmaLegNPV") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="liborSchedule",Description = "Reference to liborSchedule")>] 
         liborSchedule : obj)
        ([<ExcelArgument(Name="liborFraction",Description = "Reference to liborFraction")>] 
         liborFraction : obj)
        ([<ExcelArgument(Name="liborSpread",Description = "Reference to liborSpread")>] 
         liborSpread : obj)
        ([<ExcelArgument(Name="liborIndex",Description = "Reference to liborIndex")>] 
         liborIndex : obj)
        ([<ExcelArgument(Name="liborDayCount",Description = "Reference to liborDayCount")>] 
         liborDayCount : obj)
        ([<ExcelArgument(Name="bmaSchedule",Description = "Reference to bmaSchedule")>] 
         bmaSchedule : obj)
        ([<ExcelArgument(Name="bmaIndex",Description = "Reference to bmaIndex")>] 
         bmaIndex : obj)
        ([<ExcelArgument(Name="bmaDayCount",Description = "Reference to bmaDayCount")>] 
         bmaDayCount : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Type> Type "Type" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _liborSchedule = Helper.toCell<Schedule> liborSchedule "liborSchedule" true
                let _liborFraction = Helper.toCell<double> liborFraction "liborFraction" true
                let _liborSpread = Helper.toCell<double> liborSpread "liborSpread" true
                let _liborIndex = Helper.toCell<IborIndex> liborIndex "liborIndex" true
                let _liborDayCount = Helper.toCell<DayCounter> liborDayCount "liborDayCount" true
                let _bmaSchedule = Helper.toCell<Schedule> bmaSchedule "bmaSchedule" true
                let _bmaIndex = Helper.toCell<BMAIndex> bmaIndex "bmaIndex" true
                let _bmaDayCount = Helper.toCell<DayCounter> bmaDayCount "bmaDayCount" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.BMASwap 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _liborSchedule.cell 
                                                            _liborFraction.cell 
                                                            _liborSpread.cell 
                                                            _liborIndex.cell 
                                                            _liborDayCount.cell 
                                                            _bmaSchedule.cell 
                                                            _bmaIndex.cell 
                                                            _bmaDayCount.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BMASwap>) l

                let source = Helper.sourceFold "Fun.BMASwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _liborSchedule.source
                                               ;  _liborFraction.source
                                               ;  _liborSpread.source
                                               ;  _liborIndex.source
                                               ;  _liborDayCount.source
                                               ;  _bmaSchedule.source
                                               ;  _bmaIndex.source
                                               ;  _bmaDayCount.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _liborSchedule.cell
                                ;  _liborFraction.cell
                                ;  _liborSpread.cell
                                ;  _liborIndex.cell
                                ;  _liborDayCount.cell
                                ;  _bmaSchedule.cell
                                ;  _bmaIndex.cell
                                ;  _bmaDayCount.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
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
    [<ExcelFunction(Name="_BMASwap_fairLiborFraction", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_fairLiborFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).FairLiborFraction
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".FairLiborFraction") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_fairLiborSpread", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_fairLiborSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).FairLiborSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".FairLiborSpread") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_liborFraction", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_liborFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LiborFraction
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LiborFraction") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_liborLeg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_liborLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LiborLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BMASwap.source + ".LiborLeg") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_liborLegBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_liborLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LiborLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LiborLegBPS") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_liborLegNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_liborLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LiborLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LiborLegNPV") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_liborSpread", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_liborSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LiborSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LiborSpread") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_nominal", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".Nominal") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_type", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".TYPE") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_endDiscounts", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".EndDiscounts") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BMASwap_engine", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".Engine") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_isExpired", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".IsExpired") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_leg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BMASwap.source + ".Leg") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_legBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LegBPS") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BMASwap_legNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".LegNPV") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BMASwap_maturityDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".MaturityDate") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_npvDateDiscount", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".NpvDateDiscount") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_payer", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".Payer") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BMASwap_startDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".StartDate") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_startDiscounts", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".StartDiscounts") 
                                               [| _BMASwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BMASwap_CASH", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".CASH") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_errorEstimate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".ErrorEstimate") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_NPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".NPV") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_BMASwap_result", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".Result") 
                                               [| _BMASwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_BMASwap_setPricingEngine", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BMASwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".SetPricingEngine") 
                                               [| _BMASwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_BMASwap_valuationDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap" true 
                let builder () = withMnemonic mnemonic ((_BMASwap.cell :?> BMASwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwap.source + ".ValuationDate") 
                                               [| _BMASwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwap.cell
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
    [<ExcelFunction(Name="_BMASwap_Range", Description="Create a range of BMASwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BMASwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BMASwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BMASwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BMASwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BMASwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
