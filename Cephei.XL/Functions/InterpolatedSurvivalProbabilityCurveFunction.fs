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
module InterpolatedSurvivalProbabilityCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_Clone", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_data", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_data_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_dates", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_dates_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_discounts", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_discounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Discounts
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Discounts") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="probabilities",Description = "double range")>] 
         probabilities : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar or empty")>] 
         calendar : obj)
        ([<ExcelArgument(Name="jumps",Description = "Quote or empty")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Date or empty")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _probabilities = Helper.toCell<Generic.List<double>> probabilities "probabilities" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedSurvivalProbabilityCurve 
                                                            _dates.cell 
                                                            _probabilities.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSurvivalProbabilityCurve>) l

                let source () = Helper.sourceFold "Fun.InterpolatedSurvivalProbabilityCurve" 
                                               [| _dates.source
                                               ;  _probabilities.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _probabilities.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSurvivalProbabilityCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_interpolation_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSurvivalProbabilityCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_interpolator_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSurvivalProbabilityCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_maxDate", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_maxDate_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_nodes", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_setupInterpolation", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedSurvivalProbabilityCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_survivalProbabilities", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_survivalProbabilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).SurvivalProbabilities
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".SurvivalProbabilities") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
        other inspectors
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_times", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_times_", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultDensity", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultDensity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultDensity
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultDensity") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _t.cell
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
        These methods return the default density at a given date or time. In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultDensity", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultDensity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultDensity1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultDensity") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _d.cell
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
        ! probability of default between two given times
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        ([<ExcelArgument(Name="extrapo",Description = "bool")>] 
         extrapo : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _extrapo = Helper.toCell<bool> extrapo "extrapo" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultProbability
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _extrapo.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultProbability") 

                                               [| _t1.source
                                               ;  _t2.source
                                               ;  _extrapo.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _extrapo.cell
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
        ! probability of default between two given dates
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultProbability1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultProbability") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultProbability2
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultProbability") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _t.cell
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
        These methods return the default probability from the reference date until a given date or time.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_defaultProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_defaultProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DefaultProbability3
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DefaultProbability") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_hazardRate", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_hazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).HazardRate
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".HazardRate") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _t.cell
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
        These methods returns the hazard rate at a given date or time. In the latter case, the time is calculated as a fraction of year from the reference date.  Hazard rates are defined with annual frequency and continuous compounding.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_hazardRate", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_hazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).HazardRate1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".HazardRate") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_jumpDates", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".JumpDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_jumpTimes", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".JumpTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_survivalProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_survivalProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).SurvivalProbability
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".SurvivalProbability") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _t.cell
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
        These methods return the survival probability from the reference date until a given date or time.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_survivalProbability", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_survivalProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).SurvivalProbability1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".SurvivalProbability") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_update", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedSurvivalProbabilityCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_calendar", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSurvivalProbabilityCurve> format
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_dayCounter", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSurvivalProbabilityCurve> format
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_maxTime", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_referenceDate", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_settlementDays", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_timeFromReference", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_allowsExtrapolation", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_disableExtrapolation", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedSurvivalProbabilityCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_enableExtrapolation", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedSurvivalProbabilityCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_extrapolate", Description="Create a InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSurvivalProbabilityCurve",Description = "InterpolatedSurvivalProbabilityCurve")>] 
         interpolatedsurvivalprobabilitycurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSurvivalProbabilityCurve = Helper.toCell<InterpolatedSurvivalProbabilityCurve> interpolatedsurvivalprobabilitycurve "InterpolatedSurvivalProbabilityCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSurvivalProbabilityCurveModel.Cast _InterpolatedSurvivalProbabilityCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSurvivalProbabilityCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSurvivalProbabilityCurve.cell
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
    [<ExcelFunction(Name="_InterpolatedSurvivalProbabilityCurve_Range", Description="Create a range of InterpolatedSurvivalProbabilityCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSurvivalProbabilityCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedSurvivalProbabilityCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<InterpolatedSurvivalProbabilityCurve> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<InterpolatedSurvivalProbabilityCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InterpolatedSurvivalProbabilityCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
