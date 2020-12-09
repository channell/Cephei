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
(*!! generic)
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module SimulatedAnnealingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimulatedAnnealing_minimize", Description="Create a SimulatedAnnealing",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimulatedAnnealing_minimize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimulatedAnnealing",Description = "SimulatedAnnealing")>] 
         simulatedannealing : obj)
        ([<ExcelArgument(Name="P",Description = "Problem")>] 
         P : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimulatedAnnealing = Helper.toCell<SimulatedAnnealing> simulatedannealing "SimulatedAnnealing"  
                let _P = Helper.toCell<Problem> P "P" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let builder (current : ICell) = withMnemonic mnemonic ((SimulatedAnnealingModel.Cast _SimulatedAnnealing.cell).Minimize
                                                            _P.cell 
                                                            _endCriteria.cell 
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimulatedAnnealing.source + ".Minimize") 

                                               [| _P.source
                                               ;  _endCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimulatedAnnealing.cell
                                ;  _P.cell
                                ;  _endCriteria.cell
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
    [<ExcelFunction(Name="_SimulatedAnnealing", Description="Create a SimulatedAnnealing",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimulatedAnnealing_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lambda",Description = "double")>] 
         lambda : obj)
        ([<ExcelArgument(Name="T0",Description = "double")>] 
         T0 : obj)
        ([<ExcelArgument(Name="K",Description = "int")>] 
         K : obj)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="rng",Description = "'RNG or empty")>] 
         rng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lambda = Helper.toCell<double> lambda "lambda" 
                let _T0 = Helper.toCell<double> T0 "T0" 
                let _K = Helper.toCell<int> K "K" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _rng = Helper.toDefault<'RNG> rng "rng" default(RNG)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SimulatedAnnealing 
                                                            _lambda.cell 
                                                            _T0.cell 
                                                            _K.cell 
                                                            _alpha.cell 
                                                            _rng.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimulatedAnnealing>) l

                let source () = Helper.sourceFold "Fun.SimulatedAnnealing" 
                                               [| _lambda.source
                                               ;  _T0.source
                                               ;  _K.source
                                               ;  _alpha.source
                                               ;  _rng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lambda.cell
                                ;  _T0.cell
                                ;  _K.cell
                                ;  _alpha.cell
                                ;  _rng.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimulatedAnnealing> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimulatedAnnealing1", Description="Create a SimulatedAnnealing",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimulatedAnnealing_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lambda",Description = "double")>] 
         lambda : obj)
        ([<ExcelArgument(Name="T0",Description = "double")>] 
         T0 : obj)
        ([<ExcelArgument(Name="epsilon",Description = "double")>] 
         epsilon : obj)
        ([<ExcelArgument(Name="m",Description = "int")>] 
         m : obj)
        ([<ExcelArgument(Name="rng",Description = "'RNG or empty")>] 
         rng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lambda = Helper.toCell<double> lambda "lambda" 
                let _T0 = Helper.toCell<double> T0 "T0" 
                let _epsilon = Helper.toCell<double> epsilon "epsilon" 
                let _m = Helper.toCell<int> m "m" 
                let _rng = Helper.toDefault<'RNG> rng "rng" default(RNG)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SimulatedAnnealing1 
                                                            _lambda.cell 
                                                            _T0.cell 
                                                            _epsilon.cell 
                                                            _m.cell 
                                                            _rng.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimulatedAnnealing>) l

                let source () = Helper.sourceFold "Fun.SimulatedAnnealing1" 
                                               [| _lambda.source
                                               ;  _T0.source
                                               ;  _epsilon.source
                                               ;  _m.source
                                               ;  _rng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lambda.cell
                                ;  _T0.cell
                                ;  _epsilon.cell
                                ;  _m.cell
                                ;  _rng.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimulatedAnnealing> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SimulatedAnnealing_Range", Description="Create a range of SimulatedAnnealing",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimulatedAnnealing_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimulatedAnnealing> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SimulatedAnnealing> (c)) :> ICell
                let format (i : Generic.List<ICell<SimulatedAnnealing>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SimulatedAnnealing>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
