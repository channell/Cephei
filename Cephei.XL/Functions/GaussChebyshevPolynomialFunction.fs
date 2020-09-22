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
  Gauss-Chebyshev polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussChebyshevPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.GaussChebyshevPolynomial ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussChebyshevPolynomial>) l

                let source = Helper.sourceFold "Fun.GaussChebyshevPolynomial" 
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
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_alpha", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".Alpha") 
                                               [| _GaussChebyshevPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
                                ;  _i.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_beta", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".Beta") 
                                               [| _GaussChebyshevPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
                                ;  _i.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_mu_0", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".Mu_0") 
                                               [| _GaussChebyshevPolynomial.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_w", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".W") 
                                               [| _GaussChebyshevPolynomial.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_value", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let _n = Helper.toCell<int> n "n" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".Value") 
                                               [| _GaussChebyshevPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
                                ;  _n.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_weightedValue", Description="Create a GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshevPolynomial",Description = "Reference to GaussChebyshevPolynomial")>] 
         gausschebyshevpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshevPolynomial = Helper.toCell<GaussChebyshevPolynomial> gausschebyshevpolynomial "GaussChebyshevPolynomial" true 
                let _n = Helper.toCell<int> n "n" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussChebyshevPolynomial.cell :?> GaussChebyshevPolynomialModel).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussChebyshevPolynomial.source + ".WeightedValue") 
                                               [| _GaussChebyshevPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshevPolynomial.cell
                                ;  _n.cell
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
    [<ExcelFunction(Name="_GaussChebyshevPolynomial_Range", Description="Create a range of GaussChebyshevPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussChebyshevPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussChebyshevPolynomial")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussChebyshevPolynomial> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussChebyshevPolynomial>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussChebyshevPolynomial>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussChebyshevPolynomial>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
