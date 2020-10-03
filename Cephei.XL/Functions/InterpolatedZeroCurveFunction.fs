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
module InterpolatedZeroCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve_Clone", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Clone") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_data", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Data") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_data_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Data_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_dates", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Dates") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_dates_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Dates_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create
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
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve" 
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
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve1", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create1
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
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve1 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve1" 
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
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve2", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create2
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
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve2 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve2" 
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
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve3", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="yields",Description = "Reference to yields")>] 
         yields : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _yields = Helper.toCell<Generic.List<double>> yields "yields" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _compounding = Helper.toDefault<Compounding> compounding "compounding" Compounding.Continuous
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.Annual
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve3 
                                                            _dates.cell 
                                                            _yields.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _interpolator.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve3" 
                                               [| _dates.source
                                               ;  _yields.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _interpolator.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _yields.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _interpolator.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve4", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="yields",Description = "Reference to yields")>] 
         yields : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _yields = Helper.toCell<Generic.List<double>> yields "yields" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _compounding = Helper.toDefault<Compounding> compounding "compounding" Compounding.Continuous
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.Annual
                let _refDate = Helper.toDefault<Date> refDate "refDate" null
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve4 
                                                            _dates.cell 
                                                            _yields.cell 
                                                            _dayCounter.cell 
                                                            _interpolator.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve4" 
                                               [| _dates.source
                                               ;  _yields.source
                                               ;  _dayCounter.source
                                               ;  _interpolator.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _yields.cell
                                ;  _dayCounter.cell
                                ;  _interpolator.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _refDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve5", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="yields",Description = "Reference to yields")>] 
         yields : obj)
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
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _yields = Helper.toCell<Generic.List<double>> yields "yields" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _compounding = Helper.toDefault<Compounding> compounding "compounding" Compounding.Continuous
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.Annual
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroCurve5 
                                                            _dates.cell 
                                                            _yields.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedZeroCurve5" 
                                               [| _dates.source
                                               ;  _yields.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _yields.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve_interpolation_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Interpolation_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve_interpolator_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Interpolator_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroCurve_maxDate", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".MaxDate") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_maxDate_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".MaxDate_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_nodes", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Nodes") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_setupInterpolation", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedZeroCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".SetupInterpolation") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_times", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Times") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_times_", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".Times_") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_zeroRates", Description="Create a InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_zeroRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroCurve",Description = "Reference to InterpolatedZeroCurve")>] 
         interpolatedzerocurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroCurve = Helper.toCell<InterpolatedZeroCurve> interpolatedzerocurve "InterpolatedZeroCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroCurve.cell :?> InterpolatedZeroCurveModel).ZeroRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroCurve.source + ".ZeroRates") 
                                               [| _InterpolatedZeroCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroCurve_Range", Description="Create a range of InterpolatedZeroCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedZeroCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedZeroCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedZeroCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedZeroCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedZeroCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
