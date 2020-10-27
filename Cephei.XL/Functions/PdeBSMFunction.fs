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
    [<ExcelFunction(Name="_PdeBSM_diffusion", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PdeBSMModel.Cast _PdeBSM.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PdeBSM.source + ".Diffusion") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_discount", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PdeBSMModel.Cast _PdeBSM.cell).Discount
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PdeBSM.source + ".Discount") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_drift", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PdeBSMModel.Cast _PdeBSM.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PdeBSM.source + ".Drift") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_PdeBSM_factory", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic ((PdeBSMModel.Cast _PdeBSM.cell).Factory
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeSecondOrderParabolic>) l

                let source () = Helper.sourceFold (_PdeBSM.source + ".Factory") 

                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeBSM.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeBSM> format
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
    [<ExcelFunction(Name="_PdeBSM1", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PdeBSM1 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeBSM>) l

                let source () = Helper.sourceFold "Fun.PdeBSM1" 
                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeBSM> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeBSM", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PdeBSM ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeBSM>) l

                let source () = Helper.sourceFold "Fun.PdeBSM" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeBSM> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeBSM_generateOperator", Description="Create a PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_generateOperator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeBSM",Description = "PdeBSM")>] 
         pdebsm : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="tg",Description = "TransformedGrid")>] 
         tg : obj)
        ([<ExcelArgument(Name="L",Description = "TridiagonalOperator")>] 
         L : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeBSM = Helper.toCell<PdeBSM> pdebsm "PdeBSM"  
                let _t = Helper.toCell<double> t "t" 
                let _tg = Helper.toCell<TransformedGrid> tg "tg" 
                let _L = Helper.toCell<TridiagonalOperator> L "L" 
                let builder (current : ICell) = withMnemonic mnemonic ((PdeBSMModel.Cast _PdeBSM.cell).GenerateOperator
                                                            _t.cell 
                                                            _tg.cell 
                                                            _L.cell 
                                                       ) :> ICell
                let format (o : PdeBSM) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PdeBSM.source + ".GenerateOperator") 

                                               [| _t.source
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
    [<ExcelFunction(Name="_PdeBSM_Range", Description="Create a range of PdeBSM",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PdeBSM_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PdeBSM> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PdeBSM>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PdeBSM>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PdeBSM>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
