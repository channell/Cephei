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
(*!!
(* <summary>
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  The differential operator must be linear for this evolver to work.  findiff
  </summary> *)
[<AutoSerializable(true)>]
module CrankNicolsonFunction =

    (*
        required for generics
    *)
    [<ExcelFunction(Name="_CrankNicolson", Description="Create a CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<'Operator> L "L" 
                let _bcs = Helper.toCell<Generic.List<BoundaryCondition<IOperator>>> bcs "bcs" 
                let builder () = withMnemonic mnemonic (Fun.CrankNicolson 
                                                            _L.cell 
                                                            _bcs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CrankNicolson>) l

                let source = Helper.sourceFold "Fun.CrankNicolson" 
                                               [| _L.source
                                               ;  _bcs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _L.cell
                                ;  _bcs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolson> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructors
    *)
    [<ExcelFunction(Name="_CrankNicolson1", Description="Create a CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CrankNicolson1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CrankNicolson>) l

                let source = Helper.sourceFold "Fun.CrankNicolson1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolson> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolson_factory", Description="Create a CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolson",Description = "Reference to CrankNicolson")>] 
         cranknicolson : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalFields",Description = "Reference to additionalFields")>] 
         additionalFields : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolson = Helper.toCell<CrankNicolson> cranknicolson "CrankNicolson"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalFields = Helper.toDefault<Object[]> additionalFields "additionalFields" null
                let builder () = withMnemonic mnemonic ((_CrankNicolson.cell :?> CrankNicolsonModel).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalFields.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_CrankNicolson.source + ".Factory") 
                                               [| _CrankNicolson.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalFields.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolson.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalFields.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolson> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolson_setStep", Description="Create a CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolson",Description = "Reference to CrankNicolson")>] 
         cranknicolson : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolson = Helper.toCell<CrankNicolson> cranknicolson "CrankNicolson"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((_CrankNicolson.cell :?> CrankNicolsonModel).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : CrankNicolson) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CrankNicolson.source + ".SetStep") 
                                               [| _CrankNicolson.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolson.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_CrankNicolson_step", Description="Create a CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolson",Description = "Reference to CrankNicolson")>] 
         cranknicolson : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolson = Helper.toCell<CrankNicolson> cranknicolson "CrankNicolson"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toCell<double> theta "theta" 
                let builder () = withMnemonic mnemonic ((_CrankNicolson.cell :?> CrankNicolsonModel).Step
                                                            _o.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : CrankNicolson) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CrankNicolson.source + ".Step") 
                                               [| _CrankNicolson.source
                                               ;  _o.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolson.cell
                                ;  _o.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_CrankNicolson_Range", Description="Create a range of CrankNicolson",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolson_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CrankNicolson")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CrankNicolson> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CrankNicolson>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CrankNicolson>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CrankNicolson>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)