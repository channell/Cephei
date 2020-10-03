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
  helper class building a sequence of fixed rate coupons
  </summary> *)
[<AutoSerializable(true)>]
module FixedRateLegFunction =

    (*
        constructor
    *)
    [<ExcelFunction(Name="_FixedRateLeg", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let builder () = withMnemonic mnemonic (Fun.FixedRateLeg 
                                                            _schedule.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold "Fun.FixedRateLeg" 
                                               [| _schedule.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        creator
    *)
    [<ExcelFunction(Name="_FixedRateLeg_value", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".Value") 
                                               [| _FixedRateLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
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
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates3", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRates",Description = "Reference to couponRates")>] 
         couponRates : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRates = Helper.toCell<Generic.List<double>> couponRates "couponRates" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates3
                                                            _couponRates.cell 
                                                            _paymentDayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates3") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRates.source
                                               ;  _paymentDayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRates.cell
                                ;  _paymentDayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        other initializers
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates6", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRate",Description = "Reference to couponRate")>] 
         couponRate : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRate = Helper.toCell<double> couponRate "couponRate" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates6
                                                            _couponRate.cell 
                                                            _paymentDayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates6") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRate.source
                                               ;  _paymentDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRate.cell
                                ;  _paymentDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates1", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRate",Description = "Reference to couponRate")>] 
         couponRate : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRate = Helper.toCell<double> couponRate "couponRate" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates1
                                                            _couponRate.cell 
                                                            _paymentDayCounter.cell 
                                                            _comp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates1") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRate.source
                                               ;  _paymentDayCounter.source
                                               ;  _comp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRate.cell
                                ;  _paymentDayCounter.cell
                                ;  _comp.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRate",Description = "Reference to couponRate")>] 
         couponRate : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRate = Helper.toCell<double> couponRate "couponRate" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates
                                                            _couponRate.cell 
                                                            _paymentDayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRate.source
                                               ;  _paymentDayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRate.cell
                                ;  _paymentDayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates7", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRates",Description = "Reference to couponRates")>] 
         couponRates : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRates = Helper.toCell<Generic.List<double>> couponRates "couponRates" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates7
                                                            _couponRates.cell 
                                                            _paymentDayCounter.cell 
                                                            _comp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates7") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRates.source
                                               ;  _paymentDayCounter.source
                                               ;  _comp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRates.cell
                                ;  _paymentDayCounter.cell
                                ;  _comp.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates5", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRate",Description = "Reference to couponRate")>] 
         couponRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRate = Helper.toCell<InterestRate> couponRate "couponRate" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates5
                                                            _couponRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates5") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates4", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRates",Description = "Reference to couponRates")>] 
         couponRates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRates = Helper.toCell<Generic.List<InterestRate>> couponRates "couponRates" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates4
                                                            _couponRates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates4") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRates.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withCouponRates2", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withCouponRates2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="couponRates",Description = "Reference to couponRates")>] 
         couponRates : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _couponRates = Helper.toCell<Generic.List<double>> couponRates "couponRates" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithCouponRates2
                                                            _couponRates.cell 
                                                            _paymentDayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithCouponRates2") 
                                               [| _FixedRateLeg.source
                                               ;  _couponRates.source
                                               ;  _paymentDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _couponRates.cell
                                ;  _paymentDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withExCouponPeriod", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withExCouponPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="period",Description = "Reference to period")>] 
         period : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _period = Helper.toCell<Period> period "period" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toDefault<bool> endOfMonth "endOfMonth" false
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithExCouponPeriod
                                                            _period.cell 
                                                            _cal.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithExCouponPeriod") 
                                               [| _FixedRateLeg.source
                                               ;  _period.source
                                               ;  _cal.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _period.cell
                                ;  _cal.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withFirstPeriodDayCounter", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withFirstPeriodDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithFirstPeriodDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithFirstPeriodDayCounter") 
                                               [| _FixedRateLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withLastPeriodDayCounter", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withLastPeriodDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithLastPeriodDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithLastPeriodDayCounter") 
                                               [| _FixedRateLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withPaymentCalendar", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withPaymentCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithPaymentCalendar
                                                            _cal.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateLeg>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithPaymentCalendar") 
                                               [| _FixedRateLeg.source
                                               ;  _cal.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _cal.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withNotionals1", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithNotionals1") 
                                               [| _FixedRateLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        initializers
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withNotionals", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithNotionals") 
                                               [| _FixedRateLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateLeg_withPaymentAdjustment", Description="Create a FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateLeg",Description = "Reference to FixedRateLeg")>] 
         fixedrateleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateLeg = Helper.toCell<FixedRateLeg> fixedrateleg "FixedRateLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder () = withMnemonic mnemonic ((_FixedRateLeg.cell :?> FixedRateLegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_FixedRateLeg.source + ".WithPaymentAdjustment") 
                                               [| _FixedRateLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FixedRateLeg_Range", Description="Create a range of FixedRateLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FixedRateLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedRateLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedRateLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FixedRateLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
