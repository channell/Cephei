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
module CdorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Cdor", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_create
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
                let builder () = withMnemonic mnemonic (Fun.Cdor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cdor>) l

                let source = Helper.sourceFold "Fun.Cdor" 
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
                    ; subscriber = Helper.subscriberModel<Cdor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cdor1", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.Cdor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cdor>) l

                let source = Helper.sourceFold "Fun.Cdor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
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
    [<ExcelFunction(Name="_Cdor_businessDayConvention", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".BusinessDayConvention") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_clone", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Cdor.source + ".Clone") 
                                               [| _Cdor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cdor_endOfMonth", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".EndOfMonth") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_forecastFixing1", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cdor.source + ".ForecastFixing1") 
                                               [| _Cdor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_forecastFixing", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cdor.source + ".ForecastFixing") 
                                               [| _Cdor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_forwardingTermStructure", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Cdor.source + ".ForwardingTermStructure") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
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
    [<ExcelFunction(Name="_Cdor_maturityDate", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".MaturityDate") 
                                               [| _Cdor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_currency", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Cdor.source + ".Currency") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cdor_dayCounter", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Cdor.source + ".DayCounter") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
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
    [<ExcelFunction(Name="_Cdor_familyName", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".FamilyName") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_fixing", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cdor.source + ".Fixing") 
                                               [| _Cdor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_fixingCalendar", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Cdor.source + ".FixingCalendar") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cdor_fixingDate", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".FixingDate") 
                                               [| _Cdor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_fixingDays", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Cdor.source + ".FixingDays") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_isValidFixingDate", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".IsValidFixingDate") 
                                               [| _Cdor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_name", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".Name") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_pastFixing", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".PastFixing") 
                                               [| _Cdor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_tenor", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Cdor.source + ".Tenor") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cdor> format
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
    [<ExcelFunction(Name="_Cdor_update", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).Update
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".Update") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_valueDate", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".ValueDate") 
                                               [| _Cdor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_addFixing", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".AddFixing") 
                                               [| _Cdor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_addFixings", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".AddFixings") 
                                               [| _Cdor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_addFixings1", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".AddFixings1") 
                                               [| _Cdor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_allowsNativeFixings", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".AllowsNativeFixings") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_clearFixings", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".ClearFixings") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_registerWith", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".RegisterWith") 
                                               [| _Cdor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_timeSeries", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".TimeSeries") 
                                               [| _Cdor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_unregisterWith", Description="Create a Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cdor",Description = "Reference to Cdor")>] 
         cdor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cdor = Helper.toCell<Cdor> cdor "Cdor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((CdorModel.Cast _Cdor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Cdor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Cdor.source + ".UnregisterWith") 
                                               [| _Cdor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cdor.cell
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
    [<ExcelFunction(Name="_Cdor_Range", Description="Create a range of Cdor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Cdor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Cdor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Cdor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Cdor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Cdor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Cdor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
