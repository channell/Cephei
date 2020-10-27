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
module FlatSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FlatSmileSection_atmLevel", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "FlatSmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".AtmLevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FlatSmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseTime",Description = "double")>] 
         exerciseTime : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "double")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "FlatSmileSection")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseTime = Helper.toCell<double> exerciseTime "exerciseTime" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _atmLevel = Helper.toNullable<double> atmLevel "atmLevel"
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FlatSmileSection 
                                                            _exerciseTime.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _atmLevel.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatSmileSection>) l

                let source () = Helper.sourceFold "Fun.FlatSmileSection" 
                                               [| _exerciseTime.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _atmLevel.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exerciseTime.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _atmLevel.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatSmileSection1", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FlatSmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "FlatSmileSection")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "double")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "FlatSmileSection")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _referenceDate = Helper.toDefault<Date> referenceDate "referenceDate" null
                let _atmLevel = Helper.toNullable<double> atmLevel "atmLevel"
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FlatSmileSection1 
                                                            _d.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _referenceDate.cell 
                                                            _atmLevel.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatSmileSection>) l

                let source () = Helper.sourceFold "Fun.FlatSmileSection1" 
                                               [| _d.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _referenceDate.source
                                               ;  _atmLevel.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _referenceDate.cell
                                ;  _atmLevel.cell
                                ;  _Type.cell
                                ;  _shift.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatSmileSection_maxStrike", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_minStrike", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_dayCounter", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatSmileSection_density", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Density") 

                                               [| _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_digitalOptionPrice", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
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

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".DigitalOptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_exerciseDate", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".ExerciseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_exerciseTime", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".ExerciseTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_optionPrice", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".OptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_referenceDate", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_shift", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Shift") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_update", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : FlatSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_variance", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Variance") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_vega", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Vega") 

                                               [| _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_volatility", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Helper.Range.fromModelList")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_volatility1", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".Volatility1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_volatilityType", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatSmileSectionModel.Cast _FlatSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatSmileSection.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_Range", Description="Create a range of FlatSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FlatSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FlatSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FlatSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FlatSmileSection>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
