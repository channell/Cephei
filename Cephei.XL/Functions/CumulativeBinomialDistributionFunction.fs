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
  Given an integer k it provides the cumulative probability of observing kk<=k: formula here ...
  </summary> *)
[<AutoSerializable(true)>]
module CumulativeBinomialDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeBinomialDistribution", Description="Create a CumulativeBinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeBinomialDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CumulativeBinomialDistribution")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "double")>] 
         p : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<double> p "p" 
                let _n = Helper.toCell<int> n "n" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CumulativeBinomialDistribution 
                                                            _p.cell 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CumulativeBinomialDistribution>) l

                let source () = Helper.sourceFold "Fun.CumulativeBinomialDistribution" 
                                               [| _p.source
                                               ;  _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                ;  _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CumulativeBinomialDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        function
    *)
    [<ExcelFunction(Name="_CumulativeBinomialDistribution_value", Description="Create a CumulativeBinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeBinomialDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CumulativeBinomialDistribution",Description = "CumulativeBinomialDistribution")>] 
         cumulativebinomialdistribution : obj)
        ([<ExcelArgument(Name="k",Description = "int64")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CumulativeBinomialDistribution = Helper.toCell<CumulativeBinomialDistribution> cumulativebinomialdistribution "CumulativeBinomialDistribution"  
                let _k = Helper.toCell<int64> k "k" 
                let builder (current : ICell) = withMnemonic mnemonic ((CumulativeBinomialDistributionModel.Cast _CumulativeBinomialDistribution.cell).Value
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CumulativeBinomialDistribution.source + ".Value") 
                                               [| _CumulativeBinomialDistribution.source
                                               ;  _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CumulativeBinomialDistribution.cell
                                ;  _k.cell
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
    [<ExcelFunction(Name="_CumulativeBinomialDistribution_Range", Description="Create a range of CumulativeBinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeBinomialDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CumulativeBinomialDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CumulativeBinomialDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CumulativeBinomialDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CumulativeBinomialDistribution>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
