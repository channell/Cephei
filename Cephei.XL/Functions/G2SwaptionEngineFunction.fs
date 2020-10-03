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
module G2SwaptionEngineFunction =


    (*
        range is the number of standard deviations to use in the exponential term of the integral for the european swaption. intervals is the number of intervals to use in the integration.
    *)
    [<ExcelFunction(Name="_G2SwaptionEngine", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="range",Description = "Reference to range")>] 
         range : obj)
        ([<ExcelArgument(Name="intervals",Description = "Reference to intervals")>] 
         intervals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<G2> model "model" 
                let _range = Helper.toCell<double> range "range" 
                let _intervals = Helper.toCell<int> intervals "intervals" 
                let builder () = withMnemonic mnemonic (Fun.G2SwaptionEngine 
                                                            _model.cell 
                                                            _range.cell 
                                                            _intervals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2SwaptionEngine>) l

                let source = Helper.sourceFold "Fun.G2SwaptionEngine" 
                                               [| _model.source
                                               ;  _range.source
                                               ;  _intervals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _range.cell
                                ;  _intervals.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2SwaptionEngine> format
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
    [<ExcelFunction(Name="_G2SwaptionEngine_setModel", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2SwaptionEngine",Description = "Reference to G2SwaptionEngine")>] 
         g2swaptionengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2SwaptionEngine = Helper.toCell<G2SwaptionEngine> g2swaptionengine "G2SwaptionEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic ((G2SwaptionEngineModel.Cast _G2SwaptionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : G2SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2SwaptionEngine.source + ".SetModel") 
                                               [| _G2SwaptionEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2SwaptionEngine.cell
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
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_G2SwaptionEngine_registerWith", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2SwaptionEngine",Description = "Reference to G2SwaptionEngine")>] 
         g2swaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2SwaptionEngine = Helper.toCell<G2SwaptionEngine> g2swaptionengine "G2SwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((G2SwaptionEngineModel.Cast _G2SwaptionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : G2SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2SwaptionEngine.source + ".RegisterWith") 
                                               [| _G2SwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2SwaptionEngine.cell
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
    [<ExcelFunction(Name="_G2SwaptionEngine_reset", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2SwaptionEngine",Description = "Reference to G2SwaptionEngine")>] 
         g2swaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2SwaptionEngine = Helper.toCell<G2SwaptionEngine> g2swaptionengine "G2SwaptionEngine"  
                let builder () = withMnemonic mnemonic ((G2SwaptionEngineModel.Cast _G2SwaptionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : G2SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2SwaptionEngine.source + ".Reset") 
                                               [| _G2SwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2SwaptionEngine.cell
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
    [<ExcelFunction(Name="_G2SwaptionEngine_unregisterWith", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2SwaptionEngine",Description = "Reference to G2SwaptionEngine")>] 
         g2swaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2SwaptionEngine = Helper.toCell<G2SwaptionEngine> g2swaptionengine "G2SwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((G2SwaptionEngineModel.Cast _G2SwaptionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : G2SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2SwaptionEngine.source + ".UnregisterWith") 
                                               [| _G2SwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2SwaptionEngine.cell
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
    [<ExcelFunction(Name="_G2SwaptionEngine_update", Description="Create a G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2SwaptionEngine",Description = "Reference to G2SwaptionEngine")>] 
         g2swaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2SwaptionEngine = Helper.toCell<G2SwaptionEngine> g2swaptionengine "G2SwaptionEngine"  
                let builder () = withMnemonic mnemonic ((G2SwaptionEngineModel.Cast _G2SwaptionEngine.cell).Update
                                                       ) :> ICell
                let format (o : G2SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2SwaptionEngine.source + ".Update") 
                                               [| _G2SwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2SwaptionEngine.cell
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
    [<ExcelFunction(Name="_G2SwaptionEngine_Range", Description="Create a range of G2SwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let G2SwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the G2SwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<G2SwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<G2SwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<G2SwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<G2SwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
