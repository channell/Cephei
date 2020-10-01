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
  1-month %Euribor index
  </summary> *)
[<AutoSerializable(true)>]
module Euribor1MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1M", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Euribor1M 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor1M>) l

                let source = Helper.sourceFold "Fun.Euribor1M" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1M1", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Euribor1M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor1M>) l

                let source = Helper.sourceFold "Fun.Euribor1M1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
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
    [<ExcelFunction(Name="_Euribor1M_businessDayConvention", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".BusinessDayConvention") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_clone", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".Clone") 
                                               [| _Euribor1M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1M_endOfMonth", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".EndOfMonth") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_forecastFixing1", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".ForecastFixing1") 
                                               [| _Euribor1M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_forecastFixing", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".ForecastFixing") 
                                               [| _Euribor1M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_forwardingTermStructure", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".ForwardingTermStructure") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
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
    [<ExcelFunction(Name="_Euribor1M_maturityDate", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".MaturityDate") 
                                               [| _Euribor1M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_currency", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".Currency") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1M_dayCounter", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".DayCounter") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
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
    [<ExcelFunction(Name="_Euribor1M_familyName", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".FamilyName") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_fixing", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".Fixing") 
                                               [| _Euribor1M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_fixingCalendar", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".FixingCalendar") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1M_fixingDate", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".FixingDate") 
                                               [| _Euribor1M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_fixingDays", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".FixingDays") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_isValidFixingDate", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".IsValidFixingDate") 
                                               [| _Euribor1M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_name", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".Name") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_pastFixing", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".PastFixing") 
                                               [| _Euribor1M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_tenor", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Euribor1M.source + ".Tenor") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1M> format
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
    [<ExcelFunction(Name="_Euribor1M_update", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).Update
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".Update") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_valueDate", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".ValueDate") 
                                               [| _Euribor1M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_addFixing", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".AddFixing") 
                                               [| _Euribor1M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_addFixings", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".AddFixings") 
                                               [| _Euribor1M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_addFixings1", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".AddFixings1") 
                                               [| _Euribor1M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_allowsNativeFixings", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".AllowsNativeFixings") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_clearFixings", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".ClearFixings") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_registerWith", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".RegisterWith") 
                                               [| _Euribor1M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_timeSeries", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".TimeSeries") 
                                               [| _Euribor1M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_unregisterWith", Description="Create a Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1M",Description = "Reference to Euribor1M")>] 
         euribor1m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1M = Helper.toCell<Euribor1M> euribor1m "Euribor1M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Euribor1M.cell :?> Euribor1MModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor1M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1M.source + ".UnregisterWith") 
                                               [| _Euribor1M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1M.cell
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
    [<ExcelFunction(Name="_Euribor1M_Range", Description="Create a range of Euribor1M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Euribor1M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor1M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Euribor1M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Euribor1M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Euribor1M>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
