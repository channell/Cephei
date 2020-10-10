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
module FloatingLoanFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingLoan_floatingLeg", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingLoan.source + ".FloatingLeg") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="floatingSchedule",Description = "Reference to floatingSchedule")>] 
         floatingSchedule : obj)
        ([<ExcelArgument(Name="floatingSpread",Description = "Reference to floatingSpread")>] 
         floatingSpread : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "Reference to floatingDayCount")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="principalSchedule",Description = "Reference to principalSchedule")>] 
         principalSchedule : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Loan.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _floatingSchedule = Helper.toCell<Schedule> floatingSchedule "floatingSchedule" 
                let _floatingSpread = Helper.toCell<double> floatingSpread "floatingSpread" 
                let _floatingDayCount = Helper.toCell<DayCounter> floatingDayCount "floatingDayCount" 
                let _principalSchedule = Helper.toCell<Schedule> principalSchedule "principalSchedule" 
                let _paymentConvention = Helper.toNullable<BusinessDayConvention> paymentConvention "paymentConvention"
                let _index = Helper.toCell<IborIndex> index "index" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingLoan 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _floatingSchedule.cell 
                                                            _floatingSpread.cell 
                                                            _floatingDayCount.cell 
                                                            _principalSchedule.cell 
                                                            _paymentConvention.cell 
                                                            _index.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLoan>) l

                let source () = Helper.sourceFold "Fun.FloatingLoan" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _floatingSchedule.source
                                               ;  _floatingSpread.source
                                               ;  _floatingDayCount.source
                                               ;  _principalSchedule.source
                                               ;  _paymentConvention.source
                                               ;  _index.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _floatingSchedule.cell
                                ;  _floatingSpread.cell
                                ;  _floatingDayCount.cell
                                ;  _principalSchedule.cell
                                ;  _paymentConvention.cell
                                ;  _index.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingLoan> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingLoan_principalLeg", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_principalLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).PrincipalLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingLoan.source + ".PrincipalLeg") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_isExpired", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".IsExpired") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_CASH", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".CASH") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_errorEstimate", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".ErrorEstimate") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_NPV", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".NPV") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_result", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".Result") 
                                               [| _FloatingLoan.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_setPricingEngine", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatingLoan) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".SetPricingEngine") 
                                               [| _FloatingLoan.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_valuationDate", Description="Create a FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingLoan",Description = "Reference to FloatingLoan")>] 
         floatingloan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingLoan = Helper.toCell<FloatingLoan> floatingloan "FloatingLoan"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingLoanModel.Cast _FloatingLoan.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingLoan.source + ".ValuationDate") 
                                               [| _FloatingLoan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingLoan.cell
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
    [<ExcelFunction(Name="_FloatingLoan_Range", Description="Create a range of FloatingLoan",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingLoan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloatingLoan")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingLoan> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatingLoan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatingLoan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FloatingLoan>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
