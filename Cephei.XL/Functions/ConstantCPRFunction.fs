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
module ConstantCPRFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConstantCPR", Description="Create a ConstantCPR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCPR_create
        ([<ExcelArgument(Name="Mnemonic",Description = "ConstantCPR")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="cpr",Description = "double")>] 
         cpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _cpr = Helper.toCell<double> cpr "cpr" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantCPR 
                                                            _cpr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCPR>) l

                let source () = Helper.sourceFold "Fun.ConstantCPR" 
                                               [| _cpr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _cpr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCPR> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantCPR_getCPR", Description="Create a ConstantCPR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCPR_getCPR
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCPR",Description = "ConstantCPR")>] 
         constantcpr : obj)
        ([<ExcelArgument(Name="valDate",Description = "Date")>] 
         valDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCPR = Helper.toCell<ConstantCPR> constantcpr "ConstantCPR"  
                let _valDate = Helper.toCell<Date> valDate "valDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCPRModel.Cast _ConstantCPR.cell).GetCPR
                                                            _valDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCPR.source + ".GetCPR") 
                                               [| _ConstantCPR.source
                                               ;  _valDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCPR.cell
                                ;  _valDate.cell
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
    [<ExcelFunction(Name="_ConstantCPR_getSMM", Description="Create a ConstantCPR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCPR_getSMM
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCPR",Description = "ConstantCPR")>] 
         constantcpr : obj)
        ([<ExcelArgument(Name="valDate",Description = "Date")>] 
         valDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCPR = Helper.toCell<ConstantCPR> constantcpr "ConstantCPR"  
                let _valDate = Helper.toCell<Date> valDate "valDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCPRModel.Cast _ConstantCPR.cell).GetSMM
                                                            _valDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCPR.source + ".GetSMM") 
                                               [| _ConstantCPR.source
                                               ;  _valDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCPR.cell
                                ;  _valDate.cell
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
    [<ExcelFunction(Name="_ConstantCPR_Range", Description="Create a range of ConstantCPR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCPR_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantCPR> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantCPR>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantCPR>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ConstantCPR>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
