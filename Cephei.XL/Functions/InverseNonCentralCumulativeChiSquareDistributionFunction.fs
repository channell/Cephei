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
module InverseNonCentralCumulativeChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralCumulativeChiSquareDistribution", Description="Create a InverseNonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralCumulativeChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "Reference to df")>] 
         df : obj)
        ([<ExcelArgument(Name="ncp",Description = "Reference to ncp")>] 
         ncp : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let _ncp = Helper.toCell<double> ncp "ncp" 
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 10
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1e-8
                let builder () = withMnemonic mnemonic (Fun.InverseNonCentralCumulativeChiSquareDistribution 
                                                            _df.cell 
                                                            _ncp.cell 
                                                            _maxEvaluations.cell 
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseNonCentralCumulativeChiSquareDistribution>) l

                let source = Helper.sourceFold "Fun.InverseNonCentralCumulativeChiSquareDistribution" 
                                               [| _df.source
                                               ;  _ncp.source
                                               ;  _maxEvaluations.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                ;  _ncp.cell
                                ;  _maxEvaluations.cell
                                ;  _accuracy.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseNonCentralCumulativeChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralCumulativeChiSquareDistribution_value", Description="Create a InverseNonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralCumulativeChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseNonCentralCumulativeChiSquareDistribution",Description = "Reference to InverseNonCentralCumulativeChiSquareDistribution")>] 
         inversenoncentralcumulativechisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseNonCentralCumulativeChiSquareDistribution = Helper.toCell<InverseNonCentralCumulativeChiSquareDistribution> inversenoncentralcumulativechisquaredistribution "InverseNonCentralCumulativeChiSquareDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((InverseNonCentralCumulativeChiSquareDistributionModel.Cast _InverseNonCentralCumulativeChiSquareDistribution.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InverseNonCentralCumulativeChiSquareDistribution.source + ".Value") 
                                               [| _InverseNonCentralCumulativeChiSquareDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseNonCentralCumulativeChiSquareDistribution.cell
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
    [<ExcelFunction(Name="_InverseNonCentralCumulativeChiSquareDistribution_Range", Description="Create a range of InverseNonCentralCumulativeChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralCumulativeChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InverseNonCentralCumulativeChiSquareDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseNonCentralCumulativeChiSquareDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InverseNonCentralCumulativeChiSquareDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InverseNonCentralCumulativeChiSquareDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InverseNonCentralCumulativeChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
