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
Helper class used by unit tests
  </summary> *)
[<AutoSerializable(true)>]
module AbcdSquaredFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AbcdSquared", Description="Create a AbcdSquared",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdSquared_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        ([<ExcelArgument(Name="T",Description = "double")>] 
         T : obj)
        ([<ExcelArgument(Name="S",Description = "double")>] 
         S : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _c = Helper.toCell<double> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let _T = Helper.toCell<double> T "T" 
                let _S = Helper.toCell<double> S "S" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AbcdSquared 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                            _T.cell 
                                                            _S.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdSquared>) l

                let source () = Helper.sourceFold "Fun.AbcdSquared" 
                                               [| _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               ;  _T.source
                                               ;  _S.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                ;  _T.cell
                                ;  _S.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdSquared> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdSquared_value", Description="Create a AbcdSquared",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdSquared_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdSquared",Description = "AbcdSquared")>] 
         abcdsquared : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdSquared = Helper.toCell<AbcdSquared> abcdsquared "AbcdSquared"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdSquaredModel.Cast _AbcdSquared.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdSquared.source + ".Value") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdSquared.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_AbcdSquared_Range", Description="Create a range of AbcdSquared",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdSquared_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdSquared> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AbcdSquared>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AbcdSquared>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AbcdSquared>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
