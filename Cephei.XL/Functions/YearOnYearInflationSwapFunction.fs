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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fairRate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FairRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FairRate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fairSpread", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FairSpread") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedDayCount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FixedDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedDayCount") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedLeg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedLeg") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedLegNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FixedLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedLegNPV") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedRate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedRate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_fixedSchedule", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_fixedSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).FixedSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".FixedSchedule") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_nominal", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Nominal") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_observationLag", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ObservationLag") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_paymentCalendar", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_paymentCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).PaymentCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".PaymentCalendar") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_paymentConvention", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_paymentConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).PaymentConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".PaymentConvention") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_spread", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Spread") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwap_type", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".TYPE") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Reference to fixedSchedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "Reference to fixedDayCount")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="yoySchedule",Description = "Reference to yoySchedule")>] 
         yoySchedule : obj)
        ([<ExcelArgument(Name="yoyIndex",Description = "Reference to yoyIndex")>] 
         yoyIndex : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="yoyDayCount",Description = "Reference to yoyDayCount")>] 
         yoyDayCount : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<YearOnYearInflationSwap.Type> Type "Type" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" true
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" true
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" true
                let _yoySchedule = Helper.toCell<Schedule> yoySchedule "yoySchedule" true
                let _yoyIndex = Helper.toCell<YoYInflationIndex> yoyIndex "yoyIndex" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _yoyDayCount = Helper.toCell<DayCounter> yoyDayCount "yoyDayCount" true
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.YearOnYearInflationSwap 
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

                let source = Helper.sourceFold "Fun.YearOnYearInflationSwap" 
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyDayCount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).YoyDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyDayCount") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyInflationIndex", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyInflationIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).YoyInflationIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyInflationIndex") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyLeg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyLeg") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoyLegNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoyLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).YoyLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoyLegNPV") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_yoySchedule", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_yoySchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).YoySchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".YoySchedule") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_endDiscounts", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".EndDiscounts") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_engine", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Engine") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_isExpired", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".IsExpired") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_leg", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Leg") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_legBPS", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".LegBPS") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_legNPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".LegNPV") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_maturityDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".MaturityDate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_npvDateDiscount", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".NpvDateDiscount") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_payer", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Payer") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_startDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".StartDate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_startDiscounts", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".StartDiscounts") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_CASH", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".CASH") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_errorEstimate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ErrorEstimate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_NPV", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".NPV") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_result", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".Result") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_setPricingEngine", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".SetPricingEngine") 
                                               [| _YearOnYearInflationSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_valuationDate", Description="Create a YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwap",Description = "Reference to YearOnYearInflationSwap")>] 
         yearonyearinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwap = Helper.toCell<YearOnYearInflationSwap> yearonyearinflationswap "YearOnYearInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwap.cell :?> YearOnYearInflationSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwap.source + ".ValuationDate") 
                                               [| _YearOnYearInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwap.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwap_Range", Description="Create a range of YearOnYearInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YearOnYearInflationSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YearOnYearInflationSwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YearOnYearInflationSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YearOnYearInflationSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YearOnYearInflationSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
