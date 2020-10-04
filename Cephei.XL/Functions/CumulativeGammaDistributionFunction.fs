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
module CumulativeGammaDistributionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeGammaDistribution", Description="Create a CumulativeGammaDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeGammaDistribution_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toCell<double> a "a" 
                let builder () = withMnemonic mnemonic (Fun.CumulativeGammaDistribution 
                                                            _a.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CumulativeGammaDistribution>) l

                let source = Helper.sourceFold "Fun.CumulativeGammaDistribution" 
                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CumulativeGammaDistribution> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CumulativeGammaDistribution_value", Description="Create a CumulativeGammaDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeGammaDistribution_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CumulativeGammaDistribution",Description = "Reference to CumulativeGammaDistribution")>] 
         cumulativegammadistribution : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CumulativeGammaDistribution = Helper.toCell<CumulativeGammaDistribution> cumulativegammadistribution "CumulativeGammaDistribution"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((CumulativeGammaDistributionModel.Cast _CumulativeGammaDistribution.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CumulativeGammaDistribution.source + ".Value") 
                                               [| _CumulativeGammaDistribution.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CumulativeGammaDistribution.cell
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
    [<ExcelFunction(Name="_CumulativeGammaDistribution_Range", Description="Create a range of CumulativeGammaDistribution",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CumulativeGammaDistribution_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CumulativeGammaDistribution")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CumulativeGammaDistribution> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CumulativeGammaDistribution>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CumulativeGammaDistribution>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CumulativeGammaDistribution>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
