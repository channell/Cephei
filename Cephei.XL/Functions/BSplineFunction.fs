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
  Follows treatment and notation from:  Weisstein, Eric W. "B-Spline." From MathWorld--A Wolfram Web Resource.  <http://mathworld.wolfram.com/B-Spline.html>  (p+1) order B-spline (or p degree polynomial) basis functions N_{i,p}(x), i = 0,1,2 n with n+1 control points, or equivalently, an associated knot vector of size p+n+2 defined at the increasingly sorted points (x_0, x_1 x_{n+p+1}) A linear B-spline has p=1 quadratic B-spline has p=2 a cubic B-spline has p=3 etc.
  </summary> *)
[<AutoSerializable(true)>]
module BSplineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BSpline", Description="Create a BSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSpline_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "int")>] 
         p : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="knots",Description = "double range")>] 
         knots : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<int> p "p" 
                let _n = Helper.toCell<int> n "n" 
                let _knots = Helper.toCell<Generic.List<double>> knots "knots" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BSpline 
                                                            _p.cell 
                                                            _n.cell 
                                                            _knots.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BSpline>) l

                let source () = Helper.sourceFold "Fun.BSpline" 
                                               [| _p.source
                                               ;  _n.source
                                               ;  _knots.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                ;  _n.cell
                                ;  _knots.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSpline> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSpline_value", Description="Create a BSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSpline_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSpline",Description = "BSpline")>] 
         bspline : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSpline = Helper.toCell<BSpline> bspline "BSpline"  
                let _i = Helper.toCell<int> i "i" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BSplineModel.Cast _BSpline.cell).Value
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BSpline.source + ".Value") 

                                               [| _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSpline.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_BSpline_Range", Description="Create a range of BSpline",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSpline_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BSpline> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BSpline> (c)) :> ICell
                let format (i : Generic.List<ICell<BSpline>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BSpline>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
