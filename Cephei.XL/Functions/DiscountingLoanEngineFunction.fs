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
module DiscountingLoanEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_DiscountingLoanEngine_discountCurve", Description="Create a DiscountingLoanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscountingLoanEngine_discountCurve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscountingLoanEngine",Description = "DiscountingLoanEngine")>] 
         discountingloanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscountingLoanEngine = Helper.toCell<DiscountingLoanEngine> discountingloanengine "DiscountingLoanEngine"  
                let builder (current : ICell) = ((DiscountingLoanEngineModel.Cast _DiscountingLoanEngine.cell).DiscountCurve
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_DiscountingLoanEngine.source + ".DiscountCurve") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscountingLoanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscountingLoanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscountingLoanEngine", Description="Create a DiscountingLoanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscountingLoanEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="includeSettlementDateFlows",Description = "bool")>] 
         includeSettlementDateFlows : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _includeSettlementDateFlows = Helper.toNullable<bool> includeSettlementDateFlows "includeSettlementDateFlows"
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.DiscountingLoanEngine 
                                                            _discountCurve.cell 
                                                            _includeSettlementDateFlows.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscountingLoanEngine>) l

                let source () = Helper.sourceFold "Fun.DiscountingLoanEngine" 
                                               [| _discountCurve.source
                                               ;  _includeSettlementDateFlows.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _includeSettlementDateFlows.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscountingLoanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscountingLoanEngine_Range", Description="Create a range of DiscountingLoanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscountingLoanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscountingLoanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscountingLoanEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscountingLoanEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscountingLoanEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
