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
module InverseNonCentralChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralChiSquareDistribution", Description="Create a InverseNonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "InverseNonCentralChiSquareDistribution")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "double")>] 
         df : obj)
        ([<ExcelArgument(Name="ncp",Description = "double")>] 
         ncp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let _ncp = Helper.toCell<double> ncp "ncp" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseNonCentralChiSquareDistribution 
                                                            _df.cell 
                                                            _ncp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseNonCentralChiSquareDistribution>) l

                let source () = Helper.sourceFold "Fun.InverseNonCentralChiSquareDistribution" 
                                               [| _df.source
                                               ;  _ncp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                ;  _ncp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseNonCentralChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralChiSquareDistribution1", Description="Create a InverseNonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralChiSquareDistribution_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "InverseNonCentralChiSquareDistribution")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "double")>] 
         df : obj)
        ([<ExcelArgument(Name="ncp",Description = "double")>] 
         ncp : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let _ncp = Helper.toCell<double> ncp "ncp" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseNonCentralChiSquareDistribution1 
                                                            _df.cell 
                                                            _ncp.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseNonCentralChiSquareDistribution>) l

                let source () = Helper.sourceFold "Fun.InverseNonCentralChiSquareDistribution1" 
                                               [| _df.source
                                               ;  _ncp.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _df.cell
                                ;  _ncp.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseNonCentralChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralChiSquareDistribution2", Description="Create a InverseNonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralChiSquareDistribution_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "InverseNonCentralChiSquareDistribution")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="df",Description = "double")>] 
         df : obj)
        ([<ExcelArgument(Name="ncp",Description = "double")>] 
         ncp : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _df = Helper.toCell<double> df "df" 
                let _ncp = Helper.toCell<double> ncp "ncp" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InverseNonCentralChiSquareDistribution2 
                                                            _df.cell 
                                                            _ncp.cell 
                                                            _maxEvaluations.cell 
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseNonCentralChiSquareDistribution>) l

                let source () = Helper.sourceFold "Fun.InverseNonCentralChiSquareDistribution2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InverseNonCentralChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InverseNonCentralChiSquareDistribution_value", Description="Create a InverseNonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseNonCentralChiSquareDistribution",Description = "InverseNonCentralChiSquareDistribution")>] 
         inversenoncentralchisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseNonCentralChiSquareDistribution = Helper.toCell<InverseNonCentralChiSquareDistribution> inversenoncentralchisquaredistribution "InverseNonCentralChiSquareDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((InverseNonCentralChiSquareDistributionModel.Cast _InverseNonCentralChiSquareDistribution.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InverseNonCentralChiSquareDistribution.source + ".Value") 
                                               [| _InverseNonCentralChiSquareDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseNonCentralChiSquareDistribution.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_InverseNonCentralChiSquareDistribution_Range", Description="Create a range of InverseNonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InverseNonCentralChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseNonCentralChiSquareDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InverseNonCentralChiSquareDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<InverseNonCentralChiSquareDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InverseNonCentralChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
