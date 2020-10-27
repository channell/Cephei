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
  Gauss-Legendre integration This class performs a 1-dimensional Gauss-Legendre integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussLegendreIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendreIntegration", Description="Create a GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GaussLegendreIntegration")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussLegendreIntegration 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLegendreIntegration>) l

                let source () = Helper.sourceFold "Fun.GaussLegendreIntegration" 
                                               [| _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLegendreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendreIntegration_order", Description="Create a GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendreIntegration",Description = "GaussLegendreIntegration")>] 
         gausslegendreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendreIntegration = Helper.toCell<GaussLegendreIntegration> gausslegendreintegration "GaussLegendreIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendreIntegrationModel.Cast _GaussLegendreIntegration.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendreIntegration.source + ".Order") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussLegendreIntegration.cell
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
    [<ExcelFunction(Name="_GaussLegendreIntegration_value", Description="Create a GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendreIntegration",Description = "GaussLegendreIntegration")>] 
         gausslegendreintegration : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendreIntegration = Helper.toCell<GaussLegendreIntegration> gausslegendreintegration "GaussLegendreIntegration"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendreIntegrationModel.Cast _GaussLegendreIntegration.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussLegendreIntegration.source + ".Value") 

                                               [| _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLegendreIntegration.cell
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
    [<ExcelFunction(Name="_GaussLegendreIntegration_weights", Description="Create a GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendreIntegration",Description = "GaussLegendreIntegration")>] 
         gausslegendreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendreIntegration = Helper.toCell<GaussLegendreIntegration> gausslegendreintegration "GaussLegendreIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendreIntegrationModel.Cast _GaussLegendreIntegration.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussLegendreIntegration.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussLegendreIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLegendreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLegendreIntegration_x", Description="Create a GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLegendreIntegration",Description = "GaussLegendreIntegration")>] 
         gausslegendreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLegendreIntegration = Helper.toCell<GaussLegendreIntegration> gausslegendreintegration "GaussLegendreIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussLegendreIntegrationModel.Cast _GaussLegendreIntegration.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussLegendreIntegration.source + ".X") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussLegendreIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLegendreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussLegendreIntegration_Range", Description="Create a range of GaussLegendreIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussLegendreIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussLegendreIntegration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussLegendreIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussLegendreIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussLegendreIntegration>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
