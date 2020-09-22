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
  vanillaengines  the correctness of the returned values is tested by checking it against analytic results.  Greeks are not overly accurate. They could be improved by building a tree so that it has three points at the current time. The value would be fetched from the middle one, while the two side points would be used for estimating partial derivatives.
  </summary> *)
[<AutoSerializable(true)>]
module BinomialVanillaEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BinomialVanillaEngine", Description="Create a BinomialVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BinomialVanillaEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let builder () = withMnemonic mnemonic (Fun.BinomialVanillaEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BinomialVanillaEngine>) l

                let source = Helper.sourceFold "Fun.BinomialVanillaEngine" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
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
    [<ExcelFunction(Name="_BinomialVanillaEngine_calculate", Description="Create a BinomialVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BinomialVanillaEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialVanillaEngine",Description = "Reference to BinomialVanillaEngine")>] 
         binomialvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialVanillaEngine = Helper.toCell<BinomialVanillaEngine> binomialvanillaengine "BinomialVanillaEngine" true 
                let builder () = withMnemonic mnemonic ((_BinomialVanillaEngine.cell :?> BinomialVanillaEngineModel).Calculate
                                                       ) :> ICell
                let format (o : BinomialVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BinomialVanillaEngine.source + ".Calculate") 
                                               [| _BinomialVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialVanillaEngine.cell
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
    [<ExcelFunction(Name="_BinomialVanillaEngine_Range", Description="Create a range of BinomialVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BinomialVanillaEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BinomialVanillaEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BinomialVanillaEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BinomialVanillaEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BinomialVanillaEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BinomialVanillaEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
