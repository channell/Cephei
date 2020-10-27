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
module FloatFloatSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_cappedRate1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_cappedRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).CappedRate1
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".CappedRate1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_cappedRate2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_cappedRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).CappedRate2
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".CappedRate2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_dayCount1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_dayCount1
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).DayCount1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".DayCount1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_dayCount2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_dayCount2
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).DayCount2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".DayCount2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatFloatSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "VanillaSwap.Type: Receiver, Payer")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal1",Description = "double")>] 
         nominal1 : obj)
        ([<ExcelArgument(Name="nominal2",Description = "double")>] 
         nominal2 : obj)
        ([<ExcelArgument(Name="schedule1",Description = "Schedule")>] 
         schedule1 : obj)
        ([<ExcelArgument(Name="index1",Description = "InterestRateIndex")>] 
         index1 : obj)
        ([<ExcelArgument(Name="dayCount1",Description = "DayCounter")>] 
         dayCount1 : obj)
        ([<ExcelArgument(Name="schedule2",Description = "Schedule")>] 
         schedule2 : obj)
        ([<ExcelArgument(Name="index2",Description = "InterestRateIndex")>] 
         index2 : obj)
        ([<ExcelArgument(Name="dayCount2",Description = "DayCounter")>] 
         dayCount2 : obj)
        ([<ExcelArgument(Name="intermediateCapitalExchange",Description = "FloatFloatSwap")>] 
         intermediateCapitalExchange : obj)
        ([<ExcelArgument(Name="finalCapitalExchange",Description = "FloatFloatSwap")>] 
         finalCapitalExchange : obj)
        ([<ExcelArgument(Name="gearing1",Description = "FloatFloatSwap")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "FloatFloatSwap")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="cappedRate1",Description = "FloatFloatSwap")>] 
         cappedRate1 : obj)
        ([<ExcelArgument(Name="flooredRate1",Description = "FloatFloatSwap")>] 
         flooredRate1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "FloatFloatSwap")>] 
         gearing2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "FloatFloatSwap")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="cappedRate2",Description = "FloatFloatSwap")>] 
         cappedRate2 : obj)
        ([<ExcelArgument(Name="flooredRate2",Description = "FloatFloatSwap")>] 
         flooredRate2 : obj)
        ([<ExcelArgument(Name="paymentConvention1",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention1 : obj)
        ([<ExcelArgument(Name="paymentConvention2",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention2 : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<VanillaSwap.Type> Type "Type" 
                let _nominal1 = Helper.toCell<Generic.List<double>> nominal1 "nominal1" 
                let _nominal2 = Helper.toCell<Generic.List<double>> nominal2 "nominal2" 
                let _schedule1 = Helper.toCell<Schedule> schedule1 "schedule1" 
                let _index1 = Helper.toCell<InterestRateIndex> index1 "index1" 
                let _dayCount1 = Helper.toCell<DayCounter> dayCount1 "dayCount1" 
                let _schedule2 = Helper.toCell<Schedule> schedule2 "schedule2" 
                let _index2 = Helper.toCell<InterestRateIndex> index2 "index2" 
                let _dayCount2 = Helper.toCell<DayCounter> dayCount2 "dayCount2" 
                let _intermediateCapitalExchange = Helper.toDefault<bool> intermediateCapitalExchange "intermediateCapitalExchange" false
                let _finalCapitalExchange = Helper.toDefault<bool> finalCapitalExchange "finalCapitalExchange" false
                let _gearing1 = Helper.toDefault<Generic.List<double>> gearing1 "gearing1" null
                let _spread1 = Helper.toDefault<Generic.List<double>> spread1 "spread1" null
                let _cappedRate1 = Helper.toDefault<Generic.List<Nullable<double>>> cappedRate1 "cappedRate1" null
                let _flooredRate1 = Helper.toDefault<Generic.List<Nullable<double>>> flooredRate1 "flooredRate1" null
                let _gearing2 = Helper.toDefault<Generic.List<double>> gearing2 "gearing2" null
                let _spread2 = Helper.toDefault<Generic.List<double>> spread2 "spread2" null
                let _cappedRate2 = Helper.toDefault<Generic.List<Nullable<double>>> cappedRate2 "cappedRate2" null
                let _flooredRate2 = Helper.toDefault<Generic.List<Nullable<double>>> flooredRate2 "flooredRate2" null
                let _paymentConvention1 = Helper.toNullable<BusinessDayConvention> paymentConvention1 "paymentConvention1"
                let _paymentConvention2 = Helper.toNullable<BusinessDayConvention> paymentConvention2 "paymentConvention2"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatFloatSwap 
                                                            _Type.cell 
                                                            _nominal1.cell 
                                                            _nominal2.cell 
                                                            _schedule1.cell 
                                                            _index1.cell 
                                                            _dayCount1.cell 
                                                            _schedule2.cell 
                                                            _index2.cell 
                                                            _dayCount2.cell 
                                                            _intermediateCapitalExchange.cell 
                                                            _finalCapitalExchange.cell 
                                                            _gearing1.cell 
                                                            _spread1.cell 
                                                            _cappedRate1.cell 
                                                            _flooredRate1.cell 
                                                            _gearing2.cell 
                                                            _spread2.cell 
                                                            _cappedRate2.cell 
                                                            _flooredRate2.cell 
                                                            _paymentConvention1.cell 
                                                            _paymentConvention2.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatFloatSwap>) l

                let source () = Helper.sourceFold "Fun.FloatFloatSwap" 
                                               [| _Type.source
                                               ;  _nominal1.source
                                               ;  _nominal2.source
                                               ;  _schedule1.source
                                               ;  _index1.source
                                               ;  _dayCount1.source
                                               ;  _schedule2.source
                                               ;  _index2.source
                                               ;  _dayCount2.source
                                               ;  _intermediateCapitalExchange.source
                                               ;  _finalCapitalExchange.source
                                               ;  _gearing1.source
                                               ;  _spread1.source
                                               ;  _cappedRate1.source
                                               ;  _flooredRate1.source
                                               ;  _gearing2.source
                                               ;  _spread2.source
                                               ;  _cappedRate2.source
                                               ;  _flooredRate2.source
                                               ;  _paymentConvention1.source
                                               ;  _paymentConvention2.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal1.cell
                                ;  _nominal2.cell
                                ;  _schedule1.cell
                                ;  _index1.cell
                                ;  _dayCount1.cell
                                ;  _schedule2.cell
                                ;  _index2.cell
                                ;  _dayCount2.cell
                                ;  _intermediateCapitalExchange.cell
                                ;  _finalCapitalExchange.cell
                                ;  _gearing1.cell
                                ;  _spread1.cell
                                ;  _cappedRate1.cell
                                ;  _flooredRate1.cell
                                ;  _gearing2.cell
                                ;  _spread2.cell
                                ;  _cappedRate2.cell
                                ;  _flooredRate2.cell
                                ;  _paymentConvention1.cell
                                ;  _paymentConvention2.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatFloatSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "VanillaSwap.Type: Receiver, Payer")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal1",Description = "double")>] 
         nominal1 : obj)
        ([<ExcelArgument(Name="nominal2",Description = "double")>] 
         nominal2 : obj)
        ([<ExcelArgument(Name="schedule1",Description = "Schedule")>] 
         schedule1 : obj)
        ([<ExcelArgument(Name="index1",Description = "InterestRateIndex")>] 
         index1 : obj)
        ([<ExcelArgument(Name="dayCount1",Description = "DayCounter")>] 
         dayCount1 : obj)
        ([<ExcelArgument(Name="schedule2",Description = "Schedule")>] 
         schedule2 : obj)
        ([<ExcelArgument(Name="index2",Description = "InterestRateIndex")>] 
         index2 : obj)
        ([<ExcelArgument(Name="dayCount2",Description = "DayCounter")>] 
         dayCount2 : obj)
        ([<ExcelArgument(Name="intermediateCapitalExchange",Description = "FloatFloatSwap")>] 
         intermediateCapitalExchange : obj)
        ([<ExcelArgument(Name="finalCapitalExchange",Description = "FloatFloatSwap")>] 
         finalCapitalExchange : obj)
        ([<ExcelArgument(Name="gearing1",Description = "double")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "double")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="cappedRate1",Description = "double")>] 
         cappedRate1 : obj)
        ([<ExcelArgument(Name="flooredRate1",Description = "double")>] 
         flooredRate1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "double")>] 
         gearing2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "double")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="cappedRate2",Description = "double")>] 
         cappedRate2 : obj)
        ([<ExcelArgument(Name="flooredRate2",Description = "double")>] 
         flooredRate2 : obj)
        ([<ExcelArgument(Name="paymentConvention1",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention1 : obj)
        ([<ExcelArgument(Name="paymentConvention2",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention2 : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<VanillaSwap.Type> Type "Type" 
                let _nominal1 = Helper.toCell<double> nominal1 "nominal1" 
                let _nominal2 = Helper.toCell<double> nominal2 "nominal2" 
                let _schedule1 = Helper.toCell<Schedule> schedule1 "schedule1" 
                let _index1 = Helper.toCell<InterestRateIndex> index1 "index1" 
                let _dayCount1 = Helper.toCell<DayCounter> dayCount1 "dayCount1" 
                let _schedule2 = Helper.toCell<Schedule> schedule2 "schedule2" 
                let _index2 = Helper.toCell<InterestRateIndex> index2 "index2" 
                let _dayCount2 = Helper.toCell<DayCounter> dayCount2 "dayCount2" 
                let _intermediateCapitalExchange = Helper.toDefault<bool> intermediateCapitalExchange "intermediateCapitalExchange" false
                let _finalCapitalExchange = Helper.toDefault<bool> finalCapitalExchange "finalCapitalExchange" false
                let _gearing1 = Helper.toCell<double> gearing1 "gearing1" 
                let _spread1 = Helper.toCell<double> spread1 "spread1" 
                let _cappedRate1 = Helper.toNullable<double> cappedRate1 "cappedRate1"
                let _flooredRate1 = Helper.toNullable<double> flooredRate1 "flooredRate1"
                let _gearing2 = Helper.toCell<double> gearing2 "gearing2"
                let _spread2 = Helper.toCell<double> spread2 "spread2"
                let _cappedRate2 = Helper.toNullable<double> cappedRate2 "cappedRate2"
                let _flooredRate2 = Helper.toNullable<double> flooredRate2 "flooredRate2"
                let _paymentConvention1 = Helper.toNullable<BusinessDayConvention> paymentConvention1 "paymentConvention1"
                let _paymentConvention2 = Helper.toNullable<BusinessDayConvention> paymentConvention2 "paymentConvention2"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatFloatSwap1 
                                                            _Type.cell 
                                                            _nominal1.cell 
                                                            _nominal2.cell 
                                                            _schedule1.cell 
                                                            _index1.cell 
                                                            _dayCount1.cell 
                                                            _schedule2.cell 
                                                            _index2.cell 
                                                            _dayCount2.cell 
                                                            _intermediateCapitalExchange.cell 
                                                            _finalCapitalExchange.cell 
                                                            _gearing1.cell 
                                                            _spread1.cell 
                                                            _cappedRate1.cell 
                                                            _flooredRate1.cell 
                                                            _gearing2.cell 
                                                            _spread2.cell 
                                                            _cappedRate2.cell 
                                                            _flooredRate2.cell 
                                                            _paymentConvention1.cell 
                                                            _paymentConvention2.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatFloatSwap>) l

                let source () = Helper.sourceFold "Fun.FloatFloatSwap1" 
                                               [| _Type.source
                                               ;  _nominal1.source
                                               ;  _nominal2.source
                                               ;  _schedule1.source
                                               ;  _index1.source
                                               ;  _dayCount1.source
                                               ;  _schedule2.source
                                               ;  _index2.source
                                               ;  _dayCount2.source
                                               ;  _intermediateCapitalExchange.source
                                               ;  _finalCapitalExchange.source
                                               ;  _gearing1.source
                                               ;  _spread1.source
                                               ;  _cappedRate1.source
                                               ;  _flooredRate1.source
                                               ;  _gearing2.source
                                               ;  _spread2.source
                                               ;  _cappedRate2.source
                                               ;  _flooredRate2.source
                                               ;  _paymentConvention1.source
                                               ;  _paymentConvention2.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal1.cell
                                ;  _nominal2.cell
                                ;  _schedule1.cell
                                ;  _index1.cell
                                ;  _dayCount1.cell
                                ;  _schedule2.cell
                                ;  _index2.cell
                                ;  _dayCount2.cell
                                ;  _intermediateCapitalExchange.cell
                                ;  _finalCapitalExchange.cell
                                ;  _gearing1.cell
                                ;  _spread1.cell
                                ;  _cappedRate1.cell
                                ;  _flooredRate1.cell
                                ;  _gearing2.cell
                                ;  _spread2.cell
                                ;  _cappedRate2.cell
                                ;  _flooredRate2.cell
                                ;  _paymentConvention1.cell
                                ;  _paymentConvention2.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_flooredRate1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_flooredRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).FlooredRate1
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".FlooredRate1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_flooredRate2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_flooredRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).FlooredRate2
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".FlooredRate2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_gearing1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_gearing1
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Gearing1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Gearing1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_gearing2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_gearing2
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Gearing2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Gearing2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_index1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_index1
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Index1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Index1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_index2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_index2
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRateIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Index2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Index2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_leg1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Leg1
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Leg1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_leg2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg2
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Leg2
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Leg2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_nominal1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_nominal1
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Nominal1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Nominal1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_nominal2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_nominal2
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Nominal2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Nominal2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_paymentConvention1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_paymentConvention1
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).PaymentConvention1
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".PaymentConvention1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_paymentConvention2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_paymentConvention2
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).PaymentConvention2
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".PaymentConvention2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_schedule1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_schedule1
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Schedule1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Schedule1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_schedule2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_schedule2
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Schedule2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Schedule2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatFloatSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_spread1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_spread1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Spread1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Spread1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_spread2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_spread2
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Spread2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Spread2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
        ! \name Inspectors
    *)
    [<ExcelFunction(Name="_FloatFloatSwap_type", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Type
                                                       ) :> ICell
                let format (o : VanillaSwap.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_endDiscounts", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_engine", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_isExpired", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_leg", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_legBPS", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_legNPV", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_maturityDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_npvDateDiscount", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_payer", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_startDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_startDiscounts", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_CASH", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_errorEstimate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_NPV", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_result", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_setPricingEngine", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatFloatSwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_valuationDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatFloatSwapModel.Cast _FloatFloatSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatFloatSwap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_Range", Description="Create a range of FloatFloatSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatFloatSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatFloatSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatFloatSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatFloatSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FloatFloatSwap>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
