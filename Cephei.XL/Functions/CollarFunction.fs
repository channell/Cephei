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
module CollarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Collar", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
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

                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" true
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" true
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.Collar 
                                                            _floatingLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Collar>) l

                let source = Helper.sourceFold "Fun.Collar" 
                                               [| _floatingLeg.source
                                               ;  _capRates.source
                                               ;  _floorRates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _floatingLeg.cell
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
    [<ExcelFunction(Name="_Collar_atmRate", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Collar.source + ".AtmRate") 
                                               [| _Collar.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_capRates", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Collar.source + ".CapRates") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_floatingLeg", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Collar.source + ".FloatingLeg") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_floorRates", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Collar.source + ".FloorRates") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_getType", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Collar.source + ".GetType") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_impliedVolatility", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
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

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).ImpliedVolatility
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

                let source = Helper.sourceFold (_Collar.source + ".ImpliedVolatility") 
                                               [| _Collar.source
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
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_impliedVolatility1", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
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

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Collar.source + ".ImpliedVolatility") 
                                               [| _Collar.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_isExpired", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Collar.source + ".IsExpired") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_lastFloatingRateCoupon", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_Collar.source + ".LastFloatingRateCoupon") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_maturityDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Collar.source + ".MaturityDate") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_optionlet", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold (_Collar.source + ".Optionlet") 
                                               [| _Collar.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_startDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Collar.source + ".StartDate") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_CASH", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Collar.source + ".CASH") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_errorEstimate", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Collar.source + ".ErrorEstimate") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_NPV", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Collar.source + ".NPV") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_result", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Collar.source + ".Result") 
                                               [| _Collar.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_setPricingEngine", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Collar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Collar.source + ".SetPricingEngine") 
                                               [| _Collar.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_valuationDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Reference to Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar" true 
                let builder () = withMnemonic mnemonic ((_Collar.cell :?> CollarModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Collar.source + ".ValuationDate") 
                                               [| _Collar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_Range", Description="Create a range of Collar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Collar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Collar")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Collar> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Collar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Collar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Collar>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
