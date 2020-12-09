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
  vanillaengines  add more greeks (as of now only delta and rho available)  - the correctness of the returned value in case of cash-or-nothing at-hit digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing at-hit digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of cash-or-nothing at-expiry digital payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing at-expiry digital payoff is tested by reproducing results available in literature. - the correctness of the returned greeks in case of cash-or-nothing at-hit digital payoff is tested by reproducing numerical derivatives.
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticDigitalAmericanKOEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticDigitalAmericanKOEngine", Description="Create a AnalyticDigitalAmericanKOEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanKOEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="engine",Description = "GeneralizedBlackScholesProcess")>] 
         engine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _engine = Helper.toCell<GeneralizedBlackScholesProcess> engine "engine" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticDigitalAmericanKOEngine 
                                                            _engine.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticDigitalAmericanKOEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticDigitalAmericanKOEngine" 
                                               [| _engine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _engine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticDigitalAmericanKOEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticDigitalAmericanKOEngine_knock_in", Description="Create a AnalyticDigitalAmericanKOEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanKOEngine_knock_in
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticDigitalAmericanKOEngine",Description = "AnalyticDigitalAmericanKOEngine")>] 
         analyticdigitalamericankoengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticDigitalAmericanKOEngine = Helper.toCell<AnalyticDigitalAmericanKOEngine> analyticdigitalamericankoengine "AnalyticDigitalAmericanKOEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticDigitalAmericanKOEngineModel.Cast _AnalyticDigitalAmericanKOEngine.cell).Knock_in
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticDigitalAmericanKOEngine.source + ".Knock_in") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticDigitalAmericanKOEngine.cell
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

    [<ExcelFunction(Name="_AnalyticDigitalAmericanKOEngine_Range", Description="Create a range of AnalyticDigitalAmericanKOEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanKOEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticDigitalAmericanKOEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AnalyticDigitalAmericanKOEngine> (c)) :> ICell
                let format (i : Generic.List<ICell<AnalyticDigitalAmericanKOEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AnalyticDigitalAmericanKOEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
