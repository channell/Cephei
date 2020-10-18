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
  This class implements formulae from "Correlation in the Energy Markets", E. Kirk Managing Energy Price Risk. London: Risk Publications and Enron, pp. 71-78  basketengines  the correctness of the returned value is tested by reproducing results available in literature.
  </summary> *)
[<AutoSerializable(true)>]
module KirkEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_KirkEngine", Description="Create a KirkEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KirkEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "KirkEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="process1",Description = "BlackProcess")>] 
         process1 : obj)
        ([<ExcelArgument(Name="process2",Description = "BlackProcess")>] 
         process2 : obj)
        ([<ExcelArgument(Name="correlation",Description = "double")>] 
         correlation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _process1 = Helper.toCell<BlackProcess> process1 "process1" 
                let _process2 = Helper.toCell<BlackProcess> process2 "process2" 
                let _correlation = Helper.toCell<double> correlation "correlation" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.KirkEngine 
                                                            _process1.cell 
                                                            _process2.cell 
                                                            _correlation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KirkEngine>) l

                let source () = Helper.sourceFold "Fun.KirkEngine" 
                                               [| _process1.source
                                               ;  _process2.source
                                               ;  _correlation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _process1.cell
                                ;  _process2.cell
                                ;  _correlation.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KirkEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_KirkEngine_Range", Description="Create a range of KirkEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KirkEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KirkEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KirkEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<KirkEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<KirkEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
