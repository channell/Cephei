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
  mixed linear/cubic interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module MixedLinearCubicInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "int")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Behavior: ShareRanges, SplitRanges")>] 
         behavior : obj)
        ([<ExcelArgument(Name="da",Description = "CubicInterpolation.DerivativeApprox: Spline, SplineOM1, SplineOM2, FourthOrder, Parabolic, FritschButland, Akima, Kruger, Harmonic")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "bool")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftC",Description = "CubicInterpolation.BoundaryCondition: NotAKnot, FirstDerivative, SecondDerivative, Periodic, Lagrange")>] 
         leftC : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "double")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightC",Description = "CubicInterpolation.BoundaryCondition: NotAKnot, FirstDerivative, SecondDerivative, Periodic, Lagrange")>] 
         rightC : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "double")>] 
         rightConditionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _n = Helper.toCell<int> n "n" 
                let _behavior = Helper.toCell<Behavior> behavior "behavior" 
                let _da = Helper.toCell<CubicInterpolation.DerivativeApprox> da "da" 
                let _monotonic = Helper.toCell<bool> monotonic "monotonic" 
                let _leftC = Helper.toCell<CubicInterpolation.BoundaryCondition> leftC "leftC" 
                let _leftConditionValue = Helper.toCell<double> leftConditionValue "leftConditionValue" 
                let _rightC = Helper.toCell<CubicInterpolation.BoundaryCondition> rightC "rightC" 
                let _rightConditionValue = Helper.toCell<double> rightConditionValue "rightConditionValue" 
                let builder (current : ICell) = (Fun.MixedLinearCubicInterpolation 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                            _da.cell 
                                                            _monotonic.cell 
                                                            _leftC.cell 
                                                            _leftConditionValue.cell 
                                                            _rightC.cell 
                                                            _rightConditionValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearCubicInterpolation>) l

                let source () = Helper.sourceFold "Fun.MixedLinearCubicInterpolation" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _n.source
                                               ;  _behavior.source
                                               ;  _da.source
                                               ;  _monotonic.source
                                               ;  _leftC.source
                                               ;  _leftConditionValue.source
                                               ;  _rightC.source
                                               ;  _rightConditionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _n.cell
                                ;  _behavior.cell
                                ;  _da.cell
                                ;  _monotonic.cell
                                ;  _leftC.cell
                                ;  _leftConditionValue.cell
                                ;  _rightC.cell
                                ;  _rightConditionValue.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MixedLinearCubicInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_derivative", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_empty", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_primitive", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_secondDerivative", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_update", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_value1", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_value", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_xMax", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_xMin", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_allowsExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_disableExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_enableExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_extrapolate", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder (current : ICell) = ((MixedLinearCubicInterpolationModel.Cast _MixedLinearCubicInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_Range", Description="Create a range of MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearCubicInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MixedLinearCubicInterpolation> (c)) :> ICell
                let format (i : Cephei.Cell.List<MixedLinearCubicInterpolation>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MixedLinearCubicInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
