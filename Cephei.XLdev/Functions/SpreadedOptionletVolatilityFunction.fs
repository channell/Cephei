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
module SpreadedOptionletVolatilityFunction =

    (*
        All virtual methods of base classes must be forwarded VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_businessDayConvention", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".BusinessDayConvention") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_calendar", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Calendar") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_dayCounter", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".DayCounter") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_maxDate", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".MaxDate") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_maxStrike", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".MaxStrike") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_maxTime", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".MaxTime") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_minStrike", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".MinStrike") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_referenceDate", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".ReferenceDate") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_settlementDays", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".SettlementDays") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="baseVol",Description = "Reference to baseVol")>] 
         baseVol : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _baseVol = Helper.toHandle<Handle<OptionletVolatilityStructure>> baseVol "baseVol" 
                let _spread = Helper.toHandle<Handle<Quote>> spread "spread" 
                let builder () = withMnemonic mnemonic (Fun.SpreadedOptionletVolatility 
                                                            _baseVol.cell 
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadedOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.SpreadedOptionletVolatility" 
                                               [| _baseVol.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _baseVol.cell
                                ;  _spread.cell
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
        ! returns the Black variance for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_blackVariance", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).BlackVariance
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".BlackVariance") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_blackVariance", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).BlackVariance1
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".BlackVariance1") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_blackVariance", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).BlackVariance2
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".BlackVariance2") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_displacement", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Displacement") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
        ! returns the smile for a given option time
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_smileSection", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).SmileSection
                                                            _optionTime.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".SmileSection") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option date
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_smileSection", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).SmileSection1
                                                            _optionDate.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".SmileSection1") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option tenor
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_smileSection", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).SmileSection2
                                                            _optionTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".SmileSection2") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _extr.cell
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
        ! returns the volatility for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_volatility", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Volatility
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Volatility") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_volatility", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Volatility1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Volatility1") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_volatility", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Volatility2
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Volatility2") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_volatilityType", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".VolatilityType") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_optionDateFromTenor", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".OptionDateFromTenor") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _p.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_timeFromReference", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".TimeFromReference") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_update", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Update
                                                       ) :> ICell
                let format (o : SpreadedOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Update") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_allowsExtrapolation", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".AllowsExtrapolation") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_disableExtrapolation", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SpreadedOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".DisableExtrapolation") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_enableExtrapolation", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SpreadedOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".EnableExtrapolation") 
                                               [| _SpreadedOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_extrapolate", Description="Create a SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadedOptionletVolatility",Description = "Reference to SpreadedOptionletVolatility")>] 
         spreadedoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadedOptionletVolatility = Helper.toCell<SpreadedOptionletVolatility> spreadedoptionletvolatility "SpreadedOptionletVolatility" true 
                let builder () = withMnemonic mnemonic ((_SpreadedOptionletVolatility.cell :?> SpreadedOptionletVolatilityModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadedOptionletVolatility.source + ".Extrapolate") 
                                               [| _SpreadedOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadedOptionletVolatility.cell
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
    [<ExcelFunction(Name="_SpreadedOptionletVolatility_Range", Description="Create a range of SpreadedOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadedOptionletVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SpreadedOptionletVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadedOptionletVolatility> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SpreadedOptionletVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SpreadedOptionletVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SpreadedOptionletVolatility>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
