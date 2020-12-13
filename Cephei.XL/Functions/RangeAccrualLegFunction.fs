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
  helper class building a sequence of range-accrual floating-rate coupons
  </summary> *)
[<AutoSerializable(true)>]
module RangeAccrualLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_Leg", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_Leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).Leg
                                                       ) :> ICell
                let format (i : Cephei.Cell.List<CashFlow>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".Leg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
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
    [<ExcelFunction(Name="_RangeAccrualLeg", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.RangeAccrualLeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold "Fun.RangeAccrualLeg" 
                                               [| _schedule.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _index.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withFixingDays", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withFixingDays1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withGearings", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithGearings") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withGearings1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithGearings1") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withLowerTriggers", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withLowerTriggers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="triggers",Description = "double range")>] 
         triggers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _triggers = Helper.toCell<Generic.List<double>> triggers "triggers" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithLowerTriggers
                                                            _triggers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithLowerTriggers") 

                                               [| _triggers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _triggers.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withLowerTriggers1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withLowerTriggers1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="trigger",Description = "double")>] 
         trigger : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _trigger = Helper.toCell<double> trigger "trigger" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithLowerTriggers1
                                                            _trigger.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithLowerTriggers1") 

                                               [| _trigger.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _trigger.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withNotionals1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withNotionals", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithNotionals") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withObservationConvention", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withObservationConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithObservationConvention
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithObservationConvention") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withObservationTenor", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withObservationTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithObservationTenor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithObservationTenor") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withPaymentAdjustment", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withPaymentDayCounter", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withSpreads", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithSpreads
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithSpreads") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withSpreads1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithSpreads1
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithSpreads1") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withUpperTriggers1", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withUpperTriggers1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="triggers",Description = "double range")>] 
         triggers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _triggers = Helper.toCell<Generic.List<double>> triggers "triggers" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithUpperTriggers1
                                                            _triggers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithUpperTriggers") 

                                               [| _triggers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _triggers.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualLeg_withUpperTriggers", Description="Create a RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_withUpperTriggers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualLeg",Description = "RangeAccrualLeg")>] 
         rangeaccrualleg : obj)
        ([<ExcelArgument(Name="trigger",Description = "double")>] 
         trigger : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualLeg = Helper.toCell<RangeAccrualLeg> rangeaccrualleg "RangeAccrualLeg"  
                let _trigger = Helper.toCell<double> trigger "trigger" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualLegModel.Cast _RangeAccrualLeg.cell).WithUpperTriggers
                                                            _trigger.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualLeg>) l

                let source () = Helper.sourceFold (_RangeAccrualLeg.source + ".WithUpperTriggers") 

                                               [| _trigger.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualLeg.cell
                                ;  _trigger.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RangeAccrualLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_RangeAccrualLeg_Range", Description="Create a range of RangeAccrualLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RangeAccrualLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RangeAccrualLeg> (c)) :> ICell
                let format (i : Cephei.Cell.List<RangeAccrualLeg>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RangeAccrualLeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
