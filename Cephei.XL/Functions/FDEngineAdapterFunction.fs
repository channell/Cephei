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
module FDEngineAdapterFunction =


    (*
        public FDEngineAdapter(GeneralizedBlackScholesProcess process, Size timeSteps=100, Size gridPoints=100, bool timeDependent = false)
    *)
    [<ExcelFunction(Name="_FDEngineAdapter", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_create
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
                let builder (current : ICell) = (Fun.FDEngineAdapter 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDEngineAdapter>) l

                let source () = Helper.sourceFold "Fun.FDEngineAdapter" 
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
                    ; subscriber = Helper.subscriberModel<FDEngineAdapter> format
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
    [<ExcelFunction(Name="_FDEngineAdapter1", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.FDEngineAdapter1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDEngineAdapter>) l

                let source () = Helper.sourceFold "Fun.FDEngineAdapter1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDEngineAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDEngineAdapter_registerWith", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDEngineAdapter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDEngineAdapter_reset", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).Reset
                                                       ) :> ICell
                let format (o : FDEngineAdapter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
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
    [<ExcelFunction(Name="_FDEngineAdapter_unregisterWith", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDEngineAdapter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDEngineAdapter_update", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).Update
                                                       ) :> ICell
                let format (o : FDEngineAdapter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
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
    [<ExcelFunction(Name="_FDEngineAdapter_ensureStrikeInGrid", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDEngineAdapter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
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
        this should be defined as new in each deriving class which use template iheritance in order to return a proper class to wrap
    *)
    [<ExcelFunction(Name="_FDEngineAdapter_factory", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
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

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDEngineAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDEngineAdapter_getResidualTime", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
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
    [<ExcelFunction(Name="_FDEngineAdapter_grid", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDEngineAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDEngineAdapter_intrinsicValues_", Description="Create a FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEngineAdapter",Description = "FDEngineAdapter")>] 
         fdengineadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEngineAdapter = Helper.toCell<FDEngineAdapter> fdengineadapter "FDEngineAdapter"  
                let builder (current : ICell) = ((FDEngineAdapterModel.Cast _FDEngineAdapter.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDEngineAdapter.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDEngineAdapter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDEngineAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDEngineAdapter_Range", Description="Create a range of FDEngineAdapter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDEngineAdapter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDEngineAdapter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDEngineAdapter> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDEngineAdapter>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDEngineAdapter>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
