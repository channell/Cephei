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
module CapHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CapHelper_addTimesTo", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_addTimesTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        ([<ExcelArgument(Name="times",Description = "double range")>] 
         times : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).AddTimesTo
                                                            _times.cell 
                                                       ) :> ICell
                let format (o : CapHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".AddTimesTo") 

                                               [| _times.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_blackPrice", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_blackPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).BlackPrice
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".BlackPrice") 

                                               [| _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="fixedLegFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         fixedLegFrequency : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="includeFirstSwaplet",Description = "bool")>] 
         includeFirstSwaplet : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="errorType",Description = "CalibrationHelper.CalibrationErrorType: RelativePriceError, PriceError, ImpliedVolError or empty")>] 
         errorType : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _length = Helper.toCell<Period> length "length" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixedLegFrequency = Helper.toCell<Frequency> fixedLegFrequency "fixedLegFrequency" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _includeFirstSwaplet = Helper.toCell<bool> includeFirstSwaplet "includeFirstSwaplet" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _errorType = Helper.toDefault<CalibrationHelper.CalibrationErrorType> errorType "errorType" CalibrationHelper.CalibrationErrorType.RelativePriceError
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.CapHelper 
                                                            _length.cell 
                                                            _volatility.cell 
                                                            _index.cell 
                                                            _fixedLegFrequency.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _includeFirstSwaplet.cell 
                                                            _termStructure.cell 
                                                            _errorType.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapHelper>) l

                let source () = Helper.sourceFold "Fun.CapHelper" 
                                               [| _length.source
                                               ;  _volatility.source
                                               ;  _index.source
                                               ;  _fixedLegFrequency.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _includeFirstSwaplet.source
                                               ;  _termStructure.source
                                               ;  _errorType.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _length.cell
                                ;  _volatility.cell
                                ;  _index.cell
                                ;  _fixedLegFrequency.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _includeFirstSwaplet.cell
                                ;  _termStructure.cell
                                ;  _errorType.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapHelper_modelValue", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_modelValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).ModelValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".ModelValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_calibrationError", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_calibrationError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).CalibrationError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".CalibrationError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_impliedVolatility", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
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

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_marketValue", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_marketValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).MarketValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".MarketValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_setPricingEngine", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        ([<ExcelArgument(Name="engine",Description = "IPricingEngine")>] 
         engine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let _engine = Helper.toCell<IPricingEngine> engine "engine" 
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).SetPricingEngine
                                                            _engine.cell 
                                                       ) :> ICell
                let format (o : CapHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".SetPricingEngine") 

                                               [| _engine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_volatility", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_CapHelper.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapHelper> format
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
    [<ExcelFunction(Name="_CapHelper_volatilityType", Description="Create a CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapHelper",Description = "CapHelper")>] 
         caphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapHelper = Helper.toCell<CapHelper> caphelper "CapHelper"  
                let builder (current : ICell) = ((CapHelperModel.Cast _CapHelper.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapHelper.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapHelper.cell
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
    [<ExcelFunction(Name="_CapHelper_Range", Description="Create a range of CapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CapHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<CapHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CapHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
