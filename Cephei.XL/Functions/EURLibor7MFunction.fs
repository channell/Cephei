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
  7-months %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor7MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor7M", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor7M 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor7M>) l

                let source = Helper.sourceFold "Fun.EURLibor7M" 
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
    [<ExcelFunction(Name="_EURLibor7M1", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor7M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor7M>) l

                let source = Helper.sourceFold "Fun.EURLibor7M1" 
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
    [<ExcelFunction(Name="_EURLibor7M_maturityDate", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".MaturityDate") 
                                               [| _EURLibor7M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_valueDate", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".ValueDate") 
                                               [| _EURLibor7M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_businessDayConvention", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".BusinessDayConvention") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_clone", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".Clone") 
                                               [| _EURLibor7M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_endOfMonth", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".EndOfMonth") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_forecastFixing1", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".ForecastFixing1") 
                                               [| _EURLibor7M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_forecastFixing", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".ForecastFixing") 
                                               [| _EURLibor7M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_forwardingTermStructure", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".ForwardingTermStructure") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_currency", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".Currency") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_dayCounter", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".DayCounter") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_familyName", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".FamilyName") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_fixing", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".Fixing") 
                                               [| _EURLibor7M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_fixingCalendar", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".FixingCalendar") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_fixingDate", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".FixingDate") 
                                               [| _EURLibor7M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_fixingDays", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".FixingDays") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_isValidFixingDate", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".IsValidFixingDate") 
                                               [| _EURLibor7M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_name", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".Name") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_pastFixing", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".PastFixing") 
                                               [| _EURLibor7M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_tenor", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor7M.source + ".Tenor") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_update", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).Update
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".Update") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_addFixing", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".AddFixing") 
                                               [| _EURLibor7M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_addFixings", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".AddFixings") 
                                               [| _EURLibor7M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_addFixings1", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".AddFixings1") 
                                               [| _EURLibor7M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_allowsNativeFixings", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".AllowsNativeFixings") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_clearFixings", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".ClearFixings") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_registerWith", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".RegisterWith") 
                                               [| _EURLibor7M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_timeSeries", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".TimeSeries") 
                                               [| _EURLibor7M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_unregisterWith", Description="Create a EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor7M",Description = "Reference to EURLibor7M")>] 
         eurlibor7m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor7M = Helper.toCell<EURLibor7M> eurlibor7m "EURLibor7M" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor7M.cell :?> EURLibor7MModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor7M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor7M.source + ".UnregisterWith") 
                                               [| _EURLibor7M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor7M.cell
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
    [<ExcelFunction(Name="_EURLibor7M_Range", Description="Create a range of EURLibor7M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor7M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor7M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor7M> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor7M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor7M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor7M>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
