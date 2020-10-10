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
  Criteria to end optimization process:   - maximum number of iterations AND minimum number of iterations around stationary point - x (independent variable) stationary point - y=f(x) (dependent variable) stationary point - stationary gradient
  </summary> *)
[<AutoSerializable(true)>]
module EndCriteriaFunction =

    (*
        ! Test if the number of iteration is below MaxIterations
    *)
    [<ExcelFunction(Name="_EndCriteria_checkMaxIterations", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_checkMaxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="iteration",Description = "Reference to iteration")>] 
         iteration : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _iteration = Helper.toCell<int> iteration "iteration" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).CheckMaxIterations
                                                            _iteration.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".CheckMaxIterations") 
                                               [| _EndCriteria.source
                                               ;  _iteration.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _iteration.cell
                                ;  _ecType.cell
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
        ! Test if the function value is below functionEpsilon
    *)
    [<ExcelFunction(Name="_EndCriteria_checkStationaryFunctionAccuracy", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_checkStationaryFunctionAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="positiveOptimization",Description = "Reference to positiveOptimization")>] 
         positiveOptimization : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _f = Helper.toCell<double> f "f" 
                let _positiveOptimization = Helper.toCell<bool> positiveOptimization "positiveOptimization" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).CheckStationaryFunctionAccuracy
                                                            _f.cell 
                                                            _positiveOptimization.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".CheckStationaryFunctionAccuracy") 
                                               [| _EndCriteria.source
                                               ;  _f.source
                                               ;  _positiveOptimization.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _f.cell
                                ;  _positiveOptimization.cell
                                ;  _ecType.cell
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
        ! Test if the function variation is below functionEpsilon
    *)
    [<ExcelFunction(Name="_EndCriteria_checkStationaryFunctionValue", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_checkStationaryFunctionValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="fxOld",Description = "Reference to fxOld")>] 
         fxOld : obj)
        ([<ExcelArgument(Name="fxNew",Description = "Reference to fxNew")>] 
         fxNew : obj)
        ([<ExcelArgument(Name="statStateIterations",Description = "Reference to statStateIterations")>] 
         statStateIterations : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _fxOld = Helper.toCell<double> fxOld "fxOld" 
                let _fxNew = Helper.toCell<double> fxNew "fxNew" 
                let _statStateIterations = Helper.toCell<int> statStateIterations "statStateIterations" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).CheckStationaryFunctionValue
                                                            _fxOld.cell 
                                                            _fxNew.cell 
                                                            _statStateIterations.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".CheckStationaryFunctionValue") 
                                               [| _EndCriteria.source
                                               ;  _fxOld.source
                                               ;  _fxNew.source
                                               ;  _statStateIterations.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _fxOld.cell
                                ;  _fxNew.cell
                                ;  _statStateIterations.cell
                                ;  _ecType.cell
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
        ! Test if the root variation is below rootEpsilon
    *)
    [<ExcelFunction(Name="_EndCriteria_checkStationaryPoint", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_checkStationaryPoint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="xOld",Description = "Reference to xOld")>] 
         xOld : obj)
        ([<ExcelArgument(Name="xNew",Description = "Reference to xNew")>] 
         xNew : obj)
        ([<ExcelArgument(Name="statStateIterations",Description = "Reference to statStateIterations")>] 
         statStateIterations : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _xOld = Helper.toCell<double> xOld "xOld" 
                let _xNew = Helper.toCell<double> xNew "xNew" 
                let _statStateIterations = Helper.toCell<int> statStateIterations "statStateIterations" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).CheckStationaryPoint
                                                            _xOld.cell 
                                                            _xNew.cell 
                                                            _statStateIterations.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".CheckStationaryPoint") 
                                               [| _EndCriteria.source
                                               ;  _xOld.source
                                               ;  _xNew.source
                                               ;  _statStateIterations.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _xOld.cell
                                ;  _xNew.cell
                                ;  _statStateIterations.cell
                                ;  _ecType.cell
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
    [<ExcelFunction(Name="_EndCriteria_checkZeroGradientNorm", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_checkZeroGradientNorm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="gradientNorm",Description = "Reference to gradientNorm")>] 
         gradientNorm : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _gradientNorm = Helper.toCell<double> gradientNorm "gradientNorm" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).CheckZeroGradientNorm
                                                            _gradientNorm.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".CheckZeroGradientNorm") 
                                               [| _EndCriteria.source
                                               ;  _gradientNorm.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _gradientNorm.cell
                                ;  _ecType.cell
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
        ! Initialization constructor
    *)
    [<ExcelFunction(Name="_EndCriteria", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="maxStationaryStateIterations",Description = "Reference to maxStationaryStateIterations")>] 
         maxStationaryStateIterations : obj)
        ([<ExcelArgument(Name="rootEpsilon",Description = "Reference to rootEpsilon")>] 
         rootEpsilon : obj)
        ([<ExcelArgument(Name="functionEpsilon",Description = "Reference to functionEpsilon")>] 
         functionEpsilon : obj)
        ([<ExcelArgument(Name="gradientNormEpsilon",Description = "Reference to gradientNormEpsilon")>] 
         gradientNormEpsilon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let _maxStationaryStateIterations = Helper.toNullable<int> maxStationaryStateIterations "maxStationaryStateIterations"
                let _rootEpsilon = Helper.toCell<double> rootEpsilon "rootEpsilon" 
                let _functionEpsilon = Helper.toCell<double> functionEpsilon "functionEpsilon" 
                let _gradientNormEpsilon = Helper.toNullable<double> gradientNormEpsilon "gradientNormEpsilon"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EndCriteria 
                                                            _maxIterations.cell 
                                                            _maxStationaryStateIterations.cell 
                                                            _rootEpsilon.cell 
                                                            _functionEpsilon.cell 
                                                            _gradientNormEpsilon.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EndCriteria>) l

                let source () = Helper.sourceFold "Fun.EndCriteria" 
                                               [| _maxIterations.source
                                               ;  _maxStationaryStateIterations.source
                                               ;  _rootEpsilon.source
                                               ;  _functionEpsilon.source
                                               ;  _gradientNormEpsilon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maxIterations.cell
                                ;  _maxStationaryStateIterations.cell
                                ;  _rootEpsilon.cell
                                ;  _functionEpsilon.cell
                                ;  _gradientNormEpsilon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EndCriteria> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EndCriteria_functionEpsilon", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_functionEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).FunctionEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".FunctionEpsilon") 
                                               [| _EndCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
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
    [<ExcelFunction(Name="_EndCriteria_gradientNormEpsilon", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_gradientNormEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).GradientNormEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".GradientNormEpsilon") 
                                               [| _EndCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EndCriteria_maxIterations", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".MaxIterations") 
                                               [| _EndCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
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
    [<ExcelFunction(Name="_EndCriteria_maxStationaryStateIterations", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_maxStationaryStateIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).MaxStationaryStateIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".MaxStationaryStateIterations") 
                                               [| _EndCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
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
    [<ExcelFunction(Name="_EndCriteria_rootEpsilon", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_rootEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).RootEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".RootEpsilon") 
                                               [| _EndCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
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
        ! Test if the number of iterations is not too big and if a minimum point is not reached
    *)
    [<ExcelFunction(Name="_EndCriteria_value", Description="Create a EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EndCriteria",Description = "Reference to EndCriteria")>] 
         endcriteria : obj)
        ([<ExcelArgument(Name="iteration",Description = "Reference to iteration")>] 
         iteration : obj)
        ([<ExcelArgument(Name="statStateIterations",Description = "Reference to statStateIterations")>] 
         statStateIterations : obj)
        ([<ExcelArgument(Name="positiveOptimization",Description = "Reference to positiveOptimization")>] 
         positiveOptimization : obj)
        ([<ExcelArgument(Name="fold",Description = "Reference to fold")>] 
         fold : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "Reference to UnnamedParameter1")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="fnew",Description = "Reference to fnew")>] 
         fnew : obj)
        ([<ExcelArgument(Name="normgnew",Description = "Reference to normgnew")>] 
         normgnew : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EndCriteria = Helper.toCell<EndCriteria> endcriteria "EndCriteria"  
                let _iteration = Helper.toCell<int> iteration "iteration" 
                let _statStateIterations = Helper.toCell<int> statStateIterations "statStateIterations" 
                let _positiveOptimization = Helper.toCell<bool> positiveOptimization "positiveOptimization" 
                let _fold = Helper.toCell<double> fold "fold" 
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _fnew = Helper.toCell<double> fnew "fnew" 
                let _normgnew = Helper.toCell<double> normgnew "normgnew" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let builder (current : ICell) = withMnemonic mnemonic ((EndCriteriaModel.Cast _EndCriteria.cell).Value
                                                            _iteration.cell 
                                                            _statStateIterations.cell 
                                                            _positiveOptimization.cell 
                                                            _fold.cell 
                                                            _UnnamedParameter1.cell 
                                                            _fnew.cell 
                                                            _normgnew.cell 
                                                            _ecType.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EndCriteria.source + ".Value") 
                                               [| _EndCriteria.source
                                               ;  _iteration.source
                                               ;  _statStateIterations.source
                                               ;  _positiveOptimization.source
                                               ;  _fold.source
                                               ;  _UnnamedParameter1.source
                                               ;  _fnew.source
                                               ;  _normgnew.source
                                               ;  _ecType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EndCriteria.cell
                                ;  _iteration.cell
                                ;  _statStateIterations.cell
                                ;  _positiveOptimization.cell
                                ;  _fold.cell
                                ;  _UnnamedParameter1.cell
                                ;  _fnew.cell
                                ;  _normgnew.cell
                                ;  _ecType.cell
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
    [<ExcelFunction(Name="_EndCriteria_Range", Description="Create a range of EndCriteria",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EndCriteria_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EndCriteria")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EndCriteria> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EndCriteria>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<EndCriteria>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<EndCriteria>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
