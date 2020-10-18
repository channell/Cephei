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
    [<ExcelFunction(Name="_CapFloor_atmRate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CapFloor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".AtmRate") 
                                               [| _CapFloor.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CapFloor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "CapFloorType")>] 
         Type : obj)
        ([<ExcelArgument(Name="floatingLeg",Description = "CashFlow")>] 
         floatingLeg : obj)
        ([<ExcelArgument(Name="capRates",Description = "double")>] 
         capRates : obj)
        ([<ExcelArgument(Name="floorRates",Description = "double")>] 
         floorRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<CapFloorType> Type "Type" 
                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" 
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" 
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloor 
                                                            _Type.cell 
                                                            _floatingLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source () = Helper.sourceFold "Fun.CapFloor" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapFloor1", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "CapFloor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "CapFloorType")>] 
         Type : obj)
        ([<ExcelArgument(Name="floatingLeg",Description = "CashFlow")>] 
         floatingLeg : obj)
        ([<ExcelArgument(Name="strikes",Description = "double")>] 
         strikes : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<CapFloorType> Type "Type" 
                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloor1 
                                                            _Type.cell 
                                                            _floatingLeg.cell 
                                                            _strikes.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source () = Helper.sourceFold "Fun.CapFloor1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapFloor_capRates", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CapFloor.source + ".CapRates") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_floatingLeg", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CapFloor.source + ".FloatingLeg") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_floorRates", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CapFloor.source + ".FloorRates") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_getType", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".GetType") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_impliedVolatility", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
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
        ([<ExcelArgument(Name="Type",Description = "VolatilityType")>] 
         Type : obj)
        ([<ExcelArgument(Name="displacement",Description = "double")>] 
         displacement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _displacement = Helper.toCell<double> displacement "displacement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).ImpliedVolatility
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

                let source () = Helper.sourceFold (_CapFloor.source + ".ImpliedVolatility") 
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
    [<ExcelFunction(Name="_CapFloor_impliedVolatility1", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="guess",Description = "double")>] 
         guess : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".ImpliedVolatility") 
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
    [<ExcelFunction(Name="_CapFloor_isExpired", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".IsExpired") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_lastFloatingRateCoupon", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingRateCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold (_CapFloor.source + ".LastFloatingRateCoupon") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapFloor_maturityDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CapFloor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".MaturityDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_optionlet", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "CapFloor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source () = Helper.sourceFold (_CapFloor.source + ".Optionlet") 
                                               [| _CapFloor.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapFloor_startDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".StartDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_CASH", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".CASH") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_errorEstimate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".ErrorEstimate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_NPV", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".NPV") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_result", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".Result") 
                                               [| _CapFloor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_setPricingEngine", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".SetPricingEngine") 
                                               [| _CapFloor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_valuationDate", Description="Create a CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloor",Description = "CapFloor")>] 
         capfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloor = Helper.toCell<CapFloor> capfloor "CapFloor"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorModel.Cast _CapFloor.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloor.source + ".ValuationDate") 
                                               [| _CapFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloor.cell
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
    [<ExcelFunction(Name="_CapFloor_Range", Description="Create a range of CapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapFloor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CapFloor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapFloor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CapFloor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
