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
module OptionletStripperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_atmOptionletRates", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_atmOptionletRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).AtmOptionletRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper.source + ".AtmOptionletRates") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_businessDayConvention", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OptionletStripper.source + ".BusinessDayConvention") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_calendar", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_OptionletStripper.source + ".Calendar") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_dayCounter", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_OptionletStripper.source + ".DayCounter") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_displacement", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper.source + ".Displacement") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_iborIndex", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_OptionletStripper.source + ".IborIndex") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_optionletAccrualPeriods", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletAccrualPeriods
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletAccrualPeriods
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletAccrualPeriods") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletFixingDates", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletFixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletFixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletFixingDates") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletFixingTenors", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletFixingTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletFixingTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletFixingTenors") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletFixingTimes", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletFixingTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletFixingTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletFixingTimes") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletMaturities", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletMaturities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletMaturities
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletMaturities") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_optionletPaymentDates", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletPaymentDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletPaymentDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletPaymentDates") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        StrippedOptionletBase interface
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletStrikes", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletStrikes
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletStrikes") 
                                               [| _OptionletStripper.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_optionletVolatilities", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_optionletVolatilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).OptionletVolatilities
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper.source + ".OptionletVolatilities") 
                                               [| _OptionletStripper.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper_settlementDays", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper.source + ".SettlementDays") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_termVolSurface", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_termVolSurface
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).TermVolSurface
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold (_OptionletStripper.source + ".TermVolSurface") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_volatilityType", Description="Create a OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper",Description = "Reference to OptionletStripper")>] 
         optionletstripper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper = Helper.toCell<OptionletStripper> optionletstripper "OptionletStripper" true 
                let builder () = withMnemonic mnemonic ((_OptionletStripper.cell :?> OptionletStripperModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OptionletStripper.source + ".VolatilityType") 
                                               [| _OptionletStripper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper.cell
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
    [<ExcelFunction(Name="_OptionletStripper_Range", Description="Create a range of OptionletStripper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OptionletStripper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OptionletStripper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OptionletStripper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OptionletStripper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OptionletStripper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
