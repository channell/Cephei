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
module NonCentralChiSquareDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NonCentralChiSquareDistribution", Description="Create a NonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonCentralChiSquareDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NonCentralChiSquareDistribution 
                                                            _df.cell 
                                                            _ncp.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonCentralChiSquareDistribution>) l

                let source () = Helper.sourceFold "Fun.NonCentralChiSquareDistribution" 
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
                    ; subscriber = Helper.subscriberModel<NonCentralChiSquareDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NonCentralChiSquareDistribution_value", Description="Create a NonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonCentralChiSquareDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonCentralChiSquareDistribution",Description = "NonCentralChiSquareDistribution")>] 
         noncentralchisquaredistribution : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonCentralChiSquareDistribution = Helper.toCell<NonCentralChiSquareDistribution> noncentralchisquaredistribution "NonCentralChiSquareDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((NonCentralChiSquareDistributionModel.Cast _NonCentralChiSquareDistribution.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NonCentralChiSquareDistribution.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonCentralChiSquareDistribution.cell
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
    [<ExcelFunction(Name="_NonCentralChiSquareDistribution_Range", Description="Create a range of NonCentralChiSquareDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonCentralChiSquareDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NonCentralChiSquareDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NonCentralChiSquareDistribution> (c)) :> ICell
                let format (i : Cephei.Cell.List<NonCentralChiSquareDistribution>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NonCentralChiSquareDistribution>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
