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
  Bkbm rate fixed by NZFMA.  See <http://www.nzfma.org/Site/data/default.aspx>.
  </summary> *)
[<AutoSerializable(true)>]
module BkbmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Bkbm", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_create
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
                let builder () = withMnemonic mnemonic (Fun.Bkbm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bkbm>) l

                let source = Helper.sourceFold "Fun.Bkbm" 
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Bkbm_businessDayConvention", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".BusinessDayConvention") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_clone", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Bkbm.source + ".Clone") 
                                               [| _Bkbm.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_endOfMonth", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".EndOfMonth") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_forecastFixing", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".ForecastFixing") 
                                               [| _Bkbm.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_forecastFixing", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".ForecastFixing1") 
                                               [| _Bkbm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_forwardingTermStructure", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Bkbm.source + ".ForwardingTermStructure") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_maturityDate", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".MaturityDate") 
                                               [| _Bkbm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_currency", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Bkbm.source + ".Currency") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_dayCounter", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Bkbm.source + ".DayCounter") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_familyName", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".FamilyName") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_fixing", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".Fixing") 
                                               [| _Bkbm.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_fixingCalendar", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Bkbm.source + ".FixingCalendar") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_fixingDate", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".FixingDate") 
                                               [| _Bkbm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_fixingDays", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".FixingDays") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_isValidFixingDate", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".IsValidFixingDate") 
                                               [| _Bkbm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_name", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".Name") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_pastFixing", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".PastFixing") 
                                               [| _Bkbm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_tenor", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Bkbm.source + ".Tenor") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_update", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).Update
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".Update") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_valueDate", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".ValueDate") 
                                               [| _Bkbm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_addFixing", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".AddFixing") 
                                               [| _Bkbm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_addFixings", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".AddFixings") 
                                               [| _Bkbm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_addFixings", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".AddFixings1") 
                                               [| _Bkbm.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_allowsNativeFixings", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".AllowsNativeFixings") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_clearFixings", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).ClearFixings
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".ClearFixings") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_registerWith", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".RegisterWith") 
                                               [| _Bkbm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_timeSeries", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".TimeSeries") 
                                               [| _Bkbm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_unregisterWith", Description="Create a Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bkbm",Description = "Reference to Bkbm")>] 
         bkbm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bkbm = Helper.toCell<Bkbm> bkbm "Bkbm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Bkbm.cell :?> BkbmModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bkbm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bkbm.source + ".UnregisterWith") 
                                               [| _Bkbm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bkbm.cell
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
    [<ExcelFunction(Name="_Bkbm_Range", Description="Create a range of Bkbm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bkbm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Bkbm")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bkbm> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bkbm>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bkbm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bkbm>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
