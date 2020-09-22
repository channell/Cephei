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
module FloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Floor", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_create
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
                let builder () = withMnemonic mnemonic (Fun.Floor 
                                                            _floatingLeg.cell 
                                                            _exerciseRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Floor>) l

                let source = Helper.sourceFold "Fun.Floor" 
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
    [<ExcelFunction(Name="_Floor_atmRate", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Floor.source + ".AtmRate") 
                                               [| _Floor.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_capRates", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Floor.source + ".CapRates") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_floatingLeg", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Floor.source + ".FloatingLeg") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_floorRates", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Floor.source + ".FloorRates") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_getType", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Floor.source + ".GetType") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_impliedVolatility", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
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

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<Handle<YieldTermStructure>> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).ImpliedVolatility
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

                let source = Helper.sourceFold (_Floor.source + ".ImpliedVolatility") 
                                               [| _Floor.source
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
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_impliedVolatility", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
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

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _discountCurve = Helper.toHandle<Handle<YieldTermStructure>> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Floor.source + ".ImpliedVolatility1") 
                                               [| _Floor.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _guess.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_isExpired", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Floor.source + ".IsExpired") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_lastFloatingRateCoupon", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_Floor.source + ".LastFloatingRateCoupon") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_maturityDate", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Floor.source + ".MaturityDate") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_optionlet", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source = Helper.sourceFold (_Floor.source + ".Optionlet") 
                                               [| _Floor.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_startDate", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Floor.source + ".StartDate") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_CASH", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Floor.source + ".CASH") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_errorEstimate", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Floor.source + ".ErrorEstimate") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_NPV", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Floor.source + ".NPV") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_result", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Floor.source + ".Result") 
                                               [| _Floor.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_setPricingEngine", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Floor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Floor.source + ".SetPricingEngine") 
                                               [| _Floor.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_valuationDate", Description="Create a Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Floor",Description = "Reference to Floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Floor = Helper.toCell<Floor> floor "Floor" true 
                let builder () = withMnemonic mnemonic ((_Floor.cell :?> FloorModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Floor.source + ".ValuationDate") 
                                               [| _Floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Floor.cell
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
    [<ExcelFunction(Name="_Floor_Range", Description="Create a range of Floor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Floor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Floor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Floor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Floor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Floor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Floor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
