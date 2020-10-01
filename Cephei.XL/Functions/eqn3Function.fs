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
module eqn3Function =

    (*
        Relates to eqn3 Genz 2004
    *)
    [<ExcelFunction(Name="_eqn3", Description="Create a eqn3",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let eqn3_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        ([<ExcelArgument(Name="Asr",Description = "Reference to Asr")>] 
         Asr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toCell<double> h "h" 
                let _k = Helper.toCell<double> k "k" 
                let _Asr = Helper.toCell<double> Asr "Asr" 
                let builder () = withMnemonic mnemonic (Fun.eqn3 
                                                            _h.cell 
                                                            _k.cell 
                                                            _Asr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<eqn3>) l

                let source = Helper.sourceFold "Fun.eqn3" 
                                               [| _h.source
                                               ;  _k.source
                                               ;  _Asr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _k.cell
                                ;  _Asr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<eqn3> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_eqn3_value", Description="Create a eqn3",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let eqn3_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eqn3",Description = "Reference to eqn3")>] 
         eqn3 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eqn3 = Helper.toCell<eqn3> eqn3 "eqn3"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_eqn3.cell :?> eqn3Model).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_eqn3.source + ".Value") 
                                               [| _eqn3.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eqn3.cell
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
    [<ExcelFunction(Name="_eqn3_Range", Description="Create a range of eqn3",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let eqn3_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the eqn3")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<eqn3> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<eqn3>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<eqn3>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<eqn3>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
