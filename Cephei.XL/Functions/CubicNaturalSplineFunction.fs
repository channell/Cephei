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
module CubicNaturalSplineFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_CubicNaturalSpline", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = (Fun.CubicNaturalSpline 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CubicNaturalSpline>) l

                let source () = Helper.sourceFold "Fun.CubicNaturalSpline" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CubicNaturalSpline> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CubicNaturalSpline_aCoefficients", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".ACoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_bCoefficients", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".BCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_cCoefficients", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".CCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_derivative", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_empty", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_primitive", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_secondDerivative", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_update", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Update
                                                       ) :> ICell
                let format (o : CubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_value1", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_value", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_xMax", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_xMin", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_allowsExtrapolation", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_disableExtrapolation", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_enableExtrapolation", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_extrapolate", Description="Create a CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicNaturalSpline",Description = "CubicNaturalSpline")>] 
         cubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicNaturalSpline = Helper.toCell<CubicNaturalSpline> cubicnaturalspline "CubicNaturalSpline"  
                let builder (current : ICell) = ((CubicNaturalSplineModel.Cast _CubicNaturalSpline.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CubicNaturalSpline.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_CubicNaturalSpline_Range", Description="Create a range of CubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CubicNaturalSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CubicNaturalSpline> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CubicNaturalSpline> (c)) :> ICell
                let format (i : Cephei.Cell.List<CubicNaturalSpline>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CubicNaturalSpline>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
