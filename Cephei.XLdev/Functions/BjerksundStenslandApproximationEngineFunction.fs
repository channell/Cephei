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
module BjerksundStenslandApproximationEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BjerksundStenslandApproximationEngine", Description="Create a BjerksundStenslandApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BjerksundStenslandApproximationEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic (Fun.BjerksundStenslandApproximationEngine 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BjerksundStenslandApproximationEngine>) l

                let source = Helper.sourceFold "Fun.BjerksundStenslandApproximationEngine" 
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
    [<ExcelFunction(Name="_BjerksundStenslandApproximationEngine_calculate", Description="Create a BjerksundStenslandApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BjerksundStenslandApproximationEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BjerksundStenslandApproximationEngine",Description = "Reference to BjerksundStenslandApproximationEngine")>] 
         bjerksundstenslandapproximationengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BjerksundStenslandApproximationEngine = Helper.toCell<BjerksundStenslandApproximationEngine> bjerksundstenslandapproximationengine "BjerksundStenslandApproximationEngine" true 
                let builder () = withMnemonic mnemonic ((_BjerksundStenslandApproximationEngine.cell :?> BjerksundStenslandApproximationEngineModel).Calculate
                                                       ) :> ICell
                let format (o : BjerksundStenslandApproximationEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BjerksundStenslandApproximationEngine.source + ".Calculate") 
                                               [| _BjerksundStenslandApproximationEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BjerksundStenslandApproximationEngine.cell
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
    [<ExcelFunction(Name="_BjerksundStenslandApproximationEngine_Range", Description="Create a range of BjerksundStenslandApproximationEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BjerksundStenslandApproximationEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BjerksundStenslandApproximationEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BjerksundStenslandApproximationEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BjerksundStenslandApproximationEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BjerksundStenslandApproximationEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BjerksundStenslandApproximationEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
