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
  This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  yieldtermstructures  - the correctness of the returned values is tested by checking them against numerical calculations. - observability against changes in the underlying term structure and in the added spread is checked.
  </summary> *)
[<AutoSerializable(true)>]
module ForwardSpreadedTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_calendar", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".Calendar") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_dayCounter", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".DayCounter") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let builder () = withMnemonic mnemonic (Fun.ForwardSpreadedTermStructure 
                                                            _h.cell 
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardSpreadedTermStructure>) l

                let source = Helper.sourceFold "Fun.ForwardSpreadedTermStructure" 
                                               [| _h.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_maxDate", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".MaxDate") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_maxTime", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".MaxTime") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_referenceDate", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".ReferenceDate") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_settlementDays", Description="Create a ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardSpreadedTermStructure",Description = "Reference to ForwardSpreadedTermStructure")>] 
         forwardspreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardSpreadedTermStructure = Helper.toCell<ForwardSpreadedTermStructure> forwardspreadedtermstructure "ForwardSpreadedTermStructure" true 
                let builder () = withMnemonic mnemonic ((_ForwardSpreadedTermStructure.cell :?> ForwardSpreadedTermStructureModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardSpreadedTermStructure.source + ".SettlementDays") 
                                               [| _ForwardSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ForwardSpreadedTermStructure_Range", Description="Create a range of ForwardSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardSpreadedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ForwardSpreadedTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardSpreadedTermStructure> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardSpreadedTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardSpreadedTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ForwardSpreadedTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
