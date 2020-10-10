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
  This class implements the LocalVolatilityTermStructure interface for a constant local volatility (no time/asset dependence).  Local volatility and Black volatility are the same when volatility is at most time dependent, so this class is basically a proxy for BlackVolatilityTermStructure.
  </summary> *)
[<AutoSerializable(true)>]
module LocalConstantVolFunction =

    (*
        TermStructure interface
    *)
    [<ExcelFunction(Name="_LocalConstantVol_dayCounter", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".DayCounter") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalConstantVol2", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LocalConstantVol2
                                                            _referenceDate.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalConstantVol>) l

                let source () = Helper.sourceFold "Fun.LocalConstantVol2" 
                                               [| _referenceDate.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalConstantVol1", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LocalConstantVol1 
                                                            _referenceDate.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalConstantVol>) l

                let source () = Helper.sourceFold "Fun.LocalConstantVol1" 
                                               [| _referenceDate.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalConstantVol3", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LocalConstantVol3
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalConstantVol>) l

                let source () = Helper.sourceFold "Fun.LocalConstantVol3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalConstantVol", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LocalConstantVol
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalConstantVol>) l

                let source () = Helper.sourceFold "Fun.LocalConstantVol" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LocalConstantVol_maxDate", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".MaxDate") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
    [<ExcelFunction(Name="_LocalConstantVol_maxStrike", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".MaxStrike") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_LocalConstantVol_minStrike", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".MinStrike") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
    [<ExcelFunction(Name="_LocalConstantVol_localVol", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_localVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _t = Helper.toCell<double> t "t" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).LocalVol
                                                            _t.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".LocalVol") 
                                               [| _LocalConstantVol.source
                                               ;  _t.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _t.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_LocalConstantVol_localVol1", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_localVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _d = Helper.toCell<Date> d "d" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).LocalVol1
                                                            _d.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".LocalVol1") 
                                               [| _LocalConstantVol.source
                                               ;  _d.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _d.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_LocalConstantVol_businessDayConvention", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".BusinessDayConvention") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_LocalConstantVol_optionDateFromTenor", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".OptionDateFromTenor") 
                                               [| _LocalConstantVol.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_LocalConstantVol_calendar", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".Calendar") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LocalConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_LocalConstantVol_maxTime", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".MaxTime") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_LocalConstantVol_referenceDate", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".ReferenceDate") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_LocalConstantVol_settlementDays", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".SettlementDays") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_LocalConstantVol_timeFromReference", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".TimeFromReference") 
                                               [| _LocalConstantVol.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_LocalConstantVol_update", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).Update
                                                       ) :> ICell
                let format (o : LocalConstantVol) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".Update") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_LocalConstantVol_allowsExtrapolation", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".AllowsExtrapolation") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_LocalConstantVol_disableExtrapolation", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalConstantVol) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".DisableExtrapolation") 
                                               [| _LocalConstantVol.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_LocalConstantVol_enableExtrapolation", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalConstantVol) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".EnableExtrapolation") 
                                               [| _LocalConstantVol.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_LocalConstantVol_extrapolate", Description="Create a LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalConstantVol",Description = "Reference to LocalConstantVol")>] 
         localconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalConstantVol = Helper.toCell<LocalConstantVol> localconstantvol "LocalConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((LocalConstantVolModel.Cast _LocalConstantVol.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LocalConstantVol.source + ".Extrapolate") 
                                               [| _LocalConstantVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalConstantVol.cell
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
    [<ExcelFunction(Name="_LocalConstantVol_Range", Description="Create a range of LocalConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LocalConstantVol_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LocalConstantVol")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LocalConstantVol> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LocalConstantVol>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<LocalConstantVol>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LocalConstantVol>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
