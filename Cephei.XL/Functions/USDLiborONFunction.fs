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
  Overnight %USD %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module USDLiborONFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USDLiborON1", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.USDLiborON1  
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDLiborON>) l

                let source () = Helper.sourceFold "Fun.USDLiborON1" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLiborON", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.USDLiborON ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDLiborON>) l

                let source () = Helper.sourceFold "Fun.USDLiborON" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
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
    [<ExcelFunction(Name="_USDLiborON_businessDayConvention", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".BusinessDayConvention") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_USDLiborON_clone", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".Clone") 
                                               [| _USDLiborON.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLiborON_endOfMonth", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".EndOfMonth") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_forecastFixing1", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".ForecastFixing1") 
                                               [| _USDLiborON.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_USDLiborON_forecastFixing", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".ForecastFixing") 
                                               [| _USDLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_USDLiborON_forwardingTermStructure", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".ForwardingTermStructure") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
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
    [<ExcelFunction(Name="_USDLiborON_maturityDate", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".MaturityDate") 
                                               [| _USDLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_USDLiborON_currency", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".Currency") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLiborON_dayCounter", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".DayCounter") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
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
    [<ExcelFunction(Name="_USDLiborON_familyName", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".FamilyName") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_fixing", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".Fixing") 
                                               [| _USDLiborON.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_USDLiborON_fixingCalendar", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".FixingCalendar") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLiborON_fixingDate", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".FixingDate") 
                                               [| _USDLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_USDLiborON_fixingDays", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".FixingDays") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_isValidFixingDate", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".IsValidFixingDate") 
                                               [| _USDLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_USDLiborON_name", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".Name") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_pastFixing", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".PastFixing") 
                                               [| _USDLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_USDLiborON_tenor", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_USDLiborON.source + ".Tenor") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLiborON> format
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
    [<ExcelFunction(Name="_USDLiborON_update", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).Update
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".Update") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_USDLiborON_valueDate", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".ValueDate") 
                                               [| _USDLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_USDLiborON_addFixing", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".AddFixing") 
                                               [| _USDLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_USDLiborON_addFixings", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".AddFixings") 
                                               [| _USDLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_USDLiborON_addFixings1", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".AddFixings1") 
                                               [| _USDLiborON.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_USDLiborON_allowsNativeFixings", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".AllowsNativeFixings") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_USDLiborON_clearFixings", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).ClearFixings
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".ClearFixings") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_registerWith", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".RegisterWith") 
                                               [| _USDLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_USDLiborON_timeSeries", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".TimeSeries") 
                                               [| _USDLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
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
    [<ExcelFunction(Name="_USDLiborON_unregisterWith", Description="Create a USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLiborON",Description = "Reference to USDLiborON")>] 
         usdliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLiborON = Helper.toCell<USDLiborON> usdliboron "USDLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((USDLiborONModel.Cast _USDLiborON.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USDLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USDLiborON.source + ".UnregisterWith") 
                                               [| _USDLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLiborON.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_USDLiborON_Range", Description="Create a range of USDLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USDLiborON_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the USDLiborON")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USDLiborON> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<USDLiborON>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<USDLiborON>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<USDLiborON>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
