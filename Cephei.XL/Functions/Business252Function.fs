﻿(*
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
  Business/252 day count convention
  </summary> *)
[<AutoSerializable(true)>]
module Business252Function =

    (*
        
    *)
    [<ExcelFunction(Name="_Business252", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toDefault<Calendar> c "c" null
                let builder () = withMnemonic mnemonic (Fun.Business252 
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Business252>) l

                let source = Helper.sourceFold "Fun.Business252" 
                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Business252> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Business252_dayCount", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Business252.source + ".DayCount") 
                                               [| _Business252.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
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
    [<ExcelFunction(Name="_Business252_name", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Business252.source + ".Name") 
                                               [| _Business252.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
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
    [<ExcelFunction(Name="_Business252_yearFraction", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="d3",Description = "Reference to d3")>] 
         d3 : obj)
        ([<ExcelArgument(Name="d4",Description = "Reference to d4")>] 
         d4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _d3 = Helper.toCell<Date> d3 "d3" 
                let _d4 = Helper.toCell<Date> d4 "d4" 
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _d3.cell 
                                                            _d4.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Business252.source + ".YearFraction") 
                                               [| _Business252.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _d3.source
                                               ;  _d4.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _d3.cell
                                ;  _d4.cell
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
    [<ExcelFunction(Name="_Business252_dayCounter", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Business252.source + ".DayCounter") 
                                               [| _Business252.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Business252> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Business252_empty", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Business252.source + ".Empty") 
                                               [| _Business252.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
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
    [<ExcelFunction(Name="_Business252_Equals", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Business252.source + ".Equals") 
                                               [| _Business252.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
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
    [<ExcelFunction(Name="_Business252_ToString", Description="Create a Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Business252",Description = "Reference to Business252")>] 
         business252 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Business252 = Helper.toCell<Business252> business252 "Business252"  
                let builder () = withMnemonic mnemonic ((_Business252.cell :?> Business252Model).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Business252.source + ".ToString") 
                                               [| _Business252.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Business252.cell
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
    [<ExcelFunction(Name="_Business252_Range", Description="Create a range of Business252",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Business252_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Business252")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Business252> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Business252>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Business252>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Business252>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"