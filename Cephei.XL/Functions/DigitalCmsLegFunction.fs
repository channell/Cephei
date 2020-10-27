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
module DigitalCmsLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "SwapIndex")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<SwapIndex> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DigitalCmsLeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold "Fun.DigitalCmsLeg" 
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
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_inArrears1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_inArrears1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).InArrears1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".InArrears1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_inArrears", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).InArrears
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".InArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_value", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallATM
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallATM") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallATM1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallATM1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallATM1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallATM1") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallPayoffs1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallPayoffs1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "double range")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallPayoffs1
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallPayoffs1") 

                                               [| _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoffs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "double")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _payoff = Helper.toCell<double> payoff "payoff" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallPayoffs
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallPayoffs") 

                                               [| _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallStrikes1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallStrikes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallStrikes1
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallStrikes1") 

                                               [| _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strikes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithCallStrikes
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallStrikes") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withFixingDays1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withFixingDays", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withGearings", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithGearings") 

                                               [| _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withGearings1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithGearings1") 

                                               [| _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withLongCallOption", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withLongCallOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithLongCallOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithLongCallOption") 

                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withLongPutOption", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withLongPutOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithLongPutOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithLongPutOption") 

                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withNotionals1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withNotionals", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithNotionals") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPaymentAdjustment", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPaymentDayCounter", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "bool")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _flag = Helper.toCell<bool> flag "flag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutATM
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutATM") 

                                               [| _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _flag.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutATM1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutATM1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutATM1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutATM1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "double range")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutPayoffs
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutPayoffs") 

                                               [| _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoffs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutPayoffs1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutPayoffs1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "double")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _payoff = Helper.toCell<double> payoff "payoff" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutPayoffs1
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutPayoffs1") 

                                               [| _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutStrikes
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutStrikes") 

                                               [| _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strikes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutStrikes1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutStrikes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithPutStrikes1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutStrikes1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withReplication", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withReplication
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="replication",Description = "DigitalReplication")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _replication = Helper.toCell<DigitalReplication> replication "replication" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithReplication
                                                            _replication.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithReplication") 

                                               [| _replication.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _replication.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withReplication1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withReplication1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithReplication1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithReplication1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withSpreads1", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithSpreads1") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withSpreads", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalCmsLegModel.Cast _DigitalCmsLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source () = Helper.sourceFold (_DigitalCmsLeg.source + ".WithSpreads") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DigitalCmsLeg_Range", Description="Create a range of DigitalCmsLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalCmsLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalCmsLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalCmsLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DigitalCmsLeg>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
