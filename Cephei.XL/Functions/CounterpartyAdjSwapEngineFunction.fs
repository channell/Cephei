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
  Bilateral (CVA and DVA) default adjusted vanilla swap pricing engine. Collateral is not considered. No wrong way risk is considered (rates and counterparty default are uncorrelated). Based on: Sorensen,  E.H.  and  Bollier,  T.F.,  Pricing  swap  default risk. Financial Analysts Journal, 1994, 50, 23–33 Also see sect. II-5 in: Risk Neutral Pricing of Counterparty Risk D. Brigo, M. Masetti, 2004 or in sections 3 and 4 of "A Formula for Interest Rate Swaps Valuation under Counterparty Risk in presence of Netting Agreements" D. Brigo and M. Masetti; May 4, 2005  to do: Compute fair rate through iteration instead of the current approximation . to do: write Issuer based constructors (event type) to do: Check consistency between option engine discount and the one given
  </summary> *)
[<AutoSerializable(true)>]
module CounterpartyAdjSwapEngineFunction =


    (*
        ! Creates an engine with a black volatility model for the exposure. The volatility is given as a quote. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param blackVol Black volatility used in the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
    *)
    [<ExcelFunction(Name="_CounterpartyAdjSwapEngine", Description="Create a CounterpartyAdjSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CounterpartyAdjSwapEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="blackVol",Description = "Reference to blackVol")>] 
         blackVol : obj)
        ([<ExcelArgument(Name="ctptyDTS",Description = "Reference to ctptyDTS")>] 
         ctptyDTS : obj)
        ([<ExcelArgument(Name="ctptyRecoveryRate",Description = "Reference to ctptyRecoveryRate")>] 
         ctptyRecoveryRate : obj)
        ([<ExcelArgument(Name="invstDTS",Description = "Reference to invstDTS")>] 
         invstDTS : obj)
        ([<ExcelArgument(Name="invstRecoveryRate",Description = "Reference to invstRecoveryRate")>] 
         invstRecoveryRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _blackVol = Helper.toHandle<Quote> blackVol "blackVol" 
                let _ctptyDTS = Helper.toHandle<DefaultProbabilityTermStructure> ctptyDTS "ctptyDTS" 
                let _ctptyRecoveryRate = Helper.toCell<double> ctptyRecoveryRate "ctptyRecoveryRate" 
                let _invstDTS = Helper.toHandle<DefaultProbabilityTermStructure> invstDTS "invstDTS" 
                let _invstRecoveryRate = Helper.toDefault<double> invstRecoveryRate "invstRecoveryRate" 0.999
                let builder () = withMnemonic mnemonic (Fun.CounterpartyAdjSwapEngine 
                                                            _discountCurve.cell 
                                                            _blackVol.cell 
                                                            _ctptyDTS.cell 
                                                            _ctptyRecoveryRate.cell 
                                                            _invstDTS.cell 
                                                            _invstRecoveryRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CounterpartyAdjSwapEngine>) l

                let source = Helper.sourceFold "Fun.CounterpartyAdjSwapEngine" 
                                               [| _discountCurve.source
                                               ;  _blackVol.source
                                               ;  _ctptyDTS.source
                                               ;  _ctptyRecoveryRate.source
                                               ;  _invstDTS.source
                                               ;  _invstRecoveryRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _blackVol.cell
                                ;  _ctptyDTS.cell
                                ;  _ctptyRecoveryRate.cell
                                ;  _invstDTS.cell
                                ;  _invstRecoveryRate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CounterpartyAdjSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Creates an engine with a black volatility model for the exposure. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param blackVol Black volatility used in the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
    *)
    [<ExcelFunction(Name="_CounterpartyAdjSwapEngine1", Description="Create a CounterpartyAdjSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CounterpartyAdjSwapEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="blackVol",Description = "Reference to blackVol")>] 
         blackVol : obj)
        ([<ExcelArgument(Name="ctptyDTS",Description = "Reference to ctptyDTS")>] 
         ctptyDTS : obj)
        ([<ExcelArgument(Name="ctptyRecoveryRate",Description = "Reference to ctptyRecoveryRate")>] 
         ctptyRecoveryRate : obj)
        ([<ExcelArgument(Name="invstDTS",Description = "Reference to invstDTS")>] 
         invstDTS : obj)
        ([<ExcelArgument(Name="invstRecoveryRate",Description = "Reference to invstRecoveryRate")>] 
         invstRecoveryRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _blackVol = Helper.toCell<double> blackVol "blackVol" 
                let _ctptyDTS = Helper.toHandle<DefaultProbabilityTermStructure> ctptyDTS "ctptyDTS" 
                let _ctptyRecoveryRate = Helper.toCell<double> ctptyRecoveryRate "ctptyRecoveryRate" 
                let _invstDTS = Helper.toHandle<DefaultProbabilityTermStructure> invstDTS "invstDTS" 
                let _invstRecoveryRate = Helper.toDefault<double> invstRecoveryRate "invstRecoveryRate" 0.999
                let builder () = withMnemonic mnemonic (Fun.CounterpartyAdjSwapEngine1 
                                                            _discountCurve.cell 
                                                            _blackVol.cell 
                                                            _ctptyDTS.cell 
                                                            _ctptyRecoveryRate.cell 
                                                            _invstDTS.cell 
                                                            _invstRecoveryRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CounterpartyAdjSwapEngine>) l

                let source = Helper.sourceFold "Fun.CounterpartyAdjSwapEngine1" 
                                               [| _discountCurve.source
                                               ;  _blackVol.source
                                               ;  _ctptyDTS.source
                                               ;  _ctptyRecoveryRate.source
                                               ;  _invstDTS.source
                                               ;  _invstRecoveryRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _blackVol.cell
                                ;  _ctptyDTS.cell
                                ;  _ctptyRecoveryRate.cell
                                ;  _invstDTS.cell
                                ;  _invstRecoveryRate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CounterpartyAdjSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Creates the engine from an arbitrary swaption engine. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param swaptionEngine Determines the volatility and thus the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
    *)
    [<ExcelFunction(Name="_CounterpartyAdjSwapEngine2", Description="Create a CounterpartyAdjSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CounterpartyAdjSwapEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="swaptionEngine",Description = "Reference to swaptionEngine")>] 
         swaptionEngine : obj)
        ([<ExcelArgument(Name="ctptyDTS",Description = "Reference to ctptyDTS")>] 
         ctptyDTS : obj)
        ([<ExcelArgument(Name="ctptyRecoveryRate",Description = "Reference to ctptyRecoveryRate")>] 
         ctptyRecoveryRate : obj)
        ([<ExcelArgument(Name="invstDTS",Description = "Reference to invstDTS")>] 
         invstDTS : obj)
        ([<ExcelArgument(Name="invstRecoveryRate",Description = "Reference to invstRecoveryRate")>] 
         invstRecoveryRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _swaptionEngine = Helper.toHandle<IPricingEngine> swaptionEngine "swaptionEngine" 
                let _ctptyDTS = Helper.toHandle<DefaultProbabilityTermStructure> ctptyDTS "ctptyDTS" 
                let _ctptyRecoveryRate = Helper.toCell<double> ctptyRecoveryRate "ctptyRecoveryRate" 
                let _invstDTS = Helper.toHandle<DefaultProbabilityTermStructure> invstDTS "invstDTS" 
                let _invstRecoveryRate = Helper.toDefault<double> invstRecoveryRate "invstRecoveryRate" 0.999
                let builder () = withMnemonic mnemonic (Fun.CounterpartyAdjSwapEngine2 
                                                            _discountCurve.cell 
                                                            _swaptionEngine.cell 
                                                            _ctptyDTS.cell 
                                                            _ctptyRecoveryRate.cell 
                                                            _invstDTS.cell 
                                                            _invstRecoveryRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CounterpartyAdjSwapEngine>) l

                let source = Helper.sourceFold "Fun.CounterpartyAdjSwapEngine2" 
                                               [| _discountCurve.source
                                               ;  _swaptionEngine.source
                                               ;  _ctptyDTS.source
                                               ;  _ctptyRecoveryRate.source
                                               ;  _invstDTS.source
                                               ;  _invstRecoveryRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _swaptionEngine.cell
                                ;  _ctptyDTS.cell
                                ;  _ctptyRecoveryRate.cell
                                ;  _invstDTS.cell
                                ;  _invstRecoveryRate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CounterpartyAdjSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CounterpartyAdjSwapEngine_Range", Description="Create a range of CounterpartyAdjSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CounterpartyAdjSwapEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CounterpartyAdjSwapEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CounterpartyAdjSwapEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CounterpartyAdjSwapEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CounterpartyAdjSwapEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CounterpartyAdjSwapEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
