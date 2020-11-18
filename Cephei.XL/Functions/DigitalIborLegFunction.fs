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
  helper class building a sequence of digital ibor-rate coupons
  </summary> *)
[<AutoSerializable(true)>]
module DigitalIborLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DigitalIborLeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold "Fun.DigitalIborLeg" 
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
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_inArrears1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".InArrears1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_inArrears", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".InArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_value", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
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
    [<ExcelFunction(Name="_DigitalIborLeg_withCallATM", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallATM
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallATM") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withCallATM1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallATM1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallATM1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallATM1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withCallPayoffs1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallPayoffs1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "double")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _payoff = Helper.toCell<double> payoff "payoff" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallPayoffs1
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallPayoffs1") 

                                               [| _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _payoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withCallPayoffs", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "double range")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallPayoffs
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallPayoffs") 

                                               [| _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _payoffs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withCallStrikes1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallStrikes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallStrikes1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallStrikes1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withCallStrikes", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withCallStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithCallStrikes
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithCallStrikes") 

                                               [| _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _strikes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withFixingDays", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withFixingDays1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withGearings", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithGearings") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withGearings1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithGearings1") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withLongCallOption", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withLongCallOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithLongCallOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithLongCallOption") 

                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withLongPutOption", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withLongPutOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithLongPutOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithLongPutOption") 

                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withNotionals", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithNotionals") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withNotionals1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithNotionals1") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPaymentAdjustment", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPaymentDayCounter", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutATM", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutATM
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutATM") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutATM1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutATM1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutATM1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutATM1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutPayoffs", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "double range")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutPayoffs
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutPayoffs") 

                                               [| _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _payoffs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutPayoffs1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutPayoffs1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "double")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _payoff = Helper.toCell<double> payoff "payoff" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutPayoffs1
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutPayoffs1") 

                                               [| _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _payoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutStrikes1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutStrikes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutStrikes1
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutStrikes1") 

                                               [| _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _strikes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withPutStrikes", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withPutStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithPutStrikes
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithPutStrikes") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withReplication1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withReplication1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="replication",Description = "DigitalReplication")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _replication = Helper.toCell<DigitalReplication> replication "replication" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithReplication1
                                                            _replication.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithReplication1") 

                                               [| _replication.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _replication.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withReplication", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withReplication
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithReplication
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithReplication") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withSpreads", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithSpreads
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithSpreads") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborLeg_withSpreads1", Description="Create a DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborLeg",Description = "DigitalIborLeg")>] 
         digitaliborleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborLeg = Helper.toCell<DigitalIborLeg> digitaliborleg "DigitalIborLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalIborLegModel.Cast _DigitalIborLeg.cell).WithSpreads1
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborLeg>) l

                let source () = Helper.sourceFold (_DigitalIborLeg.source + ".WithSpreads1") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DigitalIborLeg_Range", Description="Create a range of DigitalIborLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalIborLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<DigitalIborLeg> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<DigitalIborLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DigitalIborLeg>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
