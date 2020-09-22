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
module PdeBSMFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PdeBSM_diffusion", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "Reference to PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_PdeBSM.cell :?> PdeBSMModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeBSM.source + ".Diffusion") 
                                               [| _PdeBSM.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_discount", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "Reference to PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_PdeBSM.cell :?> PdeBSMModel).Discount
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeBSM.source + ".Discount") 
                                               [| _PdeBSM.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_drift", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "Reference to PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_PdeBSM.cell :?> PdeBSMModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeBSM.source + ".Drift") 
                                               [| _PdeBSM.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_factory", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "Reference to PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic ((_PdeBSM.cell :?> PdeBSMModel).Factory
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeSecondOrderParabolic>) l

                let source = Helper.sourceFold (_PdeBSM.source + ".Factory") 
                                               [| _PdeBSM.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _Process.cell
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
        required for generics
    *)
    [<ExcelFunction(Name="_PdeBSM1", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic (Fun.PdeBSM1 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeBSM>) l

                let source = Helper.sourceFold "Fun.PdeBSM1" 
                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
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
    [<ExcelFunction(Name="_PdeBSM", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PdeBSM ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeBSM>) l

                let source = Helper.sourceFold "Fun.PdeBSM" 
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
    [<ExcelFunction(Name="_PdeBSM_generateOperator", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_generateOperator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "Reference to PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="tg",Description = "Reference to tg")>] 
         tg : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM" true 
                let _t = Helper.toCell<double> t "t" true
                let _tg = Helper.toCell<TransformedGrid> tg "tg" true
                let _L = Helper.toCell<TridiagonalOperator> L "L" true
                let builder () = withMnemonic mnemonic ((_PdeBSM.cell :?> PdeBSMModel).GenerateOperator
                                                            _t.cell 
                                                            _tg.cell 
                                                            _L.cell 
                                                       ) :> ICell
                let format (o : PdeBSM) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeBSM.source + ".GenerateOperator") 
                                               [| _PdeBSM.source
                                               ;  _t.source
                                               ;  _tg.source
                                               ;  _L.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _tg.cell
                                ;  _L.cell
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
    [<ExcelFunction(Name="_PdeBSM_Range", Description="Create a range of PdeBSM",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeBSM_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PdeBSM")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PdeBSM> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PdeBSM>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PdeBSM>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PdeBSM>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
