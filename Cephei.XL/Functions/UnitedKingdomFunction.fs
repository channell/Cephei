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
  Public holidays (data from http://www.dti.gov.uk/er/bankhol.htm):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the stock exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the metals exchange:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Early May Bank Holiday, first Monday of May</li>
<li>Spring Bank Holiday, last Monday of May</li>
<li>Summer Bank Holiday, last Monday of August</li>
<li>Christmas Day, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  add LIFFE the correctness of the returned results is tested  against a list of known holidays.
  </summary> *)
[<AutoSerializable(true)>]
module UnitedKingdomFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UnitedKingdom", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Market> m "m" true
                let builder () = withMnemonic mnemonic (Fun.UnitedKingdom 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UnitedKingdom>) l

                let source = Helper.sourceFold "Fun.UnitedKingdom" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
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
    [<ExcelFunction(Name="_UnitedKingdom1", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.UnitedKingdom1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UnitedKingdom>) l

                let source = Helper.sourceFold "Fun.UnitedKingdom1" 
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
    [<ExcelFunction(Name="_UnitedKingdom_addedHolidays", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_UnitedKingdom.source + ".AddedHolidays") 
                                               [| _UnitedKingdom.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedKingdom_addHoliday", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : UnitedKingdom) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".AddHoliday") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_adjust", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Adjust") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_advance", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "Reference to unit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Advance") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_advance", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Advance") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_businessDaysBetween", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "Reference to includeFirst")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "Reference to includeLast")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".BusinessDaysBetween") 
                                               [| _UnitedKingdom.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_calendar", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Calendar") 
                                               [| _UnitedKingdom.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
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
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_UnitedKingdom_empty", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Empty") 
                                               [| _UnitedKingdom.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_endOfMonth", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".EndOfMonth") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_Equals", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Equals") 
                                               [| _UnitedKingdom.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_UnitedKingdom_isBusinessDay", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".IsBusinessDay") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_isEndOfMonth", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".IsEndOfMonth") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_UnitedKingdom_isHoliday", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".IsHoliday") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_UnitedKingdom_isWeekend", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".IsWeekend") 
                                               [| _UnitedKingdom.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_UnitedKingdom_name", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".Name") 
                                               [| _UnitedKingdom.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_removedHolidays", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_UnitedKingdom.source + ".RemovedHolidays") 
                                               [| _UnitedKingdom.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedKingdom_removeHoliday", Description="Create a UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedKingdom",Description = "Reference to UnitedKingdom")>] 
         unitedkingdom : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedKingdom = Helper.toCell<UnitedKingdom> unitedkingdom "UnitedKingdom" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_UnitedKingdom.cell :?> UnitedKingdomModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : UnitedKingdom) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitedKingdom.source + ".RemoveHoliday") 
                                               [| _UnitedKingdom.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedKingdom.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_UnitedKingdom_Range", Description="Create a range of UnitedKingdom",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitedKingdom_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UnitedKingdom")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UnitedKingdom> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UnitedKingdom>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<UnitedKingdom>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<UnitedKingdom>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
