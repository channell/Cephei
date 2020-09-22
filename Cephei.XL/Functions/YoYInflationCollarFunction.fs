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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationCollarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyLeg",Description = "Reference to yoyLeg")>] 
         yoyLeg : obj)
        ([<ExcelArgument(Name="capRates",Description = "Reference to capRates")>] 
         capRates : obj)
        ([<ExcelArgument(Name="floorRates",Description = "Reference to floorRates")>] 
         floorRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" true
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" true
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.YoYInflationCollar 
                                                            _yoyLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCollar>) l

                let source = Helper.sourceFold "Fun.YoYInflationCollar" 
                                               [| _yoyLeg.source
                                               ;  _capRates.source
                                               ;  _floorRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyLeg.cell
                                ;  _capRates.cell
                                ;  _floorRates.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_atmRate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".AtmRate") 
                                               [| _YoYInflationCollar.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _discountCurve.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_capRates", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".CapRates") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_floorRates", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".FloorRates") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! implied term volatility
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_impliedVolatility", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="yoyCurve",Description = "Reference to yoyCurve")>] 
         yoyCurve : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Reference to minVol")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Reference to maxVol")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let _price = Helper.toCell<double> price "price" true
                let _yoyCurve = Helper.toHandle<YoYInflationTermStructure> yoyCurve "yoyCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).ImpliedVolatility
                                                            _price.cell 
                                                            _yoyCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".ImpliedVolatility") 
                                               [| _YoYInflationCollar.source
                                               ;  _price.source
                                               ;  _yoyCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _price.cell
                                ;  _yoyCurve.cell
                                ;  _guess.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_isExpired", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".IsExpired") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_lastYoYInflationCoupon", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_lastYoYInflationCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).LastYoYInflationCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".LastYoYInflationCoupon") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_maturityDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".MaturityDate") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        ! Returns the n-th optionlet as a cap/floor with only one cash flow.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_optionlet", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".Optionlet") 
                                               [| _YoYInflationCollar.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_startDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".StartDate") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_type", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).Type
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".TYPE") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_yoyLeg", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".YoyLeg") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_CASH", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".CASH") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_errorEstimate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".ErrorEstimate") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_NPV", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".NPV") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_result", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".Result") 
                                               [| _YoYInflationCollar.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_setPricingEngine", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCollar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".SetPricingEngine") 
                                               [| _YoYInflationCollar.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_valuationDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "Reference to YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toCell<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCollar.cell :?> YoYInflationCollarModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCollar.source + ".ValuationDate") 
                                               [| _YoYInflationCollar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_Range", Description="Create a range of YoYInflationCollar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCollar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationCollar")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCollar> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationCollar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationCollar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationCollar>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
