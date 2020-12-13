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
(*!! generic
(* <summary>
  It uses a uniform deviate in (0, 1) as the source of cumulative distribution values. Then an inverse cumulative distribution is used to calculate the distribution deviate.  The uniform deviate is supplied by RNG. The inverse cumulative distribution is supplied by IC.
  </summary> *)
[<AutoSerializable(true)>]
module InverseCumulativeRngFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativeRng", Description="Create a InverseCumulativeRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativeRng_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="uniformGenerator",Description = "'RNG")>] 
         uniformGenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _uniformGenerator = Helper.toCell<'RNG> uniformGenerator "uniformGenerator" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseCumulativeRng 
                                                            _uniformGenerator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativeRng>) l

                let source () = Helper.sourceFold "Fun.InverseCumulativeRng" 
                                               [| _uniformGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _uniformGenerator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseCumulativeRng> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a sample from a Gaussian distribution
    *)
    [<ExcelFunction(Name="_InverseCumulativeRng_next", Description="Create a InverseCumulativeRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativeRng_next
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeRng",Description = "InverseCumulativeRng")>] 
         inversecumulativerng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeRng = Helper.toCell<InverseCumulativeRng> inversecumulativerng "InverseCumulativeRng"  
                let builder (current : ICell) = withMnemonic mnemonic ((InverseCumulativeRngModel.Cast _InverseCumulativeRng.cell).Next
                                                       ) :> ICell
                let format (o : Sample<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InverseCumulativeRng.source + ".Next") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeRng.cell
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
    [<ExcelFunction(Name="_InverseCumulativeRng_Range", Description="Create a range of InverseCumulativeRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseCumulativeRng_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseCumulativeRng> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InverseCumulativeRng> (c)) :> ICell
                let format (i : Cephei.Cell.List<InverseCumulativeRng>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InverseCumulativeRng>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
