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
  Overnight %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLiborONFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborON", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLiborON 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLiborON>) l

                let source = Helper.sourceFold "Fun.EURLiborON" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborON1", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLiborON1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLiborON>) l

                let source = Helper.sourceFold "Fun.EURLiborON1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
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
    [<ExcelFunction(Name="_EURLiborON_businessDayConvention", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".BusinessDayConvention") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_clone", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".Clone") 
                                               [| _EURLiborON.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborON_endOfMonth", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".EndOfMonth") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_forecastFixing1", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".ForecastFixing1") 
                                               [| _EURLiborON.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_forecastFixing", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".ForecastFixing") 
                                               [| _EURLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_forwardingTermStructure", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".ForwardingTermStructure") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
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
    [<ExcelFunction(Name="_EURLiborON_maturityDate", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".MaturityDate") 
                                               [| _EURLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_currency", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".Currency") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborON_dayCounter", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".DayCounter") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
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
    [<ExcelFunction(Name="_EURLiborON_familyName", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".FamilyName") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_fixing", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".Fixing") 
                                               [| _EURLiborON.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_fixingCalendar", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".FixingCalendar") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborON_fixingDate", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".FixingDate") 
                                               [| _EURLiborON.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_fixingDays", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".FixingDays") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_isValidFixingDate", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".IsValidFixingDate") 
                                               [| _EURLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_name", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".Name") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_pastFixing", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".PastFixing") 
                                               [| _EURLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_tenor", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLiborON.source + ".Tenor") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborON> format
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
    [<ExcelFunction(Name="_EURLiborON_update", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).Update
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".Update") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_valueDate", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".ValueDate") 
                                               [| _EURLiborON.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_addFixing", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".AddFixing") 
                                               [| _EURLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_addFixings", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".AddFixings") 
                                               [| _EURLiborON.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_addFixings1", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".AddFixings1") 
                                               [| _EURLiborON.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_allowsNativeFixings", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".AllowsNativeFixings") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_clearFixings", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".ClearFixings") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_registerWith", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".RegisterWith") 
                                               [| _EURLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_timeSeries", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".TimeSeries") 
                                               [| _EURLiborON.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_unregisterWith", Description="Create a EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborON",Description = "Reference to EURLiborON")>] 
         eurliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborON = Helper.toCell<EURLiborON> eurliboron "EURLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLiborONModel.Cast _EURLiborON.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLiborON) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborON.source + ".UnregisterWith") 
                                               [| _EURLiborON.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborON.cell
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
    [<ExcelFunction(Name="_EURLiborON_Range", Description="Create a range of EURLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborON_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLiborON")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLiborON> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLiborON>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLiborON>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLiborON>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
