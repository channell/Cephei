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
module eqn6Function =

    (*
        Relates to eqn6 Genz 2004
    *)
    [<ExcelFunction(Name="_eqn6", Description="Create a eqn6",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let eqn6_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="c",Description = "double")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        ([<ExcelArgument(Name="bs",Description = "double")>] 
         bs : obj)
        ([<ExcelArgument(Name="hk",Description = "double")>] 
         hk : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toCell<double> a "a" 
                let _c = Helper.toCell<double> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let _bs = Helper.toCell<double> bs "bs" 
                let _hk = Helper.toCell<double> hk "hk" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.eqn6 
                                                            _a.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                            _bs.cell 
                                                            _hk.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<eqn6>) l

                let source () = Helper.sourceFold "Fun.eqn6" 
                                               [| _a.source
                                               ;  _c.source
                                               ;  _d.source
                                               ;  _bs.source
                                               ;  _hk.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _c.cell
                                ;  _d.cell
                                ;  _bs.cell
                                ;  _hk.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<eqn6> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_eqn6_value", Description="Create a eqn6",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let eqn6_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eqn6",Description = "eqn6")>] 
         eqn6 : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eqn6 = Helper.toCell<eqn6> eqn6 "eqn6"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((eqn6Model.Cast _eqn6.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_eqn6.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eqn6.cell
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
    [<ExcelFunction(Name="_eqn6_Range", Description="Create a range of eqn6",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let eqn6_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<eqn6> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<eqn6> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<eqn6>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<eqn6>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
