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
module FdmAmericanStepConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmAmericanStepCondition_applyTo", Description="Create a FdmAmericanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAmericanStepCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAmericanStepCondition",Description = "FdmAmericanStepCondition")>] 
         fdmamericanstepcondition : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAmericanStepCondition = Helper.toCell<FdmAmericanStepCondition> fdmamericanstepcondition "FdmAmericanStepCondition"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmAmericanStepConditionModel.Cast _FdmAmericanStepCondition.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmAmericanStepCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmAmericanStepCondition.source + ".ApplyTo") 

                                               [| _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAmericanStepCondition.cell
                                ;  _o.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmAmericanStepCondition", Description="Create a FdmAmericanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAmericanStepCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="calculator",Description = "FdmInnerValueCalculator")>] 
         calculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _calculator = Helper.toCell<FdmInnerValueCalculator> calculator "calculator" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmAmericanStepCondition 
                                                            _mesher.cell 
                                                            _calculator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmAmericanStepCondition>) l

                let source () = Helper.sourceFold "Fun.FdmAmericanStepCondition" 
                                               [| _mesher.source
                                               ;  _calculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                ;  _calculator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAmericanStepCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmAmericanStepCondition_Range", Description="Create a range of FdmAmericanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAmericanStepCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmAmericanStepCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<FdmAmericanStepCondition> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<FdmAmericanStepCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmAmericanStepCondition>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
