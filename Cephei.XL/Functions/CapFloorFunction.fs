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
module CapFloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CapFloor_atmRate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".AtmRate") 
                                               [| _CapFloor.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="floatingLeg",Description = "Reference to floatingLeg")>] 
         floatingLeg : obj)
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

                let _Type = Helper.toCell<CapFloorType> Type "Type" true
                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" true
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" true
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CapFloor 
                                                            _Type.cell 
                                                            _floatingLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold "Fun.CapFloor" 
                                               [| _Type.source
                                               ;  _floatingLeg.source
                                               ;  _capRates.source
                                               ;  _floorRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _floatingLeg.cell
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
    [<ExcelFunction(Name="_CapFloor1", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="floatingLeg",Description = "Reference to floatingLeg")>] 
         floatingLeg : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<CapFloorType> Type "Type" true
                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CapFloor1 
                                                            _Type.cell 
                                                            _floatingLeg.cell 
                                                            _strikes.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold "Fun.CapFloor1" 
                                               [| _Type.source
                                               ;  _floatingLeg.source
                                               ;  _strikes.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _floatingLeg.cell
                                ;  _strikes.cell
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
    [<ExcelFunction(Name="_CapFloor_capRates", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CapFloor.source + ".CapRates") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_floatingLeg", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CapFloor.source + ".FloatingLeg") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_floorRates", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CapFloor.source + ".FloorRates") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_getType", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".GetType") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_impliedVolatility", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
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
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                            _Type.cell 
                                                            _displacement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".ImpliedVolatility") 
                                               [| _CapFloor.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               ;  _Type.source
                                               ;  _displacement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _guess.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
                                ;  _Type.cell
                                ;  _displacement.cell
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
    [<ExcelFunction(Name="_CapFloor_impliedVolatility1", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".ImpliedVolatility") 
                                               [| _CapFloor.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _guess.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_CapFloor_isExpired", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".IsExpired") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_lastFloatingRateCoupon", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_CapFloor.source + ".LastFloatingRateCoupon") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_maturityDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".MaturityDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_optionlet", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold (_CapFloor.source + ".Optionlet") 
                                               [| _CapFloor.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_startDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".StartDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_CASH", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".CASH") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_errorEstimate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".ErrorEstimate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_NPV", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".NPV") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_result", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".Result") 
                                               [| _CapFloor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_setPricingEngine", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CapFloor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".SetPricingEngine") 
                                               [| _CapFloor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_valuationDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "Reference to CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor" true 
                let builder () = withMnemonic mnemonic ((_CapFloor.cell :?> CapFloorModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloor.source + ".ValuationDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_Range", Description="Create a range of CapFloor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CapFloor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapFloor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CapFloor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapFloor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CapFloor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
