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
  Actual/360 day count convention, also known as "Act/360", or "A/360".
  </summary> *)
[<AutoSerializable(true)>]
module Actual360Function =

    (*
        
    *)
    [<ExcelFunction(Name="_Actual360", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toDefault<bool> c "c" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Actual360 
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Actual360>) l

                let source () = Helper.sourceFold "Fun.Actual360" 
                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Actual360> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Actual360_dayCount", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".DayCount") 
                                               [| _Actual360.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_Actual360_dayCounter", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Actual360.source + ".DayCounter") 
                                               [| _Actual360.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Actual360> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Actual360_empty", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".Empty") 
                                               [| _Actual360.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
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
    [<ExcelFunction(Name="_Actual360_Equals", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".Equals") 
                                               [| _Actual360.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_Actual360_name", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".Name") 
                                               [| _Actual360.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
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
    [<ExcelFunction(Name="_Actual360_ToString", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".ToString") 
                                               [| _Actual360.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
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
    [<ExcelFunction(Name="_Actual360_yearFraction", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
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

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".YearFraction") 
                                               [| _Actual360.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
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
    [<ExcelFunction(Name="_Actual360_yearFraction1", Description="Create a Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual360",Description = "Reference to Actual360")>] 
         actual360 : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual360 = Helper.toCell<Actual360> actual360 "Actual360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = withMnemonic mnemonic ((Actual360Model.Cast _Actual360.cell).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Actual360.source + ".YearFraction") 
                                               [| _Actual360.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual360.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_Actual360_Range", Description="Create a range of Actual360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Actual360_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Actual360")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Actual360> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Actual360>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Actual360>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Actual360>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
