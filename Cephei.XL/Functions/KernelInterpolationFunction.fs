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
  Implementation of the kernel interpolation approach, which can be found in "Foreign Exchange Risk" by Hakala, Wystup page 256.  The kernel in the implementation is kept general, although a Gaussian is considered in the cited text.
  </summary> *)
[<AutoSerializable(true)>]
module KernelInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted. \pre kernel needs a Real operator()(Real x) implementation
    *)
    [<ExcelFunction(Name="_KernelInterpolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="kernel",Description = "Reference to kernel")>] 
         kernel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _size = Helper.toCell<int> size "size" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let _kernel = Helper.toCell<IKernelFunction> kernel "kernel" true
                let builder () = withMnemonic mnemonic (Fun.KernelInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _kernel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KernelInterpolation>) l

                let source = Helper.sourceFold "Fun.KernelInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _kernel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _kernel.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_derivative", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Derivative") 
                                               [| _KernelInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_empty", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Empty") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_primitive", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Primitive") 
                                               [| _KernelInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_secondDerivative", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".SecondDerivative") 
                                               [| _KernelInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_update", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Update
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Update") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_value1", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Value1") 
                                               [| _KernelInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_value", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Value") 
                                               [| _KernelInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_xMax", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".XMax") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_xMin", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".XMin") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_allowsExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".AllowsExtrapolation") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_disableExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".DisableExtrapolation") 
                                               [| _KernelInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_enableExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".EnableExtrapolation") 
                                               [| _KernelInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_extrapolate", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "Reference to KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation" true 
                let builder () = withMnemonic mnemonic ((_KernelInterpolation.cell :?> KernelInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation.source + ".Extrapolate") 
                                               [| _KernelInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_Range", Description="Create a range of KernelInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KernelInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the KernelInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KernelInterpolation> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KernelInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<KernelInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<KernelInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
