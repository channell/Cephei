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
  Sweden Krone LIBOR discontinued as of 2013.
  </summary> *)
[<AutoSerializable(true)>]
module SEKLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor1", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_create1
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
                let builder () = withMnemonic mnemonic (Fun.SEKLibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SEKLibor>) l

                let source = Helper.sourceFold "Fun.SEKLibor1" 
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
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.SEKLibor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SEKLibor>) l

                let source = Helper.sourceFold "Fun.SEKLibor" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
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
    [<ExcelFunction(Name="_SEKLibor_clone", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".Clone") 
                                               [| _SEKLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor_maturityDate", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".MaturityDate") 
                                               [| _SEKLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_valueDate", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".ValueDate") 
                                               [| _SEKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_businessDayConvention", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".BusinessDayConvention") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_endOfMonth", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".EndOfMonth") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_forecastFixing1", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".ForecastFixing") 
                                               [| _SEKLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_forecastFixing", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".ForecastFixing") 
                                               [| _SEKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_forwardingTermStructure", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".ForwardingTermStructure") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor_currency", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".Currency") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor_dayCounter", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".DayCounter") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
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
    [<ExcelFunction(Name="_SEKLibor_familyName", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".FamilyName") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_fixing", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".Fixing") 
                                               [| _SEKLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_fixingCalendar", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".FixingCalendar") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SEKLibor_fixingDate", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".FixingDate") 
                                               [| _SEKLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_fixingDays", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".FixingDays") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_isValidFixingDate", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".IsValidFixingDate") 
                                               [| _SEKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_name", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".Name") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_pastFixing", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".PastFixing") 
                                               [| _SEKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_tenor", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_SEKLibor.source + ".Tenor") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SEKLibor> format
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
    [<ExcelFunction(Name="_SEKLibor_update", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).Update
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".Update") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_addFixing", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".AddFixing") 
                                               [| _SEKLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_addFixings", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".AddFixings") 
                                               [| _SEKLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_addFixings1", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".AddFixings1") 
                                               [| _SEKLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_allowsNativeFixings", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".AllowsNativeFixings") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_clearFixings", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".ClearFixings") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_registerWith", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".RegisterWith") 
                                               [| _SEKLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_timeSeries", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".TimeSeries") 
                                               [| _SEKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_unregisterWith", Description="Create a SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SEKLibor",Description = "Reference to SEKLibor")>] 
         seklibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SEKLibor = Helper.toCell<SEKLibor> seklibor "SEKLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_SEKLibor.cell :?> SEKLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SEKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SEKLibor.source + ".UnregisterWith") 
                                               [| _SEKLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SEKLibor.cell
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
    [<ExcelFunction(Name="_SEKLibor_Range", Description="Create a range of SEKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SEKLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SEKLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SEKLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SEKLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SEKLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SEKLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
