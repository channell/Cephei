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

(*!! generic

(* <summary>
  The provided rates are not YY inflation-swap quotes. inflationtermstructures
  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedYoYInflationCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_baseDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_Clone", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_data", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_data_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dates", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dates_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_forwards", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Forwards") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lag",Description = "Period")>] 
         lag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "bool")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "YieldTermStructure")>] 
         yTS : obj)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="rates",Description = "double range")>] 
         rates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lag = Helper.toCell<Period> lag "lag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _rates = Helper.toCell<Generic.List<double>> rates "rates" 
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedYoYInflationCurve 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _lag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                            _dates.cell 
                                                            _rates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedYoYInflationCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedYoYInflationCurve" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _lag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               ;  _dates.source
                                               ;  _rates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _lag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
                                ;  _dates.cell
                                ;  _rates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve1", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lag",Description = "Period")>] 
         lag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "bool")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "YieldTermStructure")>] 
         yTS : obj)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="rates",Description = "double range")>] 
         rates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lag = Helper.toCell<Period> lag "lag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _rates = Helper.toCell<Generic.List<double>> rates "rates" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedYoYInflationCurve1 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _lag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                            _dates.cell 
                                                            _rates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedYoYInflationCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedYoYInflationCurve1" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _lag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               ;  _dates.source
                                               ;  _rates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _lag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
                                ;  _dates.cell
                                ;  _rates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_interpolation_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_interpolator_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxDate_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_nodes", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_rates", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Rates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_setupInterpolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_times", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_times_", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).YoyRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).YoyRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).YoyRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
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
        ! \note this is not the year-on-year swap (YYIIS) rate.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_yoyRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).YoyRate3
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".YoyRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_baseRate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".BaseRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_frequency", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_hasSeasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".HasSeasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_indexIsInterpolated", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".IndexIsInterpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_nominalTermStructure", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".NominalTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inflation interface ! The TS observes with a lag that is usually different from the ! availability lag of the index.  An inflation rate is given, ! by default, for the maturity requested assuming this lag.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_observationLag", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_seasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Seasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Calling setSeasonality with no arguments means unsetting as the default is used to choose unsetting.
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_setSeasonality", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SetSeasonality") 

                                               [| _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                ;  _seasonality.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_calendar", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_dayCounter", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedYoYInflationCurve> format
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_maxTime", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_referenceDate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_settlementDays", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_timeFromReference", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_update", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_allowsExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_disableExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_enableExtrapolation", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_extrapolate", Description="Create a InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedYoYInflationCurve",Description = "InterpolatedYoYInflationCurve")>] 
         interpolatedyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedYoYInflationCurve = Helper.toCell<InterpolatedYoYInflationCurve> interpolatedyoyinflationcurve "InterpolatedYoYInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedYoYInflationCurveModel.Cast _InterpolatedYoYInflationCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedYoYInflationCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedYoYInflationCurve_Range", Description="Create a range of InterpolatedYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedYoYInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedYoYInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<InterpolatedYoYInflationCurve> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<InterpolatedYoYInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InterpolatedYoYInflationCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
