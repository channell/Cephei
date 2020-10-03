﻿(*
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
module NonCentralCumulativeChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NonCentralCumulativeChiSquareDistribution", Description="Create a NonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonCentralCumulativeChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "Reference to df")>] 
         df : obj)
        ([<ExcelArgument(Name="ncp",Description = "Reference to ncp")>] 
         ncp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let _ncp = Helper.toCell<double> ncp "ncp" 
                let builder () = withMnemonic mnemonic (Fun.NonCentralCumulativeChiSquareDistribution 
                                                            _df.cell 
                                                            _ncp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonCentralCumulativeChiSquareDistribution>) l

                let source = Helper.sourceFold "Fun.NonCentralCumulativeChiSquareDistribution" 
                                               [| _df.source
                                               ;  _ncp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                ;  _ncp.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonCentralCumulativeChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NonCentralCumulativeChiSquareDistribution_value", Description="Create a NonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonCentralCumulativeChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonCentralCumulativeChiSquareDistribution",Description = "Reference to NonCentralCumulativeChiSquareDistribution")>] 
         noncentralcumulativechisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonCentralCumulativeChiSquareDistribution = Helper.toCell<NonCentralCumulativeChiSquareDistribution> noncentralcumulativechisquaredistribution "NonCentralCumulativeChiSquareDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_NonCentralCumulativeChiSquareDistribution.cell :?> NonCentralCumulativeChiSquareDistributionModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NonCentralCumulativeChiSquareDistribution.source + ".Value") 
                                               [| _NonCentralCumulativeChiSquareDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonCentralCumulativeChiSquareDistribution.cell
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
    [<ExcelFunction(Name="_NonCentralCumulativeChiSquareDistribution_Range", Description="Create a range of NonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonCentralCumulativeChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NonCentralCumulativeChiSquareDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NonCentralCumulativeChiSquareDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NonCentralCumulativeChiSquareDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NonCentralCumulativeChiSquareDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NonCentralCumulativeChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"