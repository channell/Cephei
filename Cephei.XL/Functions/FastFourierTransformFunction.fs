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
FFT implementation
  </summary> *)
[<AutoSerializable(true)>]
module FastFourierTransformFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FastFourierTransform", Description="Create a FastFourierTransform",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FastFourierTransform_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="order",Description = "int")>] 
         order : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _order = Helper.toCell<int> order "order" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FastFourierTransform 
                                                            _order.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FastFourierTransform>) l

                let source () = Helper.sourceFold "Fun.FastFourierTransform" 
                                               [| _order.source
                                               |]
                let hash = Helper.hashFold 
                                [| _order.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FastFourierTransform> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        The output sequence must be allocated by the user.
    *)
    [<ExcelFunction(Name="_FastFourierTransform_inverse_transform", Description="Create a FastFourierTransform",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FastFourierTransform_inverse_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FastFourierTransform",Description = "FastFourierTransform")>] 
         fastfouriertransform : obj)
        ([<ExcelArgument(Name="input",Description = "System.Numerics.Complex range")>] 
         input : obj)
        ([<ExcelArgument(Name="inputBeg",Description = "int")>] 
         inputBeg : obj)
        ([<ExcelArgument(Name="inputEnd",Description = "int")>] 
         inputEnd : obj)
        ([<ExcelArgument(Name="output",Description = "System.Numerics.Complex range")>] 
         output : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FastFourierTransform = Helper.toCell<FastFourierTransform> fastfouriertransform "FastFourierTransform"  
                let _input = Helper.toCell<Generic.List<System.Numerics.Complex>> input "input" 
                let _inputBeg = Helper.toCell<int> inputBeg "inputBeg" 
                let _inputEnd = Helper.toCell<int> inputEnd "inputEnd" 
                let _output = Helper.toCell<Generic.List<System.Numerics.Complex>> output "output" 
                let builder (current : ICell) = withMnemonic mnemonic ((FastFourierTransformModel.Cast _FastFourierTransform.cell).Inverse_transform
                                                            _input.cell 
                                                            _inputBeg.cell 
                                                            _inputEnd.cell 
                                                            _output.cell 
                                                       ) :> ICell
                let format (o : FastFourierTransform) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FastFourierTransform.source + ".Inverse_transform") 

                                               [| _input.source
                                               ;  _inputBeg.source
                                               ;  _inputEnd.source
                                               ;  _output.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FastFourierTransform.cell
                                ;  _input.cell
                                ;  _inputBeg.cell
                                ;  _inputEnd.cell
                                ;  _output.cell
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
        The required size for the output vector
    *)
    [<ExcelFunction(Name="_FastFourierTransform_output_size", Description="Create a FastFourierTransform",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FastFourierTransform_output_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FastFourierTransform",Description = "FastFourierTransform")>] 
         fastfouriertransform : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FastFourierTransform = Helper.toCell<FastFourierTransform> fastfouriertransform "FastFourierTransform"  
                let builder (current : ICell) = withMnemonic mnemonic ((FastFourierTransformModel.Cast _FastFourierTransform.cell).Output_size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FastFourierTransform.source + ".Output_size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FastFourierTransform.cell
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
        The output sequence must be allocated by the user
    *)
    [<ExcelFunction(Name="_FastFourierTransform_transform", Description="Create a FastFourierTransform",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FastFourierTransform_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FastFourierTransform",Description = "FastFourierTransform")>] 
         fastfouriertransform : obj)
        ([<ExcelArgument(Name="input",Description = "System.Numerics.Complex range")>] 
         input : obj)
        ([<ExcelArgument(Name="inputBeg",Description = "int")>] 
         inputBeg : obj)
        ([<ExcelArgument(Name="inputEnd",Description = "int")>] 
         inputEnd : obj)
        ([<ExcelArgument(Name="output",Description = "System.Numerics.Complex range")>] 
         output : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FastFourierTransform = Helper.toCell<FastFourierTransform> fastfouriertransform "FastFourierTransform"  
                let _input = Helper.toCell<Generic.List<System.Numerics.Complex>> input "input" 
                let _inputBeg = Helper.toCell<int> inputBeg "inputBeg" 
                let _inputEnd = Helper.toCell<int> inputEnd "inputEnd" 
                let _output = Helper.toCell<Generic.List<System.Numerics.Complex>> output "output" 
                let builder (current : ICell) = withMnemonic mnemonic ((FastFourierTransformModel.Cast _FastFourierTransform.cell).Transform
                                                            _input.cell 
                                                            _inputBeg.cell 
                                                            _inputEnd.cell 
                                                            _output.cell 
                                                       ) :> ICell
                let format (o : FastFourierTransform) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FastFourierTransform.source + ".Transform") 

                                               [| _input.source
                                               ;  _inputBeg.source
                                               ;  _inputEnd.source
                                               ;  _output.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FastFourierTransform.cell
                                ;  _input.cell
                                ;  _inputBeg.cell
                                ;  _inputEnd.cell
                                ;  _output.cell
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
    [<ExcelFunction(Name="_FastFourierTransform_Range", Description="Create a range of FastFourierTransform",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FastFourierTransform_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FastFourierTransform> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FastFourierTransform> (c)) :> ICell
                let format (i : Generic.List<ICell<FastFourierTransform>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FastFourierTransform>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
