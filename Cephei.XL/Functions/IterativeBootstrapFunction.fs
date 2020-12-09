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
  Universal piecewise-term-structure boostrapper.
  </summary> *)
[<AutoSerializable(true)>]
module IterativeBootstrapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IterativeBootstrap", Description="Create a IterativeBootstrap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IterativeBootstrap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.IterativeBootstrap 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IterativeBootstrap>) l

                let source () = Helper.sourceFold "Fun.IterativeBootstrap" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IterativeBootstrap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IterativeBootstrap_setup", Description="Create a IterativeBootstrap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IterativeBootstrap_setup
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IterativeBootstrap",Description = "IterativeBootstrap")>] 
         iterativebootstrap : obj)
        ([<ExcelArgument(Name="ts",Description = "'T")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IterativeBootstrap = Helper.toCell<IterativeBootstrap> iterativebootstrap "IterativeBootstrap"  
                let _ts = Helper.toCell<'T> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic ((IterativeBootstrapModel.Cast _IterativeBootstrap.cell).Setup
                                                            _ts.cell 
                                                       ) :> ICell
                let format (o : IterativeBootstrap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IterativeBootstrap.source + ".Setup") 

                                               [| _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IterativeBootstrap.cell
                                ;  _ts.cell
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
    [<ExcelFunction(Name="_IterativeBootstrap_Range", Description="Create a range of IterativeBootstrap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IterativeBootstrap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IterativeBootstrap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<IterativeBootstrap> (c)) :> ICell
                let format (i : Generic.List<ICell<IterativeBootstrap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<IterativeBootstrap>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
