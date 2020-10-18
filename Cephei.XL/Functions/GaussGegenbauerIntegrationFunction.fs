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
  Gauss-Gegenbauer integration This class performs a 1-dimensional Gauss-Gegenbauer integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussGegenbauerIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussGegenbauerIntegration", Description="Create a GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GaussGegenbauerIntegration")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="lambda",Description = "double")>] 
         lambda : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _lambda = Helper.toCell<double> lambda "lambda" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussGegenbauerIntegration 
                                                            _n.cell 
                                                            _lambda.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussGegenbauerIntegration>) l

                let source () = Helper.sourceFold "Fun.GaussGegenbauerIntegration" 
                                               [| _n.source
                                               ;  _lambda.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _lambda.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussGegenbauerIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussGegenbauerIntegration_order", Description="Create a GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerIntegration",Description = "GaussGegenbauerIntegration")>] 
         gaussgegenbauerintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerIntegration = Helper.toCell<GaussGegenbauerIntegration> gaussgegenbauerintegration "GaussGegenbauerIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussGegenbauerIntegrationModel.Cast _GaussGegenbauerIntegration.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerIntegration.source + ".Order") 
                                               [| _GaussGegenbauerIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerIntegration.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerIntegration_value", Description="Create a GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerIntegration",Description = "GaussGegenbauerIntegration")>] 
         gaussgegenbauerintegration : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerIntegration = Helper.toCell<GaussGegenbauerIntegration> gaussgegenbauerintegration "GaussGegenbauerIntegration"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussGegenbauerIntegrationModel.Cast _GaussGegenbauerIntegration.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerIntegration.source + ".Value") 
                                               [| _GaussGegenbauerIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerIntegration.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerIntegration_weights", Description="Create a GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerIntegration",Description = "GaussGegenbauerIntegration")>] 
         gaussgegenbauerintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerIntegration = Helper.toCell<GaussGegenbauerIntegration> gaussgegenbauerintegration "GaussGegenbauerIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussGegenbauerIntegrationModel.Cast _GaussGegenbauerIntegration.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussGegenbauerIntegration.source + ".Weights") 
                                               [| _GaussGegenbauerIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussGegenbauerIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussGegenbauerIntegration_x", Description="Create a GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerIntegration",Description = "GaussGegenbauerIntegration")>] 
         gaussgegenbauerintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerIntegration = Helper.toCell<GaussGegenbauerIntegration> gaussgegenbauerintegration "GaussGegenbauerIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussGegenbauerIntegrationModel.Cast _GaussGegenbauerIntegration.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussGegenbauerIntegration.source + ".X") 
                                               [| _GaussGegenbauerIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussGegenbauerIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussGegenbauerIntegration_Range", Description="Create a range of GaussGegenbauerIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussGegenbauerIntegration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussGegenbauerIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussGegenbauerIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussGegenbauerIntegration>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
