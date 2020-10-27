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

  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedHazardRateCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_Clone", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_data", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_data_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_dates", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_dates_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_discounts", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_discounts
        ([<ExcelArgument(Name="Mnemonic",Description = "InterpolatedHazardRateCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Discounts
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Discounts") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_hazardRates", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_hazardRates
        ([<ExcelArgument(Name="Mnemonic",Description = "InterpolatedHazardRateCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).HazardRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".HazardRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "InterpolatedHazardRateCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Date")>] 
         dates : obj)
        ([<ExcelArgument(Name="hazardRates",Description = "double")>] 
         hazardRates : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="interpolator",Description = "InterpolatedHazardRateCurve")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _hazardRates = Helper.toCell<Generic.List<double>> hazardRates "hazardRates" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedHazardRateCurve 
                                                            _dates.cell 
                                                            _hazardRates.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedHazardRateCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedHazardRateCurve" 
                                               [| _dates.source
                                               ;  _hazardRates.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _hazardRates.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedHazardRateCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve1", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "InterpolatedHazardRateCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Date")>] 
         dates : obj)
        ([<ExcelArgument(Name="hazardRates",Description = "double")>] 
         hazardRates : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="interpolator",Description = "InterpolatedHazardRateCurve")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _hazardRates = Helper.toCell<Generic.List<double>> hazardRates "hazardRates" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedHazardRateCurve1 
                                                            _dates.cell 
                                                            _hazardRates.cell 
                                                            _dayCounter.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedHazardRateCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedHazardRateCurve1" 
                                               [| _dates.source
                                               ;  _hazardRates.source
                                               ;  _dayCounter.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _hazardRates.cell
                                ;  _dayCounter.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedHazardRateCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve2", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "InterpolatedHazardRateCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Date")>] 
         dates : obj)
        ([<ExcelArgument(Name="hazardRates",Description = "double")>] 
         hazardRates : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="cal",Description = "InterpolatedHazardRateCurve")>] 
         cal : obj)
        ([<ExcelArgument(Name="jumps",Description = "InterpolatedHazardRateCurve")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "InterpolatedHazardRateCurve")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "InterpolatedHazardRateCurve")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _hazardRates = Helper.toCell<Generic.List<double>> hazardRates "hazardRates" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _cal = Helper.toDefault<Calendar> cal "cal" null
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedHazardRateCurve2 
                                                            _dates.cell 
                                                            _hazardRates.cell 
                                                            _dayCounter.cell 
                                                            _cal.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedHazardRateCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedHazardRateCurve2" 
                                               [| _dates.source
                                               ;  _hazardRates.source
                                               ;  _dayCounter.source
                                               ;  _cal.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _hazardRates.cell
                                ;  _dayCounter.cell
                                ;  _cal.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedHazardRateCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_interpolation_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedHazardRateCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_interpolator_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "IInterpolationFactory")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedHazardRateCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_maxDate", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_maxDate_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_nodes", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_setupInterpolation", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedHazardRateCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_times", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_times_", Description="Create a InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedHazardRateCurve",Description = "InterpolatedHazardRateCurve")>] 
         interpolatedhazardratecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedHazardRateCurve = Helper.toCell<InterpolatedHazardRateCurve> interpolatedhazardratecurve "InterpolatedHazardRateCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedHazardRateCurveModel.Cast _InterpolatedHazardRateCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedHazardRateCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedHazardRateCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedHazardRateCurve_Range", Description="Create a range of InterpolatedHazardRateCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedHazardRateCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedHazardRateCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedHazardRateCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedHazardRateCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InterpolatedHazardRateCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
