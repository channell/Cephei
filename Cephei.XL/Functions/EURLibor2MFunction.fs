﻿(*
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
  2-months %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor2MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M1", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor2M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor2M>) l

                let source = Helper.sourceFold "Fun.EURLibor2M" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor2M
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor2M>) l

                let source = Helper.sourceFold "Fun.EURLibor2M" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M_maturityDate", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".MaturityDate") 
                                               [| _EURLibor2M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_valueDate", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".ValueDate") 
                                               [| _EURLibor2M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_businessDayConvention", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".BusinessDayConvention") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_clone", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".Clone") 
                                               [| _EURLibor2M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M_endOfMonth", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".EndOfMonth") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_forecastFixing1", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".ForecastFixing1") 
                                               [| _EURLibor2M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_forecastFixing", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".ForecastFixing") 
                                               [| _EURLibor2M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_forwardingTermStructure", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".ForwardingTermStructure") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M_currency", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".Currency") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M_dayCounter", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".DayCounter") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
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
    [<ExcelFunction(Name="_EURLibor2M_familyName", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".FamilyName") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_fixing", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".Fixing") 
                                               [| _EURLibor2M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_fixingCalendar", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".FixingCalendar") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2M_fixingDate", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".FixingDate") 
                                               [| _EURLibor2M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_fixingDays", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".FixingDays") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_isValidFixingDate", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".IsValidFixingDate") 
                                               [| _EURLibor2M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_name", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".Name") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_pastFixing", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".PastFixing") 
                                               [| _EURLibor2M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_tenor", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor2M.source + ".Tenor") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor2M> format
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
    [<ExcelFunction(Name="_EURLibor2M_update", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).Update
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".Update") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_addFixing", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".AddFixing") 
                                               [| _EURLibor2M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_addFixings", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".AddFixings") 
                                               [| _EURLibor2M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_addFixings1", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".AddFixings1") 
                                               [| _EURLibor2M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_allowsNativeFixings", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".AllowsNativeFixings") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_clearFixings", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".ClearFixings") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_registerWith", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".RegisterWith") 
                                               [| _EURLibor2M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_timeSeries", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".TimeSeries") 
                                               [| _EURLibor2M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_unregisterWith", Description="Create a EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2M",Description = "Reference to EURLibor2M")>] 
         eurlibor2m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2M = Helper.toCell<EURLibor2M> eurlibor2m "EURLibor2M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EURLibor2M.cell :?> EURLibor2MModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor2M) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2M.source + ".UnregisterWith") 
                                               [| _EURLibor2M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2M.cell
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
    [<ExcelFunction(Name="_EURLibor2M_Range", Description="Create a range of EURLibor2M",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor2M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor2M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor2M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor2M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor2M>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"