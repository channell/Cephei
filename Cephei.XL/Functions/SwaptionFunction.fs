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
  instruments  - the correctness of the returned value is tested by checking that the price of a payer (resp. receiver) swaption decreases (resp. increases) with the strike. - the correctness of the returned value is tested by checking that the price of a payer (resp. receiver) swaption increases (resp. decreases) with the spread. - the correctness of the returned value is tested by checking it against that of a swaption on a swap with no spread and a correspondingly adjusted fixed rate. - the correctness of the returned value is tested by checking it against a known good value. - the correctness of the returned value of cash settled swaptions is tested by checking the modified annuity against a value calculated without using the Swaption class.   add greeks and explicit exercise lag
  </summary> *)
[<AutoSerializable(true)>]
module SwaptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Swaption_engine", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Engine
                                                       ) :> ICell
                let format (o : SwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".Engine") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
        ! implied volatility
    *)
    [<ExcelFunction(Name="_Swaption_impliedVolatility", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
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

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _guess = Helper.toCell<double> guess "guess" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _displacement = Helper.toNullable<double> displacement "displacement"
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).ImpliedVolatility
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

                let source = Helper.sourceFold (_Swaption.source + ".ImpliedVolatility") 
                                               [| _Swaption.source
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
                                [| _Swaption.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_Swaption_isExpired", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".IsExpired") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_settlementMethod", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_settlementMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).SettlementMethod
                                                       ) :> ICell
                let format (o : Settlement.Method) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".SettlementMethod") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_settlementType", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_settlementType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).SettlementType
                                                       ) :> ICell
                let format (o : Settlement.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".SettlementType") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "Reference to swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="delivery",Description = "Reference to delivery")>] 
         delivery : obj)
        ([<ExcelArgument(Name="settlementMethod",Description = "Reference to settlementMethod")>] 
         settlementMethod : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swap = Helper.toCell<VanillaSwap> swap "swap" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _delivery = Helper.toDefault<Settlement.Type> delivery "delivery" Settlement.Type.Physical
                let _settlementMethod = Helper.toDefault<Settlement.Method> settlementMethod "settlementMethod" Settlement.Method.PhysicalOTC
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.Swaption 
                                                            _swap.cell 
                                                            _exercise.cell 
                                                            _delivery.cell 
                                                            _settlementMethod.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swaption>) l

                let source = Helper.sourceFold "Fun.Swaption" 
                                               [| _swap.source
                                               ;  _exercise.source
                                               ;  _delivery.source
                                               ;  _settlementMethod.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swap.cell
                                ;  _exercise.cell
                                ;  _delivery.cell
                                ;  _settlementMethod.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swaption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Swaption_type", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Type
                                                       ) :> ICell
                let format (o : VanillaSwap.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".TYPE") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_underlyingSwap", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).UnderlyingSwap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_Swaption.source + ".UnderlyingSwap") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swaption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Swaption_validate", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_validate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Validate
                                                       ) :> ICell
                let format (o : Swaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".Validate") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_exercise", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_Swaption.source + ".Exercise") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swaption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Swaption_payoff", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_Swaption.source + ".Payoff") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swaption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Swaption_CASH", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swaption.source + ".CASH") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_errorEstimate", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swaption.source + ".ErrorEstimate") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_NPV", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swaption.source + ".NPV") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_result", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".Result") 
                                               [| _Swaption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_setPricingEngine", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Swaption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".SetPricingEngine") 
                                               [| _Swaption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_valuationDate", Description="Create a Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swaption",Description = "Reference to Swaption")>] 
         swaption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swaption = Helper.toCell<Swaption> swaption "Swaption"  
                let builder () = withMnemonic mnemonic ((_Swaption.cell :?> SwaptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Swaption.source + ".ValuationDate") 
                                               [| _Swaption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swaption.cell
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
    [<ExcelFunction(Name="_Swaption_Range", Description="Create a range of Swaption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swaption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Swaption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Swaption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Swaption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Swaption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Swaption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
