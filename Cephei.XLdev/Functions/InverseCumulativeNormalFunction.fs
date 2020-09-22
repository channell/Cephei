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
  Given x between zero and one as the integral value of a gaussian normal distribution this class provides the value y such that formula here ...  It use Acklam's approximation: by Peter J. Acklam, University of Oslo, Statistics Division. URL: http://home.online.no/~pjacklam/notes/invnorm/index.html  This class can also be used to generate a gaussian normal distribution from a uniform distribution. This is especially useful when a gaussian normal distribution is generated from a low discrepancy uniform distribution: in this case the traditional Box-Muller approach and its variants would not preserve the sequence's low-discrepancy.
  </summary> *)
[<AutoSerializable(true)>]
module InverseCumulativeNormalFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativeNormal", Description="Create a InverseCumulativeNormal",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeNormal_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="average",Description = "Reference to average")>] 
         average : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _average = Helper.toCell<double> average "average" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.InverseCumulativeNormal 
                                                            _average.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativeNormal>) l

                let source = Helper.sourceFold "Fun.InverseCumulativeNormal" 
                                               [| _average.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _average.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_InverseCumulativeNormal1", Description="Create a InverseCumulativeNormal",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeNormal_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.InverseCumulativeNormal1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativeNormal>) l

                let source = Helper.sourceFold "Fun.InverseCumulativeNormal1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        function
    *)
    [<ExcelFunction(Name="_InverseCumulativeNormal_value", Description="Create a InverseCumulativeNormal",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeNormal_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeNormal",Description = "Reference to InverseCumulativeNormal")>] 
         inversecumulativenormal : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeNormal = Helper.toCell<InverseCumulativeNormal> inversecumulativenormal "InverseCumulativeNormal" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_InverseCumulativeNormal.cell :?> InverseCumulativeNormalModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InverseCumulativeNormal.source + ".Value") 
                                               [| _InverseCumulativeNormal.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeNormal.cell
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
    [<ExcelFunction(Name="_InverseCumulativeNormal_Range", Description="Create a range of InverseCumulativeNormal",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeNormal_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InverseCumulativeNormal")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseCumulativeNormal> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InverseCumulativeNormal>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InverseCumulativeNormal>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InverseCumulativeNormal>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
