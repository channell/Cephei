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
"Actual/365 (Fixed)" day count convention, also know as "Act/365 (Fixed)", "A/365 (Fixed)", or "A/365F". According to ISDA, "Actual/365" (without "Fixed") is an alias for "Actual/Actual (ISDA)" (see ActualActual.) If Actual/365 is not explicitly specified as fixed in an instrument specification, you might want to double-check its meaning.
  </summary> *)
[<AutoSerializable(true)>]
module Actual365FixedFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Actual365Fixed", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Actual365Fixed 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Actual365Fixed>) l

                let source = Helper.sourceFold "Fun.Actual365Fixed" 
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
    [<ExcelFunction(Name="_Actual365Fixed_dayCount", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".DayCount") 
                                               [| _Actual365Fixed.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_dayCounter", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Actual365Fixed.source + ".DayCounter") 
                                               [| _Actual365Fixed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_empty", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".Empty") 
                                               [| _Actual365Fixed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_Equals", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".Equals") 
                                               [| _Actual365Fixed.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_name", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".Name") 
                                               [| _Actual365Fixed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_ToString", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".ToString") 
                                               [| _Actual365Fixed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_yearFraction", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
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

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".YearFraction") 
                                               [| _Actual365Fixed.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_yearFraction", Description="Create a Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Actual365Fixed",Description = "Reference to Actual365Fixed")>] 
         actual365fixed : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Actual365Fixed = Helper.toCell<Actual365Fixed> actual365fixed "Actual365Fixed" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let builder () = withMnemonic mnemonic ((_Actual365Fixed.cell :?> Actual365FixedModel).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Actual365Fixed.source + ".YearFraction1") 
                                               [| _Actual365Fixed.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Actual365Fixed.cell
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
    [<ExcelFunction(Name="_Actual365Fixed_Range", Description="Create a range of Actual365Fixed",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Actual365Fixed_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Actual365Fixed")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Actual365Fixed> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Actual365Fixed>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Actual365Fixed>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Actual365Fixed>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
