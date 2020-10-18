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
  Gauss-Chebyshev integration (second kind) This class performs a 1-dimensional Gauss-Chebyshev integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussChebyshev2ndIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration", Description="Create a GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GaussChebyshev2ndIntegration")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussChebyshev2ndIntegration 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussChebyshev2ndIntegration>) l

                let source () = Helper.sourceFold "Fun.GaussChebyshev2ndIntegration" 
                                               [| _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussChebyshev2ndIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration_order", Description="Create a GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndIntegration",Description = "GaussChebyshev2ndIntegration")>] 
         gausschebyshev2ndintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndIntegration = Helper.toCell<GaussChebyshev2ndIntegration> gausschebyshev2ndintegration "GaussChebyshev2ndIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussChebyshev2ndIntegrationModel.Cast _GaussChebyshev2ndIntegration.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndIntegration.source + ".Order") 
                                               [| _GaussChebyshev2ndIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration_value", Description="Create a GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndIntegration",Description = "GaussChebyshev2ndIntegration")>] 
         gausschebyshev2ndintegration : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndIntegration = Helper.toCell<GaussChebyshev2ndIntegration> gausschebyshev2ndintegration "GaussChebyshev2ndIntegration"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussChebyshev2ndIntegrationModel.Cast _GaussChebyshev2ndIntegration.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndIntegration.source + ".Value") 
                                               [| _GaussChebyshev2ndIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndIntegration.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration_weights", Description="Create a GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndIntegration",Description = "GaussChebyshev2ndIntegration")>] 
         gausschebyshev2ndintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndIntegration = Helper.toCell<GaussChebyshev2ndIntegration> gausschebyshev2ndintegration "GaussChebyshev2ndIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussChebyshev2ndIntegrationModel.Cast _GaussChebyshev2ndIntegration.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussChebyshev2ndIntegration.source + ".Weights") 
                                               [| _GaussChebyshev2ndIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussChebyshev2ndIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration_x", Description="Create a GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndIntegration",Description = "GaussChebyshev2ndIntegration")>] 
         gausschebyshev2ndintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndIntegration = Helper.toCell<GaussChebyshev2ndIntegration> gausschebyshev2ndintegration "GaussChebyshev2ndIntegration"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussChebyshev2ndIntegrationModel.Cast _GaussChebyshev2ndIntegration.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GaussChebyshev2ndIntegration.source + ".X") 
                                               [| _GaussChebyshev2ndIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussChebyshev2ndIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussChebyshev2ndIntegration_Range", Description="Create a range of GaussChebyshev2ndIntegration",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussChebyshev2ndIntegration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussChebyshev2ndIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussChebyshev2ndIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussChebyshev2ndIntegration>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
