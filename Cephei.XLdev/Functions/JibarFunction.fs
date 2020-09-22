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
  %JIBAR rate   Johannesburg Interbank Agreed Rate  check settlement days and day-count convention.
  </summary> *)
[<AutoSerializable(true)>]
module JibarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Jibar", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Jibar 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Jibar>) l

                let source = Helper.sourceFold "Fun.Jibar" 
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
    [<ExcelFunction(Name="_Jibar1", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.Jibar1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Jibar>) l

                let source = Helper.sourceFold "Fun.Jibar1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Jibar_businessDayConvention", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".BusinessDayConvention") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_clone", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Jibar.source + ".Clone") 
                                               [| _Jibar.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
                                ;  _forwarding.cell
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
    [<ExcelFunction(Name="_Jibar_endOfMonth", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".EndOfMonth") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_forecastFixing", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Jibar.source + ".ForecastFixing") 
                                               [| _Jibar.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_forecastFixing", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Jibar.source + ".ForecastFixing1") 
                                               [| _Jibar.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_forwardingTermStructure", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Jibar.source + ".ForwardingTermStructure") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_Jibar_maturityDate", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".MaturityDate") 
                                               [| _Jibar.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_currency", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Jibar.source + ".Currency") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_dayCounter", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Jibar.source + ".DayCounter") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Jibar_familyName", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".FamilyName") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_fixing", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Jibar.source + ".Fixing") 
                                               [| _Jibar.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_fixingCalendar", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Jibar.source + ".FixingCalendar") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_fixingDate", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".FixingDate") 
                                               [| _Jibar.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_fixingDays", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Jibar.source + ".FixingDays") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_isValidFixingDate", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".IsValidFixingDate") 
                                               [| _Jibar.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_name", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".Name") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_pastFixing", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".PastFixing") 
                                               [| _Jibar.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_tenor", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Jibar.source + ".Tenor") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_Jibar_update", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).Update
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".Update") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_valueDate", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".ValueDate") 
                                               [| _Jibar.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_addFixing", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".AddFixing") 
                                               [| _Jibar.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_addFixings", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".AddFixings") 
                                               [| _Jibar.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_addFixings", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".AddFixings1") 
                                               [| _Jibar.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_allowsNativeFixings", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".AllowsNativeFixings") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_clearFixings", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).ClearFixings
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".ClearFixings") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_registerWith", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".RegisterWith") 
                                               [| _Jibar.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_timeSeries", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".TimeSeries") 
                                               [| _Jibar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_unregisterWith", Description="Create a Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Jibar",Description = "Reference to Jibar")>] 
         jibar : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Jibar = Helper.toCell<Jibar> jibar "Jibar" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Jibar.cell :?> JibarModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Jibar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Jibar.source + ".UnregisterWith") 
                                               [| _Jibar.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Jibar.cell
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
    [<ExcelFunction(Name="_Jibar_Range", Description="Create a range of Jibar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Jibar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Jibar")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Jibar> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Jibar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Jibar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Jibar>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
