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

  </summary> *)
[<AutoSerializable(true)>]
module DifferentialEvolutionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DifferentialEvolution_configuration", Description="Create a DifferentialEvolution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DifferentialEvolution_configuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DifferentialEvolution",Description = "DifferentialEvolution")>] 
         differentialevolution : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DifferentialEvolution = Helper.toCell<DifferentialEvolution> differentialevolution "DifferentialEvolution"  
                let builder (current : ICell) = withMnemonic mnemonic ((DifferentialEvolutionModel.Cast _DifferentialEvolution.cell).Configuration
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DifferentialEvolution.Configuration>) l

                let source () = Helper.sourceFold (_DifferentialEvolution.source + ".Configuration") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DifferentialEvolution.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DifferentialEvolution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DifferentialEvolution", Description="Create a DifferentialEvolution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DifferentialEvolution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="configuration",Description = "DifferentialEvolution.Configuration or empty")>] 
         configuration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _configuration = Helper.toDefault<DifferentialEvolution.Configuration> configuration "configuration" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DifferentialEvolution 
                                                            _configuration.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DifferentialEvolution>) l

                let source () = Helper.sourceFold "Fun.DifferentialEvolution" 
                                               [| _configuration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _configuration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DifferentialEvolution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DifferentialEvolution_minimize", Description="Create a DifferentialEvolution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DifferentialEvolution_minimize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DifferentialEvolution",Description = "DifferentialEvolution")>] 
         differentialevolution : obj)
        ([<ExcelArgument(Name="P",Description = "Problem")>] 
         P : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DifferentialEvolution = Helper.toCell<DifferentialEvolution> differentialevolution "DifferentialEvolution"  
                let _P = Helper.toCell<Problem> P "P" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let builder (current : ICell) = withMnemonic mnemonic ((DifferentialEvolutionModel.Cast _DifferentialEvolution.cell).Minimize
                                                            _P.cell 
                                                            _endCriteria.cell 
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DifferentialEvolution.source + ".Minimize") 

                                               [| _P.source
                                               ;  _endCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DifferentialEvolution.cell
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
    [<ExcelFunction(Name="_DifferentialEvolution_Range", Description="Create a range of DifferentialEvolution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DifferentialEvolution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DifferentialEvolution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DifferentialEvolution> (c)) :> ICell
                let format (i : Generic.List<ICell<DifferentialEvolution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DifferentialEvolution>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
