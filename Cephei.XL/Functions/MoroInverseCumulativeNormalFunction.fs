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
  Given x between zero and one as the integral value of a gaussian normal distribution this class provides the value y such that formula here ...  It uses Beasly and Springer approximation, with an improved approximation for the tails. See Boris Moro, "The Full Monte", 1995, Risk Magazine.  This class can also be used to generate a gaussian normal distribution from a uniform distribution. This is especially useful when a gaussian normal distribution is generated from a low discrepancy uniform distribution: in this case the traditional Box-Muller approach and its variants would not preserve the sequence's low-discrepancy.  Peter J. Acklam's approximation is better and is available as QuantLib::InverseCumulativeNormal
  </summary> *)
[<AutoSerializable(true)>]
module MoroInverseCumulativeNormalFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MoroInverseCumulativeNormal", Description="Create a MoroInverseCumulativeNormal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MoroInverseCumulativeNormal_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="average",Description = "double")>] 
         average : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _average = Helper.toCell<double> average "average" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MoroInverseCumulativeNormal 
                                                            _average.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MoroInverseCumulativeNormal>) l

                let source () = Helper.sourceFold "Fun.MoroInverseCumulativeNormal" 
                                               [| _average.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _average.cell
                                ;  _sigma.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MoroInverseCumulativeNormal> format
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
    [<ExcelFunction(Name="_MoroInverseCumulativeNormal_value", Description="Create a MoroInverseCumulativeNormal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MoroInverseCumulativeNormal_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MoroInverseCumulativeNormal",Description = "MoroInverseCumulativeNormal")>] 
         moroinversecumulativenormal : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MoroInverseCumulativeNormal = Helper.toCell<MoroInverseCumulativeNormal> moroinversecumulativenormal "MoroInverseCumulativeNormal"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((MoroInverseCumulativeNormalModel.Cast _MoroInverseCumulativeNormal.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MoroInverseCumulativeNormal.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MoroInverseCumulativeNormal.cell
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
    [<ExcelFunction(Name="_MoroInverseCumulativeNormal_Range", Description="Create a range of MoroInverseCumulativeNormal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MoroInverseCumulativeNormal_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MoroInverseCumulativeNormal> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MoroInverseCumulativeNormal> (c)) :> ICell
                let format (i : Cephei.Cell.List<MoroInverseCumulativeNormal>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MoroInverseCumulativeNormal>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
