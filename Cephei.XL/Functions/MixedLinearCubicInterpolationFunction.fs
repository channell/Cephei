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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Reference to behavior")>] 
         behavior : obj)
        ([<ExcelArgument(Name="da",Description = "Reference to da")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "Reference to monotonic")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftC",Description = "Reference to leftC")>] 
         leftC : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "Reference to leftConditionValue")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightC",Description = "Reference to rightC")>] 
         rightC : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "Reference to rightConditionValue")>] 
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
                let builder () = withMnemonic mnemonic (Fun.MixedLinearCubicInterpolation 
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

                let source = Helper.sourceFold "Fun.MixedLinearCubicInterpolation" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_derivative", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Derivative") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_empty", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Empty") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_primitive", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Primitive") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_secondDerivative", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".SecondDerivative") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_update", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Update
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Update") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_value1", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Value1") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_value", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Value") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_xMax", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".XMax") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_xMin", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".XMin") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_allowsExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_disableExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".DisableExtrapolation") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_enableExtrapolation", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".EnableExtrapolation") 
                                               [| _MixedLinearCubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_extrapolate", Description="Create a MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicInterpolation",Description = "Reference to MixedLinearCubicInterpolation")>] 
         mixedlinearcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicInterpolation = Helper.toCell<MixedLinearCubicInterpolation> mixedlinearcubicinterpolation "MixedLinearCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicInterpolation.cell :?> MixedLinearCubicInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicInterpolation.source + ".Extrapolate") 
                                               [| _MixedLinearCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicInterpolation.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicInterpolation_Range", Description="Create a range of MixedLinearCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearCubicInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearCubicInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearCubicInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearCubicInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearCubicInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
