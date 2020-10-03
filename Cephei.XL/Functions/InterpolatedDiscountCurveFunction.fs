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
  yieldtermstructures
  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedDiscountCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_Clone", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Clone") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_data", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Data") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_data_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Data_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_dates", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Dates") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_dates_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Dates_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_discounts", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_discounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Discounts
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Discounts") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="discounts",Description = "Reference to discounts")>] 
         discounts : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve 
                                                            _dates.cell 
                                                            _discounts.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve" 
                                               [| _dates.source
                                               ;  _discounts.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _discounts.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve1", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="discounts",Description = "Reference to discounts")>] 
         discounts : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve1 
                                                            _dates.cell 
                                                            _discounts.cell 
                                                            _dayCounter.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve1" 
                                               [| _dates.source
                                               ;  _discounts.source
                                               ;  _dayCounter.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _discounts.cell
                                ;  _dayCounter.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve2", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="discounts",Description = "Reference to discounts")>] 
         discounts : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve2 
                                                            _dates.cell 
                                                            _discounts.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve2" 
                                               [| _dates.source
                                               ;  _discounts.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _discounts.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve3", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="discounts",Description = "Reference to discounts")>] 
         discounts : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _discounts = Helper.toCell<Generic.List<double>> discounts "discounts" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve3 
                                                            _dates.cell 
                                                            _discounts.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve3" 
                                               [| _dates.source
                                               ;  _discounts.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _discounts.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve4", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve4 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve4" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve5", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve5 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve5" 
                                               [| _referenceDate.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve6", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_create6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedDiscountCurve6 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedDiscountCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedDiscountCurve6" 
                                               [| _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_interpolation_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Interpolation_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_interpolator_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Interpolator_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_maxDate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".MaxDate") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_maxDate_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".MaxDate_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_nodes", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Nodes") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_setupInterpolation", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedDiscountCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".SetupInterpolation") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_times", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Times") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_times_", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Times_") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_discount", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Discount") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _t.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_discount", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Discount") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _d.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_forwardRate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ForwardRate") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_forwardRate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ForwardRate") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_forwardRate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ForwardRate") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_jumpDates", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".JumpDates") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_jumpTimes", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".JumpTimes") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_update", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedDiscountCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Update") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_zeroRate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ZeroRate
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ZeroRate") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_zeroRate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ZeroRate1
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ZeroRate") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_calendar", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Calendar") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_dayCounter", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".DayCounter") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedDiscountCurve> format
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_maxTime", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".MaxTime") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_referenceDate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".ReferenceDate") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_settlementDays", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".SettlementDays") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_timeFromReference", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".TimeFromReference") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_allowsExtrapolation", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".AllowsExtrapolation") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_disableExtrapolation", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedDiscountCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".DisableExtrapolation") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_enableExtrapolation", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedDiscountCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".EnableExtrapolation") 
                                               [| _InterpolatedDiscountCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_extrapolate", Description="Create a InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedDiscountCurve",Description = "Reference to InterpolatedDiscountCurve")>] 
         interpolateddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedDiscountCurve = Helper.toCell<InterpolatedDiscountCurve> interpolateddiscountcurve "InterpolatedDiscountCurve"  
                let builder () = withMnemonic mnemonic ((InterpolatedDiscountCurveModel.Cast _InterpolatedDiscountCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedDiscountCurve.source + ".Extrapolate") 
                                               [| _InterpolatedDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedDiscountCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedDiscountCurve_Range", Description="Create a range of InterpolatedDiscountCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedDiscountCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedDiscountCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedDiscountCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedDiscountCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedDiscountCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedDiscountCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
