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
    [<ExcelFunction(Name="_CPILeg", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "ZeroInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "double")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<ZeroInflationIndex> index "index" 
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let builder (current : ICell) = (Fun.CPILeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _baseCPI.cell 
                                                            _observationLag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILeg>) l

                let source () = Helper.sourceFold "Fun.CPILeg" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_value", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_CPILeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withCaps1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withCaps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cap",Description = "double range")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _cap = Helper.toNullabletList<double> cap "cap" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithCaps1
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithCaps1") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withCaps", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withCaps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _cap = Helper.toCell<double> cap "cap" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithCaps
                                                            _cap.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithCaps") 

                                               [| _cap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _cap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withExCouponPeriod", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withExCouponPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="period",Description = "Period")>] 
         period : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _period = Helper.toCell<Period> period "period" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithExCouponPeriod
                                                            _period.cell 
                                                            _cal.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithExCouponPeriod") 

                                               [| _period.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFixedRates1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFixedRates1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixedRates",Description = "double range")>] 
         fixedRates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _fixedRates = Helper.toCell<Generic.List<double>> fixedRates "fixedRates" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFixedRates1
                                                            _fixedRates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFixedRates1") 

                                               [| _fixedRates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixedRates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFixedRates", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFixedRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFixedRates
                                                            _fixedRate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFixedRates") 

                                               [| _fixedRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixedRate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFixingDays", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int range")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _fixingDays = Helper.toCell<Generic.List<int>> fixingDays "fixingDays" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFixingDays
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFixingDays") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFixingDays1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFixingDays1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFixingDays1
                                                            _fixingDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFixingDays1") 

                                               [| _fixingDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _fixingDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFloors", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFloors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFloors
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFloors") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withFloors1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withFloors1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="floors",Description = "double")>] 
         floors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _floors = Helper.toCell<double> floors "floors" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithFloors1
                                                            _floors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithFloors1") 

                                               [| _floors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _floors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withObservationInterpolation", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withObservationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="interp",Description = "InterpolationType: AsIndex, Flat, Linear")>] 
         interp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _interp = Helper.toCell<InterpolationType> interp "interp" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithObservationInterpolation
                                                            _interp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithObservationInterpolation") 

                                               [| _interp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _interp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withPaymentCalendar", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withPaymentCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithPaymentCalendar
                                                            _cal.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithPaymentCalendar") 

                                               [| _cal.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _cal.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withPaymentDayCounter", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withSpreads", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithSpreads
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithSpreads") 

                                               [| _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withSpreads1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithSpreads1
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithSpreads1") 

                                               [| _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withSubtractInflationNominal", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withSubtractInflationNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "bool")>] 
         growthOnly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithSubtractInflationNominal
                                                            _growthOnly.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPILegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithSubtractInflationNominal") 

                                               [| _growthOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _growthOnly.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withNotionals1", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithNotionals1") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
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
    [<ExcelFunction(Name="_CPILeg_withNotionals", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithNotionals") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPILeg_withPaymentAdjustment", Description="Create a CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPILeg",Description = "CPILeg")>] 
         cpileg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPILeg = Helper.toCell<CPILeg> cpileg "CPILeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = ((CPILegModel.Cast _CPILeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source () = Helper.sourceFold (_CPILeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPILeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPILeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CPILeg_Range", Description="Create a range of CPILeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPILeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPILeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CPILeg> (c)) :> ICell
                let format (i : Cephei.Cell.List<CPILeg>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CPILeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
