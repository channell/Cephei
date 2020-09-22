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
module FixedLoanFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedLoan_fixedLeg", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FixedLoan.source + ".FixedLeg") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Reference to fixedSchedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "Reference to fixedDayCount")>] 
         fixedDayCount : obj)
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

                let _Type = Helper.toCell<Loan.Type> Type "Type" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" true
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" true
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" true
                let _principalSchedule = Helper.toCell<Schedule> principalSchedule "principalSchedule" true
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FixedLoan 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _fixedSchedule.cell 
                                                            _fixedRate.cell 
                                                            _fixedDayCount.cell 
                                                            _principalSchedule.cell 
                                                            _paymentConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedLoan>) l

                let source = Helper.sourceFold "Fun.FixedLoan" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _fixedSchedule.source
                                               ;  _fixedRate.source
                                               ;  _fixedDayCount.source
                                               ;  _principalSchedule.source
                                               ;  _paymentConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _fixedSchedule.cell
                                ;  _fixedRate.cell
                                ;  _fixedDayCount.cell
                                ;  _principalSchedule.cell
                                ;  _paymentConvention.cell
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
    [<ExcelFunction(Name="_FixedLoan_principalLeg", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_principalLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).PrincipalLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FixedLoan.source + ".PrincipalLeg") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_isExpired", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".IsExpired") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_CASH", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".CASH") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_errorEstimate", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".ErrorEstimate") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_NPV", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".NPV") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_result", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".Result") 
                                               [| _FixedLoan.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_setPricingEngine", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FixedLoan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".SetPricingEngine") 
                                               [| _FixedLoan.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_valuationDate", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "Reference to FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan" true 
                let builder () = withMnemonic mnemonic ((_FixedLoan.cell :?> FixedLoanModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedLoan.source + ".ValuationDate") 
                                               [| _FixedLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_Range", Description="Create a range of FixedLoan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLoan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FixedLoan")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedLoan> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedLoan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedLoan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FixedLoan>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
