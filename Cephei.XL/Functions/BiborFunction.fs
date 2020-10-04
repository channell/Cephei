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
module BiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Bibor", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_create
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
                let builder () = withMnemonic mnemonic (Fun.Bibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bibor>) l

                let source = Helper.sourceFold "Fun.Bibor" 
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
                    ; subscriber = Helper.subscriberModel<Bibor> format
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
    [<ExcelFunction(Name="_Bibor_businessDayConvention", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".BusinessDayConvention") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_clone", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Bibor.source + ".Clone") 
                                               [| _Bibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bibor_endOfMonth", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".EndOfMonth") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_forecastFixing1", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bibor.source + ".ForecastFixing1") 
                                               [| _Bibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_forecastFixing", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bibor.source + ".ForecastFixing") 
                                               [| _Bibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_forwardingTermStructure", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Bibor.source + ".ForwardingTermStructure") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
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
    [<ExcelFunction(Name="_Bibor_maturityDate", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".MaturityDate") 
                                               [| _Bibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_currency", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Bibor.source + ".Currency") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bibor_dayCounter", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Bibor.source + ".DayCounter") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
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
    [<ExcelFunction(Name="_Bibor_familyName", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".FamilyName") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_fixing", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bibor.source + ".Fixing") 
                                               [| _Bibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_fixingCalendar", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Bibor.source + ".FixingCalendar") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bibor_fixingDate", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".FixingDate") 
                                               [| _Bibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_fixingDays", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bibor.source + ".FixingDays") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_isValidFixingDate", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".IsValidFixingDate") 
                                               [| _Bibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_name", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".Name") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_pastFixing", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".PastFixing") 
                                               [| _Bibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_tenor", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Bibor.source + ".Tenor") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bibor> format
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
    [<ExcelFunction(Name="_Bibor_update", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).Update
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".Update") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_valueDate", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".ValueDate") 
                                               [| _Bibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_addFixing", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".AddFixing") 
                                               [| _Bibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_addFixings", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".AddFixings") 
                                               [| _Bibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_addFixings1", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".AddFixings1") 
                                               [| _Bibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_allowsNativeFixings", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".AllowsNativeFixings") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_clearFixings", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".ClearFixings") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_registerWith", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".RegisterWith") 
                                               [| _Bibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_timeSeries", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".TimeSeries") 
                                               [| _Bibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_unregisterWith", Description="Create a Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bibor",Description = "Reference to Bibor")>] 
         bibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bibor = Helper.toCell<Bibor> bibor "Bibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((BiborModel.Cast _Bibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bibor.source + ".UnregisterWith") 
                                               [| _Bibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bibor.cell
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
    [<ExcelFunction(Name="_Bibor_Range", Description="Create a range of Bibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Bibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Bibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
