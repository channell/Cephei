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
    [<ExcelFunction(Name="_Cap", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="floatingLeg",Description = "Reference to floatingLeg")>] 
         floatingLeg : obj)
        ([<ExcelArgument(Name="exerciseRates",Description = "Reference to exerciseRates")>] 
         exerciseRates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" true
                let _exerciseRates = Helper.toCell<Generic.List<double>> exerciseRates "exerciseRates" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.Cap 
                                                            _floatingLeg.cell 
                                                            _exerciseRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cap>) l

                let source = Helper.sourceFold "Fun.Cap" 
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
    [<ExcelFunction(Name="_Cap_atmRate", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cap.source + ".AtmRate") 
                                               [| _Cap.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_capRates", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Cap.source + ".CapRates") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_floatingLeg", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Cap.source + ".FloatingLeg") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_floorRates", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Cap.source + ".FloorRates") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_getType", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cap.source + ".GetType") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_impliedVolatility", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
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

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).ImpliedVolatility
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

                let source = Helper.sourceFold (_Cap.source + ".ImpliedVolatility") 
                                               [| _Cap.source
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
    [<ExcelFunction(Name="_Cap_impliedVolatility1", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
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

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cap.source + ".ImpliedVolatility") 
                                               [| _Cap.source
                                               ;  _targetValue.source
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
    [<ExcelFunction(Name="_Cap_isExpired", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cap.source + ".IsExpired") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_lastFloatingRateCoupon", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_Cap.source + ".LastFloatingRateCoupon") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_maturityDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cap.source + ".MaturityDate") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_optionlet", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold (_Cap.source + ".Optionlet") 
                                               [| _Cap.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_startDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cap.source + ".StartDate") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_CASH", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cap.source + ".CASH") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_errorEstimate", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cap.source + ".ErrorEstimate") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_NPV", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cap.source + ".NPV") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_result", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cap.source + ".Result") 
                                               [| _Cap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_setPricingEngine", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Cap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cap.source + ".SetPricingEngine") 
                                               [| _Cap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_valuationDate", Description="Create a Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cap",Description = "Reference to Cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cap = Helper.toCell<Cap> cap "Cap" true 
                let builder () = withMnemonic mnemonic ((_Cap.cell :?> CapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cap.source + ".ValuationDate") 
                                               [| _Cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cap.cell
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
    [<ExcelFunction(Name="_Cap_Range", Description="Create a range of Cap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Cap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Cap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Cap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Cap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Cap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
