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
  Japanese Yen LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.  This is the rate fixed in London by ICE. Use TIBOR if you're interested in the Tokio fixing.
  </summary> *)
[<AutoSerializable(true)>]
module JPYLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor1", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JPYLibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JPYLibor>) l

                let source () = Helper.sourceFold "Fun.JPYLibor1" 
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
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JPYLibor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JPYLibor>) l

                let source () = Helper.sourceFold "Fun.JPYLibor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods
    *)
    [<ExcelFunction(Name="_JPYLibor_clone", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor_maturityDate", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_JPYLibor_valueDate", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_JPYLibor_businessDayConvention", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_endOfMonth", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_forecastFixing1", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_forecastFixing", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_forwardingTermStructure", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor_currency", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor_dayCounter", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
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
    [<ExcelFunction(Name="_JPYLibor_familyName", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_fixing", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_fixingCalendar", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JPYLibor_fixingDate", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_fixingDays", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_isValidFixingDate", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_name", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_pastFixing", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_tenor", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_JPYLibor.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JPYLibor> format
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
    [<ExcelFunction(Name="_JPYLibor_update", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).Update
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_addFixing", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_addFixings", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_addFixings1", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_allowsNativeFixings", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_clearFixings", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_registerWith", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_timeSeries", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_unregisterWith", Description="Create a JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JPYLibor",Description = "JPYLibor")>] 
         jpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JPYLibor = Helper.toCell<JPYLibor> jpylibor "JPYLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((JPYLiborModel.Cast _JPYLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JPYLibor.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JPYLibor.cell
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
    [<ExcelFunction(Name="_JPYLibor_Range", Description="Create a range of JPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JPYLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JPYLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<JPYLibor> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<JPYLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<JPYLibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
