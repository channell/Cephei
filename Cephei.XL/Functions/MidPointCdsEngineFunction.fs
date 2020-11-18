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
module MidPointCdsEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_MidPointCdsEngine", Description="Create a MidPointCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MidPointCdsEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="probability",Description = "DefaultProbabilityTermStructure")>] 
         probability : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "double")>] 
         recoveryRate : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="includeSettlementDateFlows",Description = "bool")>] 
         includeSettlementDateFlows : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _probability = Helper.toHandle<DefaultProbabilityTermStructure> probability "probability" 
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _includeSettlementDateFlows = Helper.toNullable<bool> includeSettlementDateFlows "includeSettlementDateFlows"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MidPointCdsEngine 
                                                            _probability.cell 
                                                            _recoveryRate.cell 
                                                            _discountCurve.cell 
                                                            _includeSettlementDateFlows.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MidPointCdsEngine>) l

                let source () = Helper.sourceFold "Fun.MidPointCdsEngine" 
                                               [| _probability.source
                                               ;  _recoveryRate.source
                                               ;  _discountCurve.source
                                               ;  _includeSettlementDateFlows.source
                                               |]
                let hash = Helper.hashFold 
                                [| _probability.cell
                                ;  _recoveryRate.cell
                                ;  _discountCurve.cell
                                ;  _includeSettlementDateFlows.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MidPointCdsEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MidPointCdsEngine_Range", Description="Create a range of MidPointCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MidPointCdsEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MidPointCdsEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<MidPointCdsEngine> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<MidPointCdsEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MidPointCdsEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
