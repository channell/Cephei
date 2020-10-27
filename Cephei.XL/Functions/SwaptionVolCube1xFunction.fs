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
(*
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module SwaptionVolCube1xFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_denseSabrParameters", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_denseSabrParameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).DenseSabrParameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".DenseSabrParameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_GetInterpolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_GetInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).GetInterpolation
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SABRInterpolation>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".GetInterpolation") 

                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_marketVolCube", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_marketVolCube
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MarketVolCube
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MarketVolCube") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_marketVolCube", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_marketVolCube
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MarketVolCube1
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MarketVolCube") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _beta = Helper.toCell<double> beta "beta" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Recalibration
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 

                                               [| _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="swapLengths",Description = "Period range")>] 
         swapLengths : obj)
        ([<ExcelArgument(Name="beta",Description = "double range")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _swapLengths = Helper.toCell<Generic.List<Period>> swapLengths "swapLengths" 
                let _beta = Helper.toCell<Generic.List<double>> beta "beta" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Recalibration1
                                                            _swapLengths.cell 
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 

                                               [| _swapLengths.source
                                               ;  _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _swapLengths.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_recalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_recalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="beta",Description = "double range")>] 
         beta : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _beta = Helper.toCell<Generic.List<double>> beta "beta" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Recalibration2
                                                            _beta.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Recalibration") 

                                               [| _beta.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _beta.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_sabrCalibrationSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_sabrCalibrationSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="marketVolCube",Description = "Cube.Cube")>] 
         marketVolCube : obj)
        ([<ExcelArgument(Name="parametersCube",Description = "Cube.Cube")>] 
         parametersCube : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _marketVolCube = Helper.toCell<Cube.Cube> marketVolCube "marketVolCube" 
                let _parametersCube = Helper.toCell<Cube.Cube> parametersCube "parametersCube" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SabrCalibrationSection
                                                            _marketVolCube.cell 
                                                            _parametersCube.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SabrCalibrationSection") 

                                               [| _marketVolCube.source
                                               ;  _parametersCube.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _marketVolCube.cell
                                ;  _parametersCube.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_sparseSabrParameters", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_sparseSabrParameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SparseSabrParameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SparseSabrParameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="atmVolStructure",Description = "SwaptionVolatilityStructure")>] 
         atmVolStructure : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Period range")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="strikeSpreads",Description = "double range")>] 
         strikeSpreads : obj)
        ([<ExcelArgument(Name="volSpreads",Description = "Quote range")>] 
         volSpreads : obj)
        ([<ExcelArgument(Name="swapIndexBase",Description = "SwapIndex")>] 
         swapIndexBase : obj)
        ([<ExcelArgument(Name="shortSwapIndexBase",Description = "SwapIndex")>] 
         shortSwapIndexBase : obj)
        ([<ExcelArgument(Name="vegaWeightedSmileFit",Description = "bool")>] 
         vegaWeightedSmileFit : obj)
        ([<ExcelArgument(Name="parametersGuess",Description = "Quote range")>] 
         parametersGuess : obj)
        ([<ExcelArgument(Name="isParameterFixed",Description = "bool range")>] 
         isParameterFixed : obj)
        ([<ExcelArgument(Name="isAtmCalibrated",Description = "bool")>] 
         isAtmCalibrated : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="maxErrorTolerance",Description = "double")>] 
         maxErrorTolerance : obj)
        ([<ExcelArgument(Name="optMethod",Description = "OptimizationMethod or empty")>] 
         optMethod : obj)
        ([<ExcelArgument(Name="errorAccept",Description = "double")>] 
         errorAccept : obj)
        ([<ExcelArgument(Name="useMaxError",Description = "bool or empty")>] 
         useMaxError : obj)
        ([<ExcelArgument(Name="maxGuesses",Description = "int or empty")>] 
         maxGuesses : obj)
        ([<ExcelArgument(Name="backwardFlat",Description = "bool or empty")>] 
         backwardFlat : obj)
        ([<ExcelArgument(Name="cutoffStrike",Description = "double or empty")>] 
         cutoffStrike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVolStructure = Helper.toHandle<SwaptionVolatilityStructure> atmVolStructure "atmVolStructure" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _strikeSpreads = Helper.toCell<Generic.List<double>> strikeSpreads "strikeSpreads" 
                let _volSpreads = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> volSpreads "volSpreads" 
                let _swapIndexBase = Helper.toCell<SwapIndex> swapIndexBase "swapIndexBase" 
                let _shortSwapIndexBase = Helper.toCell<SwapIndex> shortSwapIndexBase "shortSwapIndexBase" 
                let _vegaWeightedSmileFit = Helper.toCell<bool> vegaWeightedSmileFit "vegaWeightedSmileFit" 
                let _parametersGuess = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> parametersGuess "parametersGuess" 
                let _isParameterFixed = Helper.toCell<Generic.List<bool>> isParameterFixed "isParameterFixed" 
                let _isAtmCalibrated = Helper.toCell<bool> isAtmCalibrated "isAtmCalibrated" 
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _maxErrorTolerance = Helper.toNullable<double> maxErrorTolerance "maxErrorTolerance"
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let _errorAccept = Helper.toNullable<double> errorAccept "errorAccept"
                let _useMaxError = Helper.toDefault<bool> useMaxError "useMaxError" false
                let _maxGuesses = Helper.toDefault<int> maxGuesses "maxGuesses" 50
                let _backwardFlat = Helper.toDefault<bool> backwardFlat "backwardFlat" false
                let _cutoffStrike = Helper.toDefault<double> cutoffStrike "cutoffStrike" 0.0001
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolCube1x 
                                                            _atmVolStructure.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _strikeSpreads.cell 
                                                            _volSpreads.cell 
                                                            _swapIndexBase.cell 
                                                            _shortSwapIndexBase.cell 
                                                            _vegaWeightedSmileFit.cell 
                                                            _parametersGuess.cell 
                                                            _isParameterFixed.cell 
                                                            _isAtmCalibrated.cell 
                                                            _endCriteria.cell 
                                                            _maxErrorTolerance.cell 
                                                            _optMethod.cell 
                                                            _errorAccept.cell 
                                                            _useMaxError.cell 
                                                            _maxGuesses.cell 
                                                            _backwardFlat.cell 
                                                            _cutoffStrike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolCube1x>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolCube1x" 
                                               [| _atmVolStructure.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _strikeSpreads.source
                                               ;  _volSpreads.source
                                               ;  _swapIndexBase.source
                                               ;  _shortSwapIndexBase.source
                                               ;  _vegaWeightedSmileFit.source
                                               ;  _parametersGuess.source
                                               ;  _isParameterFixed.source
                                               ;  _isAtmCalibrated.source
                                               ;  _endCriteria.source
                                               ;  _maxErrorTolerance.source
                                               ;  _optMethod.source
                                               ;  _errorAccept.source
                                               ;  _useMaxError.source
                                               ;  _maxGuesses.source
                                               ;  _backwardFlat.source
                                               ;  _cutoffStrike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _atmVolStructure.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _strikeSpreads.cell
                                ;  _volSpreads.cell
                                ;  _swapIndexBase.cell
                                ;  _shortSwapIndexBase.cell
                                ;  _vegaWeightedSmileFit.cell
                                ;  _parametersGuess.cell
                                ;  _isParameterFixed.cell
                                ;  _isAtmCalibrated.cell
                                ;  _endCriteria.cell
                                ;  _maxErrorTolerance.cell
                                ;  _optMethod.cell
                                ;  _errorAccept.cell
                                ;  _useMaxError.cell
                                ;  _maxGuesses.cell
                                ;  _backwardFlat.cell
                                ;  _cutoffStrike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_updateAfterRecalibration", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_updateAfterRecalibration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).UpdateAfterRecalibration
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".UpdateAfterRecalibration") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volCubeAtmCalibrated", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volCubeAtmCalibrated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).VolCubeAtmCalibrated
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolCubeAtmCalibrated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).AtmStrike
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmStrike") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        Other inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).AtmStrike1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmStrike") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_atmVol", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_atmVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).AtmVol
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".AtmVol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_calendar", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        TermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_dayCounter", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxDate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxSwapTenor", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxSwapTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxTime", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_minStrike", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_referenceDate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_settlementDays", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_shortSwapIndexBase", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shortSwapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).ShortSwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".ShortSwapIndexBase") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_strikeSpreads", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_strikeSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).StrikeSpreads
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".StrikeSpreads") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapIndexBase", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapIndexBase") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_vegaWeightedSmileFit", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_vegaWeightedSmileFit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).VegaWeightedSmileFit
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".VegaWeightedSmileFit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatilityType", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_volSpreads", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).VolSpreads
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Generic.List<ICell<Handle<Quote>>>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".VolSpreads") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! additional inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDateFromTime", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDateFromTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).OptionDateFromTime
                                                            _optionTime.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDateFromTime") 

                                               [| _optionTime.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDates", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionTenors", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionTenors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionTimes", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLengths", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLengths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SwapLengths
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLengths") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapTenors", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SwapTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapTenors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_update", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Update
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance2
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance3
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_blackVariance", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BlackVariance5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BlackVariance") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_maxSwapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".MaxSwapLength") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift4
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_shift", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Shift5
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Shift") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SmileSection
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SmileSection1
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_smileSection", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SmileSection2
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SmileSection") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube1x> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="start",Description = "Date")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLength") 

                                               [| _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_swapLength", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".SwapLength") 

                                               [| _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_volatility", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Volatility5
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Volatility") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_businessDayConvention", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_optionDateFromTenor", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _p.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_timeFromReference", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _date.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_allowsExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_disableExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SwaptionVolCube1x_enableExtrapolation", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube1x) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_extrapolate", Description="Create a SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube1x",Description = "SwaptionVolCube1x")>] 
         swaptionvolcube1x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube1x = Helper.toCell<SwaptionVolCube1x> swaptionvolcube1x "SwaptionVolCube1x"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolCube1xModel.Cast _SwaptionVolCube1x.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolCube1x.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube1x.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube1x_Range", Description="Create a range of SwaptionVolCube1x",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolCube1x_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwaptionVolCube1x> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SwaptionVolCube1x>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SwaptionVolCube1x>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SwaptionVolCube1x>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
