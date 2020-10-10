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
  Constant callable-bond volatility, no time-strike dependence
  </summary> *)
[<AutoSerializable(true)>]
module CallableBondConstantVolatilityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CallableBondConstantVolatility 
                                                            _referenceDate.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableBondConstantVolatility>) l

                let source () = Helper.sourceFold "Fun.CallableBondConstantVolatility" 
                                               [| _referenceDate.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility2", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CallableBondConstantVolatility2
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableBondConstantVolatility>) l

                let source () = Helper.sourceFold "Fun.CallableBondConstantVolatility2" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility1", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CallableBondConstantVolatility1
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableBondConstantVolatility>) l

                let source () = Helper.sourceFold "Fun.CallableBondConstantVolatility1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility3", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CallableBondConstantVolatility3 
                                                            _referenceDate.cell 
                                                            _volatility.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableBondConstantVolatility>) l

                let source () = Helper.sourceFold "Fun.CallableBondConstantVolatility3" 
                                               [| _referenceDate.source
                                               ;  _volatility.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _volatility.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_dayCounter", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".DayCounter") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_maxBondLength", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_maxBondLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MaxBondLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MaxBondLength") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
        CallableBondConstantVolatility interface
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_maxBondTenor", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_maxBondTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MaxBondTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MaxBondTenor") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_maxDate", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MaxDate") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_maxStrike", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MaxStrike") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_minStrike", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MinStrike") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
        ! returns the Black variance for a given option date and bond tenor
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_blackVariance", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).BlackVariance
                                                            _optionDate.cell 
                                                            _bondTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".BlackVariance") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionDate.source
                                               ;  _bondTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionDate.cell
                                ;  _bondTenor.cell
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
        ! returns the Black variance for a given option time and bondLength
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_blackVariance1", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="bondLength",Description = "Reference to bondLength")>] 
         bondLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _bondLength = Helper.toCell<double> bondLength "bondLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).BlackVariance1
                                                            _optionTime.cell 
                                                            _bondLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".BlackVariance1") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTime.source
                                               ;  _bondLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTime.cell
                                ;  _bondLength.cell
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
        ! returns the Black variance for a given option tenor and bond tenor
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_blackVariance2", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).BlackVariance2
                                                            _optionTenor.cell 
                                                            _bondTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".BlackVariance2") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTenor.source
                                               ;  _bondTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTenor.cell
                                ;  _bondTenor.cell
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
        ! the business day convention used for option date calculation
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_businessDayConvention", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".BusinessDayConvention") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
        ! implements the conversion between dates and times
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_convertDates", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_convertDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).ConvertDates
                                                            _optionDate.cell 
                                                            _bondTenor.cell 
                                                       ) :> ICell
                let format (o : System.Collections.Generic.KeyValuePair<double,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".ConvertDates") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionDate.source
                                               ;  _bondTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionDate.cell
                                ;  _bondTenor.cell
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
        ! implements the conversion between optionTenors and optionDates
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_optionDateFromTenor", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).OptionDateFromTenor
                                                            _optionTenor.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".OptionDateFromTenor") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTenor.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_smileSection1", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).SmileSection1
                                                            _optionTenor.cell 
                                                            _bondTenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".SmileSection1") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTenor.source
                                               ;  _bondTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTenor.cell
                                ;  _bondTenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_smileSection", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).SmileSection
                                                            _optionDate.cell 
                                                            _bondTenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".SmileSection") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionDate.source
                                               ;  _bondTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionDate.cell
                                ;  _bondTenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the volatility for a given option tenor and bond tenor
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_volatility2", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Volatility2
                                                            _optionTenor.cell 
                                                            _bondTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Volatility2") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTenor.source
                                               ;  _bondTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTenor.cell
                                ;  _bondTenor.cell
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
        ! returns the volatility for a given option date and bond tenor
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_volatility1", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Volatility1
                                                            _optionDate.cell 
                                                            _bondTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Volatility") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionDate.source
                                               ;  _bondTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionDate.cell
                                ;  _bondTenor.cell
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
        ! returns the volatility for a given option time and bondLength
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_volatility", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _optionTenor = Helper.toCell<double> optionTenor "optionTenor" 
                let _bondTenor = Helper.toCell<double> bondTenor "bondTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Volatility
                                                            _optionTenor.cell 
                                                            _bondTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Volatility") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _optionTenor.source
                                               ;  _bondTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                ;  _optionTenor.cell
                                ;  _bondTenor.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_calendar", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Calendar") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBondConstantVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_maxTime", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".MaxTime") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_referenceDate", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".ReferenceDate") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_CallableBondConstantVolatility_settlementDays", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".SettlementDays") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_timeFromReference", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".TimeFromReference") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_update", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Update
                                                       ) :> ICell
                let format (o : CallableBondConstantVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Update") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_allowsExtrapolation", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".AllowsExtrapolation") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_disableExtrapolation", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CallableBondConstantVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".DisableExtrapolation") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_enableExtrapolation", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CallableBondConstantVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".EnableExtrapolation") 
                                               [| _CallableBondConstantVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_extrapolate", Description="Create a CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBondConstantVolatility",Description = "Reference to CallableBondConstantVolatility")>] 
         callablebondconstantvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBondConstantVolatility = Helper.toCell<CallableBondConstantVolatility> callablebondconstantvolatility "CallableBondConstantVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondConstantVolatilityModel.Cast _CallableBondConstantVolatility.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBondConstantVolatility.source + ".Extrapolate") 
                                               [| _CallableBondConstantVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBondConstantVolatility.cell
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
    [<ExcelFunction(Name="_CallableBondConstantVolatility_Range", Description="Create a range of CallableBondConstantVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBondConstantVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CallableBondConstantVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableBondConstantVolatility> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableBondConstantVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableBondConstantVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CallableBondConstantVolatility>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
