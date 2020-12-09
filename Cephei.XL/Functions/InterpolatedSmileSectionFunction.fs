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
module InterpolatedSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_atmLevel", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".AtmLevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_Clone", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_data", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_data_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dates", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dates_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_discounts", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_discounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Discounts
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Discounts") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "double")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevHandles",Description = "Quote range")>] 
         stdDevHandles : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Quote")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _stdDevHandles = Helper.toCell<Generic.List<Handle<Quote>>> stdDevHandles "stdDevHandles" 
                let _atmLevel = Helper.toHandle<Quote> atmLevel "atmLevel" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedSmileSection 
                                                            _timeToExpiry.cell 
                                                            _strikes.cell 
                                                            _stdDevHandles.cell 
                                                            _atmLevel.cell 
                                                            _interpolator.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.InterpolatedSmileSection" 
                                               [| _timeToExpiry.source
                                               ;  _strikes.source
                                               ;  _stdDevHandles.source
                                               ;  _atmLevel.source
                                               ;  _interpolator.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeToExpiry.cell
                                ;  _strikes.cell
                                ;  _stdDevHandles.cell
                                ;  _atmLevel.cell
                                ;  _interpolator.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection1", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "double")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevs",Description = "double range")>] 
         stdDevs : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "double")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _stdDevs = Helper.toCell<Generic.List<double>> stdDevs "stdDevs" 
                let _atmLevel = Helper.toCell<double> atmLevel "atmLevel" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedSmileSection1 
                                                            _timeToExpiry.cell 
                                                            _strikes.cell 
                                                            _stdDevs.cell 
                                                            _atmLevel.cell 
                                                            _interpolator.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.InterpolatedSmileSection1" 
                                               [| _timeToExpiry.source
                                               ;  _strikes.source
                                               ;  _stdDevs.source
                                               ;  _atmLevel.source
                                               ;  _interpolator.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeToExpiry.cell
                                ;  _strikes.cell
                                ;  _stdDevs.cell
                                ;  _atmLevel.cell
                                ;  _interpolator.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection2", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevHandles",Description = "Quote range")>] 
         stdDevHandles : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Quote")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date or empty")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _stdDevHandles = Helper.toCell<Generic.List<Handle<Quote>>> stdDevHandles "stdDevHandles" 
                let _atmLevel = Helper.toHandle<Quote> atmLevel "atmLevel" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _referenceDate = Helper.toDefault<Date> referenceDate "referenceDate" null
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedSmileSection2 
                                                            _d.cell 
                                                            _strikes.cell 
                                                            _stdDevHandles.cell 
                                                            _atmLevel.cell 
                                                            _dc.cell 
                                                            _interpolator.cell 
                                                            _referenceDate.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.InterpolatedSmileSection2" 
                                               [| _d.source
                                               ;  _strikes.source
                                               ;  _stdDevHandles.source
                                               ;  _atmLevel.source
                                               ;  _dc.source
                                               ;  _interpolator.source
                                               ;  _referenceDate.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _strikes.cell
                                ;  _stdDevHandles.cell
                                ;  _atmLevel.cell
                                ;  _dc.cell
                                ;  _interpolator.cell
                                ;  _referenceDate.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection3", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevs",Description = "double range")>] 
         stdDevs : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "double")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="interpolator",Description = "'Interpolator or empty")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date or empty")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _stdDevs = Helper.toCell<Generic.List<double>> stdDevs "stdDevs" 
                let _atmLevel = Helper.toCell<double> atmLevel "atmLevel" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let _referenceDate = Helper.toDefault<Date> referenceDate "referenceDate" null
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedSmileSection3 
                                                            _d.cell 
                                                            _strikes.cell 
                                                            _stdDevs.cell 
                                                            _atmLevel.cell 
                                                            _dc.cell 
                                                            _interpolator.cell 
                                                            _referenceDate.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.InterpolatedSmileSection3" 
                                               [| _d.source
                                               ;  _strikes.source
                                               ;  _stdDevs.source
                                               ;  _atmLevel.source
                                               ;  _dc.source
                                               ;  _interpolator.source
                                               ;  _referenceDate.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _strikes.cell
                                ;  _stdDevs.cell
                                ;  _atmLevel.cell
                                ;  _dc.cell
                                ;  _interpolator.cell
                                ;  _referenceDate.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_interpolation_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_interpolator_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxDate_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxStrike", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_minStrike", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_nodes", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_setupInterpolation", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_times", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_times_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_update", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dayCounter", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_density", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Density") 

                                               [| _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _gap.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_digitalOptionPrice", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".DigitalOptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _Type.cell
                                ;  _discount.cell
                                ;  _gap.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_exerciseDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".ExerciseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_exerciseTime", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".ExerciseTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_optionPrice", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".OptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _Type.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_referenceDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_shift", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Shift") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_variance", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Variance") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_vega", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Vega") 

                                               [| _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatility", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _volatilityType.cell
                                ;  _shift.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatility", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatilityType", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedSmileSectionModel.Cast _InterpolatedSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedSmileSection.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_Range", Description="Create a range of InterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InterpolatedSmileSection> (c)) :> ICell
                let format (i : Generic.List<ICell<InterpolatedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
