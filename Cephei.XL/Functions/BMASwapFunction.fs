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
    [<ExcelFunction(Name="_BMASwap_bmaLeg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_bmaLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).BmaLeg
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
    [<ExcelFunction(Name="_BMASwap_bmaLegBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_bmaLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).BmaLegBPS
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
    [<ExcelFunction(Name="_BMASwap_bmaLegNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_bmaLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).BmaLegNPV
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
    [<ExcelFunction(Name="_BMASwap", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _Type = Helper.toCell<BMASwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _liborSchedule = Helper.toCell<Schedule> liborSchedule "liborSchedule" 
                let _liborFraction = Helper.toCell<double> liborFraction "liborFraction" 
                let _liborSpread = Helper.toCell<double> liborSpread "liborSpread" 
                let _liborIndex = Helper.toCell<IborIndex> liborIndex "liborIndex" 
                let _liborDayCount = Helper.toCell<DayCounter> liborDayCount "liborDayCount" 
                let _bmaSchedule = Helper.toCell<Schedule> bmaSchedule "bmaSchedule" 
                let _bmaIndex = Helper.toCell<BMAIndex> bmaIndex "bmaIndex" 
                let _bmaDayCount = Helper.toCell<DayCounter> bmaDayCount "bmaDayCount" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
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
                    ; subscriber = Helper.subscriberModel<BMASwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_fairLiborFraction", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_fairLiborFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).FairLiborFraction
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
    [<ExcelFunction(Name="_BMASwap_fairLiborSpread", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_fairLiborSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).FairLiborSpread
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
    [<ExcelFunction(Name="_BMASwap_liborFraction", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_liborFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LiborFraction
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
    [<ExcelFunction(Name="_BMASwap_liborLeg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_liborLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LiborLeg
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
    [<ExcelFunction(Name="_BMASwap_liborLegBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_liborLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LiborLegBPS
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
    [<ExcelFunction(Name="_BMASwap_liborLegNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_liborLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LiborLegNPV
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
    [<ExcelFunction(Name="_BMASwap_liborSpread", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_liborSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LiborSpread
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
    [<ExcelFunction(Name="_BMASwap_nominal", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Nominal
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
    [<ExcelFunction(Name="_BMASwap_type", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Type
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
    [<ExcelFunction(Name="_BMASwap_endDiscounts", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).EndDiscounts
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
    (*!!
    [<ExcelFunction(Name="_BMASwap_engine", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Engine
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwap_isExpired", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).IsExpired
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
    [<ExcelFunction(Name="_BMASwap_leg", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Leg
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
    [<ExcelFunction(Name="_BMASwap_legBPS", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LegBPS
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
    [<ExcelFunction(Name="_BMASwap_legNPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).LegNPV
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
    [<ExcelFunction(Name="_BMASwap_maturityDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).MaturityDate
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
    [<ExcelFunction(Name="_BMASwap_npvDateDiscount", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).NpvDateDiscount
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
    [<ExcelFunction(Name="_BMASwap_payer", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Payer
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
    [<ExcelFunction(Name="_BMASwap_startDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).StartDate
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
    [<ExcelFunction(Name="_BMASwap_startDiscounts", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).StartDiscounts
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
    [<ExcelFunction(Name="_BMASwap_CASH", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).CASH
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
    [<ExcelFunction(Name="_BMASwap_errorEstimate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).ErrorEstimate
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
    [<ExcelFunction(Name="_BMASwap_NPV", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).NPV
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
    [<ExcelFunction(Name="_BMASwap_result", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

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
    [<ExcelFunction(Name="_BMASwap_setPricingEngine", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).SetPricingEngine
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
    [<ExcelFunction(Name="_BMASwap_valuationDate", Description="Create a BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwap",Description = "Reference to BMASwap")>] 
         bmaswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwap = Helper.toCell<BMASwap> bmaswap "BMASwap"  
                let builder () = withMnemonic mnemonic ((BMASwapModel.Cast _BMASwap.cell).ValuationDate
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
    [<ExcelFunction(Name="_BMASwap_Range", Description="Create a range of BMASwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
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
                        Seq.map (fun (i : obj) -> Helper.toCell<BMASwap> i "value" ) |>
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
