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
  instruments  Note that the standard YoY inflation cap/floor defined here is different from nominal, because in nominal world standard cap/floors do not have the first optionlet.  This is because they set in advance so there is no point.  However, yoy inflation generally sets (effectively) in arrears, (actually in arrears vs lag of a few months) thus the first optionlet is relevant.  Hence we can do a parity test without a special definition of the YoY cap/floor instrument.  - the relationship between the values of caps, floors and the resulting collars is checked. - the put-call parity between the values of caps, floors and swaps is checked. - the correctness of the returned value is tested by checking it against a known good value.
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationCapFloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloor_atmRate", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".AtmRate") 
                                               [| _YoYInflationCapFloor.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_capRates", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".CapRates") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_floorRates", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".FloorRates") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_impliedVolatility", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
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

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let _price = Helper.toCell<double> price "price" 
                let _yoyCurve = Helper.toHandle<YoYInflationTermStructure> yoyCurve "yoyCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).ImpliedVolatility
                                                            _price.cell 
                                                            _yoyCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".ImpliedVolatility") 
                                               [| _YoYInflationCapFloor.source
                                               ;  _price.source
                                               ;  _yoyCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_isExpired", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".IsExpired") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_lastYoYInflationCoupon", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_lastYoYInflationCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).LastYoYInflationCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".LastYoYInflationCoupon") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloor_maturityDate", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".MaturityDate") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_optionlet", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".Optionlet") 
                                               [| _YoYInflationCapFloor.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloor_startDate", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".StartDate") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_type", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).Type
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".TYPE") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="yoyLeg",Description = "Reference to yoyLeg")>] 
         yoyLeg : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<CapFloorType> Type "Type" 
                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YoYInflationCapFloor 
                                                            _Type.cell 
                                                            _yoyLeg.cell 
                                                            _strikes.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source () = Helper.sourceFold "Fun.YoYInflationCapFloor" 
                                               [| _Type.source
                                               ;  _yoyLeg.source
                                               ;  _strikes.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _yoyLeg.cell
                                ;  _strikes.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloor1", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
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

                let _Type = Helper.toCell<CapFloorType> Type "Type" 
                let _yoyLeg = Helper.toCell<Generic.List<CashFlow>> yoyLeg "yoyLeg" 
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" 
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YoYInflationCapFloor1 
                                                            _Type.cell 
                                                            _yoyLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCapFloor>) l

                let source () = Helper.sourceFold "Fun.YoYInflationCapFloor1" 
                                               [| _Type.source
                                               ;  _yoyLeg.source
                                               ;  _capRates.source
                                               ;  _floorRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _yoyLeg.cell
                                ;  _capRates.cell
                                ;  _floorRates.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCapFloor_yoyLeg", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_yoyLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).YoyLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".YoyLeg") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_CASH", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".CASH") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_errorEstimate", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".ErrorEstimate") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_NPV", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".NPV") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_result", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".Result") 
                                               [| _YoYInflationCapFloor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_setPricingEngine", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".SetPricingEngine") 
                                               [| _YoYInflationCapFloor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_valuationDate", Description="Create a YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCapFloor",Description = "Reference to YoYInflationCapFloor")>] 
         yoyinflationcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCapFloor = Helper.toCell<YoYInflationCapFloor> yoyinflationcapfloor "YoYInflationCapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationCapFloorModel.Cast _YoYInflationCapFloor.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_YoYInflationCapFloor.source + ".ValuationDate") 
                                               [| _YoYInflationCapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCapFloor.cell
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
    [<ExcelFunction(Name="_YoYInflationCapFloor_Range", Description="Create a range of YoYInflationCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationCapFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationCapFloor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCapFloor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationCapFloor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationCapFloor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<YoYInflationCapFloor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
