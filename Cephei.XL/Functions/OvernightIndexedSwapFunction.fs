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
  Overnight indexed swap: fix vs compounded overnight rate
  </summary> *)
[<AutoSerializable(true)>]
module OvernightIndexedSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwap_fairRate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FairRate
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FairRate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fairSpread", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FairSpread") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedDayCount", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedDayCount") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedLeg", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedLeg") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedLegBPS", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedLegBPS
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedLegBPS") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedLegNPV", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedLegNPV
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedLegNPV") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedNominal", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedNominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedNominal") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedPaymentFrequency", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedPaymentFrequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedPaymentFrequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedPaymentFrequency") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_fixedRate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".FixedRate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap1", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDC",Description = "Reference to fixedDC")>] 
         fixedDC : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "Reference to overnightIndex")>] 
         overnightIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<OvernightIndexedSwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _fixedDC = Helper.toCell<DayCounter> fixedDC "fixedDC" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.OvernightIndexedSwap1
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _schedule.cell 
                                                            _fixedRate.cell 
                                                            _fixedDC.cell 
                                                            _overnightIndex.cell 
                                                            _spread.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedSwap>) l

                let source = Helper.sourceFold "Fun.OvernightIndexedSwap1" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _schedule.source
                                               ;  _fixedRate.source
                                               ;  _fixedDC.source
                                               ;  _overnightIndex.source
                                               ;  _spread.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _schedule.cell
                                ;  _fixedRate.cell
                                ;  _fixedDC.cell
                                ;  _overnightIndex.cell
                                ;  _spread.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwap", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="fixedNominal",Description = "Reference to fixedNominal")>] 
         fixedNominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Reference to fixedSchedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDC",Description = "Reference to fixedDC")>] 
         fixedDC : obj)
        ([<ExcelArgument(Name="overnightNominal",Description = "Reference to overnightNominal")>] 
         overnightNominal : obj)
        ([<ExcelArgument(Name="overnightSchedule",Description = "Reference to overnightSchedule")>] 
         overnightSchedule : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "Reference to overnightIndex")>] 
         overnightIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<OvernightIndexedSwap.Type> Type "Type" 
                let _fixedNominal = Helper.toCell<double> fixedNominal "fixedNominal" 
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _fixedDC = Helper.toCell<DayCounter> fixedDC "fixedDC" 
                let _overnightNominal = Helper.toCell<double> overnightNominal "overnightNominal" 
                let _overnightSchedule = Helper.toCell<Schedule> overnightSchedule "overnightSchedule" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.OvernightIndexedSwap 
                                                            _Type.cell 
                                                            _fixedNominal.cell 
                                                            _fixedSchedule.cell 
                                                            _fixedRate.cell 
                                                            _fixedDC.cell 
                                                            _overnightNominal.cell 
                                                            _overnightSchedule.cell 
                                                            _overnightIndex.cell 
                                                            _spread.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedSwap>) l

                let source = Helper.sourceFold "Fun.OvernightIndexedSwap" 
                                               [| _Type.source
                                               ;  _fixedNominal.source
                                               ;  _fixedSchedule.source
                                               ;  _fixedRate.source
                                               ;  _fixedDC.source
                                               ;  _overnightNominal.source
                                               ;  _overnightSchedule.source
                                               ;  _overnightIndex.source
                                               ;  _spread.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _fixedNominal.cell
                                ;  _fixedSchedule.cell
                                ;  _fixedRate.cell
                                ;  _fixedDC.cell
                                ;  _overnightNominal.cell
                                ;  _overnightSchedule.cell
                                ;  _overnightIndex.cell
                                ;  _spread.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwap_overnightLeg", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_overnightLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).OvernightLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".OvernightLeg") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_overnightLegBPS", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_overnightLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).OvernightLegBPS
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".OvernightLegBPS") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_overnightLegNPV", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_overnightLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).OvernightLegNPV
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".OvernightLegNPV") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_overnightNominal", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_overnightNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).OvernightNominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".OvernightNominal") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_overnightPaymentFrequency", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_overnightPaymentFrequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).OvernightPaymentFrequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".OvernightPaymentFrequency") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_spread", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".Spread") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_type", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".TYPE") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_endDiscounts", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".EndDiscounts") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    (*!! ommited
    [<ExcelFunction(Name="_OvernightIndexedSwap_engine", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".Engine") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_isExpired", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".IsExpired") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_leg", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".Leg") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_legBPS", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".LegBPS") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_legNPV", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".LegNPV") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_maturityDate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".MaturityDate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_npvDateDiscount", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".NpvDateDiscount") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_payer", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".Payer") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_startDate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".StartDate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_startDiscounts", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".StartDiscounts") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_CASH", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".CASH") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_errorEstimate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".ErrorEstimate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_NPV", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".NPV") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_result", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".Result") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_setPricingEngine", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".SetPricingEngine") 
                                               [| _OvernightIndexedSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_valuationDate", Description="Create a OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwap",Description = "Reference to OvernightIndexedSwap")>] 
         overnightindexedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwap = Helper.toCell<OvernightIndexedSwap> overnightindexedswap "OvernightIndexedSwap"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapModel.Cast _OvernightIndexedSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwap.source + ".ValuationDate") 
                                               [| _OvernightIndexedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwap.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwap_Range", Description="Create a range of OvernightIndexedSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OvernightIndexedSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndexedSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightIndexedSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightIndexedSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OvernightIndexedSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
