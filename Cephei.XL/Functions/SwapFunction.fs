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
Interest rate swap The cash flows belonging to the first leg are paid; the ones belonging to the second leg are received.
  </summary> *)
[<AutoSerializable(true)>]
module SwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Swap_endDiscounts", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".EndDiscounts") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_engine", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).Engine
                                                       ) :> ICell
                let format (o : Swap.SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".Engine") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_isExpired", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".IsExpired") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_leg", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Swap.source + ".Leg") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_legBPS", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".LegBPS") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_legNPV", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".LegNPV") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_maturityDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Swap.source + ".MaturityDate") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_npvDateDiscount", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".NpvDateDiscount") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_payer", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swap.source + ".Payer") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_startDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Swap.source + ".StartDate") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_startDiscounts", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".StartDiscounts") 
                                               [| _Swap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
        Multi leg constructor.
    *)
    [<ExcelFunction(Name="_Swap", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="legs",Description = "Reference to legs")>] 
         legs : obj)
        ([<ExcelArgument(Name="payer",Description = "Reference to payer")>] 
         payer : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _legs = Helper.toCell<Generic.List<Generic.List<CashFlow>>> legs "legs" true
                let _payer = Helper.toCell<Generic.List<bool>> payer "payer" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.Swap 
                                                            _legs.cell 
                                                            _payer.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swap>) l

                let source = Helper.sourceFold "Fun.Swap" 
                                               [| _legs.source
                                               ;  _payer.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _legs.cell
                                ;  _payer.cell
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
        The cash flows belonging to the first leg are paid the ones belonging to the second leg are received.
    *)
    [<ExcelFunction(Name="_Swap1", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="firstLeg",Description = "Reference to firstLeg")>] 
         firstLeg : obj)
        ([<ExcelArgument(Name="secondLeg",Description = "Reference to secondLeg")>] 
         secondLeg : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _firstLeg = Helper.toCell<Generic.List<CashFlow>> firstLeg "firstLeg" true
                let _secondLeg = Helper.toCell<Generic.List<CashFlow>> secondLeg "secondLeg" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.Swap1 
                                                            _firstLeg.cell 
                                                            _secondLeg.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swap>) l

                let source = Helper.sourceFold "Fun.Swap1" 
                                               [| _firstLeg.source
                                               ;  _secondLeg.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _firstLeg.cell
                                ;  _secondLeg.cell
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
    [<ExcelFunction(Name="_Swap_CASH", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swap.source + ".CASH") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_errorEstimate", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swap.source + ".ErrorEstimate") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_NPV", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Swap.source + ".NPV") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_result", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".Result") 
                                               [| _Swap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_setPricingEngine", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Swap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Swap.source + ".SetPricingEngine") 
                                               [| _Swap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_valuationDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Reference to Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap" true 
                let builder () = withMnemonic mnemonic ((_Swap.cell :?> SwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Swap.source + ".valuationDate") 
                                               [| _Swap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_Range", Description="Create a range of Swap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Swap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Swap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Swap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Swap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Swap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Swap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
