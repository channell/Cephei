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

  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedSmileSection_atmLevel", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".AtmLevel") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_Clone", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Clone
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Clone") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_data", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Data") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_data_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Data_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dates", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Dates") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dates_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Dates_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_discounts", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_discounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Discounts
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Discounts") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "Reference to timeToExpiry")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevHandles",Description = "Reference to stdDevHandles")>] 
         stdDevHandles : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _stdDevHandles = Helper.toCell<Generic.List<Handle<Quote>>> stdDevHandles "stdDevHandles" true
                let _atmLevel = Helper.toHandle<Handle<Quote>> atmLevel "atmLevel" 
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedSmileSection 
                                                            _timeToExpiry.cell 
                                                            _strikes.cell 
                                                            _stdDevHandles.cell 
                                                            _atmLevel.cell 
                                                            _interpolator.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.InterpolatedSmileSection" 
                                               [| _timeToExpiry.source
                                               ;  _strikes.source
                                               ;  _stdDevHandles.source
                                               ;  _atmLevel.source
                                               ;  _interpolator.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection1", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "Reference to timeToExpiry")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevs",Description = "Reference to stdDevs")>] 
         stdDevs : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _stdDevs = Helper.toCell<Generic.List<double>> stdDevs "stdDevs" true
                let _atmLevel = Helper.toCell<double> atmLevel "atmLevel" true
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedSmileSection1 
                                                            _timeToExpiry.cell 
                                                            _strikes.cell 
                                                            _stdDevs.cell 
                                                            _atmLevel.cell 
                                                            _interpolator.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.InterpolatedSmileSection1" 
                                               [| _timeToExpiry.source
                                               ;  _strikes.source
                                               ;  _stdDevs.source
                                               ;  _atmLevel.source
                                               ;  _interpolator.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection2", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevHandles",Description = "Reference to stdDevHandles")>] 
         stdDevHandles : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _stdDevHandles = Helper.toCell<Generic.List<Handle<Quote>>> stdDevHandles "stdDevHandles" true
                let _atmLevel = Helper.toHandle<Handle<Quote>> atmLevel "atmLevel" 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" true
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedSmileSection2 
                                                            _d.cell 
                                                            _strikes.cell 
                                                            _stdDevHandles.cell 
                                                            _atmLevel.cell 
                                                            _dc.cell 
                                                            _interpolator.cell 
                                                            _referenceDate.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.InterpolatedSmileSection2" 
                                               [| _d.source
                                               ;  _strikes.source
                                               ;  _stdDevHandles.source
                                               ;  _atmLevel.source
                                               ;  _dc.source
                                               ;  _interpolator.source
                                               ;  _referenceDate.source
                                               ;  _Type.source
                                               ;  _shift.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection3", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="stdDevs",Description = "Reference to stdDevs")>] 
         stdDevs : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _stdDevs = Helper.toCell<Generic.List<double>> stdDevs "stdDevs" true
                let _atmLevel = Helper.toCell<double> atmLevel "atmLevel" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _interpolator = Helper.toCell<'Interpolator> interpolator "interpolator" true
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.InterpolatedSmileSection3 
                                                            _d.cell 
                                                            _strikes.cell 
                                                            _stdDevs.cell 
                                                            _atmLevel.cell 
                                                            _dc.cell 
                                                            _interpolator.cell 
                                                            _referenceDate.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.InterpolatedSmileSection3" 
                                               [| _d.source
                                               ;  _strikes.source
                                               ;  _stdDevs.source
                                               ;  _atmLevel.source
                                               ;  _dc.source
                                               ;  _interpolator.source
                                               ;  _referenceDate.source
                                               ;  _shift.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_interpolation_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Interpolation_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_interpolator_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Interpolator_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxDate") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxDate_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxDate_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_maxStrike", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".MaxStrike") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_minStrike", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".MinStrike") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_nodes", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Nodes") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_setupInterpolation", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".SetupInterpolation") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_times", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Times") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_times_", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Times_") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_update", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : InterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Update") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_dayCounter", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".DayCounter") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_density", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Density") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_digitalOptionPrice", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".DigitalOptionPrice") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_exerciseDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".ExerciseDate") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_exerciseTime", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".ExerciseTime") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_optionPrice", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".OptionPrice") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_referenceDate", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".ReferenceDate") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_shift", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Shift") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_variance", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Variance") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_vega", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Vega") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatility", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Volatility") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatility", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".Volatility1") 
                                               [| _InterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_volatilityType", Description="Create a InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedSmileSection",Description = "Reference to InterpolatedSmileSection")>] 
         interpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedSmileSection = Helper.toCell<InterpolatedSmileSection> interpolatedsmilesection "InterpolatedSmileSection" true 
                let builder () = withMnemonic mnemonic ((_InterpolatedSmileSection.cell :?> InterpolatedSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedSmileSection.source + ".VolatilityType") 
                                               [| _InterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_InterpolatedSmileSection_Range", Description="Create a range of InterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedSmileSection> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
