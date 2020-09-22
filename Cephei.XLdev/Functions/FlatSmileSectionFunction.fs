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
    [<ExcelFunction(Name="_FlatSmileSection_atmLevel", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".AtmLevel") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseTime",Description = "Reference to exerciseTime")>] 
         exerciseTime : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseTime = Helper.toCell<double> exerciseTime "exerciseTime" true
                let _vol = Helper.toCell<double> vol "vol" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _atmLevel = Helper.toNullable<Nullable<double>> atmLevel "atmLevel"
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.FlatSmileSection 
                                                            _exerciseTime.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _atmLevel.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatSmileSection>) l

                let source = Helper.sourceFold "Fun.FlatSmileSection" 
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
    [<ExcelFunction(Name="_FlatSmileSection1", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="atmLevel",Description = "Reference to atmLevel")>] 
         atmLevel : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" true
                let _vol = Helper.toCell<double> vol "vol" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _atmLevel = Helper.toNullable<Nullable<double>> atmLevel "atmLevel"
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.FlatSmileSection1 
                                                            _d.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _referenceDate.cell 
                                                            _atmLevel.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatSmileSection>) l

                let source = Helper.sourceFold "Fun.FlatSmileSection1" 
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
    [<ExcelFunction(Name="_FlatSmileSection_maxStrike", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".MaxStrike") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_minStrike", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".MinStrike") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_dayCounter", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FlatSmileSection.source + ".DayCounter") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_density", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Density") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_FlatSmileSection_digitalOptionPrice", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
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

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".DigitalOptionPrice") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_FlatSmileSection_exerciseDate", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".ExerciseDate") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_exerciseTime", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".ExerciseTime") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_optionPrice", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".OptionPrice") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_FlatSmileSection_referenceDate", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".ReferenceDate") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_shift", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Shift") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_update", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : FlatSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Update") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_variance", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Variance") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_vega", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Vega") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_volatility", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Volatility") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_FlatSmileSection_volatility", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".Volatility1") 
                                               [| _FlatSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_volatilityType", Description="Create a FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatSmileSection",Description = "Reference to FlatSmileSection")>] 
         flatsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatSmileSection = Helper.toCell<FlatSmileSection> flatsmilesection "FlatSmileSection" true 
                let builder () = withMnemonic mnemonic ((_FlatSmileSection.cell :?> FlatSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatSmileSection.source + ".VolatilityType") 
                                               [| _FlatSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatSmileSection.cell
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
    [<ExcelFunction(Name="_FlatSmileSection_Range", Description="Create a range of FlatSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FlatSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FlatSmileSection> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FlatSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FlatSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FlatSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
