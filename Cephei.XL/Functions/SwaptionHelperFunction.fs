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
module SwaptionHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionHelper_addTimesTo", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_addTimesTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        ([<ExcelArgument(Name="times",Description = "double range")>] 
         times : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).AddTimesTo
                                                            _times.cell 
                                                       ) :> ICell
                let format (o : SwaptionHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".AddTimesTo") 

                                               [| _times.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                ;  _times.cell
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
    [<ExcelFunction(Name="_SwaptionHelper_blackPrice", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_blackPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).BlackPrice
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".BlackPrice") 

                                               [| _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_SwaptionHelper_modelValue", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_modelValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).ModelValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".ModelValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
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
    [<ExcelFunction(Name="_SwaptionHelper_swaption", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_swaption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).Swaption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swaption>) l

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".Swaption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionHelper", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturity",Description = "Period")>] 
         maturity : obj)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="fixedLegTenor",Description = "Period")>] 
         fixedLegTenor : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="floatingLegDayCounter",Description = "DayCounter")>] 
         floatingLegDayCounter : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError")>] 
         errorType : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="nominal",Description = "double or empty")>] 
         nominal : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturity = Helper.toCell<Period> maturity "maturity" 
                let _length = Helper.toCell<Period> length "length" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixedLegTenor = Helper.toCell<Period> fixedLegTenor "fixedLegTenor" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _floatingLegDayCounter = Helper.toCell<DayCounter> floatingLegDayCounter "floatingLegDayCounter" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _errorType = Helper.toCell<CalibrationHelper.CalibrationErrorType> errorType "errorType"
                let _strike = Helper.toNullable<double> strike "strike"
                let _nominal = Helper.toDefault<double> nominal "nominal" 1.0
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.SwaptionHelper 
                                                            _maturity.cell 
                                                            _length.cell 
                                                            _volatility.cell 
                                                            _index.cell 
                                                            _fixedLegTenor.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _floatingLegDayCounter.cell 
                                                            _termStructure.cell 
                                                            _errorType.cell 
                                                            _strike.cell 
                                                            _nominal.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionHelper>) l

                let source () = Helper.sourceFold "Fun.SwaptionHelper" 
                                               [| _maturity.source
                                               ;  _length.source
                                               ;  _volatility.source
                                               ;  _index.source
                                               ;  _fixedLegTenor.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _floatingLegDayCounter.source
                                               ;  _termStructure.source
                                               ;  _errorType.source
                                               ;  _strike.source
                                               ;  _nominal.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturity.cell
                                ;  _length.cell
                                ;  _volatility.cell
                                ;  _index.cell
                                ;  _fixedLegTenor.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _floatingLegDayCounter.cell
                                ;  _termStructure.cell
                                ;  _errorType.cell
                                ;  _strike.cell
                                ;  _nominal.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionHelper1", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseDate",Description = "Date")>] 
         exerciseDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Date")>] 
         endDate : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="fixedLegTenor",Description = "Period")>] 
         fixedLegTenor : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="floatingLegDayCounter",Description = "DayCounter")>] 
         floatingLegDayCounter : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError")>] 
         errorType : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="nominal",Description = "double or empty")>] 
         nominal : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseDate = Helper.toCell<Date> exerciseDate "exerciseDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixedLegTenor = Helper.toCell<Period> fixedLegTenor "fixedLegTenor" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _floatingLegDayCounter = Helper.toCell<DayCounter> floatingLegDayCounter "floatingLegDayCounter" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _errorType = Helper.toCell<CalibrationHelper.CalibrationErrorType> errorType "errorType" 
                let _strike = Helper.toNullable<double> strike "strike"
                let _nominal = Helper.toDefault<double> nominal "nominal" 1.0
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.SwaptionHelper1 
                                                            _exerciseDate.cell 
                                                            _endDate.cell 
                                                            _volatility.cell 
                                                            _index.cell 
                                                            _fixedLegTenor.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _floatingLegDayCounter.cell 
                                                            _termStructure.cell 
                                                            _errorType.cell 
                                                            _strike.cell 
                                                            _nominal.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionHelper>) l

                let source () = Helper.sourceFold "Fun.SwaptionHelper1" 
                                               [| _exerciseDate.source
                                               ;  _endDate.source
                                               ;  _volatility.source
                                               ;  _index.source
                                               ;  _fixedLegTenor.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _floatingLegDayCounter.source
                                               ;  _termStructure.source
                                               ;  _errorType.source
                                               ;  _strike.source
                                               ;  _nominal.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exerciseDate.cell
                                ;  _endDate.cell
                                ;  _volatility.cell
                                ;  _index.cell
                                ;  _fixedLegTenor.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _floatingLegDayCounter.cell
                                ;  _termStructure.cell
                                ;  _errorType.cell
                                ;  _strike.cell
                                ;  _nominal.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionHelper2", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseDate",Description = "Date")>] 
         exerciseDate : obj)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="fixedLegTenor",Description = "Period")>] 
         fixedLegTenor : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="floatingLegDayCounter",Description = "DayCounter")>] 
         floatingLegDayCounter : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError")>] 
         errorType : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="nominal",Description = "double or empty")>] 
         nominal : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseDate = Helper.toCell<Date> exerciseDate "exerciseDate" 
                let _length = Helper.toCell<Period> length "length" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixedLegTenor = Helper.toCell<Period> fixedLegTenor "fixedLegTenor" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _floatingLegDayCounter = Helper.toCell<DayCounter> floatingLegDayCounter "floatingLegDayCounter" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _errorType = Helper.toCell<CalibrationHelper.CalibrationErrorType> errorType "errorType" 
                let _strike = Helper.toNullable<double> strike "strike"
                let _nominal = Helper.toDefault<double> nominal "nominal" 1.0
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.SwaptionHelper2 
                                                            _exerciseDate.cell 
                                                            _length.cell 
                                                            _volatility.cell 
                                                            _index.cell 
                                                            _fixedLegTenor.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _floatingLegDayCounter.cell 
                                                            _termStructure.cell 
                                                            _errorType.cell 
                                                            _strike.cell 
                                                            _nominal.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionHelper>) l

                let source () = Helper.sourceFold "Fun.SwaptionHelper2" 
                                               [| _exerciseDate.source
                                               ;  _length.source
                                               ;  _volatility.source
                                               ;  _index.source
                                               ;  _fixedLegTenor.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _floatingLegDayCounter.source
                                               ;  _termStructure.source
                                               ;  _errorType.source
                                               ;  _strike.source
                                               ;  _nominal.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exerciseDate.cell
                                ;  _length.cell
                                ;  _volatility.cell
                                ;  _index.cell
                                ;  _fixedLegTenor.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _floatingLegDayCounter.cell
                                ;  _termStructure.cell
                                ;  _errorType.cell
                                ;  _strike.cell
                                ;  _nominal.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionHelper_underlyingSwap", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).UnderlyingSwap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".UnderlyingSwap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the error resulting from the model valuation
    *)
    [<ExcelFunction(Name="_SwaptionHelper_calibrationError", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_calibrationError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).CalibrationError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".CalibrationError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
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
        ! Black volatility implied by the model
    *)
    [<ExcelFunction(Name="_SwaptionHelper_impliedVolatility", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "double")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "double")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                ;  _targetValue.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
        ! returns the actual price of the instrument (from volatility)
    *)
    [<ExcelFunction(Name="_SwaptionHelper_marketValue", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_marketValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).MarketValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".MarketValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
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
    [<ExcelFunction(Name="_SwaptionHelper_setPricingEngine", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        ([<ExcelArgument(Name="engine",Description = "IPricingEngine")>] 
         engine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let _engine = Helper.toCell<IPricingEngine> engine "engine" 
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).SetPricingEngine
                                                            _engine.cell 
                                                       ) :> ICell
                let format (o : SwaptionHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".SetPricingEngine") 

                                               [| _engine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                ;  _engine.cell
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
        ! returns the volatility Handle
    *)
    [<ExcelFunction(Name="_SwaptionHelper_volatility", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the volatility type
    *)
    [<ExcelFunction(Name="_SwaptionHelper_volatilityType", Description="Create a SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionHelper",Description = "SwaptionHelper")>] 
         swaptionhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionHelper = Helper.toModelReference<SwaptionHelper> swaptionhelper "SwaptionHelper"  
                let builder (current : ICell) = ((SwaptionHelperModel.Cast _SwaptionHelper.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionHelper.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionHelper.cell
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
    [<ExcelFunction(Name="_SwaptionHelper_Range", Description="Create a range of SwaptionHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwaptionHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SwaptionHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<SwaptionHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SwaptionHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
