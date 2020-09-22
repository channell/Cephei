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
module CmsSpreadLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="swapSpreadIndex",Description = "Reference to swapSpreadIndex")>] 
         swapSpreadIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _swapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapSpreadIndex "swapSpreadIndex" true
                let builder () = withMnemonic mnemonic (Fun.CmsSpreadLeg 
                                                            _schedule.cell 
                                                            _swapSpreadIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsSpreadLeg>) l

                let source = Helper.sourceFold "Fun.CmsSpreadLeg" 
                                               [| _schedule.source
                                               ;  _swapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _swapSpreadIndex.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_value", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".Value") 
                                               [| _CmsSpreadLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_inArrears1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="flag",Description = "Reference to flag")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _flag = Helper.toCell<bool> flag "flag" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".InArrears1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _flag.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_inArrears", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".InArrears") 
                                               [| _CmsSpreadLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withCaps", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _caps = Helper.toCell<Generic.List<Nullable<double>>> caps "caps" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithCaps
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithCaps") 
                                               [| _CmsSpreadLeg.source
                                               ;  _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _caps.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withCaps1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _cap = Helper.toNullable<double> cap "cap"
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithCaps1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _cap.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withFixingDays1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFixingDays1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _fixingDays.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withFixingDays", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFixingDays") 
                                               [| _CmsSpreadLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _fixingDays.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withFloors1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _floors = Helper.toCell<Generic.List<Nullable<double>>> floors "floors" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFloors1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _floors.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withFloors", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _floor = Helper.toNullable<double> floor "floor"
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithFloors
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFloors") 
                                               [| _CmsSpreadLeg.source
                                               ;  _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _floor.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withGearings", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithGearings
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithGearings") 
                                               [| _CmsSpreadLeg.source
                                               ;  _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _gearing.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withGearings1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithGearings1
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithGearings1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _gearings.cell
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
        initializers
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withPaymentDayCounter", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithPaymentDayCounter") 
                                               [| _CmsSpreadLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _dayCounter.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withSpreads1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithSpreads1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _spreads.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withSpreads", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _spread = Helper.toCell<double> spread "spread" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithSpreads") 
                                               [| _CmsSpreadLeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
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
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withZeroPayments1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withZeroPayments1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="flag",Description = "Reference to flag")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _flag = Helper.toCell<bool> flag "flag" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithZeroPayments1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithZeroPayments1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _flag.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withZeroPayments", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withZeroPayments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithZeroPayments
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithZeroPayments") 
                                               [| _CmsSpreadLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withNotionals1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithNotionals1") 
                                               [| _CmsSpreadLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _notionals.cell
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
        initializers
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withNotionals", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _notional = Helper.toCell<double> notional "notional" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithNotionals") 
                                               [| _CmsSpreadLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _notional.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withPaymentAdjustment", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "Reference to CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg" true 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let builder () = withMnemonic mnemonic ((_CmsSpreadLeg.cell :?> CmsSpreadLegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CmsSpreadLeg.source + ".WithPaymentAdjustment") 
                                               [| _CmsSpreadLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _convention.cell
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
    [<ExcelFunction(Name="_CmsSpreadLeg_Range", Description="Create a range of CmsSpreadLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsSpreadLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CmsSpreadLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsSpreadLeg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CmsSpreadLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CmsSpreadLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CmsSpreadLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
