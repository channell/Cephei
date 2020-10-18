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
module MidPointFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MidPoint_integrate", Description="Create a MidPoint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MidPoint_integrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MidPoint",Description = "MidPoint")>] 
         midpoint : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="I",Description = "double")>] 
         I : obj)
        ([<ExcelArgument(Name="N",Description = "int")>] 
         N : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MidPoint = Helper.toCell<MidPoint> midpoint "MidPoint"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _I = Helper.toCell<double> I "I" 
                let _N = Helper.toCell<int> N "N" 
                let builder (current : ICell) = withMnemonic mnemonic ((MidPointModel.Cast _MidPoint.cell).Integrate
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _I.cell 
                                                            _N.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MidPoint.source + ".Integrate") 
                                               [| _MidPoint.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _I.source
                                               ;  _N.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MidPoint.cell
                                ;  _f.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _I.cell
                                ;  _N.cell
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
    [<ExcelFunction(Name="_MidPoint_nbEvalutions", Description="Create a MidPoint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MidPoint_nbEvalutions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MidPoint",Description = "MidPoint")>] 
         midpoint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MidPoint = Helper.toCell<MidPoint> midpoint "MidPoint"  
                let builder (current : ICell) = withMnemonic mnemonic ((MidPointModel.Cast _MidPoint.cell).NbEvalutions
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MidPoint.source + ".NbEvalutions") 
                                               [| _MidPoint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MidPoint.cell
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
    [<ExcelFunction(Name="_MidPoint_Range", Description="Create a range of MidPoint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MidPoint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MidPoint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MidPoint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MidPoint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MidPoint>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
