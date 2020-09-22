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
  Helper class building a sequence of capped/floored yoy inflation coupons   payoff is: spread + gearing x index
  </summary> *)
[<AutoSerializable(true)>]
module yoyInflationLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_yoyInflationLeg_value", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".Value") 
                                               [| _yoyInflationLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _index = Helper.toCell<YoYInflationIndex> index "index" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let builder () = withMnemonic mnemonic (Fun.yoyInflationLeg 
                                                            _schedule.cell 
                                                            _cal.cell 
                                                            _index.cell 
                                                            _observationLag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLeg>) l

                let source = Helper.sourceFold "Fun.yoyInflationLeg" 
                                               [| _schedule.source
                                               ;  _cal.source
                                               ;  _index.source
                                               ;  _observationLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _cal.cell
                                ;  _index.cell
                                ;  _observationLag.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withCaps", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _cap = Helper.toCell<double> cap "cap" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithCaps
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithCaps") 
                                               [| _yoyInflationLeg.source
                                               ;  _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withCaps", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _caps = Helper.toCell<List<Nullable<double>>> caps "caps" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithCaps1
                                                            _caps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithCaps1") 
                                               [| _yoyInflationLeg.source
                                               ;  _caps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withFixingDays", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithFixingDays") 
                                               [| _yoyInflationLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withFixingDays", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithFixingDays1") 
                                               [| _yoyInflationLeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withFloors", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _floors = Helper.toCell<List<Nullable<double>>> floors "floors" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithFloors
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithFloors") 
                                               [| _yoyInflationLeg.source
                                               ;  _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withFloors", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _floor = Helper.toCell<double> floor "floor" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithFloors1
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithFloors1") 
                                               [| _yoyInflationLeg.source
                                               ;  _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withGearings", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithGearings") 
                                               [| _yoyInflationLeg.source
                                               ;  _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withGearings", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithGearings1") 
                                               [| _yoyInflationLeg.source
                                               ;  _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withPaymentDayCounter", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithPaymentDayCounter") 
                                               [| _yoyInflationLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withSpreads", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _spread = Helper.toCell<double> spread "spread" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithSpreads") 
                                               [| _yoyInflationLeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withSpreads", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<yoyInflationLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithSpreads1") 
                                               [| _yoyInflationLeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withNotionals", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithNotionals") 
                                               [| _yoyInflationLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withNotionals", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _notional = Helper.toCell<double> notional "notional" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithNotionals1") 
                                               [| _yoyInflationLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_withPaymentAdjustment", Description="Create a yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="yoyInflationLeg",Description = "Reference to yoyInflationLeg")>] 
         yoyinflationleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _yoyInflationLeg = Helper.toCell<yoyInflationLeg> yoyinflationleg "yoyInflationLeg" true 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let builder () = withMnemonic mnemonic ((_yoyInflationLeg.cell :?> yoyInflationLegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_yoyInflationLeg.source + ".WithPaymentAdjustment") 
                                               [| _yoyInflationLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _yoyInflationLeg.cell
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
    [<ExcelFunction(Name="_yoyInflationLeg_Range", Description="Create a range of yoyInflationLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let yoyInflationLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the yoyInflationLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<yoyInflationLeg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<yoyInflationLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<yoyInflationLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<yoyInflationLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
