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
  "Actual/365 (No Leap)" day count convention, also known as "Act/365 (NL)", "NL/365", or "Actual/365 (JGB)".  daycounters
  </summary> *)
[<AutoSerializable(true)>]
module Actual365NoLeapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Actual365NoLeap", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Actual365NoLeap ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Actual365NoLeap>) l

                let source = Helper.sourceFold "Fun.Actual365NoLeap" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Actual365NoLeap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Actual365NoLeap_dayCount", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".DayCount") 
                                               [| _Actual365NoLeap.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_dayCounter", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".DayCounter") 
                                               [| _Actual365NoLeap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Actual365NoLeap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Actual365NoLeap_empty", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".Empty") 
                                               [| _Actual365NoLeap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_Equals", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".Equals") 
                                               [| _Actual365NoLeap.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_name", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".Name") 
                                               [| _Actual365NoLeap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_ToString", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".ToString") 
                                               [| _Actual365NoLeap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_yearFraction", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
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

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".YearFraction") 
                                               [| _Actual365NoLeap.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_yearFraction1", Description="Create a Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365NoLeap",Description = "Reference to Actual365NoLeap")>] 
         actual365noleap : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365NoLeap = Helper.toCell<Actual365NoLeap> actual365noleap "Actual365NoLeap"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_Actual365NoLeap.cell :?> Actual365NoLeapModel).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365NoLeap.source + ".YearFraction1") 
                                               [| _Actual365NoLeap.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365NoLeap.cell
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
    [<ExcelFunction(Name="_Actual365NoLeap_Range", Description="Create a range of Actual365NoLeap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365NoLeap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Actual365NoLeap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Actual365NoLeap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Actual365NoLeap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Actual365NoLeap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Actual365NoLeap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
