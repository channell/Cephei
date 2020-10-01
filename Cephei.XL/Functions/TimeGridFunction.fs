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
module TimeGridFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TimeGrid_closestIndex", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_closestIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).ClosestIndex
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".ClosestIndex") 
                                               [| _TimeGrid.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TimeGrid_closestTime", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_closestTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).ClosestTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".ClosestTime") 
                                               [| _TimeGrid.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TimeGrid_dt", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_dt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Dt
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".Dt") 
                                               [| _TimeGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_TimeGrid_empty", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".Empty") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
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
    [<ExcelFunction(Name="_TimeGrid_First", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_First
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).First
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".First") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
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
    [<ExcelFunction(Name="_TimeGrid_index", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Index
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".Index") 
                                               [| _TimeGrid.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TimeGrid_Last", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_Last
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Last
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".Last") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
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
    [<ExcelFunction(Name="_TimeGrid_mandatoryTimes", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_TimeGrid.source + ".MandatoryTimes") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TimeGrid_size", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".Size") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
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
    [<ExcelFunction(Name="_TimeGrid_this", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).This
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TimeGrid.source + ".This") 
                                               [| _TimeGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_TimeGrid3", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="offset",Description = "Reference to offset")>] 
         offset : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let _offset = Helper.toCell<int> offset "offset" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.TimeGrid3
                                                            _times.cell 
                                                            _offset.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source = Helper.sourceFold "Fun.TimeGrid3" 
                                               [| _times.source
                                               ;  _offset.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                ;  _offset.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeGrid2", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.TimeGrid2
                                                            _times.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source = Helper.sourceFold "Fun.TimeGrid2" 
                                               [| _times.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeGrid1", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let builder () = withMnemonic mnemonic (Fun.TimeGrid1
                                                            _times.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source = Helper.sourceFold "Fun.TimeGrid1" 
                                               [| _times.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeGrid", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.TimeGrid
                                                            _End.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source = Helper.sourceFold "Fun.TimeGrid" 
                                               [| _End.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _End.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeGrid_Times", Description="Create a TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_Times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeGrid",Description = "Reference to TimeGrid")>] 
         timegrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeGrid = Helper.toCell<TimeGrid> timegrid "TimeGrid"  
                let builder () = withMnemonic mnemonic ((_TimeGrid.cell :?> TimeGridModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_TimeGrid.source + ".Times") 
                                               [| _TimeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TimeGrid_Range", Description="Create a range of TimeGrid",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TimeGrid_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TimeGrid")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TimeGrid> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TimeGrid>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TimeGrid>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TimeGrid>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
