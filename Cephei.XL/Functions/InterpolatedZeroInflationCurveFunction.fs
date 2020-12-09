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
module InterpolatedZeroInflationCurveFunction =

    (*
        InflationTermStructure interface
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_baseDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_Clone", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_data", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_data_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dates", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dates_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_forwards", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Forwards") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_create
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
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
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
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedZeroInflationCurve 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedZeroInflationCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedZeroInflationCurve" 
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
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_interpolation_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_interpolator_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxDate_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_nodes", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_rates", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Rates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_setupInterpolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_times", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_times_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
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

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ZeroRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ZeroRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ZeroRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
        ! Essentially the fair rate for a zero-coupon inflation swap (by definition), i.e. the zero term structure uses yearly compounding, which is assumed for ZCIIS instrument quotes. N.B. by default you get the same as lag and interpolation as the term structure. If you want to get predictions of RPI/CPI/etc then use an index.
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ZeroRate3
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_baseRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".BaseRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_frequency", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_hasSeasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".HasSeasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_indexIsInterpolated", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".IndexIsInterpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_nominalTermStructure", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".NominalTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_observationLag", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_seasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Seasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_setSeasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SetSeasonality") 

                                               [| _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_calendar", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dayCounter", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedZeroInflationCurve> format
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxTime", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_referenceDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_settlementDays", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_timeFromReference", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_update", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_allowsExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_disableExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_enableExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_extrapolate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedZeroInflationCurveModel.Cast _InterpolatedZeroInflationCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_Range", Description="Create a range of InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedZeroInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InterpolatedZeroInflationCurve> (c)) :> ICell
                let format (i : Generic.List<ICell<InterpolatedZeroInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InterpolatedZeroInflationCurve>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
