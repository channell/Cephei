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
module SviSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SviSmileSection_atmLevel", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".AtmLevel") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_init", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_init
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Init
                                                       ) :> ICell
                let format (o : SviSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Init") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_maxStrike", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".MaxStrike") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_minStrike", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".MinStrike") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeToExpiry",Description = "Reference to timeToExpiry")>] 
         timeToExpiry : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="sviParameters",Description = "Reference to sviParameters")>] 
         sviParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeToExpiry = Helper.toCell<double> timeToExpiry "timeToExpiry" true
                let _forward = Helper.toCell<double> forward "forward" true
                let _sviParameters = Helper.toCell<Generic.List<double>> sviParameters "sviParameters" true
                let builder () = withMnemonic mnemonic (Fun.SviSmileSection 
                                                            _timeToExpiry.cell 
                                                            _forward.cell 
                                                            _sviParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviSmileSection>) l

                let source = Helper.sourceFold "Fun.SviSmileSection" 
                                               [| _timeToExpiry.source
                                               ;  _forward.source
                                               ;  _sviParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeToExpiry.cell
                                ;  _forward.cell
                                ;  _sviParameters.cell
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
    [<ExcelFunction(Name="_SviSmileSection1", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="sviParameters",Description = "Reference to sviParameters")>] 
         sviParameters : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<Date> d "d" true
                let _forward = Helper.toCell<double> forward "forward" true
                let _sviParameters = Helper.toCell<Generic.List<double>> sviParameters "sviParameters" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.SviSmileSection1 
                                                            _d.cell 
                                                            _forward.cell 
                                                            _sviParameters.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviSmileSection>) l

                let source = Helper.sourceFold "Fun.SviSmileSection1" 
                                               [| _d.source
                                               ;  _forward.source
                                               ;  _sviParameters.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _forward.cell
                                ;  _sviParameters.cell
                                ;  _dc.cell
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
    [<ExcelFunction(Name="_SviSmileSection_dayCounter", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SviSmileSection.source + ".DayCounter") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_density", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Density") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_digitalOptionPrice", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
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

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".DigitalOptionPrice") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_exerciseDate", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".ExerciseDate") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_exerciseTime", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".ExerciseTime") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_optionPrice", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".OptionPrice") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_referenceDate", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".ReferenceDate") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_shift", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Shift") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_update", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : SviSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Update") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_variance", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Variance") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_vega", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Vega") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_volatility", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Volatility") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_volatility1", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".Volatility1") 
                                               [| _SviSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_volatilityType", Description="Create a SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviSmileSection",Description = "Reference to SviSmileSection")>] 
         svismilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviSmileSection = Helper.toCell<SviSmileSection> svismilesection "SviSmileSection" true 
                let builder () = withMnemonic mnemonic ((_SviSmileSection.cell :?> SviSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviSmileSection.source + ".VolatilityType") 
                                               [| _SviSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviSmileSection.cell
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
    [<ExcelFunction(Name="_SviSmileSection_Range", Description="Create a range of SviSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SviSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SviSmileSection> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SviSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SviSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SviSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
