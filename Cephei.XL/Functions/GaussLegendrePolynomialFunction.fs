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
  Gauss-Legendre polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussLegendrePolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussLegendrePolynomial 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLegendrePolynomial>) l

                let source () = Helper.sourceFold "Fun.GaussLegendrePolynomial" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLegendrePolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_alpha", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".Alpha") 
                                               [| _GaussLegendrePolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
                                ;  _i.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_beta", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".Beta") 
                                               [| _GaussLegendrePolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
                                ;  _i.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_mu_0", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".Mu_0") 
                                               [| _GaussLegendrePolynomial.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_w", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".W") 
                                               [| _GaussLegendrePolynomial.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_value", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".Value") 
                                               [| _GaussLegendrePolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
                                ;  _n.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendrePolynomial_weightedValue", Description="Create a GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendrePolynomial",Description = "Reference to GaussLegendrePolynomial")>] 
         gausslegendrepolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendrePolynomial = Helper.toCell<GaussLegendrePolynomial> gausslegendrepolynomial "GaussLegendrePolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendrePolynomialModel.Cast _GaussLegendrePolynomial.cell).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendrePolynomial.source + ".WeightedValue") 
                                               [| _GaussLegendrePolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendrePolynomial.cell
                                ;  _n.cell
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
    [<ExcelFunction(Name="_GaussLegendrePolynomial_Range", Description="Create a range of GaussLegendrePolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendrePolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussLegendrePolynomial")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussLegendrePolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussLegendrePolynomial>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussLegendrePolynomial>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussLegendrePolynomial>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
