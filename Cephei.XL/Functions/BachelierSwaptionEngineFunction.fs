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
module BachelierSwaptionEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSwaptionEngine", Description="Create a BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="model",Description = ".CashAnnuityModel or empty")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel.DiscountCurve
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BachelierSwaptionEngine 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierSwaptionEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierSwaptionEngine" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSwaptionEngine2", Description="Create a BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Quote")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="model",Description = ".CashAnnuityModel or empty")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel.DiscountCurve
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BachelierSwaptionEngine2 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierSwaptionEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierSwaptionEngine1" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSwaptionEngine1", Description="Create a BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "SwaptionVolatilityStructure")>] 
         vol : obj)
        ([<ExcelArgument(Name="model",Description = ".CashAnnuityModel or empty")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<SwaptionVolatilityStructure> vol "vol" 
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel.DiscountCurve
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.BachelierSwaptionEngine1
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierSwaptionEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierSwaptionEngine2" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSwaptionEngine_termStructure", Description="Create a BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierSwaptionEngine",Description = "BachelierSwaptionEngine")>] 
         bachelierswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierSwaptionEngine = Helper.toCell<BachelierSwaptionEngine> bachelierswaptionengine "BachelierSwaptionEngine"  
                let builder (current : ICell) = ((BachelierSwaptionEngineModel.Cast _BachelierSwaptionEngine.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BachelierSwaptionEngine.source + ".TermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSwaptionEngine_volatility", Description="Create a BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierSwaptionEngine",Description = "BachelierSwaptionEngine")>] 
         bachelierswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierSwaptionEngine = Helper.toCell<BachelierSwaptionEngine> bachelierswaptionengine "BachelierSwaptionEngine"  
                let builder (current : ICell) = ((BachelierSwaptionEngineModel.Cast _BachelierSwaptionEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source () = Helper.sourceFold (_BachelierSwaptionEngine.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BachelierSwaptionEngine_Range", Description="Create a range of BachelierSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BachelierSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BachelierSwaptionEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<BachelierSwaptionEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BachelierSwaptionEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
