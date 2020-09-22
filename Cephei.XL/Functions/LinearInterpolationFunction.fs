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
  %Linear interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module LinearInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_LinearInterpolation", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_create
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
                let builder () = withMnemonic mnemonic (Fun.LinearInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LinearInterpolation>) l

                let source = Helper.sourceFold "Fun.LinearInterpolation" 
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
    [<ExcelFunction(Name="_LinearInterpolation_derivative", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Derivative") 
                                               [| _LinearInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_empty", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Empty") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_primitive", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Primitive") 
                                               [| _LinearInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_secondDerivative", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".SecondDerivative") 
                                               [| _LinearInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_update", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Update
                                                       ) :> ICell
                let format (o : LinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Update") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_value1", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Value1") 
                                               [| _LinearInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_value", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Value") 
                                               [| _LinearInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_xMax", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".XMax") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_xMin", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".XMin") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_allowsExtrapolation", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".AllowsExtrapolation") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_disableExtrapolation", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".DisableExtrapolation") 
                                               [| _LinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_enableExtrapolation", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".EnableExtrapolation") 
                                               [| _LinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_extrapolate", Description="Create a LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearInterpolation",Description = "Reference to LinearInterpolation")>] 
         linearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearInterpolation = Helper.toCell<LinearInterpolation> linearinterpolation "LinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_LinearInterpolation.cell :?> LinearInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LinearInterpolation.source + ".Extrapolate") 
                                               [| _LinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearInterpolation.cell
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
    [<ExcelFunction(Name="_LinearInterpolation_Range", Description="Create a range of LinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LinearInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LinearInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LinearInterpolation> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LinearInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LinearInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LinearInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
