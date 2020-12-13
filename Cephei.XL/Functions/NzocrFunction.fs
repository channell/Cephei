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
  %Nzocr (New Zealand official cash rate) rate fixed by the RBNZ.  See <http://www.rbnz.govt.nz/monetary-policy/official-cash-rate-decisions>.
  </summary> *)
[<AutoSerializable(true)>]
module NzocrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Nzocr", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Nzocr 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Nzocr>) l

                let source () = Helper.sourceFold "Fun.Nzocr" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
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
    [<ExcelFunction(Name="_Nzocr_clone", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
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
    [<ExcelFunction(Name="_Nzocr_businessDayConvention", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_endOfMonth", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_forecastFixing1", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_forecastFixing", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_forwardingTermStructure", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
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
    [<ExcelFunction(Name="_Nzocr_maturityDate", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_currency", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Nzocr_dayCounter", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
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
    [<ExcelFunction(Name="_Nzocr_familyName", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_fixing", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_fixingCalendar", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Nzocr_fixingDate", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_fixingDays", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_isValidFixingDate", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_name", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_pastFixing", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_tenor", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Nzocr.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Nzocr> format
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
    [<ExcelFunction(Name="_Nzocr_update", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).Update
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_valueDate", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_addFixing", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_addFixings", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_addFixings1", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_allowsNativeFixings", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_clearFixings", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_registerWith", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_timeSeries", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_unregisterWith", Description="Create a Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Nzocr",Description = "Nzocr")>] 
         nzocr : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Nzocr = Helper.toCell<Nzocr> nzocr "Nzocr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((NzocrModel.Cast _Nzocr.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Nzocr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Nzocr.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Nzocr.cell
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
    [<ExcelFunction(Name="_Nzocr_Range", Description="Create a range of Nzocr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Nzocr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Nzocr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Nzocr> (c)) :> ICell
                let format (i : Cephei.Cell.List<Nzocr>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Nzocr>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
