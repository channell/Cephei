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
  tabulated Gauss-Legendre quadratures
  </summary> *)
[<AutoSerializable(true)>]
module TabulatedGaussLegendreFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TabulatedGaussLegendre_order", Description="Create a TabulatedGaussLegendre",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TabulatedGaussLegendre_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TabulatedGaussLegendre",Description = "TabulatedGaussLegendre")>] 
         tabulatedgausslegendre : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TabulatedGaussLegendre = Helper.toCell<TabulatedGaussLegendre> tabulatedgausslegendre "TabulatedGaussLegendre"  
                let builder (current : ICell) = withMnemonic mnemonic ((TabulatedGaussLegendreModel.Cast _TabulatedGaussLegendre.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TabulatedGaussLegendre.source + ".Order") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TabulatedGaussLegendre.cell
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
    [<ExcelFunction(Name="_TabulatedGaussLegendre_order1", Description="Create a TabulatedGaussLegendre",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TabulatedGaussLegendre_order1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TabulatedGaussLegendre",Description = "TabulatedGaussLegendre")>] 
         tabulatedgausslegendre : obj)
        ([<ExcelArgument(Name="order",Description = "int")>] 
         order : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TabulatedGaussLegendre = Helper.toCell<TabulatedGaussLegendre> tabulatedgausslegendre "TabulatedGaussLegendre"  
                let _order = Helper.toCell<int> order "order" 
                let builder (current : ICell) = withMnemonic mnemonic ((TabulatedGaussLegendreModel.Cast _TabulatedGaussLegendre.cell).Order1
                                                            _order.cell 
                                                       ) :> ICell
                let format (o : TabulatedGaussLegendre) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TabulatedGaussLegendre.source + ".Order") 

                                               [| _order.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TabulatedGaussLegendre.cell
                                ;  _order.cell
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
    [<ExcelFunction(Name="_TabulatedGaussLegendre", Description="Create a TabulatedGaussLegendre",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TabulatedGaussLegendre_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int or empty")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toDefault<int> n "n" 20
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TabulatedGaussLegendre 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TabulatedGaussLegendre>) l

                let source () = Helper.sourceFold "Fun.TabulatedGaussLegendre" 
                                               [| _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TabulatedGaussLegendre> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TabulatedGaussLegendre_value", Description="Create a TabulatedGaussLegendre",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TabulatedGaussLegendre_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TabulatedGaussLegendre",Description = "TabulatedGaussLegendre")>] 
         tabulatedgausslegendre : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TabulatedGaussLegendre = Helper.toCell<TabulatedGaussLegendre> tabulatedgausslegendre "TabulatedGaussLegendre"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((TabulatedGaussLegendreModel.Cast _TabulatedGaussLegendre.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TabulatedGaussLegendre.source + ".Value") 

                                               [| _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TabulatedGaussLegendre.cell
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
    [<ExcelFunction(Name="_TabulatedGaussLegendre_Range", Description="Create a range of TabulatedGaussLegendre",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TabulatedGaussLegendre_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TabulatedGaussLegendre> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<TabulatedGaussLegendre> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<TabulatedGaussLegendre>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TabulatedGaussLegendre>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
