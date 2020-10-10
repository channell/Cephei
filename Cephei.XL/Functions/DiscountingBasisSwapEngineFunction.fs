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
module DiscountingBasisSwapEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscountingBasisSwapEngine", Description="Create a DiscountingBasisSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscountingBasisSwapEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve1",Description = "Reference to discountCurve1")>] 
         discountCurve1 : obj)
        ([<ExcelArgument(Name="discountCurve2",Description = "Reference to discountCurve2")>] 
         discountCurve2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve1 = Helper.toHandle<YieldTermStructure> discountCurve1 "discountCurve1" 
                let _discountCurve2 = Helper.toHandle<YieldTermStructure> discountCurve2 "discountCurve2" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscountingBasisSwapEngine 
                                                            _discountCurve1.cell 
                                                            _discountCurve2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscountingBasisSwapEngine>) l

                let source () = Helper.sourceFold "Fun.DiscountingBasisSwapEngine" 
                                               [| _discountCurve1.source
                                               ;  _discountCurve2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve1.cell
                                ;  _discountCurve2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscountingBasisSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscountingBasisSwapEngine_Range", Description="Create a range of DiscountingBasisSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscountingBasisSwapEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscountingBasisSwapEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscountingBasisSwapEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscountingBasisSwapEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscountingBasisSwapEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DiscountingBasisSwapEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
