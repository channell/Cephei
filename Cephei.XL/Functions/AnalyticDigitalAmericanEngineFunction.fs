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
module AnalyticDigitalAmericanEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticDigitalAmericanEngine", Description="Create a AnalyticDigitalAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticDigitalAmericanEngine 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticDigitalAmericanEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticDigitalAmericanEngine" 
                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticDigitalAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticDigitalAmericanEngine_knock_in", Description="Create a AnalyticDigitalAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanEngine_knock_in
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticDigitalAmericanEngine",Description = "AnalyticDigitalAmericanEngine")>] 
         analyticdigitalamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticDigitalAmericanEngine = Helper.toCell<AnalyticDigitalAmericanEngine> analyticdigitalamericanengine "AnalyticDigitalAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticDigitalAmericanEngineModel.Cast _AnalyticDigitalAmericanEngine.cell).Knock_in
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticDigitalAmericanEngine.source + ".Knock_in") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticDigitalAmericanEngine.cell
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
    [<ExcelFunction(Name="_AnalyticDigitalAmericanEngine_Range", Description="Create a range of AnalyticDigitalAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDigitalAmericanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticDigitalAmericanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticDigitalAmericanEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticDigitalAmericanEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AnalyticDigitalAmericanEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
