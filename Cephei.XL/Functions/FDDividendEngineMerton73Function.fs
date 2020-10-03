﻿(*
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_factory2", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_factory2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "Reference to timeDependent")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).Factory2
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Factory2") 
                                               [| _FDDividendEngineMerton73.source
                                               ;  _Process.source
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "Reference to timeDependent")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic (Fun.FDDividendEngineMerton73 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngineMerton73>) l

                let source = Helper.sourceFold "Fun.FDDividendEngineMerton73" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FDDividendEngineMerton731", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FDDividendEngineMerton731 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngineMerton73>) l

                let source = Helper.sourceFold "Fun.FDDividendEngineMerton731" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_factory", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "Reference to timeDependent")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Factory") 
                                               [| _FDDividendEngineMerton73.source
                                               ;  _Process.source
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_setStepCondition", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDDividendEngineMerton73) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".SetStepCondition") 
                                               [| _FDDividendEngineMerton73.source
                                               ;  _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                ;  _impl.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_ensureStrikeInGrid", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendEngineMerton73) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".EnsureStrikeInGrid") 
                                               [| _FDDividendEngineMerton73.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_getResidualTime", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".GetResidualTime") 
                                               [| _FDDividendEngineMerton73.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_grid", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".Grid") 
                                               [| _FDDividendEngineMerton73.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FDDividendEngineMerton73_intrinsicValues_", Description="Create a FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineMerton73",Description = "Reference to FDDividendEngineMerton73")>] 
         fddividendenginemerton73 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineMerton73 = Helper.toCell<FDDividendEngineMerton73> fddividendenginemerton73 "FDDividendEngineMerton73"  
                let builder () = withMnemonic mnemonic ((_FDDividendEngineMerton73.cell :?> FDDividendEngineMerton73Model).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDDividendEngineMerton73.source + ".IntrinsicValues_") 
                                               [| _FDDividendEngineMerton73.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineMerton73.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngineMerton73> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDDividendEngineMerton73_Range", Description="Create a range of FDDividendEngineMerton73",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineMerton73_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDDividendEngineMerton73")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendEngineMerton73> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDDividendEngineMerton73>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDDividendEngineMerton73>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDDividendEngineMerton73>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"