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
  %CHF %ZIBOR rate   Zurich Interbank Offered Rate.  This is the rate fixed in Zurich by BBA. Use CHFLibor if you're interested in the London fixing by BBA.  check settlement days, end-of-month adjustment, and day-count convention.
  </summary> *)
[<AutoSerializable(true)>]
module ZiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Zibor", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Zibor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Zibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Zibor>) l

                let source () = Helper.sourceFold "Fun.Zibor" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Zibor1", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Zibor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Zibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Zibor>) l

                let source () = Helper.sourceFold "Fun.Zibor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
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
    [<ExcelFunction(Name="_Zibor_businessDayConvention", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".BusinessDayConvention") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_clone", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_Zibor.source + ".Clone") 
                                               [| _Zibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Zibor_endOfMonth", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".EndOfMonth") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_forecastFixing1", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".ForecastFixing") 
                                               [| _Zibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_forecastFixing", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".ForecastFixing") 
                                               [| _Zibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_forwardingTermStructure", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_Zibor.source + ".ForwardingTermStructure") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
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
    [<ExcelFunction(Name="_Zibor_maturityDate", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".MaturityDate") 
                                               [| _Zibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_currency", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Zibor.source + ".Currency") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Zibor_dayCounter", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Zibor.source + ".DayCounter") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
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
    [<ExcelFunction(Name="_Zibor_familyName", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".FamilyName") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_fixing", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".Fixing") 
                                               [| _Zibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_fixingCalendar", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Zibor.source + ".FixingCalendar") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Zibor_fixingDate", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".FixingDate") 
                                               [| _Zibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_fixingDays", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".FixingDays") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_isValidFixingDate", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".IsValidFixingDate") 
                                               [| _Zibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_name", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".Name") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_pastFixing", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".PastFixing") 
                                               [| _Zibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_tenor", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Zibor.source + ".Tenor") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Zibor> format
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
    [<ExcelFunction(Name="_Zibor_update", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).Update
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".Update") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_valueDate", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".ValueDate") 
                                               [| _Zibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_addFixing", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".AddFixing") 
                                               [| _Zibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_addFixings", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".AddFixings") 
                                               [| _Zibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_addFixings1", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".AddFixings1") 
                                               [| _Zibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_allowsNativeFixings", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".AllowsNativeFixings") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_clearFixings", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".ClearFixings") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_registerWith", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".RegisterWith") 
                                               [| _Zibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_timeSeries", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".TimeSeries") 
                                               [| _Zibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_unregisterWith", Description="Create a Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Zibor",Description = "Zibor")>] 
         zibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Zibor = Helper.toCell<Zibor> zibor "Zibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZiborModel.Cast _Zibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Zibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Zibor.source + ".UnregisterWith") 
                                               [| _Zibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Zibor.cell
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
    [<ExcelFunction(Name="_Zibor_Range", Description="Create a range of Zibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Zibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Zibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Zibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Zibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Zibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
