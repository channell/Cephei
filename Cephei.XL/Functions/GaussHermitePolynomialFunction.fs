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
  Gauss-Hermite polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussHermitePolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussHermitePolynomial_alpha", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".Alpha") 
                                               [| _GaussHermitePolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_beta", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".Beta") 
                                               [| _GaussHermitePolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mu",Description = "Reference to mu")>] 
         mu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mu = Helper.toCell<double> mu "mu" true
                let builder () = withMnemonic mnemonic (Fun.GaussHermitePolynomial 
                                                            _mu.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussHermitePolynomial>) l

                let source = Helper.sourceFold "Fun.GaussHermitePolynomial" 
                                               [| _mu.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mu.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial1", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.GaussHermitePolynomial1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussHermitePolynomial>) l

                let source = Helper.sourceFold "Fun.GaussHermitePolynomial1" 
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_mu_0", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".Mu_0") 
                                               [| _GaussHermitePolynomial.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_w", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".W") 
                                               [| _GaussHermitePolynomial.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_value", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let _n = Helper.toCell<int> n "n" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".Value") 
                                               [| _GaussHermitePolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_weightedValue", Description="Create a GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermitePolynomial",Description = "Reference to GaussHermitePolynomial")>] 
         gausshermitepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermitePolynomial = Helper.toCell<GaussHermitePolynomial> gausshermitepolynomial "GaussHermitePolynomial" true 
                let _n = Helper.toCell<int> n "n" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GaussHermitePolynomial.cell :?> GaussHermitePolynomialModel).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermitePolynomial.source + ".WeightedValue") 
                                               [| _GaussHermitePolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermitePolynomial.cell
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
    [<ExcelFunction(Name="_GaussHermitePolynomial_Range", Description="Create a range of GaussHermitePolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermitePolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussHermitePolynomial")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussHermitePolynomial> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussHermitePolynomial>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussHermitePolynomial>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussHermitePolynomial>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
