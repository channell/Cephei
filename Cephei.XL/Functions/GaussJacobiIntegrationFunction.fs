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
  Gauss-Jacobi integration This class performs a 1-dimensional Gauss-Jacobi integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussJacobiIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiIntegration", Description="Create a GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic (Fun.GaussJacobiIntegration 
                                                            _n.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussJacobiIntegration>) l

                let source = Helper.sourceFold "Fun.GaussJacobiIntegration" 
                                               [| _n.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussJacobiIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiIntegration_order", Description="Create a GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiIntegration",Description = "Reference to GaussJacobiIntegration")>] 
         gaussjacobiintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiIntegration = Helper.toCell<GaussJacobiIntegration> gaussjacobiintegration "GaussJacobiIntegration"  
                let builder () = withMnemonic mnemonic ((GaussJacobiIntegrationModel.Cast _GaussJacobiIntegration.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiIntegration.source + ".Order") 
                                               [| _GaussJacobiIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiIntegration.cell
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
    [<ExcelFunction(Name="_GaussJacobiIntegration_value", Description="Create a GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiIntegration",Description = "Reference to GaussJacobiIntegration")>] 
         gaussjacobiintegration : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiIntegration = Helper.toCell<GaussJacobiIntegration> gaussjacobiintegration "GaussJacobiIntegration"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder () = withMnemonic mnemonic ((GaussJacobiIntegrationModel.Cast _GaussJacobiIntegration.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiIntegration.source + ".Value") 
                                               [| _GaussJacobiIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiIntegration.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_GaussJacobiIntegration_weights", Description="Create a GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiIntegration",Description = "Reference to GaussJacobiIntegration")>] 
         gaussjacobiintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiIntegration = Helper.toCell<GaussJacobiIntegration> gaussjacobiintegration "GaussJacobiIntegration"  
                let builder () = withMnemonic mnemonic ((GaussJacobiIntegrationModel.Cast _GaussJacobiIntegration.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussJacobiIntegration.source + ".Weights") 
                                               [| _GaussJacobiIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussJacobiIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiIntegration_x", Description="Create a GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiIntegration",Description = "Reference to GaussJacobiIntegration")>] 
         gaussjacobiintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiIntegration = Helper.toCell<GaussJacobiIntegration> gaussjacobiintegration "GaussJacobiIntegration"  
                let builder () = withMnemonic mnemonic ((GaussJacobiIntegrationModel.Cast _GaussJacobiIntegration.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussJacobiIntegration.source + ".X") 
                                               [| _GaussJacobiIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussJacobiIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussJacobiIntegration_Range", Description="Create a range of GaussJacobiIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussJacobiIntegration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussJacobiIntegration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussJacobiIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussJacobiIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussJacobiIntegration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
