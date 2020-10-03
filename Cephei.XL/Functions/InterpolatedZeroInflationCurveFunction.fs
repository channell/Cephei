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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_baseDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".BaseDate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_Clone", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Clone") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_data", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Data") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_data_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Data_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dates", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Dates") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dates_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Dates_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_forwards", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Forwards") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lag",Description = "Reference to lag")>] 
         lag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="rates",Description = "Reference to rates")>] 
         rates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
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
                let builder () = withMnemonic mnemonic (Fun.InterpolatedZeroInflationCurve 
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

                let source = Helper.sourceFold "Fun.InterpolatedZeroInflationCurve" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_interpolation_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Interpolation_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_interpolator_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Interpolator_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxDate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxDate_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxDate_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_nodes", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Nodes") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_rates", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Rates") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_setupInterpolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SetupInterpolation") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_times", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Times") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_times_", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Times_") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ZeroRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ZeroRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ZeroRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
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
        ! Essentially the fair rate for a zero-coupon inflation swap (by definition), i.e. the zero term structure uses yearly compounding, which is assumed for ZCIIS instrument quotes. N.B. by default you get the same as lag and interpolation as the term structure. If you want to get predictions of RPI/CPI/etc then use an index.
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_zeroRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ZeroRate3
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ZeroRate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_baseRate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".BaseRate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_frequency", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Frequency") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_hasSeasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".HasSeasonality") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_indexIsInterpolated", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".IndexIsInterpolated") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_nominalTermStructure", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".NominalTermStructure") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_observationLag", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ObservationLag") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_seasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Seasonality") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_setSeasonality", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Reference to seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SetSeasonality") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                ;  _seasonality.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_calendar", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Calendar") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_dayCounter", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".DayCounter") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_maxTime", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".MaxTime") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_referenceDate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".ReferenceDate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_settlementDays", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".SettlementDays") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_timeFromReference", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".TimeFromReference") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_update", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Update
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Update") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_allowsExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".AllowsExtrapolation") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_disableExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".DisableExtrapolation") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_enableExtrapolation", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".EnableExtrapolation") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_extrapolate", Description="Create a InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedZeroInflationCurve",Description = "Reference to InterpolatedZeroInflationCurve")>] 
         interpolatedzeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedZeroInflationCurve = Helper.toCell<InterpolatedZeroInflationCurve> interpolatedzeroinflationcurve "InterpolatedZeroInflationCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedZeroInflationCurve.cell :?> InterpolatedZeroInflationCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedZeroInflationCurve.source + ".Extrapolate") 
                                               [| _InterpolatedZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedZeroInflationCurve_Range", Description="Create a range of InterpolatedZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedZeroInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedZeroInflationCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedZeroInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedZeroInflationCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedZeroInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedZeroInflationCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
