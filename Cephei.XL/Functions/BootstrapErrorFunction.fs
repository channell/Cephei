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
(*!!
(* <summary>
  bootstrap error
  </summary> *)
[<AutoSerializable(true)>]
module BootstrapErrorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BootstrapError", Description="Create a BootstrapError",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BootstrapError_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="curve",Description = "Reference to curve")>] 
         curve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        ([<ExcelArgument(Name="segment",Description = "Reference to segment")>] 
         segment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _curve = Helper.toCell<'T> curve "curve" 
                let _helper = Helper.toCell<BootstrapHelper<'U>> helper "helper" 
                let _segment = Helper.toCell<int> segment "segment" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BootstrapError 
                                                            _curve.cell 
                                                            _helper.cell 
                                                            _segment.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BootstrapError>) l

                let source () = Helper.sourceFold "Fun.BootstrapError" 
                                               [| _curve.source
                                               ;  _helper.source
                                               ;  _segment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _curve.cell
                                ;  _helper.cell
                                ;  _segment.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BootstrapError> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BootstrapError_value", Description="Create a BootstrapError",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BootstrapError_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapError",Description = "Reference to BootstrapError")>] 
         bootstraperror : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapError = Helper.toCell<BootstrapError> bootstraperror "BootstrapError"  
                let _guess = Helper.toCell<double> guess "guess" 
                let builder (current : ICell) = withMnemonic mnemonic ((BootstrapErrorModel.Cast _BootstrapError.cell).Value
                                                            _guess.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BootstrapError.source + ".Value") 
                                               [| _BootstrapError.source
                                               ;  _guess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapError.cell
                                ;  _guess.cell
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
    [<ExcelFunction(Name="_BootstrapError_derivative", Description="Create a BootstrapError",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BootstrapError_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BootstrapError",Description = "Reference to BootstrapError")>] 
         bootstraperror : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BootstrapError = Helper.toCell<BootstrapError> bootstraperror "BootstrapError"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BootstrapErrorModel.Cast _BootstrapError.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BootstrapError.source + ".Derivative") 
                                               [| _BootstrapError.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BootstrapError.cell
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
    [<ExcelFunction(Name="_BootstrapError_Range", Description="Create a range of BootstrapError",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BootstrapError_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BootstrapError")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BootstrapError> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BootstrapError>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BootstrapError>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BootstrapError>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
