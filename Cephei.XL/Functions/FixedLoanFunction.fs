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
    [<ExcelFunction(Name="_FixedLoan_fixedLeg", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FixedLoan.source + ".FixedLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedLoan")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Loan.Type: Deposit, Loan")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Schedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="principalSchedule",Description = "Schedule")>] 
         principalSchedule : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Loan.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _principalSchedule = Helper.toCell<Schedule> principalSchedule "principalSchedule" 
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedLoan 
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

                let source () = Helper.sourceFold "Fun.FixedLoan" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLoan> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedLoan_principalLeg", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_principalLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).PrincipalLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FixedLoan.source + ".PrincipalLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_FixedLoan_isExpired", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_CASH", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_errorEstimate", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_NPV", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_result", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_setPricingEngine", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FixedLoan) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_valuationDate", Description="Create a FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLoan",Description = "FixedLoan")>] 
         fixedloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLoan = Helper.toCell<FixedLoan> fixedloan "FixedLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedLoanModel.Cast _FixedLoan.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedLoan.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedLoan.cell
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
    [<ExcelFunction(Name="_FixedLoan_Range", Description="Create a range of FixedLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedLoan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedLoan> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedLoan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedLoan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FixedLoan>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
