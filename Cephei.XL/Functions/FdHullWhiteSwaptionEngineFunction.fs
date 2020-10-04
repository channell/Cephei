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
module FdHullWhiteSwaptionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="tGrid",Description = "Reference to tGrid")>] 
         tGrid : obj)
        ([<ExcelArgument(Name="xGrid",Description = "Reference to xGrid")>] 
         xGrid : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "Reference to dampingSteps")>] 
         dampingSteps : obj)
        ([<ExcelArgument(Name="invEps",Description = "Reference to invEps")>] 
         invEps : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HullWhite> model "model" 
                let _tGrid = Helper.toDefault<int> tGrid "tGrid" 100
                let _xGrid = Helper.toDefault<int> xGrid "xGrid" 100
                let _dampingSteps = Helper.toDefault<int> dampingSteps "dampingSteps" 0
                let _invEps = Helper.toDefault<double> invEps "invEps" 1e-5
                let _schemeDesc = Helper.toDefault<FdmSchemeDesc> schemeDesc "schemeDesc" null
                let builder () = withMnemonic mnemonic (Fun.FdHullWhiteSwaptionEngine 
                                                            _model.cell 
                                                            _tGrid.cell 
                                                            _xGrid.cell 
                                                            _dampingSteps.cell 
                                                            _invEps.cell 
                                                            _schemeDesc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdHullWhiteSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.FdHullWhiteSwaptionEngine" 
                                               [| _model.source
                                               ;  _tGrid.source
                                               ;  _xGrid.source
                                               ;  _dampingSteps.source
                                               ;  _invEps.source
                                               ;  _schemeDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _tGrid.cell
                                ;  _xGrid.cell
                                ;  _dampingSteps.cell
                                ;  _invEps.cell
                                ;  _schemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdHullWhiteSwaptionEngine> format
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
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_setModel", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdHullWhiteSwaptionEngine",Description = "Reference to FdHullWhiteSwaptionEngine")>] 
         fdhullwhiteswaptionengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdHullWhiteSwaptionEngine = Helper.toCell<FdHullWhiteSwaptionEngine> fdhullwhiteswaptionengine "FdHullWhiteSwaptionEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic ((FdHullWhiteSwaptionEngineModel.Cast _FdHullWhiteSwaptionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : FdHullWhiteSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdHullWhiteSwaptionEngine.source + ".SetModel") 
                                               [| _FdHullWhiteSwaptionEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdHullWhiteSwaptionEngine.cell
                                ;  _model.cell
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
            "<WIZ>"*)
    (*
        
    *)
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_registerWith", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdHullWhiteSwaptionEngine",Description = "Reference to FdHullWhiteSwaptionEngine")>] 
         fdhullwhiteswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdHullWhiteSwaptionEngine = Helper.toCell<FdHullWhiteSwaptionEngine> fdhullwhiteswaptionengine "FdHullWhiteSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((FdHullWhiteSwaptionEngineModel.Cast _FdHullWhiteSwaptionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdHullWhiteSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdHullWhiteSwaptionEngine.source + ".RegisterWith") 
                                               [| _FdHullWhiteSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdHullWhiteSwaptionEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_reset", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdHullWhiteSwaptionEngine",Description = "Reference to FdHullWhiteSwaptionEngine")>] 
         fdhullwhiteswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdHullWhiteSwaptionEngine = Helper.toCell<FdHullWhiteSwaptionEngine> fdhullwhiteswaptionengine "FdHullWhiteSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((FdHullWhiteSwaptionEngineModel.Cast _FdHullWhiteSwaptionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : FdHullWhiteSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdHullWhiteSwaptionEngine.source + ".Reset") 
                                               [| _FdHullWhiteSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdHullWhiteSwaptionEngine.cell
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
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_unregisterWith", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdHullWhiteSwaptionEngine",Description = "Reference to FdHullWhiteSwaptionEngine")>] 
         fdhullwhiteswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdHullWhiteSwaptionEngine = Helper.toCell<FdHullWhiteSwaptionEngine> fdhullwhiteswaptionengine "FdHullWhiteSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((FdHullWhiteSwaptionEngineModel.Cast _FdHullWhiteSwaptionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdHullWhiteSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdHullWhiteSwaptionEngine.source + ".UnregisterWith") 
                                               [| _FdHullWhiteSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdHullWhiteSwaptionEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_update", Description="Create a FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdHullWhiteSwaptionEngine",Description = "Reference to FdHullWhiteSwaptionEngine")>] 
         fdhullwhiteswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdHullWhiteSwaptionEngine = Helper.toCell<FdHullWhiteSwaptionEngine> fdhullwhiteswaptionengine "FdHullWhiteSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((FdHullWhiteSwaptionEngineModel.Cast _FdHullWhiteSwaptionEngine.cell).Update
                                                       ) :> ICell
                let format (o : FdHullWhiteSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdHullWhiteSwaptionEngine.source + ".Update") 
                                               [| _FdHullWhiteSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdHullWhiteSwaptionEngine.cell
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
    [<ExcelFunction(Name="_FdHullWhiteSwaptionEngine_Range", Description="Create a range of FdHullWhiteSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdHullWhiteSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdHullWhiteSwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdHullWhiteSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdHullWhiteSwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdHullWhiteSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdHullWhiteSwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
