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
  This day counter tries to ensure that whole-month distances are returned as a simple fraction, i.e., 1 year = 1.0, 6 months = 0.5, 3 months = 0.25 and so forth. this day counter should be used together with NullCalendar, which ensures that dates at whole-month distances share the same day of month. It is <b>not</b> guaranteed to work with any other calendar.
  </summary> *)
[<AutoSerializable(true)>]
module SimpleDayCounterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimpleDayCounter", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SimpleDayCounter ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpleDayCounter>) l

                let source = Helper.sourceFold "Fun.SimpleDayCounter" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimpleDayCounter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimpleDayCounter_dayCount", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".DayCount") 
                                               [| _SimpleDayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_dayCounter", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".DayCounter") 
                                               [| _SimpleDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimpleDayCounter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimpleDayCounter_empty", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".Empty") 
                                               [| _SimpleDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_Equals", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".Equals") 
                                               [| _SimpleDayCounter.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_name", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".Name") 
                                               [| _SimpleDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_ToString", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".ToString") 
                                               [| _SimpleDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_yearFraction", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".YearFraction") 
                                               [| _SimpleDayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SimpleDayCounter_yearFraction1", Description="Create a SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleDayCounter",Description = "Reference to SimpleDayCounter")>] 
         simpledaycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleDayCounter = Helper.toCell<SimpleDayCounter> simpledaycounter "SimpleDayCounter"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_SimpleDayCounter.cell :?> SimpleDayCounterModel).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpleDayCounter.source + ".YearFraction1") 
                                               [| _SimpleDayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleDayCounter.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SimpleDayCounter_Range", Description="Create a range of SimpleDayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleDayCounter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SimpleDayCounter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimpleDayCounter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SimpleDayCounter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SimpleDayCounter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SimpleDayCounter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
