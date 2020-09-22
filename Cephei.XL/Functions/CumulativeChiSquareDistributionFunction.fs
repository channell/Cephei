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
module CumulativeChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeChiSquareDistribution", Description="Create a CumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "Reference to df")>] 
         df : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" true
                let builder () = withMnemonic mnemonic (Fun.CumulativeChiSquareDistribution 
                                                            _df.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CumulativeChiSquareDistribution>) l

                let source = Helper.sourceFold "Fun.CumulativeChiSquareDistribution" 
                                               [| _df.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeChiSquareDistribution_value", Description="Create a CumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CumulativeChiSquareDistribution",Description = "Reference to CumulativeChiSquareDistribution")>] 
         cumulativechisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CumulativeChiSquareDistribution = Helper.toCell<CumulativeChiSquareDistribution> cumulativechisquaredistribution "CumulativeChiSquareDistribution" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_CumulativeChiSquareDistribution.cell :?> CumulativeChiSquareDistributionModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CumulativeChiSquareDistribution.source + ".Value") 
                                               [| _CumulativeChiSquareDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CumulativeChiSquareDistribution.cell
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
    [<ExcelFunction(Name="_CumulativeChiSquareDistribution_Range", Description="Create a range of CumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CumulativeChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CumulativeChiSquareDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CumulativeChiSquareDistribution> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CumulativeChiSquareDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CumulativeChiSquareDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CumulativeChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
