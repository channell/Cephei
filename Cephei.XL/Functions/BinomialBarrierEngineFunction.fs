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
  barrierengines  Timesteps for Cox-Ross-Rubinstein trees are adjusted using Boyle and Lau algorithm. See Journal of Derivatives, 1/1994, "Bumping up against the barrier with the binomial method"  the correctness of the returned values is tested by checking it against analytic european results.
  </summary> *)
[<AutoSerializable(true)>]
module BinomialBarrierEngineFunction =

    (*
        ! \param maxTimeSteps is used to limit timeSteps when using Boyle-Lau optimization. If zero (the default) the maximum number of steps is calculated by an heuristic: anything when < 1000, otherwise no more than 5*timeSteps. If maxTimeSteps is equal to timeSteps Boyle-Lau is disabled. Likewise if the lattice is not CoxRossRubinstein Boyle-Lau is disabled and maxTimeSteps ignored.
    *)
    [<ExcelFunction(Name="_BinomialBarrierEngine", Description="Create a BinomialBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="getTree",Description = "Reference to getTree")>] 
         getTree : obj)
        ([<ExcelArgument(Name="getAsset",Description = "Reference to getAsset")>] 
         getAsset : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="maxTimeSteps",Description = "Reference to maxTimeSteps")>] 
         maxTimeSteps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _getTree = Helper.toCell<BinomialBarrierEngine.GetTree> getTree "getTree" 
                let _getAsset = Helper.toCell<BinomialBarrierEngine.GetAsset> getAsset "getAsset" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _maxTimeSteps = Helper.toDefault<int> maxTimeSteps "maxTimeSteps" 0
                let builder () = withMnemonic mnemonic (Fun.BinomialBarrierEngine 
                                                            _getTree.cell 
                                                            _getAsset.cell 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _maxTimeSteps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BinomialBarrierEngine>) l

                let source = Helper.sourceFold "Fun.BinomialBarrierEngine" 
                                               [| _getTree.source
                                               ;  _getAsset.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _maxTimeSteps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _getTree.cell
                                ;  _getAsset.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _maxTimeSteps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BinomialBarrierEngine_getAsset", Description="Create a BinomialBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialBarrierEngine_getAsset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialBarrierEngine",Description = "Reference to BinomialBarrierEngine")>] 
         binomialbarrierengine : obj)
        ([<ExcelArgument(Name="args",Description = "Reference to args")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialBarrierEngine = Helper.toCell<BinomialBarrierEngine> binomialbarrierengine "BinomialBarrierEngine"  
                let _args = Helper.toCell<BarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder () = withMnemonic mnemonic ((BinomialBarrierEngineModel.Cast _BinomialBarrierEngine.cell).getAsset
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedAsset>) l

                let source = Helper.sourceFold (_BinomialBarrierEngine.source + ".getAsset") 
                                               [| _BinomialBarrierEngine.source
                                               ;  _args.source
                                               ;  _Process.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialBarrierEngine.cell
                                ;  _args.cell
                                ;  _Process.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BinomialBarrierEngine_GetTree", Description="Create a BinomialBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialBarrierEngine_GetTree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialBarrierEngine",Description = "Reference to BinomialBarrierEngine")>] 
         binomialbarrierengine : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialBarrierEngine = Helper.toCell<BinomialBarrierEngine> binomialbarrierengine "BinomialBarrierEngine"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BinomialBarrierEngineModel.Cast _BinomialBarrierEngine.cell).getTree
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITree>) l

                let source = Helper.sourceFold (_BinomialBarrierEngine.source + ".getTree") 
                                               [| _BinomialBarrierEngine.source
                                               ;  _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialBarrierEngine.cell
                                ;  _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    [<ExcelFunction(Name="_BinomialBarrierEngine_Range", Description="Create a range of BinomialBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BinomialBarrierEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BinomialBarrierEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BinomialBarrierEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BinomialBarrierEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BinomialBarrierEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
