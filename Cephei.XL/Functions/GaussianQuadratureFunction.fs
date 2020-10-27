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
  References: Gauss quadratures and orthogonal polynomials  G.H. Gloub and J.H. Welsch: Calculation of Gauss quadrature rule. Math. Comput. 23 (1986), 221-230  "Numerical Recipes in C", 2nd edition, Press, Teukolsky, Vetterling, Flannery,  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module GaussianQuadratureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussianQuadrature", Description="Create a GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GaussianQuadrature")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="orthPoly",Description = "GaussianOrthogonalPolynomial")>] 
         orthPoly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _orthPoly = Helper.toCell<GaussianOrthogonalPolynomial> orthPoly "orthPoly" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussianQuadrature 
                                                            _n.cell 
                                                            _orthPoly.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussianQuadrature>) l

                let source () = Helper.sourceFold "Fun.GaussianQuadrature" 
                                               [| _n.source
                                               ;  _orthPoly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _orthPoly.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussianQuadrature> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussianQuadrature_order", Description="Create a GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianQuadrature",Description = "GaussianQuadrature")>] 
         gaussianquadrature : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianQuadrature = Helper.toCell<GaussianQuadrature> gaussianquadrature "GaussianQuadrature"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussianQuadratureModel.Cast _GaussianQuadrature.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussianQuadrature.source + ".Order") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussianQuadrature.cell
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
    [<ExcelFunction(Name="_GaussianQuadrature_value", Description="Create a GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianQuadrature",Description = "GaussianQuadrature")>] 
         gaussianquadrature : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianQuadrature = Helper.toCell<GaussianQuadrature> gaussianquadrature "GaussianQuadrature"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussianQuadratureModel.Cast _GaussianQuadrature.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussianQuadrature.source + ".Value") 

                                               [| _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussianQuadrature.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_GaussianQuadrature_weights", Description="Create a GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianQuadrature",Description = "GaussianQuadrature")>] 
         gaussianquadrature : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianQuadrature = Helper.toCell<GaussianQuadrature> gaussianquadrature "GaussianQuadrature"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussianQuadratureModel.Cast _GaussianQuadrature.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussianQuadrature.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussianQuadrature.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussianQuadrature> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussianQuadrature_x", Description="Create a GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussianQuadrature",Description = "GaussianQuadrature")>] 
         gaussianquadrature : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussianQuadrature = Helper.toCell<GaussianQuadrature> gaussianquadrature "GaussianQuadrature"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussianQuadratureModel.Cast _GaussianQuadrature.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussianQuadrature.source + ".X") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussianQuadrature.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussianQuadrature> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussianQuadrature_Range", Description="Create a range of GaussianQuadrature",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussianQuadrature_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussianQuadrature> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussianQuadrature>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussianQuadrature>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussianQuadrature>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
