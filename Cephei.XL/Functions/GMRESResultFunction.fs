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
  References: Saad, Yousef. 1996, Iterative methods for sparse linear systems, http://www-users.cs.umn.edu/~saad/books.html  Dongarra et al. 1994, Templates for the Solution of Linear Systems: Building Blocks for Iterative Methods, 2nd Edition, SIAM, Philadelphia http://www.netlib.org/templates/templates.pdf  Christian Kanzow Numerik linearer Gleichungssysteme (German) Chapter 6: GMRES und verwandte Verfahren http://bilder.buecher.de/zusatz/12/12950/12950560_lese_1.pdf
  </summary> *)
[<AutoSerializable(true)>]
module GMRESResultFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GMRESResult_Errors", Description="Create a GMRESResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRESResult_Errors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRESResult",Description = "Reference to GMRESResult")>] 
         gmresresult : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRESResult = Helper.toCell<GMRESResult> gmresresult "GMRESResult" true 
                let builder () = withMnemonic mnemonic ((_GMRESResult.cell :?> GMRESResultModel).Errors
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GMRESResult.source + ".Errors") 
                                               [| _GMRESResult.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRESResult.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GMRESResult", Description="Create a GMRESResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRESResult_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        ([<ExcelArgument(Name="xx",Description = "Reference to xx")>] 
         xx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _e = Helper.toCell<Generic.List<double>> e "e" true
                let _xx = Helper.toCell<Vector> xx "xx" true
                let builder () = withMnemonic mnemonic (Fun.GMRESResult 
                                                            _e.cell 
                                                            _xx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRESResult>) l

                let source = Helper.sourceFold "Fun.GMRESResult" 
                                               [| _e.source
                                               ;  _xx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _e.cell
                                ;  _xx.cell
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
    [<ExcelFunction(Name="_GMRESResult_X", Description="Create a GMRESResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRESResult_X
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRESResult",Description = "Reference to GMRESResult")>] 
         gmresresult : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRESResult = Helper.toCell<GMRESResult> gmresresult "GMRESResult" true 
                let builder () = withMnemonic mnemonic ((_GMRESResult.cell :?> GMRESResultModel).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GMRESResult.source + ".X") 
                                               [| _GMRESResult.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRESResult.cell
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
    [<ExcelFunction(Name="_GMRESResult_Range", Description="Create a range of GMRESResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRESResult_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GMRESResult")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GMRESResult> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GMRESResult>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GMRESResult>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GMRESResult>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
