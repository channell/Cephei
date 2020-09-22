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
    [<ExcelFunction(Name="_DigitalCmsLeg", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<SwapIndex> index "index" true
                let builder () = withMnemonic mnemonic (Fun.DigitalCmsLeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold "Fun.DigitalCmsLeg" 
                                               [| _schedule.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_inArrears", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "Reference to flag")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _flag = Helper.toCell<bool> flag "flag" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).InArrears
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".InArrears") 
                                               [| _DigitalCmsLeg.source
                                               ;  _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_inArrears", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_inArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).InArrears1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".InArrears1") 
                                               [| _DigitalCmsLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_value", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".Value") 
                                               [| _DigitalCmsLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallATM
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallATM") 
                                               [| _DigitalCmsLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "Reference to flag")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _flag = Helper.toCell<bool> flag "flag" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallATM1
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallATM1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "Reference to payoffs")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallPayoffs
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallPayoffs") 
                                               [| _DigitalCmsLeg.source
                                               ;  _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoffs.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _payoff = Helper.toCell<double> payoff "payoff" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallPayoffs1
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallPayoffs1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoff.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallStrikes
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallStrikes") 
                                               [| _DigitalCmsLeg.source
                                               ;  _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strikes.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withCallStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withCallStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithCallStrikes1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithCallStrikes1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withFixingDays", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithFixingDays") 
                                               [| _DigitalCmsLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withFixingDays", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithFixingDays1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withGearings", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithGearings") 
                                               [| _DigitalCmsLeg.source
                                               ;  _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withGearings", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithGearings1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withLongCallOption", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withLongCallOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _Type = Helper.toCell<Position.Type> Type "Type" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithLongCallOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithLongCallOption") 
                                               [| _DigitalCmsLeg.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _Type.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withLongPutOption", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withLongPutOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _Type = Helper.toCell<Position.Type> Type "Type" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithLongPutOption
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithLongPutOption") 
                                               [| _DigitalCmsLeg.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _Type.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withNotionals", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithNotionals") 
                                               [| _DigitalCmsLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withNotionals", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _notional = Helper.toCell<double> notional "notional" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithNotionals1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPaymentAdjustment", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPaymentAdjustment") 
                                               [| _DigitalCmsLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsLeg_withPaymentDayCounter", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPaymentDayCounter") 
                                               [| _DigitalCmsLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="flag",Description = "Reference to flag")>] 
         flag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _flag = Helper.toCell<bool> flag "flag" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutATM
                                                            _flag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutATM") 
                                               [| _DigitalCmsLeg.source
                                               ;  _flag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutATM", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutATM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutATM1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutATM1") 
                                               [| _DigitalCmsLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoffs",Description = "Reference to payoffs")>] 
         payoffs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _payoffs = Helper.toCell<Generic.List<double>> payoffs "payoffs" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutPayoffs
                                                            _payoffs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutPayoffs") 
                                               [| _DigitalCmsLeg.source
                                               ;  _payoffs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoffs.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutPayoffs", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutPayoffs
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _payoff = Helper.toCell<double> payoff "payoff" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutPayoffs1
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutPayoffs1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _payoff.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutStrikes
                                                            _strikes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutStrikes") 
                                               [| _DigitalCmsLeg.source
                                               ;  _strikes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strikes.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withPutStrikes", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withPutStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithPutStrikes1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithPutStrikes1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withReplication", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withReplication
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="replication",Description = "Reference to replication")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _replication = Helper.toCell<DigitalReplication> replication "replication" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithReplication
                                                            _replication.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithReplication") 
                                               [| _DigitalCmsLeg.source
                                               ;  _replication.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
                                ;  _replication.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withReplication", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withReplication
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithReplication1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithReplication1") 
                                               [| _DigitalCmsLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withSpreads", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithSpreads
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithSpreads") 
                                               [| _DigitalCmsLeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_withSpreads", Description="Create a DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsLeg",Description = "Reference to DigitalCmsLeg")>] 
         digitalcmsleg : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsLeg = Helper.toCell<DigitalCmsLeg> digitalcmsleg "DigitalCmsLeg" true 
                let _spread = Helper.toCell<double> spread "spread" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsLeg.cell :?> DigitalCmsLegModel).WithSpreads1
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsLeg>) l

                let source = Helper.sourceFold (_DigitalCmsLeg.source + ".WithSpreads1") 
                                               [| _DigitalCmsLeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsLeg.cell
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
    [<ExcelFunction(Name="_DigitalCmsLeg_Range", Description="Create a range of DigitalCmsLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DigitalCmsLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalCmsLeg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalCmsLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalCmsLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DigitalCmsLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
