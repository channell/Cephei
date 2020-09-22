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
This class provides methods for determining the length of a time period according to given market convention, both as a number of days and as a year fraction.
  </summary> *)
[<AutoSerializable(true)>]
module DayCounterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DayCounter_dayCount", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".DayCount") 
                                               [| _DayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_dayCounter", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DayCounter.source + ".DayCounter") 
                                               [| _DayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<DayCounter> d "d" true
                let builder () = withMnemonic mnemonic (Fun.DayCounter 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold "Fun.DayCounter" 
                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
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
        ! The default constructor returns a day counter with a null implementation, which is therefore unusable except as a placeholder.
    *)
    [<ExcelFunction(Name="_DayCounter1", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DayCounter1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold "Fun.DayCounter1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_DayCounter_empty", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".Empty") 
                                               [| _DayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_Equals", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".Equals") 
                                               [| _DayCounter.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_name", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".Name") 
                                               [| _DayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_ToString", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".ToString") 
                                               [| _DayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_yearFraction", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
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

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".YearFraction") 
                                               [| _DayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_yearFraction1", Description="Create a DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DayCounter",Description = "Reference to DayCounter")>] 
         daycounter : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DayCounter = Helper.toCell<DayCounter> daycounter "DayCounter" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_DayCounter.cell :?> DayCounterModel).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DayCounter.source + ".YearFraction1") 
                                               [| _DayCounter.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DayCounter.cell
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
    [<ExcelFunction(Name="_DayCounter_Range", Description="Create a range of DayCounter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DayCounter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DayCounter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DayCounter> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DayCounter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DayCounter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DayCounter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
