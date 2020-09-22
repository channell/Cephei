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
  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature
  </summary> *)
[<AutoSerializable(true)>]
module MCEuropeanHestonEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MCEuropeanHestonEngine", Description="Create a MCEuropeanHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MCEuropeanHestonEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="timeStepsPerYear",Description = "Reference to timeStepsPerYear")>] 
         timeStepsPerYear : obj)
        ([<ExcelArgument(Name="antitheticVariate",Description = "Reference to antitheticVariate")>] 
         antitheticVariate : obj)
        ([<ExcelArgument(Name="requiredSamples",Description = "Reference to requiredSamples")>] 
         requiredSamples : obj)
        ([<ExcelArgument(Name="requiredTolerance",Description = "Reference to requiredTolerance")>] 
         requiredTolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "Reference to maxSamples")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<HestonProcess> Process "Process" true
                let _timeSteps = Helper.toNullable<Nullable<int>> timeSteps "timeSteps"
                let _timeStepsPerYear = Helper.toNullable<Nullable<int>> timeStepsPerYear "timeStepsPerYear"
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" true
                let _requiredSamples = Helper.toNullable<Nullable<int>> requiredSamples "requiredSamples"
                let _requiredTolerance = Helper.toNullable<Nullable<double>> requiredTolerance "requiredTolerance"
                let _maxSamples = Helper.toNullable<Nullable<int>> maxSamples "maxSamples"
                let _seed = Helper.toCell<uint64> seed "seed" true
                let builder () = withMnemonic mnemonic (Fun.MCEuropeanHestonEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _timeStepsPerYear.cell 
                                                            _antitheticVariate.cell 
                                                            _requiredSamples.cell 
                                                            _requiredTolerance.cell 
                                                            _maxSamples.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MCEuropeanHestonEngine>) l

                let source = Helper.sourceFold "Fun.MCEuropeanHestonEngine" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _timeStepsPerYear.source
                                               ;  _antitheticVariate.source
                                               ;  _requiredSamples.source
                                               ;  _requiredTolerance.source
                                               ;  _maxSamples.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _timeStepsPerYear.cell
                                ;  _antitheticVariate.cell
                                ;  _requiredSamples.cell
                                ;  _requiredTolerance.cell
                                ;  _maxSamples.cell
                                ;  _seed.cell
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
    [<ExcelFunction(Name="_MCEuropeanHestonEngine_Range", Description="Create a range of MCEuropeanHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MCEuropeanHestonEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MCEuropeanHestonEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MCEuropeanHestonEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MCEuropeanHestonEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MCEuropeanHestonEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MCEuropeanHestonEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
