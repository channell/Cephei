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
  swaptionengines  The engine assumes that the exercise date equals the start date of the passed swap.
  </summary> *)
[<AutoSerializable(true)>]
module JamshidianSwaptionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_JamshidianSwaptionEngine", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "OneFactorAffineModel")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<OneFactorAffineModel> model "model" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JamshidianSwaptionEngine 
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JamshidianSwaptionEngine>) l

                let source () = Helper.sourceFold "Fun.JamshidianSwaptionEngine" 
                                               [| _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JamshidianSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \note the term structure is only needed when the short-rate model cannot provide one itself.
    *)
    [<ExcelFunction(Name="_JamshidianSwaptionEngine1", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "OneFactorAffineModel")>] 
         model : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<OneFactorAffineModel> model "model" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JamshidianSwaptionEngine1 
                                                            _model.cell 
                                                            _termStructure.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JamshidianSwaptionEngine>) l

                let source () = Helper.sourceFold "Fun.JamshidianSwaptionEngine1" 
                                               [| _model.source
                                               ;  _termStructure.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _termStructure.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JamshidianSwaptionEngine> format
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
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_setModel", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JamshidianSwaptionEngine",Description = "JamshidianSwaptionEngine")>] 
         jamshidianswaptionengine : obj)
        ([<ExcelArgument(Name="model",Description = "'ModelType")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JamshidianSwaptionEngine = Helper.toCell<JamshidianSwaptionEngine> jamshidianswaptionengine "JamshidianSwaptionEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder (current : ICell) = withMnemonic mnemonic ((JamshidianSwaptionEngineModel.Cast _JamshidianSwaptionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : JamshidianSwaptionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JamshidianSwaptionEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JamshidianSwaptionEngine.cell
                                ;  _model.cell
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
            "<WIZ>" *)
    (*
        
    *)
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_registerWith", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JamshidianSwaptionEngine",Description = "JamshidianSwaptionEngine")>] 
         jamshidianswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JamshidianSwaptionEngine = Helper.toCell<JamshidianSwaptionEngine> jamshidianswaptionengine "JamshidianSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((JamshidianSwaptionEngineModel.Cast _JamshidianSwaptionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JamshidianSwaptionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JamshidianSwaptionEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JamshidianSwaptionEngine.cell
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
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_reset", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JamshidianSwaptionEngine",Description = "JamshidianSwaptionEngine")>] 
         jamshidianswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JamshidianSwaptionEngine = Helper.toCell<JamshidianSwaptionEngine> jamshidianswaptionengine "JamshidianSwaptionEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((JamshidianSwaptionEngineModel.Cast _JamshidianSwaptionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : JamshidianSwaptionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JamshidianSwaptionEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JamshidianSwaptionEngine.cell
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
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_unregisterWith", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JamshidianSwaptionEngine",Description = "JamshidianSwaptionEngine")>] 
         jamshidianswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JamshidianSwaptionEngine = Helper.toCell<JamshidianSwaptionEngine> jamshidianswaptionengine "JamshidianSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((JamshidianSwaptionEngineModel.Cast _JamshidianSwaptionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JamshidianSwaptionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JamshidianSwaptionEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JamshidianSwaptionEngine.cell
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
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_update", Description="Create a JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JamshidianSwaptionEngine",Description = "JamshidianSwaptionEngine")>] 
         jamshidianswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JamshidianSwaptionEngine = Helper.toCell<JamshidianSwaptionEngine> jamshidianswaptionengine "JamshidianSwaptionEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((JamshidianSwaptionEngineModel.Cast _JamshidianSwaptionEngine.cell).Update
                                                       ) :> ICell
                let format (o : JamshidianSwaptionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JamshidianSwaptionEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JamshidianSwaptionEngine.cell
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
    [<ExcelFunction(Name="_JamshidianSwaptionEngine_Range", Description="Create a range of JamshidianSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JamshidianSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JamshidianSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<JamshidianSwaptionEngine> (c)) :> ICell
                let format (i : Generic.List<ICell<JamshidianSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<JamshidianSwaptionEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
