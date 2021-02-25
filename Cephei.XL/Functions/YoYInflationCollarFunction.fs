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
    [<ExcelFunction(Name="_YoYInflationCollar", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyLeg",Description = "CashFlow range")>] 
         yoyLeg : obj)
        ([<ExcelArgument(Name="capRates",Description = "double range")>] 
         capRates : obj)
        ([<ExcelArgument(Name="floorRates",Description = "double range")>] 
         floorRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" 
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" 
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.YoYInflationCollar 
                                                            _yoyLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCollar>) l

                let source () = Helper.sourceFold "Fun.YoYInflationCollar" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCollar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_atmRate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".AtmRate") 

                                               [| _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _discountCurve.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_capRates", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".CapRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YoYInflationCollar_floorRates", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".FloorRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YoYInflationCollar_impliedVolatility", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        ([<ExcelArgument(Name="yoyCurve",Description = "YoYInflationTermStructure")>] 
         yoyCurve : obj)
        ([<ExcelArgument(Name="guess",Description = "double")>] 
         guess : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "double")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "double")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let _price = Helper.toCell<double> price "price" 
                let _yoyCurve = Helper.toHandle<YoYInflationTermStructure> yoyCurve "yoyCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).ImpliedVolatility
                                                            _price.cell 
                                                            _yoyCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".ImpliedVolatility") 

                                               [| _price.source
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_isExpired", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_lastYoYInflationCoupon", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_lastYoYInflationCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).LastYoYInflationCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".LastYoYInflationCoupon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCollar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_maturityDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        ! Returns the n-th optionlet as a cap/floor with only one cash flow.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_optionlet", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".Optionlet") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCollar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_startDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_type", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).Type
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_yoyLeg", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".YoyLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YoYInflationCollar_CASH", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_errorEstimate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_NPV", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_result", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_setPricingEngine", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCollar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_YoYInflationCollar_valuationDate", Description="Create a YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCollar",Description = "YoYInflationCollar")>] 
         yoyinflationcollar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCollar = Helper.toModelReference<YoYInflationCollar> yoyinflationcollar "YoYInflationCollar"  
                let builder (current : ICell) = ((YoYInflationCollarModel.Cast _YoYInflationCollar.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCollar.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCollar.cell
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
    [<ExcelFunction(Name="_YoYInflationCollar_Range", Description="Create a range of YoYInflationCollar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCollar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCollar> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YoYInflationCollar> (c)) :> ICell
                let format (i : Cephei.Cell.List<YoYInflationCollar>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YoYInflationCollar>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
