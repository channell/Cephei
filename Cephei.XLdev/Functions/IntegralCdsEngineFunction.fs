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
module IntegralCdsEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IntegralCdsEngine_calculate", Description="Create a IntegralCdsEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IntegralCdsEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IntegralCdsEngine",Description = "Reference to IntegralCdsEngine")>] 
         integralcdsengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IntegralCdsEngine = Helper.toCell<IntegralCdsEngine> integralcdsengine "IntegralCdsEngine" true 
                let builder () = withMnemonic mnemonic ((_IntegralCdsEngine.cell :?> IntegralCdsEngineModel).Calculate
                                                       ) :> ICell
                let format (o : IntegralCdsEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IntegralCdsEngine.source + ".Calculate") 
                                               [| _IntegralCdsEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IntegralCdsEngine.cell
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
    [<ExcelFunction(Name="_IntegralCdsEngine", Description="Create a IntegralCdsEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IntegralCdsEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="step",Description = "Reference to step")>] 
         step : obj)
        ([<ExcelArgument(Name="probability",Description = "Reference to probability")>] 
         probability : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "Reference to recoveryRate")>] 
         recoveryRate : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="includeSettlementDateFlows",Description = "Reference to includeSettlementDateFlows")>] 
         includeSettlementDateFlows : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _step = Helper.toCell<Period> step "step" true
                let _probability = Helper.toHandle<Handle<DefaultProbabilityTermStructure>> probability "probability" 
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" true
                let _discountCurve = Helper.toHandle<Handle<YieldTermStructure>> discountCurve "discountCurve" 
                let _includeSettlementDateFlows = Helper.toNullable<Nullable<bool>> includeSettlementDateFlows "includeSettlementDateFlows"
                let builder () = withMnemonic mnemonic (Fun.IntegralCdsEngine 
                                                            _step.cell 
                                                            _probability.cell 
                                                            _recoveryRate.cell 
                                                            _discountCurve.cell 
                                                            _includeSettlementDateFlows.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IntegralCdsEngine>) l

                let source = Helper.sourceFold "Fun.IntegralCdsEngine" 
                                               [| _step.source
                                               ;  _probability.source
                                               ;  _recoveryRate.source
                                               ;  _discountCurve.source
                                               ;  _includeSettlementDateFlows.source
                                               |]
                let hash = Helper.hashFold 
                                [| _step.cell
                                ;  _probability.cell
                                ;  _recoveryRate.cell
                                ;  _discountCurve.cell
                                ;  _includeSettlementDateFlows.cell
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
    [<ExcelFunction(Name="_IntegralCdsEngine_Range", Description="Create a range of IntegralCdsEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IntegralCdsEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IntegralCdsEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IntegralCdsEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IntegralCdsEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IntegralCdsEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IntegralCdsEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
