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
module IsdaCdsEngineFunction =


    (*
        ! Constructor where the client code is responsible for providing a default curve and an interest rate curve compliant with the ISDA specifications.  To be precisely consistent with the ISDA specification QL_USE_INDEXED_COUPON must not be defined. This is not checked in order not to kill the engine completely in this case.  Furthermore, the ibor index in the swap rate helpers should not provide the evaluation date's fixing.
    *)
    [<ExcelFunction(Name="_IsdaCdsEngine", Description="Create a IsdaCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IsdaCdsEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="probability",Description = "Reference to probability")>] 
         probability : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "Reference to recoveryRate")>] 
         recoveryRate : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="includeSettlementDateFlows",Description = "Reference to includeSettlementDateFlows")>] 
         includeSettlementDateFlows : obj)
        ([<ExcelArgument(Name="numericalFix",Description = "Reference to numericalFix")>] 
         numericalFix : obj)
        ([<ExcelArgument(Name="accrualBias",Description = "Reference to accrualBias")>] 
         accrualBias : obj)
        ([<ExcelArgument(Name="forwardsInCouponPeriod",Description = "Reference to forwardsInCouponPeriod")>] 
         forwardsInCouponPeriod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _probability = Helper.toHandle<DefaultProbabilityTermStructure> probability "probability" 
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _includeSettlementDateFlows = Helper.toNullable<bool> includeSettlementDateFlows "includeSettlementDateFlows"
                let _numericalFix = Helper.toDefault<IsdaCdsEngine.NumericalFix> numericalFix "numericalFix" IsdaCdsEngine.NumericalFix.Taylor
                let _accrualBias = Helper.toDefault<IsdaCdsEngine.AccrualBias> accrualBias "accrualBias" IsdaCdsEngine.AccrualBias.HalfDayBias
                let _forwardsInCouponPeriod = Helper.toDefault<IsdaCdsEngine.ForwardsInCouponPeriod> forwardsInCouponPeriod "forwardsInCouponPeriod" IsdaCdsEngine.ForwardsInCouponPeriod.Piecewise
                let builder () = withMnemonic mnemonic (Fun.IsdaCdsEngine 
                                                            _probability.cell 
                                                            _recoveryRate.cell 
                                                            _discountCurve.cell 
                                                            _includeSettlementDateFlows.cell 
                                                            _numericalFix.cell 
                                                            _accrualBias.cell 
                                                            _forwardsInCouponPeriod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IsdaCdsEngine>) l

                let source = Helper.sourceFold "Fun.IsdaCdsEngine" 
                                               [| _probability.source
                                               ;  _recoveryRate.source
                                               ;  _discountCurve.source
                                               ;  _includeSettlementDateFlows.source
                                               ;  _numericalFix.source
                                               ;  _accrualBias.source
                                               ;  _forwardsInCouponPeriod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _probability.cell
                                ;  _recoveryRate.cell
                                ;  _discountCurve.cell
                                ;  _includeSettlementDateFlows.cell
                                ;  _numericalFix.cell
                                ;  _accrualBias.cell
                                ;  _forwardsInCouponPeriod.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IsdaCdsEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IsdaCdsEngine_isdaCreditCurve", Description="Create a IsdaCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IsdaCdsEngine_isdaCreditCurve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IsdaCdsEngine",Description = "Reference to IsdaCdsEngine")>] 
         isdacdsengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IsdaCdsEngine = Helper.toCell<IsdaCdsEngine> isdacdsengine "IsdaCdsEngine"  
                let builder () = withMnemonic mnemonic ((IsdaCdsEngineModel.Cast _IsdaCdsEngine.cell).IsdaCreditCurve
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<DefaultProbabilityTermStructure>>) l

                let source = Helper.sourceFold (_IsdaCdsEngine.source + ".IsdaCreditCurve") 
                                               [| _IsdaCdsEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IsdaCdsEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IsdaCdsEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IsdaCdsEngine_isdaRateCurve", Description="Create a IsdaCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IsdaCdsEngine_isdaRateCurve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IsdaCdsEngine",Description = "Reference to IsdaCdsEngine")>] 
         isdacdsengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IsdaCdsEngine = Helper.toCell<IsdaCdsEngine> isdacdsengine "IsdaCdsEngine"  
                let builder () = withMnemonic mnemonic ((IsdaCdsEngineModel.Cast _IsdaCdsEngine.cell).IsdaRateCurve
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_IsdaCdsEngine.source + ".IsdaRateCurve") 
                                               [| _IsdaCdsEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IsdaCdsEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IsdaCdsEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_IsdaCdsEngine_Range", Description="Create a range of IsdaCdsEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IsdaCdsEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IsdaCdsEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IsdaCdsEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IsdaCdsEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IsdaCdsEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IsdaCdsEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
