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
  LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.
  </summary> *)
[<AutoSerializable(true)>]
module LiborFunction =

    (*
        Other methods
    *)
    [<ExcelFunction(Name="_Libor_clone", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Libor.source + ".Clone") 
                                               [| _Libor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Libor", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="financialCenterCalendar",Description = "Reference to financialCenterCalendar")>] 
         financialCenterCalendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _financialCenterCalendar = Helper.toCell<Calendar> financialCenterCalendar "financialCenterCalendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Libor 
                                                            _familyName.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _financialCenterCalendar.cell 
                                                            _dayCounter.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Libor>) l

                let source = Helper.sourceFold "Fun.Libor" 
                                               [| _familyName.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _financialCenterCalendar.source
                                               ;  _dayCounter.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _financialCenterCalendar.cell
                                ;  _dayCounter.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Libor_maturityDate", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Libor.source + ".MaturityDate") 
                                               [| _Libor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_Libor_valueDate", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Libor.source + ".ValueDate") 
                                               [| _Libor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Libor_businessDayConvention", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".BusinessDayConvention") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_endOfMonth", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".EndOfMonth") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_forecastFixing1", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Libor.source + ".ForecastFixing1") 
                                               [| _Libor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_forecastFixing", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Libor.source + ".ForecastFixing") 
                                               [| _Libor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_forwardingTermStructure", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Libor.source + ".ForwardingTermStructure") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Libor_currency", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Libor.source + ".Currency") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Libor_dayCounter", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Libor.source + ".DayCounter") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
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
    [<ExcelFunction(Name="_Libor_familyName", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".FamilyName") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_fixing", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Libor.source + ".Fixing") 
                                               [| _Libor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_fixingCalendar", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Libor.source + ".FixingCalendar") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Libor_fixingDate", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Libor.source + ".FixingDate") 
                                               [| _Libor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_fixingDays", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Libor.source + ".FixingDays") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_isValidFixingDate", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".IsValidFixingDate") 
                                               [| _Libor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_name", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".Name") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_pastFixing", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".PastFixing") 
                                               [| _Libor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_tenor", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Libor.source + ".Tenor") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Libor> format
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
    [<ExcelFunction(Name="_Libor_update", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).Update
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".Update") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_addFixing", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".AddFixing") 
                                               [| _Libor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_addFixings", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".AddFixings") 
                                               [| _Libor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_addFixings1", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".AddFixings1") 
                                               [| _Libor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_allowsNativeFixings", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".AllowsNativeFixings") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_clearFixings", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".ClearFixings") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_registerWith", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".RegisterWith") 
                                               [| _Libor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_timeSeries", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".TimeSeries") 
                                               [| _Libor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_unregisterWith", Description="Create a Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Libor",Description = "Reference to Libor")>] 
         libor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Libor = Helper.toCell<Libor> libor "Libor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Libor.cell :?> LiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Libor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Libor.source + ".UnregisterWith") 
                                               [| _Libor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Libor.cell
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
    [<ExcelFunction(Name="_Libor_Range", Description="Create a range of Libor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Libor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Libor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Libor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Libor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Libor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Libor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
