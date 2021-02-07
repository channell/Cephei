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
module CapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Cap", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="floatingLeg",Description = "CashFlow range")>] 
         floatingLeg : obj)
        ([<ExcelArgument(Name="exerciseRates",Description = "double range")>] 
         exerciseRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" 
                let _exerciseRates = Helper.toCell<Generic.List<double>> exerciseRates "exerciseRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.Cap 
                                                            _floatingLeg.cell 
                                                            _exerciseRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cap>) l

                let source () = Helper.sourceFold "Fun.Cap" 
                                               [| _floatingLeg.source
                                               ;  _exerciseRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _floatingLeg.cell
                                ;  _exerciseRates.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cap_atmRate", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cap.source + ".AtmRate") 

                                               [| _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_capRates", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Cap.source + ".CapRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_floatingLeg", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_Cap.source + ".FloatingLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_floorRates", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Cap.source + ".FloorRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_getType", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".GetType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_impliedVolatility", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
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
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="displacement",Description = "double")>] 
         displacement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _displacement = Helper.toCell<double> displacement "displacement" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).ImpliedVolatility
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

                let source () = Helper.sourceFold (_Cap.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
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
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_impliedVolatility1", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
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

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cap.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_isExpired", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_lastFloatingRateCoupon", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold (_Cap.source + ".LastFloatingRateCoupon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cap_maturityDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_optionlet", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source () = Helper.sourceFold (_Cap.source + ".Optionlet") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cap_startDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_CASH", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_errorEstimate", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_NPV", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_result", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_setPricingEngine", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Cap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_valuationDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap"  
                let builder (current : ICell) = ((CapModel.Cast _Cap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Cap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_Range", Description="Create a range of Cap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Cap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Cap> (c)) :> ICell
                let format (i : Cephei.Cell.List<Cap>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Cap>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
