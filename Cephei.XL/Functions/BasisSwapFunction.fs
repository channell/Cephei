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
  Basis swap. Simple Libor swap vs Libor swap
  </summary> *)
[<AutoSerializable(true)>]
module BasisSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap1", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="float1Schedule",Description = "Reference to float1Schedule")>] 
         float1Schedule : obj)
        ([<ExcelArgument(Name="iborIndex1",Description = "Reference to iborIndex1")>] 
         iborIndex1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "Reference to spread1")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="float1DayCount",Description = "Reference to float1DayCount")>] 
         float1DayCount : obj)
        ([<ExcelArgument(Name="float2Schedule",Description = "Reference to float2Schedule")>] 
         float2Schedule : obj)
        ([<ExcelArgument(Name="iborIndex2",Description = "Reference to iborIndex2")>] 
         iborIndex2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "Reference to spread2")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="float2DayCount",Description = "Reference to float2DayCount")>] 
         float2DayCount : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<BasisSwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _float1Schedule = Helper.toCell<Schedule> float1Schedule "float1Schedule" 
                let _iborIndex1 = Helper.toCell<IborIndex> iborIndex1 "iborIndex1" 
                let _spread1 = Helper.toCell<double> spread1 "spread1" 
                let _float1DayCount = Helper.toCell<DayCounter> float1DayCount "float1DayCount" 
                let _float2Schedule = Helper.toCell<Schedule> float2Schedule "float2Schedule" 
                let _iborIndex2 = Helper.toCell<IborIndex> iborIndex2 "iborIndex2" 
                let _spread2 = Helper.toCell<double> spread2 "spread2" 
                let _float2DayCount = Helper.toCell<DayCounter> float2DayCount "float2DayCount" 
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.BasisSwap1 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _float1Schedule.cell 
                                                            _iborIndex1.cell 
                                                            _spread1.cell 
                                                            _float1DayCount.cell 
                                                            _float2Schedule.cell 
                                                            _iborIndex2.cell 
                                                            _spread2.cell 
                                                            _float2DayCount.cell 
                                                            _paymentConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasisSwap>) l

                let source = Helper.sourceFold "Fun.BasisSwap1" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _float1Schedule.source
                                               ;  _iborIndex1.source
                                               ;  _spread1.source
                                               ;  _float1DayCount.source
                                               ;  _float2Schedule.source
                                               ;  _iborIndex2.source
                                               ;  _spread2.source
                                               ;  _float2DayCount.source
                                               ;  _paymentConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _float1Schedule.cell
                                ;  _iborIndex1.cell
                                ;  _spread1.cell
                                ;  _float1DayCount.cell
                                ;  _float2Schedule.cell
                                ;  _iborIndex2.cell
                                ;  _spread2.cell
                                ;  _float2DayCount.cell
                                ;  _paymentConvention.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructor
    *)
    [<ExcelFunction(Name="_BasisSwap", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="float1Schedule",Description = "Reference to float1Schedule")>] 
         float1Schedule : obj)
        ([<ExcelArgument(Name="iborIndex1",Description = "Reference to iborIndex1")>] 
         iborIndex1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "Reference to spread1")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="float1DayCount",Description = "Reference to float1DayCount")>] 
         float1DayCount : obj)
        ([<ExcelArgument(Name="float2Schedule",Description = "Reference to float2Schedule")>] 
         float2Schedule : obj)
        ([<ExcelArgument(Name="iborIndex2",Description = "Reference to iborIndex2")>] 
         iborIndex2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "Reference to spread2")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="float2DayCount",Description = "Reference to float2DayCount")>] 
         float2DayCount : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<BasisSwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _float1Schedule = Helper.toCell<Schedule> float1Schedule "float1Schedule" 
                let _iborIndex1 = Helper.toCell<IborIndex> iborIndex1 "iborIndex1" 
                let _spread1 = Helper.toCell<double> spread1 "spread1" 
                let _float1DayCount = Helper.toCell<DayCounter> float1DayCount "float1DayCount" 
                let _float2Schedule = Helper.toCell<Schedule> float2Schedule "float2Schedule" 
                let _iborIndex2 = Helper.toCell<IborIndex> iborIndex2 "iborIndex2" 
                let _spread2 = Helper.toCell<double> spread2 "spread2" 
                let _float2DayCount = Helper.toCell<DayCounter> float2DayCount "float2DayCount" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.BasisSwap
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _float1Schedule.cell 
                                                            _iborIndex1.cell 
                                                            _spread1.cell 
                                                            _float1DayCount.cell 
                                                            _float2Schedule.cell 
                                                            _iborIndex2.cell 
                                                            _spread2.cell 
                                                            _float2DayCount.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasisSwap>) l

                let source = Helper.sourceFold "Fun.BasisSwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _float1Schedule.source
                                               ;  _iborIndex1.source
                                               ;  _spread1.source
                                               ;  _float1DayCount.source
                                               ;  _float2Schedule.source
                                               ;  _iborIndex2.source
                                               ;  _spread2.source
                                               ;  _float2DayCount.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _float1Schedule.cell
                                ;  _iborIndex1.cell
                                ;  _spread1.cell
                                ;  _float1DayCount.cell
                                ;  _float2Schedule.cell
                                ;  _iborIndex2.cell
                                ;  _spread2.cell
                                ;  _float2DayCount.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap_fairLongSpread", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_fairLongSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).FairLongSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".FairLongSpread") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_fairShortSpread", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_fairShortSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).FairShortSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".FairShortSpread") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating1Leg", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating1Leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating1Leg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating1Leg") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
        results
    *)
    [<ExcelFunction(Name="_BasisSwap_floating1LegBPS", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating1LegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating1LegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating1LegBPS") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating1LegNPV", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating1LegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating1LegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating1LegNPV") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating1Schedule", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating1Schedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating1Schedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating1Schedule") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap_floating2Leg", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating2Leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating2Leg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating2Leg") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating2LegBPS", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating2LegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating2LegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating2LegBPS") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating2LegNPV", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating2LegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating2LegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating2LegNPV") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_floating2Schedule", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_floating2Schedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Floating2Schedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_BasisSwap.source + ".Floating2Schedule") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap_iborIndex1", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_iborIndex1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).IborIndex1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_BasisSwap.source + ".IborIndex1") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap_iborIndex2", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_iborIndex2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).IborIndex2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_BasisSwap.source + ".IborIndex2") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwap_nominal", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Nominal") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_spread1", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_spread1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Spread1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Spread1") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_spread2", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_spread2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Spread2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Spread2") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_swapType", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_swapType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).SwapType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".SwapType") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_endDiscounts", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".EndDiscounts") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_engine", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Engine") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_isExpired", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".IsExpired") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_leg", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BasisSwap.source + ".Leg") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_legBPS", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".LegBPS") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_legNPV", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".LegNPV") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_maturityDate", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".MaturityDate") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_npvDateDiscount", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".NpvDateDiscount") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_payer", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Payer") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_startDate", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".StartDate") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_startDiscounts", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".StartDiscounts") 
                                               [| _BasisSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_CASH", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".CASH") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_errorEstimate", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".ErrorEstimate") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_NPV", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".NPV") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_result", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".Result") 
                                               [| _BasisSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_setPricingEngine", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BasisSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".SetPricingEngine") 
                                               [| _BasisSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_valuationDate", Description="Create a BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwap",Description = "Reference to BasisSwap")>] 
         basisswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwap = Helper.toCell<BasisSwap> basisswap "BasisSwap"  
                let builder () = withMnemonic mnemonic ((_BasisSwap.cell :?> BasisSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwap.source + ".ValuationDate") 
                                               [| _BasisSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwap.cell
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
    [<ExcelFunction(Name="_BasisSwap_Range", Description="Create a range of BasisSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BasisSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BasisSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BasisSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BasisSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BasisSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
