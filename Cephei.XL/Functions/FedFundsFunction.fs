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
module FedFundsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FedFunds", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.FedFunds 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FedFunds>) l

                let source = Helper.sourceFold "Fun.FedFunds" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_FedFunds_clone", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source = Helper.sourceFold (_FedFunds.source + ".Clone") 
                                               [| _FedFunds.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
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
    [<ExcelFunction(Name="_FedFunds_businessDayConvention", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".BusinessDayConvention") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_endOfMonth", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".EndOfMonth") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_forecastFixing1", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".ForecastFixing") 
                                               [| _FedFunds.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FedFunds_forecastFixing", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".ForecastFixing") 
                                               [| _FedFunds.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_FedFunds_forwardingTermStructure", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_FedFunds.source + ".ForwardingTermStructure") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_FedFunds_maturityDate", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".MaturityDate") 
                                               [| _FedFunds.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_FedFunds_currency", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_FedFunds.source + ".Currency") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FedFunds_dayCounter", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FedFunds.source + ".DayCounter") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
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
    [<ExcelFunction(Name="_FedFunds_familyName", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".FamilyName") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_fixing", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".Fixing") 
                                               [| _FedFunds.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_FedFunds_fixingCalendar", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FedFunds.source + ".FixingCalendar") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FedFunds_fixingDate", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".FixingDate") 
                                               [| _FedFunds.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_FedFunds_fixingDays", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".FixingDays") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_isValidFixingDate", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".IsValidFixingDate") 
                                               [| _FedFunds.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_FedFunds_name", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".Name") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_pastFixing", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".PastFixing") 
                                               [| _FedFunds.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_FedFunds_tenor", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_FedFunds.source + ".Tenor") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FedFunds> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_FedFunds_update", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).Update
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".Update") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_FedFunds_valueDate", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".ValueDate") 
                                               [| _FedFunds.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_FedFunds_addFixing", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".AddFixing") 
                                               [| _FedFunds.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_FedFunds_addFixings", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".AddFixings") 
                                               [| _FedFunds.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_FedFunds_addFixings1", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".AddFixings1") 
                                               [| _FedFunds.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_FedFunds_allowsNativeFixings", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".AllowsNativeFixings") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_FedFunds_clearFixings", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).ClearFixings
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".ClearFixings") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_registerWith", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".RegisterWith") 
                                               [| _FedFunds.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_FedFunds_timeSeries", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".TimeSeries") 
                                               [| _FedFunds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
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
    [<ExcelFunction(Name="_FedFunds_unregisterWith", Description="Create a FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FedFunds",Description = "Reference to FedFunds")>] 
         fedfunds : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FedFunds = Helper.toCell<FedFunds> fedfunds "FedFunds"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_FedFunds.cell :?> FedFundsModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FedFunds) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FedFunds.source + ".UnregisterWith") 
                                               [| _FedFunds.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FedFunds.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FedFunds_Range", Description="Create a range of FedFunds",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FedFunds_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FedFunds")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FedFunds> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FedFunds>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FedFunds>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FedFunds>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
