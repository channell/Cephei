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
  Euribor rate adjusted for the mismatch between the actual/360 convention used for Euribor and the actual/365 convention previously used by a few pre-EUR currencies.
  </summary> *)
[<AutoSerializable(true)>]
module Euribor365Function =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor3651", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.Euribor3651 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor365>) l

                let source = Helper.sourceFold "Fun.Euribor365" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Euribor365 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor365>) l

                let source = Helper.sourceFold "Fun.Euribor3651" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_businessDayConvention", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".BusinessDayConvention") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Euribor365_clone", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Euribor365.source + ".Clone") 
                                               [| _Euribor365.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_endOfMonth", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".EndOfMonth") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forecastFixing1", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".ForecastFixing1") 
                                               [| _Euribor365.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forecastFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".ForecastFixing") 
                                               [| _Euribor365.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forwardingTermStructure", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Euribor365.source + ".ForwardingTermStructure") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_maturityDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".MaturityDate") 
                                               [| _Euribor365.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_currency", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Euribor365.source + ".Currency") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_dayCounter", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Euribor365.source + ".DayCounter") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_familyName", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".FamilyName") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".Fixing") 
                                               [| _Euribor365.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixingCalendar", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Euribor365.source + ".FixingCalendar") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_fixingDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".FixingDate") 
                                               [| _Euribor365.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixingDays", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".FixingDays") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_isValidFixingDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".IsValidFixingDate") 
                                               [| _Euribor365.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_name", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".Name") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_pastFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".PastFixing") 
                                               [| _Euribor365.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_tenor", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Euribor365.source + ".Tenor") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_update", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Update
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".Update") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_valueDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".ValueDate") 
                                               [| _Euribor365.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".AddFixing") 
                                               [| _Euribor365.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".AddFixings") 
                                               [| _Euribor365.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixings1", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".AddFixings1") 
                                               [| _Euribor365.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_allowsNativeFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".AllowsNativeFixings") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_clearFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".ClearFixings") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_registerWith", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".RegisterWith") 
                                               [| _Euribor365.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_timeSeries", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".TimeSeries") 
                                               [| _Euribor365.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_unregisterWith", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Reference to Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor365.source + ".UnregisterWith") 
                                               [| _Euribor365.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_Range", Description="Create a range of Euribor365",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor365_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Euribor365")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor365> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Euribor365>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Euribor365>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Euribor365>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
