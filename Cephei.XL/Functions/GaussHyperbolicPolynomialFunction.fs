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
  Gauss hyperbolic polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussHyperbolicPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_alpha", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Alpha") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_beta", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Beta") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_mu_0", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Mu_0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_w", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".W") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_value", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Value") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_weightedValue", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussHyperbolicPolynomialModel.Cast _GaussHyperbolicPolynomial.cell).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".WeightedValue") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_Range", Description="Create a range of GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussHyperbolicPolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GaussHyperbolicPolynomial> (c)) :> ICell
                let format (i : Cephei.Cell.List<GaussHyperbolicPolynomial>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GaussHyperbolicPolynomial>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
