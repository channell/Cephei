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
module YoYInflationCapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCap", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyLeg",Description = "CashFlow range")>] 
         yoyLeg : obj)
        ([<ExcelArgument(Name="exerciseRates",Description = "double range")>] 
         exerciseRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" 
                let _exerciseRates = Helper.toCell<Generic.List<double>> exerciseRates "exerciseRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YoYInflationCap 
                                                            _yoyLeg.cell 
                                                            _exerciseRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCap>) l

                let source () = Helper.sourceFold "Fun.YoYInflationCap" 
                                               [| _yoyLeg.source
                                               ;  _exerciseRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyLeg.cell
                                ;  _exerciseRates.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCap_atmRate", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".AtmRate") 

                                               [| _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_capRates", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".CapRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_floorRates", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".FloorRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_impliedVolatility", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
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

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let _price = Helper.toCell<double> price "price" 
                let _yoyCurve = Helper.toHandle<YoYInflationTermStructure> yoyCurve "yoyCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).ImpliedVolatility
                                                            _price.cell 
                                                            _yoyCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".ImpliedVolatility") 

                                               [| _price.source
                                               ;  _yoyCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_isExpired", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_lastYoYInflationCoupon", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_lastYoYInflationCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).LastYoYInflationCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".LastYoYInflationCoupon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCap_maturityDate", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_optionlet", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".Optionlet") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCap_startDate", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_type", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).Type
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_yoyLeg", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".YoyLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_CASH", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_errorEstimate", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_NPV", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_result", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_setPricingEngine", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_valuationDate", Description="Create a YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCap",Description = "YoYInflationCap")>] 
         yoyinflationcap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCap = Helper.toCell<YoYInflationCap> yoyinflationcap "YoYInflationCap"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapModel.Cast _YoYInflationCap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationCap.cell
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
    [<ExcelFunction(Name="_YoYInflationCap_Range", Description="Create a range of YoYInflationCap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YoYInflationCap> (c)) :> ICell
                let format (i : Cephei.Cell.List<YoYInflationCap>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YoYInflationCap>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
