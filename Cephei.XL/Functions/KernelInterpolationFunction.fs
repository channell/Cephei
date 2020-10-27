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
    [<ExcelFunction(Name="_KernelInterpolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "KernelInterpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="kernel",Description = "IKernelFunction")>] 
         kernel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _kernel = Helper.toCell<IKernelFunction> kernel "kernel" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.KernelInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _kernel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KernelInterpolation>) l

                let source () = Helper.sourceFold "Fun.KernelInterpolation" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KernelInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_KernelInterpolation_derivative", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_empty", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_primitive", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_secondDerivative", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_update", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_value1", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_value", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_xMax", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_xMin", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_allowsExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_disableExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_enableExtrapolation", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_extrapolate", Description="Create a KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation",Description = "KernelInterpolation")>] 
         kernelinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation = Helper.toCell<KernelInterpolation> kernelinterpolation "KernelInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((KernelInterpolationModel.Cast _KernelInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KernelInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation.cell
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
    [<ExcelFunction(Name="_KernelInterpolation_Range", Description="Create a range of KernelInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KernelInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KernelInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<KernelInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<KernelInterpolation>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
