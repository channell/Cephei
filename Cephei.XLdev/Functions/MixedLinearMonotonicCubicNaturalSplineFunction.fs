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
module MixedLinearMonotonicCubicNaturalSplineFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_create
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
                let builder () = withMnemonic mnemonic (Fun.MixedLinearMonotonicCubicNaturalSpline 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearMonotonicCubicNaturalSpline>) l

                let source = Helper.sourceFold "Fun.MixedLinearMonotonicCubicNaturalSpline" 
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_derivative", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Derivative") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_empty", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Empty") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_primitive", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Primitive") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_secondDerivative", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".SecondDerivative") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_update", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Update
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Update") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_value", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Value
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Value") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_value", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Value1
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Value1") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_xMax", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".XMax") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_xMin", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".XMin") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_allowsExtrapolation", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_disableExtrapolation", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".DisableExtrapolation") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_enableExtrapolation", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".EnableExtrapolation") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_extrapolate", Description="Create a MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicCubicNaturalSpline",Description = "Reference to MixedLinearMonotonicCubicNaturalSpline")>] 
         mixedlinearmonotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicCubicNaturalSpline = Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> mixedlinearmonotoniccubicnaturalspline "MixedLinearMonotonicCubicNaturalSpline" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearMonotonicCubicNaturalSpline.cell :?> MixedLinearMonotonicCubicNaturalSplineModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearMonotonicCubicNaturalSpline.source + ".Extrapolate") 
                                               [| _MixedLinearMonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicCubicNaturalSpline_Range", Description="Create a range of MixedLinearMonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearMonotonicCubicNaturalSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearMonotonicCubicNaturalSpline")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearMonotonicCubicNaturalSpline> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearMonotonicCubicNaturalSpline>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearMonotonicCubicNaturalSpline>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearMonotonicCubicNaturalSpline>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
