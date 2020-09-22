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
  Also allowing for the inflated notional at the end... especially if there is only one date in the schedule. If a fixedRate is zero you get a FixedRateCoupon, otherwise you get a ZeroInflationCoupon.  payoff is: spread + fixedRate x index
  </summary> *)
[<AutoSerializable(true)>]
module CPILegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "Reference to baseCPI")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<ZeroInflationIndex> index "index" true
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let builder () = withMnemonic mnemonic (Fun.CPILeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _baseCPI.cell 
                                                            _observationLag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILeg>) l

                let source = Helper.sourceFold "Fun.CPILeg" 
                                               [| _schedule.source
                                               ;  _index.source
                                               ;  _baseCPI.source
                                               ;  _observationLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _index.cell
                                ;  _baseCPI.cell
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
    [<ExcelFunction(Name="_CPILeg_value", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CPILeg.source + ".Value") 
                                               [| _CPILeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withCaps", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _cap = Helper.toCell<List<Nullable<double>>> cap "cap" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithCaps
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithCaps") 
                                               [| _CPILeg.source
                                               ;  _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withCaps", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _cap = Helper.toCell<double> cap "cap" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithCaps1") 
                                               [| _CPILeg.source
                                               ;  _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withExCouponPeriod", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withExCouponPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="period",Description = "Reference to period")>] 
         period : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _period = Helper.toCell<Period> period "period" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithExCouponPeriod
                                                            _period.cell 
                                                            _cal.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithExCouponPeriod") 
                                               [| _CPILeg.source
                                               ;  _period.source
                                               ;  _cal.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _period.cell
                                ;  _cal.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_CPILeg_withFixedRates", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFixedRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixedRates",Description = "Reference to fixedRates")>] 
         fixedRates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _fixedRates = Helper.toCell<Generic.List<double>> fixedRates "fixedRates" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFixedRates
                                                            _fixedRates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFixedRates") 
                                               [| _CPILeg.source
                                               ;  _fixedRates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixedRates.cell
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
    [<ExcelFunction(Name="_CPILeg_withFixedRates", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFixedRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFixedRates1
                                                            _fixedRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFixedRates1") 
                                               [| _CPILeg.source
                                               ;  _fixedRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixedRate.cell
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
    [<ExcelFunction(Name="_CPILeg_withFixingDays", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFixingDays") 
                                               [| _CPILeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withFixingDays", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFixingDays1") 
                                               [| _CPILeg.source
                                               ;  _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withFloors", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _floors = Helper.toCell<List<Nullable<double>>> floors "floors" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFloors
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFloors") 
                                               [| _CPILeg.source
                                               ;  _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withFloors", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _floors = Helper.toCell<double> floors "floors" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithFloors1") 
                                               [| _CPILeg.source
                                               ;  _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withObservationInterpolation", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withObservationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="interp",Description = "Reference to interp")>] 
         interp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _interp = Helper.toCell<InterpolationType> interp "interp" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithObservationInterpolation
                                                            _interp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithObservationInterpolation") 
                                               [| _CPILeg.source
                                               ;  _interp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _interp.cell
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
    [<ExcelFunction(Name="_CPILeg_withPaymentCalendar", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withPaymentCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithPaymentCalendar
                                                            _cal.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithPaymentCalendar") 
                                               [| _CPILeg.source
                                               ;  _cal.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _cal.cell
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
    [<ExcelFunction(Name="_CPILeg_withPaymentDayCounter", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithPaymentDayCounter") 
                                               [| _CPILeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withSpreads", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithSpreads
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithSpreads") 
                                               [| _CPILeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withSpreads", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _spread = Helper.toCell<double> spread "spread" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithSpreads1
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithSpreads1") 
                                               [| _CPILeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withSubtractInflationNominal", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withSubtractInflationNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "Reference to growthOnly")>] 
         growthOnly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithSubtractInflationNominal
                                                            _growthOnly.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithSubtractInflationNominal") 
                                               [| _CPILeg.source
                                               ;  _growthOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _growthOnly.cell
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
    [<ExcelFunction(Name="_CPILeg_withNotionals", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithNotionals") 
                                               [| _CPILeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withNotionals", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _notional = Helper.toCell<double> notional "notional" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithNotionals1") 
                                               [| _CPILeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_withPaymentAdjustment", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "Reference to CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg" true 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let builder () = withMnemonic mnemonic ((_CPILeg.cell :?> CPILegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_CPILeg.source + ".WithPaymentAdjustment") 
                                               [| _CPILeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
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
    [<ExcelFunction(Name="_CPILeg_Range", Description="Create a range of CPILeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPILeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CPILeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPILeg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPILeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPILeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CPILeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
