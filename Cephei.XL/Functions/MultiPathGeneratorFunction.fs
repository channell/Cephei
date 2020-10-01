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
(*!! generic 
(* <summary>
  RSG is a sample generator which returns a random sequence.  the generated paths are checked against cached results
  </summary> *)
[<AutoSerializable(true)>]
module MultiPathGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MultiPathGenerator_antithetic", Description="Create a MultiPathGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPathGenerator_antithetic
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPathGenerator",Description = "Reference to MultiPathGenerator")>] 
         multipathgenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPathGenerator = Helper.toCell<MultiPathGenerator> multipathgenerator "MultiPathGenerator"  
                let builder () = withMnemonic mnemonic ((_MultiPathGenerator.cell :?> MultiPathGeneratorModel).Antithetic
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sample<IPath>>) l

                let source = Helper.sourceFold (_MultiPathGenerator.source + ".Antithetic") 
                                               [| _MultiPathGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPathGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiPathGenerator", Description="Create a MultiPathGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPathGenerator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="generator",Description = "Reference to generator")>] 
         generator : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "Reference to brownianBridge")>] 
         brownianBridge : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _times = Helper.toCell<TimeGrid> times "times" 
                let _generator = Helper.toCell<'GSG> generator "generator" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let builder () = withMnemonic mnemonic (Fun.MultiPathGenerator 
                                                            _Process.cell 
                                                            _times.cell 
                                                            _generator.cell 
                                                            _brownianBridge.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPathGenerator>) l

                let source = Helper.sourceFold "Fun.MultiPathGenerator" 
                                               [| _Process.source
                                               ;  _times.source
                                               ;  _generator.source
                                               ;  _brownianBridge.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _times.cell
                                ;  _generator.cell
                                ;  _brownianBridge.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiPathGenerator_next", Description="Create a MultiPathGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPathGenerator_next
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPathGenerator",Description = "Reference to MultiPathGenerator")>] 
         multipathgenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPathGenerator = Helper.toCell<MultiPathGenerator> multipathgenerator "MultiPathGenerator"  
                let builder () = withMnemonic mnemonic ((_MultiPathGenerator.cell :?> MultiPathGeneratorModel).Next
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sample<IPath>>) l

                let source = Helper.sourceFold (_MultiPathGenerator.source + ".Next") 
                                               [| _MultiPathGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPathGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MultiPathGenerator_Range", Description="Create a range of MultiPathGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPathGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MultiPathGenerator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiPathGenerator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MultiPathGenerator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MultiPathGenerator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MultiPathGenerator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
