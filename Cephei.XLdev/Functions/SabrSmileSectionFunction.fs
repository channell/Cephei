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
    [<ExcelFunction(Name="_SabrSmileSection_atmLevel", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".AtmLevel") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_maxStrike", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".MaxStrike") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_minStrike", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".MinStrike") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "Reference to timeToExpiry")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="sabrParams",Description = "Reference to sabrParams")>] 
         sabrParams : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" true
                let _forward = Helper.toCell<double> forward "forward" true
                let _sabrParams = Helper.toCell<Generic.List<double>> sabrParams "sabrParams" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.SabrSmileSection 
                                                            _timeToExpiry.cell 
                                                            _forward.cell 
                                                            _sabrParams.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrSmileSection>) l

                let source = Helper.sourceFold "Fun.SabrSmileSection" 
                                               [| _timeToExpiry.source
                                               ;  _forward.source
                                               ;  _sabrParams.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeToExpiry.cell
                                ;  _forward.cell
                                ;  _sabrParams.cell
                                ;  _volatilityType.cell
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
    [<ExcelFunction(Name="_SabrSmileSection1", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="sabrParams",Description = "Reference to sabrParams")>] 
         sabrParams : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" true
                let _forward = Helper.toCell<double> forward "forward" true
                let _sabrParams = Helper.toCell<Generic.List<double>> sabrParams "sabrParams" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic (Fun.SabrSmileSection1 
                                                            _d.cell 
                                                            _forward.cell 
                                                            _sabrParams.cell 
                                                            _dc.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrSmileSection>) l

                let source = Helper.sourceFold "Fun.SabrSmileSection1" 
                                               [| _d.source
                                               ;  _forward.source
                                               ;  _sabrParams.source
                                               ;  _dc.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _forward.cell
                                ;  _sabrParams.cell
                                ;  _dc.cell
                                ;  _volatilityType.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_dayCounter", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SabrSmileSection.source + ".DayCounter") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_density", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Density") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrSmileSection_digitalOptionPrice", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
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

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".DigitalOptionPrice") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrSmileSection_exerciseDate", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".ExerciseDate") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_exerciseTime", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".ExerciseTime") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_optionPrice", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".OptionPrice") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrSmileSection_referenceDate", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".ReferenceDate") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_shift", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Shift") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_update", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : SabrSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Update") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_variance", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Variance") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_vega", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Vega") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_volatility", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Volatility") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrSmileSection_volatility", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".Volatility1") 
                                               [| _SabrSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_volatilityType", Description="Create a SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrSmileSection",Description = "Reference to SabrSmileSection")>] 
         sabrsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrSmileSection = Helper.toCell<SabrSmileSection> sabrsmilesection "SabrSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SabrSmileSection.cell :?> SabrSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrSmileSection.source + ".VolatilityType") 
                                               [| _SabrSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrSmileSection.cell
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
    [<ExcelFunction(Name="_SabrSmileSection_Range", Description="Create a range of SabrSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SabrSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SabrSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SabrSmileSection> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SabrSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SabrSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SabrSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
