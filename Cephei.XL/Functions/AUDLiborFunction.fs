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
  Australian Dollar LIBOR discontinued as of 2013.
  </summary> *)
[<AutoSerializable(true)>]
module AUDLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor1", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_create1
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
                let builder () = withMnemonic mnemonic (Fun.AUDLibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AUDLibor>) l

                let source = Helper.sourceFold "Fun.AUDLibor" 
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
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.AUDLibor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AUDLibor>) l

                let source = Helper.sourceFold "Fun.AUDLibor" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
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
    [<ExcelFunction(Name="_AUDLibor_clone", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".Clone") 
                                               [| _AUDLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor_maturityDate", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".MaturityDate") 
                                               [| _AUDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_valueDate", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".ValueDate") 
                                               [| _AUDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_businessDayConvention", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".BusinessDayConvention") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_endOfMonth", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".EndOfMonth") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_forecastFixing1", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".ForecastFixing1") 
                                               [| _AUDLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    
    [<ExcelFunction(Name="_AUDLibor_forecastFixing", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".ForecastFixing") 
                                               [| _AUDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_forwardingTermStructure", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".ForwardingTermStructure") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor_currency", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".Currency") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor_dayCounter", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".DayCounter") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
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
    [<ExcelFunction(Name="_AUDLibor_familyName", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".FamilyName") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_fixing", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".Fixing") 
                                               [| _AUDLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_fixingCalendar", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".FixingCalendar") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUDLibor_fixingDate", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".FixingDate") 
                                               [| _AUDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_fixingDays", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".FixingDays") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_isValidFixingDate", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".IsValidFixingDate") 
                                               [| _AUDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_name", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".Name") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_pastFixing", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".PastFixing") 
                                               [| _AUDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_tenor", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_AUDLibor.source + ".Tenor") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDLibor> format
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
    [<ExcelFunction(Name="_AUDLibor_update", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).Update
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".Update") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_addFixing", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".AddFixing") 
                                               [| _AUDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_addFixings", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".AddFixings") 
                                               [| _AUDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_addFixings1", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".AddFixings1") 
                                               [| _AUDLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_allowsNativeFixings", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".AllowsNativeFixings") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_clearFixings", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".ClearFixings") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_registerWith", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".RegisterWith") 
                                               [| _AUDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_timeSeries", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".TimeSeries") 
                                               [| _AUDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_unregisterWith", Description="Create a AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDLibor",Description = "Reference to AUDLibor")>] 
         audlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDLibor = Helper.toCell<AUDLibor> audlibor "AUDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AUDLibor.cell :?> AUDLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AUDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUDLibor.source + ".UnregisterWith") 
                                               [| _AUDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDLibor.cell
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
    [<ExcelFunction(Name="_AUDLibor_Range", Description="Create a range of AUDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUDLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AUDLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AUDLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AUDLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AUDLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AUDLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
