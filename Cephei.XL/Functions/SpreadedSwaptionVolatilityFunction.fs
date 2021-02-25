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
module SpreadedSwaptionVolatilityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_calendar", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        All virtual methods of base classes must be forwarded TermStructure interface
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_dayCounter", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_maxDate", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_maxStrike", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_maxSwapTenor", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MaxSwapTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_maxTime", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_minStrike", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_referenceDate", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_settlementDays", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="baseVol",Description = "SwaptionVolatilityStructure")>] 
         baseVol : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _baseVol = Helper.toHandle<SwaptionVolatilityStructure> baseVol "baseVol" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let builder (current : ICell) = (Fun.SpreadedSwaptionVolatility 
                                                            _baseVol.cell 
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadedSwaptionVolatility>) l

                let source () = Helper.sourceFold "Fun.SpreadedSwaptionVolatility" 
                                               [| _baseVol.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _baseVol.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatilityType", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance4", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance4") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance5", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance5
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance5") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance3", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance3") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance2", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance2
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance2") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance1", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance1") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_blackVariance", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BlackVariance
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BlackVariance") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_maxSwapLength", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".MaxSwapLength") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift4", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift4
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift4") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift5", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift5
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift5") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift1", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift1") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift2", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift2") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_shift3", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_shift3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Shift3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Shift3") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_smileSection1", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SmileSection1
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SmileSection1") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_smileSection2", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SmileSection2
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SmileSection2") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_smileSection", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SmileSection
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SmileSection") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadedSwaptionVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_swapLength", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="start",Description = "Date")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SwapLength") 

                                               [| _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_swapLength1", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_swapLength1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".SwapLength1") 

                                               [| _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility4", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility4") 

                                               [| _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility2", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility2") 

                                               [| _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility5", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility5") 

                                               [| _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility1", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility1
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility1") 

                                               [| _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility3", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "double")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility3") 

                                               [| _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_volatility", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Volatility
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Volatility") 

                                               [| _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_businessDayConvention", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_optionDateFromTenor", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_timeFromReference", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_update", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Update
                                                       ) :> ICell
                let format (o : SpreadedSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_allowsExtrapolation", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_disableExtrapolation", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SpreadedSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_enableExtrapolation", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SpreadedSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_extrapolate", Description="Create a SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedSwaptionVolatility",Description = "SpreadedSwaptionVolatility")>] 
         spreadedswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedSwaptionVolatility = Helper.toModelReference<SpreadedSwaptionVolatility> spreadedswaptionvolatility "SpreadedSwaptionVolatility"  
                let builder (current : ICell) = ((SpreadedSwaptionVolatilityModel.Cast _SpreadedSwaptionVolatility.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadedSwaptionVolatility.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadedSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedSwaptionVolatility_Range", Description="Create a range of SpreadedSwaptionVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadedSwaptionVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadedSwaptionVolatility> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SpreadedSwaptionVolatility> (c)) :> ICell
                let format (i : Cephei.Cell.List<SpreadedSwaptionVolatility>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SpreadedSwaptionVolatility>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
