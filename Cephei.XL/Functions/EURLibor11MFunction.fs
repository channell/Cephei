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
  11-months %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor11MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor11M1 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor11M>) l

                let source = Helper.sourceFold "Fun.EURLibor11M1" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
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
    [<ExcelFunction(Name="_EURLibor11M", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor11M ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor11M>) l

                let source = Helper.sourceFold "Fun.EURLibor11M" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_EURLibor11M_maturityDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".MaturityDate") 
                                               [| _EURLibor11M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_valueDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".ValueDate") 
                                               [| _EURLibor11M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_businessDayConvention", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".BusinessDayConvention") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_clone", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".Clone") 
                                               [| _EURLibor11M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_endOfMonth", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".EndOfMonth") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_forecastFixing1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".ForecastFixing1") 
                                               [| _EURLibor11M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_forecastFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".ForecastFixing") 
                                               [| _EURLibor11M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_forwardingTermStructure", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".ForwardingTermStructure") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_currency", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".Currency") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_dayCounter", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".DayCounter") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_familyName", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".FamilyName") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".Fixing") 
                                               [| _EURLibor11M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixingCalendar", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".FixingCalendar") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixingDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".FixingDate") 
                                               [| _EURLibor11M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixingDays", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".FixingDays") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_isValidFixingDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".IsValidFixingDate") 
                                               [| _EURLibor11M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_name", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".Name") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_pastFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".PastFixing") 
                                               [| _EURLibor11M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_tenor", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor11M.source + ".Tenor") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_update", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).Update
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".Update") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_addFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".AddFixing") 
                                               [| _EURLibor11M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_addFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".AddFixings") 
                                               [| _EURLibor11M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_addFixings1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".AddFixings1") 
                                               [| _EURLibor11M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_allowsNativeFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".AllowsNativeFixings") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_clearFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".ClearFixings") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_registerWith", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".RegisterWith") 
                                               [| _EURLibor11M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_timeSeries", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".TimeSeries") 
                                               [| _EURLibor11M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_unregisterWith", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "Reference to EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor11M.cell :?> EURLibor11MModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor11M.source + ".UnregisterWith") 
                                               [| _EURLibor11M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_Range", Description="Create a range of EURLibor11M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor11M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor11M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor11M> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor11M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor11M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor11M>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
