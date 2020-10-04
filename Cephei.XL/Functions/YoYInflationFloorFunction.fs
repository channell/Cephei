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
module YoYInflationFloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationFloor", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyLeg",Description = "Reference to yoyLeg")>] 
         yoyLeg : obj)
        ([<ExcelArgument(Name="exerciseRates",Description = "Reference to exerciseRates")>] 
         exerciseRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" 
                let _exerciseRates = Helper.toCell<Generic.List<double>> exerciseRates "exerciseRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.YoYInflationFloor 
                                                            _yoyLeg.cell 
                                                            _exerciseRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationFloor>) l

                let source = Helper.sourceFold "Fun.YoYInflationFloor" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationFloor_atmRate", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".AtmRate") 
                                               [| _YoYInflationFloor.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_capRates", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".CapRates") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_floorRates", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".FloorRates") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_impliedVolatility", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
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

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let _price = Helper.toCell<double> price "price" 
                let _yoyCurve = Helper.toHandle<YoYInflationTermStructure> yoyCurve "yoyCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).ImpliedVolatility
                                                            _price.cell 
                                                            _yoyCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".ImpliedVolatility") 
                                               [| _YoYInflationFloor.source
                                               ;  _price.source
                                               ;  _yoyCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_isExpired", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".IsExpired") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_lastYoYInflationCoupon", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_lastYoYInflationCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).LastYoYInflationCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".LastYoYInflationCoupon") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationFloor_maturityDate", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".MaturityDate") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_optionlet", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".Optionlet") 
                                               [| _YoYInflationFloor.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationFloor_startDate", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".StartDate") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_type", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).Type
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".TYPE") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_yoyLeg", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".YoyLeg") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_CASH", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".CASH") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_errorEstimate", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".ErrorEstimate") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_NPV", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".NPV") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_result", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".Result") 
                                               [| _YoYInflationFloor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_setPricingEngine", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YoYInflationFloor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".SetPricingEngine") 
                                               [| _YoYInflationFloor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_valuationDate", Description="Create a YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationFloor",Description = "Reference to YoYInflationFloor")>] 
         yoyinflationfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationFloor = Helper.toCell<YoYInflationFloor> yoyinflationfloor "YoYInflationFloor"  
                let builder () = withMnemonic mnemonic ((YoYInflationFloorModel.Cast _YoYInflationFloor.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationFloor.source + ".ValuationDate") 
                                               [| _YoYInflationFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationFloor_Range", Description="Create a range of YoYInflationFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationFloor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationFloor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationFloor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationFloor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationFloor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
