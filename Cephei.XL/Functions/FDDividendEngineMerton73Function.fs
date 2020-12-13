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
The merton 73 engine is the classic engine described in most derivatives texts.  However, Haug, Haug, and Lewis in "Back to Basics: a new approach to the discrete dividend problem" argues that this scheme underprices call options. This is set as the default engine, because it is consistent with the analytic version.
  </summary> *)
[<AutoSerializable(true)>]
module FDDividendEngineMerton73Function =

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton73_factory2", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_factory2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).Factory2
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Factory2") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton73", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendEngineMerton73 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngineMerton73>) l

                let source () = Helper.sourceFold "Fun.FDDividendEngineMerton73" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton731", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendEngineMerton731 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngineMerton73>) l

                let source () = Helper.sourceFold "Fun.FDDividendEngineMerton731" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton73_factory", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton73_setStepCondition", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDDividendEngineMerton73) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                ;  _impl.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_ensureStrikeInGrid", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendEngineMerton73) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_getResidualTime", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_grid", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineMerton73_intrinsicValues_", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineMerton73Model.Cast _FDDividendEngineMerton73.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDDividendEngineMerton73.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDDividendEngineMerton73_Range", Description="Create a range of FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendEngineMerton73> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDDividendEngineMerton73> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDDividendEngineMerton73>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDDividendEngineMerton73>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
