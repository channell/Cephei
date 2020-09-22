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
module AtmSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AtmSmileSection_atmLevel", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".AtmLevel") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="atm",Description = "Reference to atm")>] 
         atm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _source = Helper.toCell<SmileSection> source "source" true
                let _atm = Helper.toNullable<Nullable<double>> atm "atm"
                let builder () = withMnemonic mnemonic (Fun.AtmSmileSection 
                                                            _source.cell 
                                                            _atm.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AtmSmileSection>) l

                let source = Helper.sourceFold "Fun.AtmSmileSection" 
                                               [| _source.source
                                               ;  _atm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _source.cell
                                ;  _atm.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_dayCounter", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_AtmSmileSection.source + ".DayCounter") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_exerciseDate", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".ExerciseDate") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_exerciseTime", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".ExerciseTime") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_maxStrike", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".MaxStrike") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_minStrike", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".MinStrike") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_referenceDate", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".ReferenceDate") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_shift", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Shift") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_volatilityType", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".VolatilityType") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_density", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Density") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_digitalOptionPrice", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
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

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _gap = Helper.toCell<double> gap "gap" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".DigitalOptionPrice") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_optionPrice", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".OptionPrice") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_update", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : AtmSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Update") 
                                               [| _AtmSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_variance", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Variance") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_vega", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Vega") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_volatility", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" true
                let _shift = Helper.toCell<double> shift "shift" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Volatility") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_volatility", Description="Create a AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AtmSmileSection",Description = "Reference to AtmSmileSection")>] 
         atmsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AtmSmileSection = Helper.toCell<AtmSmileSection> atmsmilesection "AtmSmileSection" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_AtmSmileSection.cell :?> AtmSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AtmSmileSection.source + ".Volatility1") 
                                               [| _AtmSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AtmSmileSection.cell
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
    [<ExcelFunction(Name="_AtmSmileSection_Range", Description="Create a range of AtmSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AtmSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AtmSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AtmSmileSection> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AtmSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AtmSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AtmSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
