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
  helper class building a sequence of capped/floored ibor-rate coupons
  </summary> *)
[<AutoSerializable(true)>]
module IborLegFunction =

    (*
        constructor
    *)
    [<ExcelFunction(Name="_IborLeg", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.IborLeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborLeg>) l

                let source () = Helper.sourceFold "Fun.IborLeg" 
                                               [| _schedule.source
                                               ;  _index.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _index.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_value", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_IborLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
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
    [<ExcelFunction(Name="_IborLeg_inArrears1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".InArrears1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_inArrears", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".InArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withCaps", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithCaps
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithCaps") 

                                               [| _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _caps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withCaps1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _cap = Helper.toNullable<double> cap "cap"
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithCaps1") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withFixingDays1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withFixingDays", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withFloors1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithFloors1") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withFloors", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _floor = Helper.toNullable<double> floor "floor"
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithFloors
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithFloors") 

                                               [| _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _floor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withGearings", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithGearings
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithGearings") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withGearings1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithGearings1
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithGearings1") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
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
    [<ExcelFunction(Name="_IborLeg_withPaymentDayCounter", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withSpreads1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithSpreads1") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withSpreads", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithSpreads") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withZeroPayments1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withZeroPayments1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithZeroPayments1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithZeroPayments1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withZeroPayments", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withZeroPayments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithZeroPayments
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithZeroPayments") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withNotionals1", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
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
    [<ExcelFunction(Name="_IborLeg_withNotionals", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithNotional") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IborLeg_withPaymentAdjustment", Description="Create a IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborLeg",Description = "IborLeg")>] 
         iborleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborLeg = Helper.toCell<IborLeg> iborleg "IborLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((IborLegModel.Cast _IborLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_IborLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_IborLeg_Range", Description="Create a range of IborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IborLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IborLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<IborLeg> (c)) :> ICell
                let format (i : Generic.List<ICell<IborLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<IborLeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
