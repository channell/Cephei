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
  calibration helper for Heston model
  </summary> *)
[<AutoSerializable(true)>]
module HestonModelHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HestonModelHelper_addTimesTo", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_addTimesTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        ([<ExcelArgument(Name="t",Description = "double range")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let _t = Helper.toCell<Generic.List<double>> t "t" 
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).AddTimesTo
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : HestonModelHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".AddTimesTo") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_blackPrice", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_blackPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        ([<ExcelArgument(Name="volatility",Description = "double")>] 
         volatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).BlackPrice
                                                            _volatility.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".BlackPrice") 

                                               [| _volatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
                                ;  _volatility.cell
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
    [<ExcelFunction(Name="_HestonModelHelper1", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturity",Description = "Period")>] 
         maturity : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="s0",Description = "double")>] 
         s0 : obj)
        ([<ExcelArgument(Name="strikePrice",Description = "double")>] 
         strikePrice : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="riskFreeRate",Description = "YieldTermStructure")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="dividendYield",Description = "YieldTermStructure")>] 
         dividendYield : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError or empty")>] 
         errorType : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturity = Helper.toCell<Period> maturity "maturity" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _s0 = Helper.toCell<double> s0 "s0" 
                let _strikePrice = Helper.toCell<double> strikePrice "strikePrice" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _riskFreeRate = Helper.toHandle<YieldTermStructure> riskFreeRate "riskFreeRate" 
                let _dividendYield = Helper.toHandle<YieldTermStructure> dividendYield "dividendYield" 
                let _errorType = Helper.toDefault<CalibrationHelper.CalibrationErrorType> errorType "errorType" CalibrationHelper.CalibrationErrorType.RelativePriceError
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.HestonModelHelper1 
                                                            _maturity.cell 
                                                            _calendar.cell 
                                                            _s0.cell 
                                                            _strikePrice.cell 
                                                            _volatility.cell 
                                                            _riskFreeRate.cell 
                                                            _dividendYield.cell 
                                                            _errorType.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonModelHelper>) l

                let source () = Helper.sourceFold "Fun.HestonModelHelper1" 
                                               [| _maturity.source
                                               ;  _calendar.source
                                               ;  _s0.source
                                               ;  _strikePrice.source
                                               ;  _volatility.source
                                               ;  _riskFreeRate.source
                                               ;  _dividendYield.source
                                               ;  _errorType.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturity.cell
                                ;  _calendar.cell
                                ;  _s0.cell
                                ;  _strikePrice.cell
                                ;  _volatility.cell
                                ;  _riskFreeRate.cell
                                ;  _dividendYield.cell
                                ;  _errorType.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModelHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonModelHelper", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturity",Description = "Period")>] 
         maturity : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="s0",Description = "Quote")>] 
         s0 : obj)
        ([<ExcelArgument(Name="strikePrice",Description = "double")>] 
         strikePrice : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="riskFreeRate",Description = "YieldTermStructure")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="dividendYield",Description = "YieldTermStructure")>] 
         dividendYield : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError or empty")>] 
         errorType : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturity = Helper.toCell<Period> maturity "maturity" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _s0 = Helper.toHandle<Quote> s0 "s0" 
                let _strikePrice = Helper.toCell<double> strikePrice "strikePrice" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _riskFreeRate = Helper.toHandle<YieldTermStructure> riskFreeRate "riskFreeRate" 
                let _dividendYield = Helper.toHandle<YieldTermStructure> dividendYield "dividendYield" 
                let _errorType = Helper.toDefault<CalibrationHelper.CalibrationErrorType> errorType "errorType" CalibrationHelper.CalibrationErrorType.RelativePriceError
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.HestonModelHelper
                                                            _maturity.cell 
                                                            _calendar.cell 
                                                            _s0.cell 
                                                            _strikePrice.cell 
                                                            _volatility.cell 
                                                            _riskFreeRate.cell 
                                                            _dividendYield.cell 
                                                            _errorType.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonModelHelper>) l

                let source () = Helper.sourceFold "Fun.HestonModelHelper" 
                                               [| _maturity.source
                                               ;  _calendar.source
                                               ;  _s0.source
                                               ;  _strikePrice.source
                                               ;  _volatility.source
                                               ;  _riskFreeRate.source
                                               ;  _dividendYield.source
                                               ;  _errorType.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturity.cell
                                ;  _calendar.cell
                                ;  _s0.cell
                                ;  _strikePrice.cell
                                ;  _volatility.cell
                                ;  _riskFreeRate.cell
                                ;  _dividendYield.cell
                                ;  _errorType.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModelHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonModelHelper_maturity", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_maturity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).Maturity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".Maturity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_modelValue", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_modelValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).ModelValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".ModelValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_optionType", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_strike", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
        ! returns the error resulting from the model valuation
    *)
    [<ExcelFunction(Name="_HestonModelHelper_calibrationError", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_calibrationError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).CalibrationError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".CalibrationError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_impliedVolatility", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
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

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_marketValue", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_marketValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).MarketValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".MarketValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_setPricingEngine", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        ([<ExcelArgument(Name="engine",Description = "IPricingEngine")>] 
         engine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let _engine = Helper.toCell<IPricingEngine> engine "engine" 
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).SetPricingEngine
                                                            _engine.cell 
                                                       ) :> ICell
                let format (o : HestonModelHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".SetPricingEngine") 

                                               [| _engine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_volatility", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModelHelper> format
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
    [<ExcelFunction(Name="_HestonModelHelper_volatilityType", Description="Create a HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModelHelper",Description = "HestonModelHelper")>] 
         hestonmodelhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModelHelper = Helper.toModelReference<HestonModelHelper> hestonmodelhelper "HestonModelHelper"  
                let builder (current : ICell) = ((HestonModelHelperModel.Cast _HestonModelHelper.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModelHelper.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModelHelper.cell
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
    [<ExcelFunction(Name="_HestonModelHelper_Range", Description="Create a range of HestonModelHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModelHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonModelHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<HestonModelHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<HestonModelHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<HestonModelHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
