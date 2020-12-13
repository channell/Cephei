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
(*!!
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module equal_on_firstFunction =

    (*
        
    *)
    (*!! duplicate equals function
    [<ExcelFunction(Name="_equal_on_first_Equals", Description="Create a equal_on_first",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let equal_on_first_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="equal_on_first",Description = "equal_on_first")>] 
         equal_on_first : obj)
        ([<ExcelArgument(Name="p1",Description = "double")>] 
         p1 : obj)
        ([<ExcelArgument(Name="p2",Description = "double")>] 
         p2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _equal_on_first = Helper.toCell<equal_on_first> equal_on_first "equal_on_first"  
                let _p1 = Helper.toCell<Pair<Nullable<double>,Nullable<double>>> p1 "p1" 
                let _p2 = Helper.toCell<Pair<Nullable<double>,Nullable<double>>> p2 "p2" 
                let builder (current : ICell) = withMnemonic mnemonic ((equal_on_firstModel.Cast _equal_on_first.cell).Equals
                                                            _p1.cell 
                                                            _p2.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_equal_on_first.source + ".Equals") 

                                               [| _p1.source
                                               ;  _p2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _equal_on_first.cell
                                ;  _p1.cell
                                ;  _p2.cell
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
            *)
    [<ExcelFunction(Name="_equal_on_first_Range", Description="Create a range of equal_on_first",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let equal_on_first_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<equal_on_first> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<equal_on_first> (c)) :> ICell
                let format (i : Cephei.Cell.List<equal_on_first>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<equal_on_first>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
