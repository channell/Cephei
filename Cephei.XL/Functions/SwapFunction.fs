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
    [<ExcelFunction(Name="_Swap_endDiscounts", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_engine", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).Engine
                                                       ) :> ICell
                let format (o : Swap.SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_isExpired", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_leg", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Swap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_legBPS", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_legNPV", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_maturityDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_npvDateDiscount", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_payer", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Swap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Swap_startDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_startDiscounts", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
                                ;  _j.cell
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
        Multi leg constructor.
    *)
    [<ExcelFunction(Name="_Swap", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="legs",Description = "CashFlow")>] 
         legs : obj)
        ([<ExcelArgument(Name="payer",Description = "bool")>] 
         payer : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _legs = Helper.toCell<Generic.List<Generic.List<CashFlow>>> legs "legs" 
                let _payer = Helper.toCell<Generic.List<bool>> payer "payer" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Swap 
                                                            _legs.cell 
                                                            _payer.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swap>) l

                let source () = Helper.sourceFold "Fun.Swap" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swap> format
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
    [<ExcelFunction(Name="_Swap1", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Swap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="firstLeg",Description = "CashFlow")>] 
         firstLeg : obj)
        ([<ExcelArgument(Name="secondLeg",Description = "CashFlow")>] 
         secondLeg : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _firstLeg = Helper.toCell<Generic.List<CashFlow>> firstLeg "firstLeg" 
                let _secondLeg = Helper.toCell<Generic.List<CashFlow>> secondLeg "secondLeg" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Swap1 
                                                            _firstLeg.cell 
                                                            _secondLeg.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Swap>) l

                let source () = Helper.sourceFold "Fun.Swap1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Swap_CASH", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Swap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_errorEstimate", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Swap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_NPV", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Swap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_result", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_setPricingEngine", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Swap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_valuationDate", Description="Create a Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Swap",Description = "Swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Swap = Helper.toCell<Swap> swap "Swap"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapModel.Cast _Swap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Swap.source + ".valuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Swap.cell
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
    [<ExcelFunction(Name="_Swap_Range", Description="Create a range of Swap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Swap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Swap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Swap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Swap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Swap>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
