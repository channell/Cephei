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
  Local volatility curve derived from a Black curve
  </summary> *)
[<AutoSerializable(true)>]
module LocalVolCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LocalVolCurve_calendar", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_LocalVolCurve.source + ".Calendar") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_dayCounter", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_LocalVolCurve.source + ".DayCounter") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="curve",Description = "Reference to curve")>] 
         curve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _curve = Helper.toHandle<BlackVarianceCurve> curve "curve" 
                let builder () = withMnemonic mnemonic (Fun.LocalVolCurve 
                                                            _curve.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LocalVolCurve>) l

                let source = Helper.sourceFold "Fun.LocalVolCurve" 
                                               [| _curve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _curve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_maxDate", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".MaxDate") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_maxStrike", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".MaxStrike") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_LocalVolCurve_minStrike", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".MinStrike") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_LocalVolCurve_referenceDate", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".ReferenceDate") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_localVol", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_localVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _t = Helper.toCell<double> t "t" true
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).LocalVol
                                                            _t.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".LocalVol") 
                                               [| _LocalVolCurve.source
                                               ;  _t.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _t.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_localVol1", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_localVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).LocalVol1
                                                            _d.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".LocalVol1") 
                                               [| _LocalVolCurve.source
                                               ;  _d.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _d.cell
                                ;  _underlyingLevel.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_LocalVolCurve_businessDayConvention", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".BusinessDayConvention") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_LocalVolCurve_optionDateFromTenor", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".OptionDateFromTenor") 
                                               [| _LocalVolCurve.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _p.cell
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
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_LocalVolCurve_maxTime", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".MaxTime") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_LocalVolCurve_settlementDays", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".SettlementDays") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_LocalVolCurve_timeFromReference", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".TimeFromReference") 
                                               [| _LocalVolCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_LocalVolCurve_update", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).Update
                                                       ) :> ICell
                let format (o : LocalVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".Update") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_LocalVolCurve_allowsExtrapolation", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".AllowsExtrapolation") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_LocalVolCurve_disableExtrapolation", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".DisableExtrapolation") 
                                               [| _LocalVolCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_LocalVolCurve_enableExtrapolation", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LocalVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".EnableExtrapolation") 
                                               [| _LocalVolCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_extrapolate", Description="Create a LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LocalVolCurve",Description = "Reference to LocalVolCurve")>] 
         localvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LocalVolCurve = Helper.toCell<LocalVolCurve> localvolcurve "LocalVolCurve" true 
                let builder () = withMnemonic mnemonic ((_LocalVolCurve.cell :?> LocalVolCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LocalVolCurve.source + ".Extrapolate") 
                                               [| _LocalVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LocalVolCurve.cell
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
    [<ExcelFunction(Name="_LocalVolCurve_Range", Description="Create a range of LocalVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LocalVolCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LocalVolCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LocalVolCurve> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LocalVolCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LocalVolCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LocalVolCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
