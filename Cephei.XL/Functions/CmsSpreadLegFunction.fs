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
    [<ExcelFunction(Name="_CmsSpreadLeg", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="swapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapSpreadIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _swapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapSpreadIndex "swapSpreadIndex" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CmsSpreadLeg 
                                                            _schedule.cell 
                                                            _swapSpreadIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsSpreadLeg>) l

                let source () = Helper.sourceFold "Fun.CmsSpreadLeg" 
                                               [| _schedule.source
                                               ;  _swapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _swapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_value", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_CmsSpreadLeg_inArrears1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".InArrears1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_inArrears", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".InArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withCaps", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithCaps
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithCaps") 

                                               [| _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _caps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withCaps1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _cap = Helper.toNullable<double> cap "cap"
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithCaps1") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withFixingDays1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withFixingDays", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withFloors1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFloors1") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withFloors", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _floor = Helper.toNullable<double> floor "floor"
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithFloors
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithFloors") 

                                               [| _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _floor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withGearings", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithGearings
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithGearings") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withGearings1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithGearings1
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithGearings1") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withPaymentDayCounter", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withSpreads1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithSpreads1") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withSpreads", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithSpreads") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withZeroPayments1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withZeroPayments1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithZeroPayments1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithZeroPayments1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withZeroPayments", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withZeroPayments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithZeroPayments
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithZeroPayments") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withNotionals1", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
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
    [<ExcelFunction(Name="_CmsSpreadLeg_withNotionals", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithNotionals") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadLeg_withPaymentAdjustment", Description="Create a CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadLeg",Description = "CmsSpreadLeg")>] 
         cmsspreadleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadLeg = Helper.toCell<CmsSpreadLeg> cmsspreadleg "CmsSpreadLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsSpreadLegModel.Cast _CmsSpreadLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsSpreadLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CmsSpreadLeg_Range", Description="Create a range of CmsSpreadLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsSpreadLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<CmsSpreadLeg> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<CmsSpreadLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CmsSpreadLeg>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
