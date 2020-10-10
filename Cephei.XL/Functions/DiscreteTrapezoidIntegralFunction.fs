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
  References: Levy, D. Numerical Integration http://www2.math.umd.edu/~dlevy/classes/amsc466/lecture-notes/integration-chap.pdf
  </summary> *)
[<AutoSerializable(true)>]
module DiscreteTrapezoidIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegral_value", Description="Create a DiscreteTrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegral",Description = "Reference to DiscreteTrapezoidIntegral")>] 
         discretetrapezoidintegral : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegral = Helper.toCell<DiscreteTrapezoidIntegral> discretetrapezoidintegral "DiscreteTrapezoidIntegral"  
                let _x = Helper.toCell<Vector> x "x" 
                let _f = Helper.toCell<Vector> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegralModel.Cast _DiscreteTrapezoidIntegral.cell).Value
                                                            _x.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegral.source + ".Value") 
                                               [| _DiscreteTrapezoidIntegral.source
                                               ;  _x.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegral.cell
                                ;  _x.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegral_Range", Description="Create a range of DiscreteTrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscreteTrapezoidIntegral")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscreteTrapezoidIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscreteTrapezoidIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscreteTrapezoidIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DiscreteTrapezoidIntegral>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
