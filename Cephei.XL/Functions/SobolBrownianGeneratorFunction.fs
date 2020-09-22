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
  Incremental Brownian generator using a Sobol generator, inverse-cumulative Gaussian method, and Brownian bridging.
  </summary> *)
[<AutoSerializable(true)>]
module SobolBrownianGeneratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator_nextPath", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_nextPath
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).NextPath
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".NextPath") 
                                               [| _SobolBrownianGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_nextStep", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_nextStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        ([<ExcelArgument(Name="output",Description = "Reference to output")>] 
         output : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let _output = Helper.toCell<Generic.List<double>> output "output" true
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).NextStep
                                                            _output.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".NextStep") 
                                               [| _SobolBrownianGenerator.source
                                               ;  _output.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
                                ;  _output.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_numberOfFactors", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_numberOfFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).NumberOfFactors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".NumberOfFactors") 
                                               [| _SobolBrownianGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_numberOfSteps", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_numberOfSteps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).NumberOfSteps
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".NumberOfSteps") 
                                               [| _SobolBrownianGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
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
        test interface
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator_orderedIndices", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_orderedIndices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).OrderedIndices
                                                       ) :> ICell
                let format (i : Generic.List<Generic.List<int>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".OrderedIndices") 
                                               [| _SobolBrownianGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianGenerator", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="ordering",Description = "Reference to ordering")>] 
         ordering : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        ([<ExcelArgument(Name="directionIntegers",Description = "Reference to directionIntegers")>] 
         directionIntegers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _factors = Helper.toCell<int> factors "factors" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _ordering = Helper.toCell<SobolBrownianGenerator.Ordering> ordering "ordering" true
                let _seed = Helper.toCell<uint64> seed "seed" true
                let _directionIntegers = Helper.toCell<SobolRsg.DirectionIntegers> directionIntegers "directionIntegers" true
                let builder () = withMnemonic mnemonic (Fun.SobolBrownianGenerator 
                                                            _factors.cell 
                                                            _steps.cell 
                                                            _ordering.cell 
                                                            _seed.cell 
                                                            _directionIntegers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolBrownianGenerator>) l

                let source = Helper.sourceFold "Fun.SobolBrownianGenerator" 
                                               [| _factors.source
                                               ;  _steps.source
                                               ;  _ordering.source
                                               ;  _seed.source
                                               ;  _directionIntegers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _factors.cell
                                ;  _steps.cell
                                ;  _ordering.cell
                                ;  _seed.cell
                                ;  _directionIntegers.cell
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
    [<ExcelFunction(Name="_SobolBrownianGenerator_transform", Description="Create a SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianGenerator",Description = "Reference to SobolBrownianGenerator")>] 
         sobolbrowniangenerator : obj)
        ([<ExcelArgument(Name="variates",Description = "Reference to variates")>] 
         variates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianGenerator = Helper.toCell<SobolBrownianGenerator> sobolbrowniangenerator "SobolBrownianGenerator" true 
                let _variates = Helper.toCell<Generic.List<Generic.List<double>>> variates "variates" true
                let builder () = withMnemonic mnemonic ((_SobolBrownianGenerator.cell :?> SobolBrownianGeneratorModel).Transform
                                                            _variates.cell 
                                                       ) :> ICell
                let format (i : Generic.List<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SobolBrownianGenerator.source + ".Transform") 
                                               [| _SobolBrownianGenerator.source
                                               ;  _variates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianGenerator.cell
                                ;  _variates.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SobolBrownianGenerator_Range", Description="Create a range of SobolBrownianGenerator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SobolBrownianGenerator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SobolBrownianGenerator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SobolBrownianGenerator> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SobolBrownianGenerator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SobolBrownianGenerator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SobolBrownianGenerator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
