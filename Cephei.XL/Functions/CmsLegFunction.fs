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
  helper class building a sequence of capped/floored cms-rate coupons
  </summary> *)
[<AutoSerializable(true)>]
module CmsLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="swapIndex",Description = "SwapIndex")>] 
         swapIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _swapIndex = Helper.toCell<SwapIndex> swapIndex "swapIndex" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CmsLeg 
                                                            _schedule.cell 
                                                            _swapIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsLeg>) l

                let source () = Helper.sourceFold "Fun.CmsLeg" 
                                               [| _schedule.source
                                               ;  _swapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _swapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_value", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CmsLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
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
    [<ExcelFunction(Name="_CmsLeg_inArrears1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".InArrears1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_inArrears", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".InArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withCaps", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithCaps
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithCaps") 

                                               [| _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _caps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withCaps1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _cap = Helper.toNullable<double> cap "cap"
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithCaps1") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withFixingDays1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withFixingDays", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withFloors1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithFloors1") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withFloors", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _floor = Helper.toNullable<double> floor "floor"
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithFloors
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithFloors") 

                                               [| _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _floor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withGearings", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithGearings
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithGearings") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withGearings1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithGearings1
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithGearings1") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
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
    [<ExcelFunction(Name="_CmsLeg_withPaymentDayCounter", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withSpreads1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithSpreads1") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withSpreads", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithSpreads") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withZeroPayments1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withZeroPayments1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithZeroPayments1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithZeroPayments1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withZeroPayments", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withZeroPayments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithZeroPayments
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithZeroPayments") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withNotionals1", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
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
    [<ExcelFunction(Name="_CmsLeg_withNotionals", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithNotionals1") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsLeg_withPaymentAdjustment", Description="Create a CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsLeg",Description = "CmsLeg")>] 
         cmsleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsLeg = Helper.toCell<CmsLeg> cmsleg "CmsLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsLegModel.Cast _CmsLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CmsLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CmsLeg_Range", Description="Create a range of CmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CmsLeg> (c)) :> ICell
                let format (i : Generic.List<ICell<CmsLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CmsLeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
