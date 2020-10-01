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
  Gaussian kernel function
  </summary> *)
[<AutoSerializable(true)>]
module GaussianKernelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussianKernel_derivative", Description="Create a GaussianKernel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussianKernel_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianKernel",Description = "Reference to GaussianKernel")>] 
         gaussiankernel : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianKernel = Helper.toCell<GaussianKernel> gaussiankernel "GaussianKernel"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussianKernel.cell :?> GaussianKernelModel).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussianKernel.source + ".Derivative") 
                                               [| _GaussianKernel.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussianKernel.cell
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
    [<ExcelFunction(Name="_GaussianKernel", Description="Create a GaussianKernel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussianKernel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="average",Description = "Reference to average")>] 
         average : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _average = Helper.toCell<double> average "average" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder () = withMnemonic mnemonic (Fun.GaussianKernel 
                                                            _average.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussianKernel>) l

                let source = Helper.sourceFold "Fun.GaussianKernel" 
                                               [| _average.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _average.cell
                                ;  _sigma.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussianKernel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussianKernel_primitive", Description="Create a GaussianKernel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussianKernel_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianKernel",Description = "Reference to GaussianKernel")>] 
         gaussiankernel : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianKernel = Helper.toCell<GaussianKernel> gaussiankernel "GaussianKernel"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussianKernel.cell :?> GaussianKernelModel).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussianKernel.source + ".Primitive") 
                                               [| _GaussianKernel.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussianKernel.cell
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
    [<ExcelFunction(Name="_GaussianKernel_value", Description="Create a GaussianKernel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussianKernel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianKernel",Description = "Reference to GaussianKernel")>] 
         gaussiankernel : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianKernel = Helper.toCell<GaussianKernel> gaussiankernel "GaussianKernel"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussianKernel.cell :?> GaussianKernelModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussianKernel.source + ".Value") 
                                               [| _GaussianKernel.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussianKernel.cell
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
    [<ExcelFunction(Name="_GaussianKernel_Range", Description="Create a range of GaussianKernel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussianKernel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussianKernel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussianKernel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussianKernel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussianKernel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussianKernel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
