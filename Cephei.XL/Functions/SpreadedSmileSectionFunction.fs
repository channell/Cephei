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
module SpreadedSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSmileSection_atmLevel", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".AtmLevel") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_dayCounter", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".DayCounter") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSmileSection_exerciseDate", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".ExerciseDate") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_exerciseTime", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".ExerciseTime") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_maxStrike", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".MaxStrike") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
        SmileSection interface
    *)
    [<ExcelFunction(Name="_SpreadedSmileSection_minStrike", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".MinStrike") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_referenceDate", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".ReferenceDate") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_shift", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Shift") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlyingSection",Description = "Reference to underlyingSection")>] 
         underlyingSection : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlyingSection = Helper.toCell<SmileSection> underlyingSection "underlyingSection" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let builder () = withMnemonic mnemonic (Fun.SpreadedSmileSection 
                                                            _underlyingSection.cell 
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadedSmileSection>) l

                let source = Helper.sourceFold "Fun.SpreadedSmileSection" 
                                               [| _underlyingSection.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlyingSection.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        LazyObject interface
    *)
    [<ExcelFunction(Name="_SpreadedSmileSection_update", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : SpreadedSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Update") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_volatilityType", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".VolatilityType") 
                                               [| _SpreadedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_density", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Density") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_digitalOptionPrice", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
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

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".DigitalOptionPrice") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_optionPrice", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".OptionPrice") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_variance", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Variance") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_vega", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Vega") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_volatility", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toCell<double> shift "shift" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Volatility") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_volatility1", Description="Create a SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSmileSection",Description = "Reference to SpreadedSmileSection")>] 
         spreadedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSmileSection = Helper.toCell<SpreadedSmileSection> spreadedsmilesection "SpreadedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((SpreadedSmileSectionModel.Cast _SpreadedSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedSmileSection.source + ".Volatility1") 
                                               [| _SpreadedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSmileSection.cell
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
    [<ExcelFunction(Name="_SpreadedSmileSection_Range", Description="Create a range of SpreadedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SpreadedSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SpreadedSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SpreadedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SpreadedSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
