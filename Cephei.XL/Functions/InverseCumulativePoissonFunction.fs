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
  the correctness of the returned value is tested by checking it against known good results.
  </summary> *)
[<AutoSerializable(true)>]
module InverseCumulativePoissonFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativePoisson1", Description="Create a InverseCumulativePoisson",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativePoisson_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lambda",Description = "double")>] 
         lambda : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lambda = Helper.toCell<double> lambda "lambda" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseCumulativePoisson1 
                                                            _lambda.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativePoisson>) l

                let source () = Helper.sourceFold "Fun.InverseCumulativePoisson1" 
                                               [| _lambda.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lambda.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseCumulativePoisson> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativePoisson", Description="Create a InverseCumulativePoisson",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativePoisson_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseCumulativePoisson () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativePoisson>) l

                let source () = Helper.sourceFold "Fun.InverseCumulativePoisson" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseCumulativePoisson> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativePoisson_value", Description="Create a InverseCumulativePoisson",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativePoisson_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativePoisson",Description = "InverseCumulativePoisson")>] 
         inversecumulativepoisson : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativePoisson = Helper.toCell<InverseCumulativePoisson> inversecumulativepoisson "InverseCumulativePoisson"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((InverseCumulativePoissonModel.Cast _InverseCumulativePoisson.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InverseCumulativePoisson.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativePoisson.cell
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
    [<ExcelFunction(Name="_InverseCumulativePoisson_Range", Description="Create a range of InverseCumulativePoisson",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativePoisson_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseCumulativePoisson> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InverseCumulativePoisson> (c)) :> ICell
                let format (i : Generic.List<ICell<InverseCumulativePoisson>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InverseCumulativePoisson>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
