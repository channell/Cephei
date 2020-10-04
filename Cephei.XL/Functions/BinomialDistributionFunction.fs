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
  formula here ... Given an integer k it returns its probability in a Binomial distribution with parameters p and n.
  </summary> *)
[<AutoSerializable(true)>]
module BinomialDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BinomialDistribution", Description="Create a BinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<double> p "p" 
                let _n = Helper.toCell<int> n "n" 
                let builder () = withMnemonic mnemonic (Fun.BinomialDistribution 
                                                            _p.cell 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BinomialDistribution>) l

                let source = Helper.sourceFold "Fun.BinomialDistribution" 
                                               [| _p.source
                                               ;  _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                ;  _n.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BinomialDistribution> format
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
    [<ExcelFunction(Name="_BinomialDistribution_value", Description="Create a BinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BinomialDistribution",Description = "Reference to BinomialDistribution")>] 
         binomialdistribution : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BinomialDistribution = Helper.toCell<BinomialDistribution> binomialdistribution "BinomialDistribution"  
                let _k = Helper.toCell<int> k "k" 
                let builder () = withMnemonic mnemonic ((BinomialDistributionModel.Cast _BinomialDistribution.cell).Value
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BinomialDistribution.source + ".Value") 
                                               [| _BinomialDistribution.source
                                               ;  _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BinomialDistribution.cell
                                ;  _k.cell
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
    [<ExcelFunction(Name="_BinomialDistribution_Range", Description="Create a range of BinomialDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BinomialDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BinomialDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BinomialDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BinomialDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BinomialDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BinomialDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
