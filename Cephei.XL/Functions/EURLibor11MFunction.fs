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
    [<ExcelFunction(Name="_EURLibor11M1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = (Fun.EURLibor11M1 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor11M>) l

                let source () = Helper.sourceFold "Fun.EURLibor11M1" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.EURLibor11M ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor11M>) l

                let source () = Helper.sourceFold "Fun.EURLibor11M" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M_maturityDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_EURLibor11M_valueDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EURLibor11M_businessDayConvention", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_clone", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M_endOfMonth", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_forecastFixing1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".ForecastFixing1") 

                                               [| _d1.source
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
    [<ExcelFunction(Name="_EURLibor11M_forecastFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_forwardingTermStructure", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M_currency", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M_dayCounter", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
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
    [<ExcelFunction(Name="_EURLibor11M_familyName", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixingCalendar", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor11M_fixingDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_fixingDays", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_isValidFixingDate", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_name", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_pastFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_tenor", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor11M> format
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
    [<ExcelFunction(Name="_EURLibor11M_update", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).Update
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_addFixing", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EURLibor11M_addFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EURLibor11M_addFixings1", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_allowsNativeFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_clearFixings", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_registerWith", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_timeSeries", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_unregisterWith", Description="Create a EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor11M",Description = "EURLibor11M")>] 
         eurlibor11m : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor11M = Helper.toCell<EURLibor11M> eurlibor11m "EURLibor11M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((EURLibor11MModel.Cast _EURLibor11M.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor11M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor11M.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor11M.cell
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
    [<ExcelFunction(Name="_EURLibor11M_Range", Description="Create a range of EURLibor11M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor11M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor11M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EURLibor11M> (c)) :> ICell
                let format (i : Cephei.Cell.List<EURLibor11M>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EURLibor11M>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
