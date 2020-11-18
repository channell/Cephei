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
  2-months %Euribor index
  </summary> *)
[<AutoSerializable(true)>]
module Euribor2MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor2M1", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Euribor2M1
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor2M>) l

                let source () = Helper.sourceFold "Fun.Euribor2M1" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor2M", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Euribor2M ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor2M>) l

                let source () = Helper.sourceFold "Fun.Euribor2M" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
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
    [<ExcelFunction(Name="_Euribor2M_businessDayConvention", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_clone", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor2M_endOfMonth", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_forecastFixing1", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_forecastFixing", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_forwardingTermStructure", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
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
    [<ExcelFunction(Name="_Euribor2M_maturityDate", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _valueDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_currency", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor2M_dayCounter", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
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
    [<ExcelFunction(Name="_Euribor2M_familyName", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_fixing", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_fixingCalendar", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor2M_fixingDate", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _valueDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_fixingDays", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_isValidFixingDate", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_name", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_pastFixing", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_tenor", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Euribor2M.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor2M> format
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
    [<ExcelFunction(Name="_Euribor2M_update", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).Update
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_valueDate", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_addFixing", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_addFixings", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_addFixings1", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_allowsNativeFixings", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_clearFixings", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_registerWith", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_timeSeries", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Euribor2M_unregisterWith", Description="Create a Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor2M",Description = "Euribor2M")>] 
         euribor2m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor2M = Helper.toCell<Euribor2M> euribor2m "Euribor2M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor2MModel.Cast _Euribor2M.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor2M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor2M.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor2M.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Euribor2M_Range", Description="Create a range of Euribor2M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor2M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor2M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<Euribor2M> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<Euribor2M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Euribor2M>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
