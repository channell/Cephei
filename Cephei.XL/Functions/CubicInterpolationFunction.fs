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
  Cubic interpolation is fully defined when the ${f_i}$ function values at points ${x_i}$ are supplemented with ${f_i}$ function derivative values.  Different type of first derivative approximations are implemented, both local and non-local. Local schemes (Fourth-order, Parabolic, Modified Parabolic, Fritsch-Butland, Akima, Kruger) use only $f$ values near $x_i$ to calculate $f_i$. Non-local schemes (Spline with different boundary conditions) use all ${f_i}$ values and obtain ${f_i}$ by solving a linear system of equations. Local schemes produce $C^1$ interpolants, while the spline scheme generates $C^2$ interpolants.  Hyman's monotonicity constraint filter is also implemented: it can be applied to all schemes to ensure that in the regions of local monotoniticity of the input (three successive increasing or decreasing values) the interpolating cubic remains monotonic. If the interpolating cubic is already monotonic, the Hyman filter leaves it unchanged preserving all its original features.  In the case of $C^2$ interpolants the Hyman filter ensures local monotonicity at the expense of the second derivative of the interpolant which will no longer be continuous in the points where the filter has been applied.  While some non-linear schemes (Modified Parabolic, Fritsch-Butland, Kruger) are guaranteed to be locally monotone in their original approximation, all other schemes must be filtered according to the Hyman criteria at the expense of their linearity.  See R. L. Dougherty, A. Edelman, and J. M. Hyman, "Nonnegativity-, Monotonicity-, or Convexity-Preserving CubicSpline and Quintic Hermite Interpolation" Mathematics Of Computation, v. 52, n. 186, April 1989, pp. 471-494.  implement missing schemes (FourthOrder and ModifiedParabolic) and missing boundary conditions (Periodic and Lagrange).  to be adapted from old ones.
  </summary> *)
[<AutoSerializable(true)>]
module CubicInterpolationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CubicInterpolation_aCoefficients", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicInterpolation.source + ".ACoefficients") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_bCoefficients", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicInterpolation.source + ".BCoefficients") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_cCoefficients", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicInterpolation.source + ".CCoefficients") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="da",Description = "Reference to da")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "Reference to monotonic")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftCond",Description = "Reference to leftCond")>] 
         leftCond : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "Reference to leftConditionValue")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightCond",Description = "Reference to rightCond")>] 
         rightCond : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "Reference to rightConditionValue")>] 
         rightConditionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _da = Helper.toCell<CubicInterpolation.DerivativeApprox> da "da" 
                let _monotonic = Helper.toCell<bool> monotonic "monotonic" 
                let _leftCond = Helper.toCell<CubicInterpolation.BoundaryCondition> leftCond "leftCond" 
                let _leftConditionValue = Helper.toCell<double> leftConditionValue "leftConditionValue" 
                let _rightCond = Helper.toCell<CubicInterpolation.BoundaryCondition> rightCond "rightCond" 
                let _rightConditionValue = Helper.toCell<double> rightConditionValue "rightConditionValue" 
                let builder () = withMnemonic mnemonic (Fun.CubicInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _da.cell 
                                                            _monotonic.cell 
                                                            _leftCond.cell 
                                                            _leftConditionValue.cell 
                                                            _rightCond.cell 
                                                            _rightConditionValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CubicInterpolation>) l

                let source = Helper.sourceFold "Fun.CubicInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _da.source
                                               ;  _monotonic.source
                                               ;  _leftCond.source
                                               ;  _leftConditionValue.source
                                               ;  _rightCond.source
                                               ;  _rightConditionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _da.cell
                                ;  _monotonic.cell
                                ;  _leftCond.cell
                                ;  _leftConditionValue.cell
                                ;  _rightCond.cell
                                ;  _rightConditionValue.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CubicInterpolation_derivative", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Derivative") 
                                               [| _CubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_empty", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Empty") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_primitive", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Primitive") 
                                               [| _CubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_secondDerivative", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".SecondDerivative") 
                                               [| _CubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_update", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : CubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Update") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_value1", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Value1") 
                                               [| _CubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_CubicInterpolation_value", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Value") 
                                               [| _CubicInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_xMax", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".XMax") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_xMin", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".XMin") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_CubicInterpolation_allowsExtrapolation", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".AllowsExtrapolation") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_CubicInterpolation_disableExtrapolation", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".DisableExtrapolation") 
                                               [| _CubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_CubicInterpolation_enableExtrapolation", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".EnableExtrapolation") 
                                               [| _CubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_extrapolate", Description="Create a CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicInterpolation",Description = "Reference to CubicInterpolation")>] 
         cubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicInterpolation = Helper.toCell<CubicInterpolation> cubicinterpolation "CubicInterpolation"  
                let builder () = withMnemonic mnemonic ((CubicInterpolationModel.Cast _CubicInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicInterpolation.source + ".Extrapolate") 
                                               [| _CubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicInterpolation.cell
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
    [<ExcelFunction(Name="_CubicInterpolation_Range", Description="Create a range of CubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CubicInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CubicInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CubicInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CubicInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CubicInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
