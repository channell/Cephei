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
module SabrSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SabrSmileSection_atmLevel", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".AtmLevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_maxStrike", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_minStrike", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection1", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "double")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="sabrParams",Description = "double range")>] 
         sabrParams : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal or empty")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _sabrParams = Helper.toCell<Generic.List<double>> sabrParams "sabrParams" 
                let _volatilityType = Helper.toDefault<VolatilityType> volatilityType "volatilityType" VolatilityType.ShiftedLognormal
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.SabrSmileSection1 
                                                            _timeToExpiry.cell 
                                                            _forward.cell 
                                                            _sabrParams.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrSmileSection>) l

                let source () = Helper.sourceFold "Fun.SabrSmileSection1" 
                                               [| _timeToExpiry.source
                                               ;  _forward.source
                                               ;  _sabrParams.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeToExpiry.cell
                                ;  _forward.cell
                                ;  _sabrParams.cell
                                ;  _volatilityType.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SabrSmileSection", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="sabrParams",Description = "double range")>] 
         sabrParams : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal or empty")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _sabrParams = Helper.toCell<Generic.List<double>> sabrParams "sabrParams" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _volatilityType = Helper.toDefault<VolatilityType> volatilityType "volatilityType" VolatilityType.ShiftedLognormal
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.SabrSmileSection
                                                            _d.cell 
                                                            _forward.cell 
                                                            _sabrParams.cell 
                                                            _dc.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrSmileSection>) l

                let source () = Helper.sourceFold "Fun.SabrSmileSection" 
                                               [| _d.source
                                               ;  _forward.source
                                               ;  _sabrParams.source
                                               ;  _dc.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _forward.cell
                                ;  _sabrParams.cell
                                ;  _dc.cell
                                ;  _volatilityType.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SabrSmileSection_dayCounter", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SabrSmileSection_density", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Density") 

                                               [| _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_digitalOptionPrice", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
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

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".DigitalOptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_exerciseDate", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".ExerciseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_exerciseTime", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".ExerciseTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_optionPrice", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".OptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_referenceDate", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_shift", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Shift") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_update", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : SabrSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_variance", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Variance") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_vega", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Vega") 

                                               [| _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_volatility", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal or empty")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toDefault<VolatilityType> volatilityType "volatilityType" VolatilityType.ShiftedLognormal
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_volatility1", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".Volatility1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_volatilityType", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toModelReference<SabrSmileSection> sabrsmilesection "SabrSmileSection"  
                let builder (current : ICell) = ((SabrSmileSectionModel.Cast _SabrSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrSmileSection.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_Range", Description="Create a range of SabrSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SabrSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SabrSmileSection> (c)) :> ICell
                let format (i : Cephei.Cell.List<SabrSmileSection>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SabrSmileSection>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
