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
module CubicSplineOvershootingMinimization2Function =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_create
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

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _size = Helper.toCell<int> size "size" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let builder () = withMnemonic mnemonic (Fun.CubicSplineOvershootingMinimization2 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CubicSplineOvershootingMinimization2>) l

                let source = Helper.sourceFold "Fun.CubicSplineOvershootingMinimization2" 
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_aCoefficients", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".ACoefficients") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_bCoefficients", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".BCoefficients") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_cCoefficients", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".CCoefficients") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_derivative", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Derivative") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_empty", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Empty") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_primitive", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Primitive") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_secondDerivative", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".SecondDerivative") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_update", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Update
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Update") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_value1", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Value1") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_value", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Value") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_xMax", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".XMax") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_xMin", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".XMin") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_allowsExtrapolation", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".AllowsExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_disableExtrapolation", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".DisableExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_enableExtrapolation", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CubicSplineOvershootingMinimization2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".EnableExtrapolation") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_extrapolate", Description="Create a CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CubicSplineOvershootingMinimization2",Description = "Reference to CubicSplineOvershootingMinimization2")>] 
         cubicsplineovershootingminimization2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CubicSplineOvershootingMinimization2 = Helper.toCell<CubicSplineOvershootingMinimization2> cubicsplineovershootingminimization2 "CubicSplineOvershootingMinimization2" true 
                let builder () = withMnemonic mnemonic ((_CubicSplineOvershootingMinimization2.cell :?> CubicSplineOvershootingMinimization2Model).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CubicSplineOvershootingMinimization2.source + ".Extrapolate") 
                                               [| _CubicSplineOvershootingMinimization2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CubicSplineOvershootingMinimization2.cell
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
    [<ExcelFunction(Name="_CubicSplineOvershootingMinimization2_Range", Description="Create a range of CubicSplineOvershootingMinimization2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CubicSplineOvershootingMinimization2_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CubicSplineOvershootingMinimization2")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CubicSplineOvershootingMinimization2> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CubicSplineOvershootingMinimization2>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CubicSplineOvershootingMinimization2>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CubicSplineOvershootingMinimization2>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
