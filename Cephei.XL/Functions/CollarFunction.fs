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
    [<ExcelFunction(Name="_Collar", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="floatingLeg",Description = "CashFlow range")>] 
         floatingLeg : obj)
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

                let _floatingLeg = Helper.toCell<Generic.List<CashFlow>> floatingLeg "floatingLeg" 
                let _capRates = Helper.toCell<Generic.List<double>> capRates "capRates" 
                let _floorRates = Helper.toCell<Generic.List<double>> floorRates "floorRates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Collar 
                                                            _floatingLeg.cell 
                                                            _capRates.cell 
                                                            _floorRates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Collar>) l

                let source () = Helper.sourceFold "Fun.Collar" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Collar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Collar_atmRate", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_atmRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _discountCurve = Helper.toCell<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).AtmRate
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Collar.source + ".AtmRate") 

                                               [| _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_capRates", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_capRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).CapRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Collar.source + ".CapRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_floatingLeg", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Collar.source + ".FloatingLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_floorRates", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_floorRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).FloorRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Collar.source + ".FloorRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_getType", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).GetType
                                                       ) :> ICell
                let format (o : CapFloorType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".GetType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_impliedVolatility", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
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

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _displacement = Helper.toCell<double> displacement "displacement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).ImpliedVolatility
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

                let source () = Helper.sourceFold (_Collar.source + ".ImpliedVolatility") 

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
    [<ExcelFunction(Name="_Collar_impliedVolatility1", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_impliedVolatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
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

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).ImpliedVolatility1
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _guess.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Collar.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
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
    [<ExcelFunction(Name="_Collar_isExpired", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_lastFloatingRateCoupon", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_lastFloatingRateCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).LastFloatingRateCoupon
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold (_Collar.source + ".LastFloatingRateCoupon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Collar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Collar_maturityDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_optionlet", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_optionlet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).Optionlet
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloor>) l

                let source () = Helper.sourceFold (_Collar.source + ".Optionlet") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Collar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Collar_startDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_CASH", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Collar.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_errorEstimate", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Collar.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_NPV", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Collar.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_result", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_setPricingEngine", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Collar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_valuationDate", Description="Create a Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Collar",Description = "Collar")>] 
         collar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Collar = Helper.toCell<Collar> collar "Collar"  
                let builder (current : ICell) = withMnemonic mnemonic ((CollarModel.Cast _Collar.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Collar.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Collar.cell
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
    [<ExcelFunction(Name="_Collar_Range", Description="Create a range of Collar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Collar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Collar> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<Collar> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<Collar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Collar>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
