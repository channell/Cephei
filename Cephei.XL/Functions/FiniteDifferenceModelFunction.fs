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
(*!!
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module FiniteDifferenceModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FiniteDifferenceModel_evolver", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_evolver
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FiniteDifferenceModel",Description = "FiniteDifferenceModel")>] 
         finitedifferencemodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FiniteDifferenceModel = Helper.toModelReference<FiniteDifferenceModel> finitedifferencemodel "FiniteDifferenceModel"  
                let builder (current : ICell) = ((FiniteDifferenceModelModel.Cast _FiniteDifferenceModel.cell).Evolver
                                                       ) :> ICell
                let format (o : Evolver) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FiniteDifferenceModel.source + ".Evolver") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FiniteDifferenceModel.cell
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
        public FiniteDifferenceModel(Evolver evolver, List<double> stoppingTimes = List<double>())
    *)
    [<ExcelFunction(Name="_FiniteDifferenceModel", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evolver",Description = "'Evolver")>] 
         evolver : obj)
        ([<ExcelArgument(Name="stoppingTimes",Description = "double range")>] 
         stoppingTimes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evolver = Helper.toCell<'Evolver> evolver "evolver" 
                let _stoppingTimes = Helper.toCell<Generic.List<double>> stoppingTimes "stoppingTimes" 
                let builder (current : ICell) = (Fun.FiniteDifferenceModel 
                                                            _evolver.cell 
                                                            _stoppingTimes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FiniteDifferenceModel>) l

                let source () = Helper.sourceFold "Fun.FiniteDifferenceModel" 
                                               [| _evolver.source
                                               ;  _stoppingTimes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _evolver.cell
                                ;  _stoppingTimes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FiniteDifferenceModel> format
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
    [<ExcelFunction(Name="_FiniteDifferenceModel1", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Object")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Object")>] 
         bcs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let builder (current : ICell) = (Fun.FiniteDifferenceModel1 
                                                            _L.cell 
                                                            _bcs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FiniteDifferenceModel>) l

                let source () = Helper.sourceFold "Fun.FiniteDifferenceModel1" 
                                               [| _L.source
                                               ;  _bcs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _L.cell
                                ;  _bcs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FiniteDifferenceModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FiniteDifferenceModel2", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Object")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Object")>] 
         bcs : obj)
        ([<ExcelArgument(Name="stoppingTimes",Description = "double range")>] 
         stoppingTimes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _stoppingTimes = Helper.toCell<Generic.List<double>> stoppingTimes "stoppingTimes" 
                let builder (current : ICell) = (Fun.FiniteDifferenceModel2 
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _stoppingTimes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FiniteDifferenceModel>) l

                let source () = Helper.sourceFold "Fun.FiniteDifferenceModel2" 
                                               [| _L.source
                                               ;  _bcs.source
                                               ;  _stoppingTimes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _L.cell
                                ;  _bcs.cell
                                ;  _stoppingTimes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FiniteDifferenceModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FiniteDifferenceModel_rollback", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FiniteDifferenceModel",Description = "FiniteDifferenceModel")>] 
         finitedifferencemodel : obj)
        ([<ExcelArgument(Name="a",Description = "Object")>] 
         a : obj)
        ([<ExcelArgument(Name="from",Description = "double")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="condition",Description = "Vector")>] 
         condition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FiniteDifferenceModel = Helper.toModelReference<FiniteDifferenceModel> finitedifferencemodel "FiniteDifferenceModel"  
                let _a = Helper.toCell<Object> a "a" 
                let _from = Helper.toCell<double> from "from" 
                let _To = Helper.toCell<double> To "To" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _condition = Helper.toCell<IStepCondition<Vector>> condition "condition" 
                let builder (current : ICell) = ((FiniteDifferenceModelModel.Cast _FiniteDifferenceModel.cell).Rollback
                                                            _a.cell 
                                                            _from.cell 
                                                            _To.cell 
                                                            _steps.cell 
                                                            _condition.cell 
                                                       ) :> ICell
                let format (o : FiniteDifferenceModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FiniteDifferenceModel.source + ".Rollback") 

                                               [| _a.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _steps.source
                                               ;  _condition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FiniteDifferenceModel.cell
                                ;  _a.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _steps.cell
                                ;  _condition.cell
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
        ! solves the problem between the given times, applying a condition at every step. \warning being this a rollback, <tt>from</tt> must be a later time than <tt>to</tt>.
    *)
    [<ExcelFunction(Name="_FiniteDifferenceModel_rollback", Description="Create a FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FiniteDifferenceModel",Description = "FiniteDifferenceModel")>] 
         finitedifferencemodel : obj)
        ([<ExcelArgument(Name="a",Description = "Object")>] 
         a : obj)
        ([<ExcelArgument(Name="from",Description = "double")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FiniteDifferenceModel = Helper.toModelReference<FiniteDifferenceModel> finitedifferencemodel "FiniteDifferenceModel"  
                let _a = Helper.toCell<Object> a "a" 
                let _from = Helper.toCell<double> from "from" 
                let _To = Helper.toCell<double> To "To" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder (current : ICell) = ((FiniteDifferenceModelModel.Cast _FiniteDifferenceModel.cell).Rollback1
                                                            _a.cell 
                                                            _from.cell 
                                                            _To.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (o : FiniteDifferenceModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FiniteDifferenceModel.source + ".Rollback") 

                                               [| _a.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FiniteDifferenceModel.cell
                                ;  _a.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _steps.cell
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
    [<ExcelFunction(Name="_FiniteDifferenceModel_Range", Description="Create a range of FiniteDifferenceModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FiniteDifferenceModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FiniteDifferenceModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FiniteDifferenceModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<FiniteDifferenceModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FiniteDifferenceModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
