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
module BlackSwaptionEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackSwaptionEngine2", Description="Create a BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_create2
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
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel.DiscountCurve
                let builder () = withMnemonic mnemonic (Fun.BlackSwaptionEngine2 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackSwaptionEngine2" 
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
                    ; subscriber = Helper.subscriberModel<BlackSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackSwaptionEngine", Description="Create a BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<SwaptionVolatilityStructure> vol "vol" 
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel.DiscountCurve
                let builder () = withMnemonic mnemonic (Fun.BlackSwaptionEngine
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackSwaptionEngine" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _displacement.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _displacement.cell
                                ;  _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackSwaptionEngine1", Description="Create a BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_create1
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
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let _model = Helper.toDefault<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel> model "model" BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel.DiscountCurve
                let builder () = withMnemonic mnemonic (Fun.BlackSwaptionEngine1
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _displacement.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.BlackSwaptionEngine1" 
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
                    ; subscriber = Helper.subscriberModel<BlackSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_BlackSwaptionEngine_termStructure", Description="Create a BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackSwaptionEngine",Description = "Reference to BlackSwaptionEngine")>] 
         blackswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackSwaptionEngine = Helper.toCell<BlackSwaptionEngine> blackswaptionengine "BlackSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((BlackSwaptionEngineModel.Cast _BlackSwaptionEngine.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackSwaptionEngine.source + ".TermStructure") 
                                               [| _BlackSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackSwaptionEngine_volatility", Description="Create a BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackSwaptionEngine",Description = "Reference to BlackSwaptionEngine")>] 
         blackswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackSwaptionEngine = Helper.toCell<BlackSwaptionEngine> blackswaptionengine "BlackSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((BlackSwaptionEngineModel.Cast _BlackSwaptionEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_BlackSwaptionEngine.source + ".Volatility") 
                                               [| _BlackSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackSwaptionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BlackSwaptionEngine_Range", Description="Create a range of BlackSwaptionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackSwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackSwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackSwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
