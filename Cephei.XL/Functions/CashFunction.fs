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
module CashFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Cash", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="principalSchedule",Description = "Reference to principalSchedule")>] 
         principalSchedule : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Loan.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _principalSchedule = Helper.toCell<Schedule> principalSchedule "principalSchedule" 
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.Cash 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _principalSchedule.cell 
                                                            _paymentConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cash>) l

                let source = Helper.sourceFold "Fun.Cash" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _principalSchedule.source
                                               ;  _paymentConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _principalSchedule.cell
                                ;  _paymentConvention.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cash> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cash_principalLeg", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_principalLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).PrincipalLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Cash.source + ".PrincipalLeg") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_Cash_isExpired", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cash.source + ".IsExpired") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_CASH", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cash.source + ".CASH") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_errorEstimate", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cash.source + ".ErrorEstimate") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_NPV", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cash.source + ".NPV") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_result", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cash.source + ".Result") 
                                               [| _Cash.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_setPricingEngine", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Cash) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cash.source + ".SetPricingEngine") 
                                               [| _Cash.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_valuationDate", Description="Create a Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cash",Description = "Reference to Cash")>] 
         cash : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cash = Helper.toCell<Cash> cash "Cash"  
                let builder () = withMnemonic mnemonic ((_Cash.cell :?> CashModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cash.source + ".ValuationDate") 
                                               [| _Cash.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cash.cell
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
    [<ExcelFunction(Name="_Cash_Range", Description="Create a range of Cash",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cash_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Cash")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Cash> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Cash>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Cash>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Cash>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
