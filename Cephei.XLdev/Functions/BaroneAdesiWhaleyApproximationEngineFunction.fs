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
  vanillaengines  the correctness of the returned value is tested by reproducing results available in literature.
  </summary> *)
[<AutoSerializable(true)>]
module BaroneAdesiWhaleyApproximationEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BaroneAdesiWhaleyApproximationEngine", Description="Create a BaroneAdesiWhaleyApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BaroneAdesiWhaleyApproximationEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic (Fun.BaroneAdesiWhaleyApproximationEngine 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BaroneAdesiWhaleyApproximationEngine>) l

                let source = Helper.sourceFold "Fun.BaroneAdesiWhaleyApproximationEngine" 
                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BaroneAdesiWhaleyApproximationEngine_calculate", Description="Create a BaroneAdesiWhaleyApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BaroneAdesiWhaleyApproximationEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BaroneAdesiWhaleyApproximationEngine",Description = "Reference to BaroneAdesiWhaleyApproximationEngine")>] 
         baroneadesiwhaleyapproximationengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BaroneAdesiWhaleyApproximationEngine = Helper.toCell<BaroneAdesiWhaleyApproximationEngine> baroneadesiwhaleyapproximationengine "BaroneAdesiWhaleyApproximationEngine" true 
                let builder () = withMnemonic mnemonic ((_BaroneAdesiWhaleyApproximationEngine.cell :?> BaroneAdesiWhaleyApproximationEngineModel).Calculate
                                                       ) :> ICell
                let format (o : BaroneAdesiWhaleyApproximationEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BaroneAdesiWhaleyApproximationEngine.source + ".Calculate") 
                                               [| _BaroneAdesiWhaleyApproximationEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BaroneAdesiWhaleyApproximationEngine.cell
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
    [<ExcelFunction(Name="_BaroneAdesiWhaleyApproximationEngine_Range", Description="Create a range of BaroneAdesiWhaleyApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BaroneAdesiWhaleyApproximationEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BaroneAdesiWhaleyApproximationEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BaroneAdesiWhaleyApproximationEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BaroneAdesiWhaleyApproximationEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BaroneAdesiWhaleyApproximationEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BaroneAdesiWhaleyApproximationEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
