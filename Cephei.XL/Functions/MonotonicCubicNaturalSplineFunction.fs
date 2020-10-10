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
module MonotonicCubicNaturalSplineFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MonotonicCubicNaturalSpline 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonotonicCubicNaturalSpline>) l

                let source () = Helper.sourceFold "Fun.MonotonicCubicNaturalSpline" 
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
                    ; subscriber = Helper.subscriberModel<MonotonicCubicNaturalSpline> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_aCoefficients", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".ACoefficients") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_bCoefficients", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".BCoefficients") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_cCoefficients", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".CCoefficients") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_derivative", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Derivative") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_empty", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Empty") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_primitive", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Primitive") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_secondDerivative", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".SecondDerivative") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_update", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Update
                                                       ) :> ICell
                let format (o : MonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Update") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_value1", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Value1") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_value", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Value") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_xMax", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".XMax") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_xMin", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".XMin") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_allowsExtrapolation", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".AllowsExtrapolation") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_disableExtrapolation", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".DisableExtrapolation") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_enableExtrapolation", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicCubicNaturalSpline) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".EnableExtrapolation") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_extrapolate", Description="Create a MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicCubicNaturalSpline",Description = "Reference to MonotonicCubicNaturalSpline")>] 
         monotoniccubicnaturalspline : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicCubicNaturalSpline = Helper.toCell<MonotonicCubicNaturalSpline> monotoniccubicnaturalspline "MonotonicCubicNaturalSpline"  
                let builder (current : ICell) = withMnemonic mnemonic ((MonotonicCubicNaturalSplineModel.Cast _MonotonicCubicNaturalSpline.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MonotonicCubicNaturalSpline.source + ".Extrapolate") 
                                               [| _MonotonicCubicNaturalSpline.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicCubicNaturalSpline.cell
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
    [<ExcelFunction(Name="_MonotonicCubicNaturalSpline_Range", Description="Create a range of MonotonicCubicNaturalSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonotonicCubicNaturalSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MonotonicCubicNaturalSpline")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonotonicCubicNaturalSpline> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MonotonicCubicNaturalSpline>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MonotonicCubicNaturalSpline>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MonotonicCubicNaturalSpline>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
