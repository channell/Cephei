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
  Generates random paths with drift(S,t) and variance(S,t) using a gaussian sequence generator  mcarlo  the generated paths are checked against cached results
  </summary> *)
[<AutoSerializable(true)>]
module PathGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PathGenerator_antithetic", Description="Create a PathGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PathGenerator_antithetic
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PathGenerator",Description = "PathGenerator")>] 
         pathgenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PathGenerator = Helper.toCell<PathGenerator> pathgenerator "PathGenerator"  
                let builder (current : ICell) = withMnemonic mnemonic ((PathGeneratorModel.Cast _PathGenerator.cell).Antithetic
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sample<IPath>>) l

                let source () = Helper.sourceFold (_PathGenerator.source + ".Antithetic") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PathGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PathGenerator_next", Description="Create a PathGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PathGenerator_next
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PathGenerator",Description = "PathGenerator")>] 
         pathgenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PathGenerator = Helper.toCell<PathGenerator> pathgenerator "PathGenerator"  
                let builder (current : ICell) = withMnemonic mnemonic ((PathGeneratorModel.Cast _PathGenerator.cell).Next
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sample<IPath>>) l

                let source () = Helper.sourceFold (_PathGenerator.source + ".Next") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PathGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructors
    *)
    [<ExcelFunction(Name="_PathGenerator", Description="Create a PathGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PathGenerator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="length",Description = "double")>] 
         length : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="generator",Description = "'GSG")>] 
         generator : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "bool")>] 
         brownianBridge : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _length = Helper.toCell<double> length "length" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _generator = Helper.toCell<'GSG> generator "generator" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PathGenerator 
                                                            _Process.cell 
                                                            _length.cell 
                                                            _timeSteps.cell 
                                                            _generator.cell 
                                                            _brownianBridge.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PathGenerator>) l

                let source () = Helper.sourceFold "Fun.PathGenerator" 
                                               [| _Process.source
                                               ;  _length.source
                                               ;  _timeSteps.source
                                               ;  _generator.source
                                               ;  _brownianBridge.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _length.cell
                                ;  _timeSteps.cell
                                ;  _generator.cell
                                ;  _brownianBridge.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PathGenerator1", Description="Create a PathGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PathGenerator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="generator",Description = "'GSG")>] 
         generator : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "bool")>] 
         brownianBridge : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _generator = Helper.toCell<'GSG> generator "generator" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PathGenerator1 
                                                            _Process.cell 
                                                            _timeGrid.cell 
                                                            _generator.cell 
                                                            _brownianBridge.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PathGenerator>) l

                let source () = Helper.sourceFold "Fun.PathGenerator1" 
                                               [| _Process.source
                                               ;  _timeGrid.source
                                               ;  _generator.source
                                               ;  _brownianBridge.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeGrid.cell
                                ;  _generator.cell
                                ;  _brownianBridge.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PathGenerator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PathGenerator_Range", Description="Create a range of PathGenerator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PathGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PathGenerator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<PathGenerator> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<PathGenerator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PathGenerator>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
