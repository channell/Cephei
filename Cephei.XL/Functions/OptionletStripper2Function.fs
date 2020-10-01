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
  Helper class to extend an OptionletStripper1 obj stripping additional optionlet (i.e. caplet/floorlet) volatilities (a.k.a. forward-forward volatilities) from the (cap/floor) At-The-Money term volatilities of a CapFloorTermVolCurve.
  </summary> *)
[<AutoSerializable(true)>]
module OptionletStripper2Function =

    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_atmCapFloorPrices", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_atmCapFloorPrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).AtmCapFloorPrices
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".AtmCapFloorPrices") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_atmCapFloorStrikes", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_atmCapFloorStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).AtmCapFloorStrikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".AtmCapFloorStrikes") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="optionletStripper1",Description = "Reference to optionletStripper1")>] 
         optionletStripper1 : obj)
        ([<ExcelArgument(Name="atmCapFloorTermVolCurve",Description = "Reference to atmCapFloorTermVolCurve")>] 
         atmCapFloorTermVolCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _optionletStripper1 = Helper.toCell<OptionletStripper1> optionletStripper1 "optionletStripper1" 
                let _atmCapFloorTermVolCurve = Helper.toHandle<CapFloorTermVolCurve> atmCapFloorTermVolCurve "atmCapFloorTermVolCurve" 
                let builder () = withMnemonic mnemonic (Fun.OptionletStripper2 
                                                            _optionletStripper1.cell 
                                                            _atmCapFloorTermVolCurve.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptionletStripper2>) l

                let source = Helper.sourceFold "Fun.OptionletStripper2" 
                                               [| _optionletStripper1.source
                                               ;  _atmCapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _optionletStripper1.cell
                                ;  _atmCapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_spreadsVol", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_spreadsVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).SpreadsVol
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".SpreadsVol") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_atmOptionletRates", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_atmOptionletRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).AtmOptionletRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".AtmOptionletRates") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_businessDayConvention", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OptionletStripper2.source + ".BusinessDayConvention") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_calendar", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".Calendar") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_dayCounter", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".DayCounter") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_displacement", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper2.source + ".Displacement") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_iborIndex", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".IborIndex") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_optionletAccrualPeriods", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletAccrualPeriods
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletAccrualPeriods
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletAccrualPeriods") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletFixingDates", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletFixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletFixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletFixingDates") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletFixingTenors", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletFixingTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletFixingTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletFixingTenors") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletFixingTimes", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletFixingTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletFixingTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletFixingTimes") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletMaturities", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletMaturities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletMaturities
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletMaturities") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletPaymentDates", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletPaymentDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletPaymentDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletPaymentDates") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletStrikes", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletStrikes
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletStrikes") 
                                               [| _OptionletStripper2.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_optionletVolatilities", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_optionletVolatilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).OptionletVolatilities
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OptionletStripper2.source + ".OptionletVolatilities") 
                                               [| _OptionletStripper2.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_settlementDays", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OptionletStripper2.source + ".SettlementDays") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_termVolSurface", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_termVolSurface
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).TermVolSurface
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold (_OptionletStripper2.source + ".TermVolSurface") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper2_volatilityType", Description="Create a OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper2",Description = "Reference to OptionletStripper2")>] 
         optionletstripper2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper2 = Helper.toCell<OptionletStripper2> optionletstripper2 "OptionletStripper2"  
                let builder () = withMnemonic mnemonic ((_OptionletStripper2.cell :?> OptionletStripper2Model).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OptionletStripper2.source + ".VolatilityType") 
                                               [| _OptionletStripper2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper2.cell
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
    [<ExcelFunction(Name="_OptionletStripper2_Range", Description="Create a range of OptionletStripper2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OptionletStripper2_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OptionletStripper2")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OptionletStripper2> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OptionletStripper2>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OptionletStripper2>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OptionletStripper2>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
