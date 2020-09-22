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
    [<ExcelFunction(Name="_FloatFloatSwap_cappedRate1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_cappedRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).CappedRate1
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".CappedRate1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_cappedRate2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_cappedRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).CappedRate2
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".CappedRate2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_dayCount1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_dayCount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).DayCount1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".DayCount1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_dayCount2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_dayCount2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).DayCount2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".DayCount2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal1",Description = "Reference to nominal1")>] 
         nominal1 : obj)
        ([<ExcelArgument(Name="nominal2",Description = "Reference to nominal2")>] 
         nominal2 : obj)
        ([<ExcelArgument(Name="schedule1",Description = "Reference to schedule1")>] 
         schedule1 : obj)
        ([<ExcelArgument(Name="index1",Description = "Reference to index1")>] 
         index1 : obj)
        ([<ExcelArgument(Name="dayCount1",Description = "Reference to dayCount1")>] 
         dayCount1 : obj)
        ([<ExcelArgument(Name="schedule2",Description = "Reference to schedule2")>] 
         schedule2 : obj)
        ([<ExcelArgument(Name="index2",Description = "Reference to index2")>] 
         index2 : obj)
        ([<ExcelArgument(Name="dayCount2",Description = "Reference to dayCount2")>] 
         dayCount2 : obj)
        ([<ExcelArgument(Name="intermediateCapitalExchange",Description = "Reference to intermediateCapitalExchange")>] 
         intermediateCapitalExchange : obj)
        ([<ExcelArgument(Name="finalCapitalExchange",Description = "Reference to finalCapitalExchange")>] 
         finalCapitalExchange : obj)
        ([<ExcelArgument(Name="gearing1",Description = "Reference to gearing1")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "Reference to spread1")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="cappedRate1",Description = "Reference to cappedRate1")>] 
         cappedRate1 : obj)
        ([<ExcelArgument(Name="flooredRate1",Description = "Reference to flooredRate1")>] 
         flooredRate1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "Reference to gearing2")>] 
         gearing2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "Reference to spread2")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="cappedRate2",Description = "Reference to cappedRate2")>] 
         cappedRate2 : obj)
        ([<ExcelArgument(Name="flooredRate2",Description = "Reference to flooredRate2")>] 
         flooredRate2 : obj)
        ([<ExcelArgument(Name="paymentConvention1",Description = "Reference to paymentConvention1")>] 
         paymentConvention1 : obj)
        ([<ExcelArgument(Name="paymentConvention2",Description = "Reference to paymentConvention2")>] 
         paymentConvention2 : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<VanillaSwap.Type> Type "Type" true
                let _nominal1 = Helper.toCell<Generic.List<double>> nominal1 "nominal1" true
                let _nominal2 = Helper.toCell<Generic.List<double>> nominal2 "nominal2" true
                let _schedule1 = Helper.toCell<Schedule> schedule1 "schedule1" true
                let _index1 = Helper.toCell<InterestRateIndex> index1 "index1" true
                let _dayCount1 = Helper.toCell<DayCounter> dayCount1 "dayCount1" true
                let _schedule2 = Helper.toCell<Schedule> schedule2 "schedule2" true
                let _index2 = Helper.toCell<InterestRateIndex> index2 "index2" true
                let _dayCount2 = Helper.toCell<DayCounter> dayCount2 "dayCount2" true
                let _intermediateCapitalExchange = Helper.toCell<bool> intermediateCapitalExchange "intermediateCapitalExchange" true
                let _finalCapitalExchange = Helper.toCell<bool> finalCapitalExchange "finalCapitalExchange" true
                let _gearing1 = Helper.toCell<Generic.List<double>> gearing1 "gearing1" true
                let _spread1 = Helper.toCell<Generic.List<double>> spread1 "spread1" true
                let _cappedRate1 = Helper.toCell<Generic.List<Nullable<double>>> cappedRate1 "cappedRate1" true
                let _flooredRate1 = Helper.toCell<Generic.List<Nullable<double>>> flooredRate1 "flooredRate1" true
                let _gearing2 = Helper.toCell<Generic.List<double>> gearing2 "gearing2" true
                let _spread2 = Helper.toCell<Generic.List<double>> spread2 "spread2" true
                let _cappedRate2 = Helper.toCell<Generic.List<Nullable<double>>> cappedRate2 "cappedRate2" true
                let _flooredRate2 = Helper.toCell<Generic.List<Nullable<double>>> flooredRate2 "flooredRate2" true
                let _paymentConvention1 = Helper.toNullable<BusinessDayConvention> paymentConvention1 "paymentConvention1"
                let _paymentConvention2 = Helper.toNullable<BusinessDayConvention> paymentConvention2 "paymentConvention2"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatFloatSwap 
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

                let source = Helper.sourceFold "Fun.FloatFloatSwap" 
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
    [<ExcelFunction(Name="_FloatFloatSwap1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal1",Description = "Reference to nominal1")>] 
         nominal1 : obj)
        ([<ExcelArgument(Name="nominal2",Description = "Reference to nominal2")>] 
         nominal2 : obj)
        ([<ExcelArgument(Name="schedule1",Description = "Reference to schedule1")>] 
         schedule1 : obj)
        ([<ExcelArgument(Name="index1",Description = "Reference to index1")>] 
         index1 : obj)
        ([<ExcelArgument(Name="dayCount1",Description = "Reference to dayCount1")>] 
         dayCount1 : obj)
        ([<ExcelArgument(Name="schedule2",Description = "Reference to schedule2")>] 
         schedule2 : obj)
        ([<ExcelArgument(Name="index2",Description = "Reference to index2")>] 
         index2 : obj)
        ([<ExcelArgument(Name="dayCount2",Description = "Reference to dayCount2")>] 
         dayCount2 : obj)
        ([<ExcelArgument(Name="intermediateCapitalExchange",Description = "Reference to intermediateCapitalExchange")>] 
         intermediateCapitalExchange : obj)
        ([<ExcelArgument(Name="finalCapitalExchange",Description = "Reference to finalCapitalExchange")>] 
         finalCapitalExchange : obj)
        ([<ExcelArgument(Name="gearing1",Description = "Reference to gearing1")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="spread1",Description = "Reference to spread1")>] 
         spread1 : obj)
        ([<ExcelArgument(Name="cappedRate1",Description = "Reference to cappedRate1")>] 
         cappedRate1 : obj)
        ([<ExcelArgument(Name="flooredRate1",Description = "Reference to flooredRate1")>] 
         flooredRate1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "Reference to gearing2")>] 
         gearing2 : obj)
        ([<ExcelArgument(Name="spread2",Description = "Reference to spread2")>] 
         spread2 : obj)
        ([<ExcelArgument(Name="cappedRate2",Description = "Reference to cappedRate2")>] 
         cappedRate2 : obj)
        ([<ExcelArgument(Name="flooredRate2",Description = "Reference to flooredRate2")>] 
         flooredRate2 : obj)
        ([<ExcelArgument(Name="paymentConvention1",Description = "Reference to paymentConvention1")>] 
         paymentConvention1 : obj)
        ([<ExcelArgument(Name="paymentConvention2",Description = "Reference to paymentConvention2")>] 
         paymentConvention2 : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<VanillaSwap.Type> Type "Type" true
                let _nominal1 = Helper.toCell<double> nominal1 "nominal1" true
                let _nominal2 = Helper.toCell<double> nominal2 "nominal2" true
                let _schedule1 = Helper.toCell<Schedule> schedule1 "schedule1" true
                let _index1 = Helper.toCell<InterestRateIndex> index1 "index1" true
                let _dayCount1 = Helper.toCell<DayCounter> dayCount1 "dayCount1" true
                let _schedule2 = Helper.toCell<Schedule> schedule2 "schedule2" true
                let _index2 = Helper.toCell<InterestRateIndex> index2 "index2" true
                let _dayCount2 = Helper.toCell<DayCounter> dayCount2 "dayCount2" true
                let _intermediateCapitalExchange = Helper.toCell<bool> intermediateCapitalExchange "intermediateCapitalExchange" true
                let _finalCapitalExchange = Helper.toCell<bool> finalCapitalExchange "finalCapitalExchange" true
                let _gearing1 = Helper.toCell<double> gearing1 "gearing1" true
                let _spread1 = Helper.toCell<double> spread1 "spread1" true
                let _cappedRate1 = Helper.toNullable<double> cappedRate1 "cappedRate1"
                let _flooredRate1 = Helper.toNullable<double> flooredRate1 "flooredRate1"
                let _gearing2 = Helper.toCell<double> gearing2 "gearing2" true
                let _spread2 = Helper.toCell<double> spread2 "spread2" true
                let _cappedRate2 = Helper.toNullable<double> cappedRate2 "cappedRate2"
                let _flooredRate2 = Helper.toNullable<double> flooredRate2 "flooredRate2"
                let _paymentConvention1 = Helper.toNullable<BusinessDayConvention> paymentConvention1 "paymentConvention1"
                let _paymentConvention2 = Helper.toNullable<BusinessDayConvention> paymentConvention2 "paymentConvention2"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatFloatSwap1 
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

                let source = Helper.sourceFold "Fun.FloatFloatSwap1" 
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
    [<ExcelFunction(Name="_FloatFloatSwap_flooredRate1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_flooredRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).FlooredRate1
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".FlooredRate1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_flooredRate2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_flooredRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).FlooredRate2
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".FlooredRate2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_gearing1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_gearing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Gearing1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Gearing1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_gearing2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_gearing2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Gearing2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Gearing2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_index1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_index1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Index1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Index1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_index2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_index2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Index2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Index2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_leg1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Leg1
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Leg1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_leg2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Leg2
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Leg2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_nominal1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_nominal1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Nominal1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Nominal1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_nominal2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_nominal2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Nominal2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Nominal2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_paymentConvention1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_paymentConvention1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).PaymentConvention1
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".PaymentConvention1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_paymentConvention2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_paymentConvention2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).PaymentConvention2
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".PaymentConvention2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_schedule1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_schedule1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Schedule1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Schedule1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_schedule2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_schedule2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Schedule2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Schedule2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_spread1", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_spread1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Spread1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Spread1") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_spread2", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_spread2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Spread2
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Spread2") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FloatFloatSwap_type", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Type
                                                       ) :> ICell
                let format (o : VanillaSwap.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".TYPE") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_endDiscounts", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".EndDiscounts") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_engine", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Engine") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_isExpired", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".IsExpired") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_leg", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Leg") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_legBPS", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".LegBPS") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_legNPV", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".LegNPV") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_maturityDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".MaturityDate") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_npvDateDiscount", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".NpvDateDiscount") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_payer", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Payer") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_startDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".StartDate") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_startDiscounts", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".StartDiscounts") 
                                               [| _FloatFloatSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_CASH", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".CASH") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_errorEstimate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".ErrorEstimate") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_NPV", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".NPV") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_result", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".Result") 
                                               [| _FloatFloatSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_setPricingEngine", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatFloatSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".SetPricingEngine") 
                                               [| _FloatFloatSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_valuationDate", Description="Create a FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatFloatSwap",Description = "Reference to FloatFloatSwap")>] 
         floatfloatswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatFloatSwap = Helper.toCell<FloatFloatSwap> floatfloatswap "FloatFloatSwap" true 
                let builder () = withMnemonic mnemonic ((_FloatFloatSwap.cell :?> FloatFloatSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatFloatSwap.source + ".ValuationDate") 
                                               [| _FloatFloatSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatFloatSwap.cell
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
    [<ExcelFunction(Name="_FloatFloatSwap_Range", Description="Create a range of FloatFloatSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatFloatSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloatFloatSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatFloatSwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatFloatSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatFloatSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FloatFloatSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
