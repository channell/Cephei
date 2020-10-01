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
  Generic Black-style-formula swaption engine This is the base class for the Black and Bachelier swaption engines
  </summary> *)
[<AutoSerializable(true)>]
module BlackStyleSwaptionEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine", Description="Create a BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _volatility = Helper.toHandle<SwaptionVolatilityStructure> volatility "volatility" 
                let _displacement = Helper.toNullable<Nullable<double> displacement "displacement"
                let _model = Helper.toCell<CashAnnuityModel> model "model" 
                let builder () = withMnemonic mnemonic (Fun.BlackStyleSwaptionEngine 
                                                            _discountCurve.cell 
                                                            _volatility.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackStyleSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackStyleSwaptionEngine" 
                                               [| _discountCurve.source
                                               ;  _volatility.source
                                               ;  _displacement.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _volatility.cell
                                ;  _displacement.cell
                                ;  _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackStyleSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine1", Description="Create a BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let _model = Helper.toCell<CashAnnuityModel> model "model" 
                let builder () = withMnemonic mnemonic (Fun.BlackStyleSwaptionEngine1 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackStyleSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackStyleSwaptionEngine1" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _displacement.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _displacement.cell
                                ;  _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackStyleSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine2", Description="Create a BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let _model = Helper.toCell<CashAnnuityModel> model "model" 
                let builder () = withMnemonic mnemonic (Fun.BlackStyleSwaptionEngine2 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackStyleSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackStyleSwaptionEngine2" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _displacement.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _displacement.cell
                                ;  _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackStyleSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine_termStructure", Description="Create a BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackStyleSwaptionEngine",Description = "Reference to BlackStyleSwaptionEngine")>] 
         blackstyleswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackStyleSwaptionEngine = Helper.toCell<BlackStyleSwaptionEngine> blackstyleswaptionengine "BlackStyleSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((_BlackStyleSwaptionEngine.cell :?> BlackStyleSwaptionEngineModel).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackStyleSwaptionEngine.source + ".TermStructure") 
                                               [| _BlackStyleSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackStyleSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackStyleSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine_volatility", Description="Create a BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackStyleSwaptionEngine",Description = "Reference to BlackStyleSwaptionEngine")>] 
         blackstyleswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackStyleSwaptionEngine = Helper.toCell<BlackStyleSwaptionEngine> blackstyleswaptionengine "BlackStyleSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((_BlackStyleSwaptionEngine.cell :?> BlackStyleSwaptionEngineModel).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_BlackStyleSwaptionEngine.source + ".Volatility") 
                                               [| _BlackStyleSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackStyleSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackStyleSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BlackStyleSwaptionEngine_Range", Description="Create a range of BlackStyleSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackStyleSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackStyleSwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackStyleSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackStyleSwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackStyleSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackStyleSwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
