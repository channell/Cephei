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
  The given date will be the implied reference date.  This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  yieldtermstructures  - the correctness of the returned values is tested by checking them against numerical calculations. - observability against changes in the underlying term structure is checked.
  </summary> *)
[<AutoSerializable(true)>]
module ImpliedTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_calendar", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        YieldTermStructure interface
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_dayCounter", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.ImpliedTermStructure 
                                                            _h.cell 
                                                            _referenceDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImpliedTermStructure>) l

                let source () = Helper.sourceFold "Fun.ImpliedTermStructure" 
                                               [| _h.source
                                               ;  _referenceDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _referenceDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_maxDate", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_settlementDays", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_discount", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".Discount") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _t.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_discount1", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".Discount1") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _d.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_forwardRate", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ForwardRate") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_forwardRate1", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ForwardRate1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_forwardRate2", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ForwardRate2") 

                                               [| _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_jumpDates", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".JumpDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
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
    [<ExcelFunction(Name="_ImpliedTermStructure_jumpTimes", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".JumpTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
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
    [<ExcelFunction(Name="_ImpliedTermStructure_update", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).Update
                                                       ) :> ICell
                let format (o : ImpliedTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_zeroRate1", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ZeroRate1") 

                                               [| _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_zeroRate", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ZeroRate") 

                                               [| _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_maxTime", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_referenceDate", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_timeFromReference", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        some extra functionality
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_allowsExtrapolation", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_disableExtrapolation", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ImpliedTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_enableExtrapolation", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ImpliedTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedTermStructure_extrapolate", Description="Create a ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedTermStructure",Description = "ImpliedTermStructure")>] 
         impliedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedTermStructure = Helper.toCell<ImpliedTermStructure> impliedtermstructure "ImpliedTermStructure"  
                let builder (current : ICell) = ((ImpliedTermStructureModel.Cast _ImpliedTermStructure.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImpliedTermStructure.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImpliedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ImpliedTermStructure_Range", Description="Create a range of ImpliedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImpliedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImpliedTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ImpliedTermStructure> (c)) :> ICell
                let format (i : Cephei.Cell.List<ImpliedTermStructure>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ImpliedTermStructure>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
