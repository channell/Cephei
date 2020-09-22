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
convenience classes
  </summary> *)
[<AutoSerializable(true)>]
module MixedLinearCubicNaturalSplineFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_create
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
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _xEnd = Helper.toCell<int> xEnd "xEnd" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let _n = Helper.toCell<int> n "n" true
                let _behavior = Helper.toCell<Behavior> behavior "behavior" true
                let builder () = withMnemonic mnemonic (Fun.MixedLinearCubicNaturalSpline 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearCubicNaturalSpline>) l

                let source = Helper.sourceFold "Fun.MixedLinearCubicNaturalSpline" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _n.source
                                               ;  _behavior.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _n.cell
                                ;  _behavior.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_derivative", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Derivative") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_empty", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Empty") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_primitive", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Primitive") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_secondDerivative", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".SecondDerivative") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_update", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Update
                                                       ) :> ICell
                let format (o : MixedLinearCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Update") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_value", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Value
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Value") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_value", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Value1
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Value1") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_xMax", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".XMax") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_xMin", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".XMin") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_allowsExtrapolation", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_disableExtrapolation", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".DisableExtrapolation") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_enableExtrapolation", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".EnableExtrapolation") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_extrapolate", Description="Create a MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubicNaturalSpline",Description = "Reference to MixedLinearCubicNaturalSpline")>] 
         mixedlinearcubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubicNaturalSpline = Helper.toCell<MixedLinearCubicNaturalSpline> mixedlinearcubicnaturalspline "MixedLinearCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearCubicNaturalSpline.cell :?> MixedLinearCubicNaturalSplineModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubicNaturalSpline.source + ".Extrapolate") 
                                               [| _MixedLinearCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearCubicNaturalSpline_Range", Description="Create a range of MixedLinearCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearCubicNaturalSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearCubicNaturalSpline")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearCubicNaturalSpline> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearCubicNaturalSpline>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearCubicNaturalSpline>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearCubicNaturalSpline>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
