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

  </summary> *)
[<AutoSerializable(true)>]
module ActualActualFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ActualActual", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ActualActual ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ActualActual>) l

                let source = Helper.sourceFold "Fun.ActualActual" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ActualActual> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ActualActual1", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<ActualActual.Convention> c "c" 
                let _schedule = Helper.toDefault<Schedule> schedule "schedule" null
                let builder () = withMnemonic mnemonic (Fun.ActualActual1 
                                                            _c.cell 
                                                            _schedule.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ActualActual>) l

                let source = Helper.sourceFold "Fun.ActualActual1" 
                                               [| _c.source
                                               ;  _schedule.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                ;  _schedule.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ActualActual> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ActualActual_dayCount", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".DayCount") 
                                               [| _ActualActual.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_dayCounter", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ActualActual.source + ".DayCounter") 
                                               [| _ActualActual.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ActualActual> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ActualActual_empty", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".Empty") 
                                               [| _ActualActual.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_Equals", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".Equals") 
                                               [| _ActualActual.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_name", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".Name") 
                                               [| _ActualActual.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_ToString", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".ToString") 
                                               [| _ActualActual.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_yearFraction", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
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

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".YearFraction") 
                                               [| _ActualActual.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_yearFraction1", Description="Create a ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ActualActual",Description = "Reference to ActualActual")>] 
         actualactual : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ActualActual = Helper.toCell<ActualActual> actualactual "ActualActual"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_ActualActual.cell :?> ActualActualModel).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ActualActual.source + ".YearFraction1") 
                                               [| _ActualActual.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ActualActual.cell
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
    [<ExcelFunction(Name="_ActualActual_Range", Description="Create a range of ActualActual",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ActualActual_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ActualActual")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ActualActual> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ActualActual>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ActualActual>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ActualActual>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
