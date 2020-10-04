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
(*!! generic
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module ParallelEvolverFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ParallelEvolver_factory", Description="Create a ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ParallelEvolver",Description = "Reference to ParallelEvolver")>] 
         parallelevolver : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalFields",Description = "Reference to additionalFields")>] 
         additionalFields : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ParallelEvolver = Helper.toCell<ParallelEvolver> parallelevolver "ParallelEvolver"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalFields = Helper.toDefault<Object[]> additionalFields "additionalFields" null
                let builder () = withMnemonic mnemonic ((ParallelEvolverModel.Cast _ParallelEvolver.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalFields.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_ParallelEvolver.source + ".Factory") 
                                               [| _ParallelEvolver.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalFields.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ParallelEvolver.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalFields.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ParallelEvolver> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ParallelEvolver", Description="Create a ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<Generic.List<IOperator>> L "L" 
                let _bcs = Helper.toCell<BoundaryConditionSet> bcs "bcs" 
                let builder () = withMnemonic mnemonic (Fun.ParallelEvolver 
                                                            _L.cell 
                                                            _bcs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ParallelEvolver>) l

                let source = Helper.sourceFold "Fun.ParallelEvolver" 
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
                    ; subscriber = Helper.subscriberModel<ParallelEvolver> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_ParallelEvolver1", Description="Create a ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ParallelEvolver1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ParallelEvolver>) l

                let source = Helper.sourceFold "Fun.ParallelEvolver1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ParallelEvolver> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ParallelEvolver_setStep", Description="Create a ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ParallelEvolver",Description = "Reference to ParallelEvolver")>] 
         parallelevolver : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ParallelEvolver = Helper.toCell<ParallelEvolver> parallelevolver "ParallelEvolver"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((ParallelEvolverModel.Cast _ParallelEvolver.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : ParallelEvolver) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ParallelEvolver.source + ".SetStep") 
                                               [| _ParallelEvolver.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ParallelEvolver.cell
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
    [<ExcelFunction(Name="_ParallelEvolver_step", Description="Create a ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ParallelEvolver",Description = "Reference to ParallelEvolver")>] 
         parallelevolver : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ParallelEvolver = Helper.toCell<ParallelEvolver> parallelevolver "ParallelEvolver"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder () = withMnemonic mnemonic ((ParallelEvolverModel.Cast _ParallelEvolver.cell).Step
                                                            _o.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : ParallelEvolver) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ParallelEvolver.source + ".Step") 
                                               [| _ParallelEvolver.source
                                               ;  _o.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ParallelEvolver.cell
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
    [<ExcelFunction(Name="_ParallelEvolver_Range", Description="Create a range of ParallelEvolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ParallelEvolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ParallelEvolver")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ParallelEvolver> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ParallelEvolver>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ParallelEvolver>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ParallelEvolver>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
