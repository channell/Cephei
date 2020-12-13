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
  References:  M Forde, A Jacquier, R Lee, The small-time smile and term structure of implied volatility under the Heston model SIAM Journal on Financial Mathematics, 2012 - SIAM  M Lorig, S Pagliarani, A Pascucci, Explicit implied vols for multifactor local-stochastic vol models arXiv preprint arXiv:1306.5447v3, 2014 - arxiv.org  vanillaengines
  </summary> *)
[<AutoSerializable(true)>]
module HestonExpansionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_HestonExpansionEngine", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "HestonModel")>] 
         model : obj)
        ([<ExcelArgument(Name="formula",Description = "HestonExpansionEngine.HestonExpansionFormula: LPP2, LPP3, Forde")>] 
         formula : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HestonModel> model "model" 
                let _formula = Helper.toCell<HestonExpansionEngine.HestonExpansionFormula> formula "formula" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HestonExpansionEngine 
                                                            _model.cell 
                                                            _formula.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonExpansionEngine>) l

                let source () = Helper.sourceFold "Fun.HestonExpansionEngine" 
                                               [| _model.source
                                               ;  _formula.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _formula.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonExpansionEngine> format
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
    [<ExcelFunction(Name="_HestonExpansionEngine_setModel", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonExpansionEngine",Description = "HestonExpansionEngine")>] 
         hestonexpansionengine : obj)
        ([<ExcelArgument(Name="model",Description = "'ModelType")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonExpansionEngine = Helper.toCell<HestonExpansionEngine> hestonexpansionengine "HestonExpansionEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonExpansionEngineModel.Cast _HestonExpansionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : HestonExpansionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonExpansionEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonExpansionEngine.cell
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
            "<WIZ>"*)
    (*
        
    *)
    [<ExcelFunction(Name="_HestonExpansionEngine_registerWith", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonExpansionEngine",Description = "HestonExpansionEngine")>] 
         hestonexpansionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonExpansionEngine = Helper.toCell<HestonExpansionEngine> hestonexpansionengine "HestonExpansionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonExpansionEngineModel.Cast _HestonExpansionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonExpansionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonExpansionEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonExpansionEngine.cell
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
    [<ExcelFunction(Name="_HestonExpansionEngine_reset", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonExpansionEngine",Description = "HestonExpansionEngine")>] 
         hestonexpansionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonExpansionEngine = Helper.toCell<HestonExpansionEngine> hestonexpansionengine "HestonExpansionEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonExpansionEngineModel.Cast _HestonExpansionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : HestonExpansionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonExpansionEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonExpansionEngine.cell
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
    [<ExcelFunction(Name="_HestonExpansionEngine_unregisterWith", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonExpansionEngine",Description = "HestonExpansionEngine")>] 
         hestonexpansionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonExpansionEngine = Helper.toCell<HestonExpansionEngine> hestonexpansionengine "HestonExpansionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonExpansionEngineModel.Cast _HestonExpansionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonExpansionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonExpansionEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonExpansionEngine.cell
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
    [<ExcelFunction(Name="_HestonExpansionEngine_update", Description="Create a HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonExpansionEngine",Description = "HestonExpansionEngine")>] 
         hestonexpansionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonExpansionEngine = Helper.toCell<HestonExpansionEngine> hestonexpansionengine "HestonExpansionEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonExpansionEngineModel.Cast _HestonExpansionEngine.cell).Update
                                                       ) :> ICell
                let format (o : HestonExpansionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonExpansionEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonExpansionEngine.cell
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
    [<ExcelFunction(Name="_HestonExpansionEngine_Range", Description="Create a range of HestonExpansionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonExpansionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonExpansionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<HestonExpansionEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<HestonExpansionEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<HestonExpansionEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
