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
  Quoted as a fixed rate K  At start: P_n(0,t_i) N K = P_n(0,t_i) N - 1 where t_M is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  These instruments have now been changed to follow typical VanillaSwap type design conventions w.r.t. Schedules etc.
  </summary> *)
[<AutoSerializable(true)>]
module YearOnYearInflationSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fairRate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FairRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FairRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fairSpread", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FairSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedDayCount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FixedDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedLeg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedLegNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FixedLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedRate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedSchedule", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).FixedSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedSchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_nominal", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_observationLag", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_paymentCalendar", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_paymentCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).PaymentCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".PaymentCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_paymentConvention", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_paymentConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).PaymentConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".PaymentConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_spread", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_type", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "YearOnYearInflationSwap.Type: Receiver, Payer")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Schedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="yoySchedule",Description = "Schedule")>] 
         yoySchedule : obj)
        ([<ExcelArgument(Name="yoyIndex",Description = "YoYInflationIndex")>] 
         yoyIndex : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="yoyDayCount",Description = "DayCounter")>] 
         yoyDayCount : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Calendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<YearOnYearInflationSwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _yoySchedule = Helper.toCell<Schedule> yoySchedule "yoySchedule" 
                let _yoyIndex = Helper.toCell<YoYInflationIndex> yoyIndex "yoyIndex" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _yoyDayCount = Helper.toCell<DayCounter> yoyDayCount "yoyDayCount" 
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.ModifiedFollowing
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.YearOnYearInflationSwap 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _fixedSchedule.cell 
                                                            _fixedRate.cell 
                                                            _fixedDayCount.cell 
                                                            _yoySchedule.cell 
                                                            _yoyIndex.cell 
                                                            _observationLag.cell 
                                                            _spread.cell 
                                                            _yoyDayCount.cell 
                                                            _paymentCalendar.cell 
                                                            _paymentConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YearOnYearInflationSwap>) l

                let source () = Helper.sourceFold "Fun.YearOnYearInflationSwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _fixedSchedule.source
                                               ;  _fixedRate.source
                                               ;  _fixedDayCount.source
                                               ;  _yoySchedule.source
                                               ;  _yoyIndex.source
                                               ;  _observationLag.source
                                               ;  _spread.source
                                               ;  _yoyDayCount.source
                                               ;  _paymentCalendar.source
                                               ;  _paymentConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _fixedSchedule.cell
                                ;  _fixedRate.cell
                                ;  _fixedDayCount.cell
                                ;  _yoySchedule.cell
                                ;  _yoyIndex.cell
                                ;  _observationLag.cell
                                ;  _spread.cell
                                ;  _yoyDayCount.cell
                                ;  _paymentCalendar.cell
                                ;  _paymentConvention.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyDayCount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).YoyDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyInflationIndex", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyInflationIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).YoyInflationIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyInflationIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyLeg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyLegNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).YoyLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoySchedule", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoySchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).YoySchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoySchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YearOnYearInflationSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_endDiscounts", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
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
    (*!!
    [<ExcelFunction(Name="_YearOnYearInflationSwap_engine", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_isExpired", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_leg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_legBPS", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_legNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_maturityDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_npvDateDiscount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_payer", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_startDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_startDiscounts", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_CASH", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_errorEstimate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_NPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_result", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_setPricingEngine", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_valuationDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap"  
                let builder (current : ICell) = ((YearOnYearInflationSwapModel.Cast _YearOnYearInflationSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_Range", Description="Create a range of YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YearOnYearInflationSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YearOnYearInflationSwap> (c)) :> ICell
                let format (i : Cephei.Cell.List<YearOnYearInflationSwap>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YearOnYearInflationSwap>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
