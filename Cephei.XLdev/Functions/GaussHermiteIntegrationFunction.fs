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
  generalized Gauss-Hermite integration This class performs a 1-dimensional Gauss-Hermite integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussHermiteIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussHermiteIntegration", Description="Create a GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="mu",Description = "Reference to mu")>] 
         mu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" true
                let _mu = Helper.toCell<double> mu "mu" true
                let builder () = withMnemonic mnemonic (Fun.GaussHermiteIntegration 
                                                            _n.cell 
                                                            _mu.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussHermiteIntegration>) l

                let source = Helper.sourceFold "Fun.GaussHermiteIntegration" 
                                               [| _n.source
                                               ;  _mu.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _mu.cell
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
    [<ExcelFunction(Name="_GaussHermiteIntegration_order", Description="Create a GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermiteIntegration",Description = "Reference to GaussHermiteIntegration")>] 
         gausshermiteintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermiteIntegration = Helper.toCell<GaussHermiteIntegration> gausshermiteintegration "GaussHermiteIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHermiteIntegration.cell :?> GaussHermiteIntegrationModel).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermiteIntegration.source + ".Order") 
                                               [| _GaussHermiteIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermiteIntegration.cell
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
    [<ExcelFunction(Name="_GaussHermiteIntegration_value", Description="Create a GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermiteIntegration",Description = "Reference to GaussHermiteIntegration")>] 
         gausshermiteintegration : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermiteIntegration = Helper.toCell<GaussHermiteIntegration> gausshermiteintegration "GaussHermiteIntegration" true 
                let _f = Helper.toCell<Func<double,double>> f "f" true
                let builder () = withMnemonic mnemonic ((_GaussHermiteIntegration.cell :?> GaussHermiteIntegrationModel).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHermiteIntegration.source + ".Value") 
                                               [| _GaussHermiteIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermiteIntegration.cell
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
    [<ExcelFunction(Name="_GaussHermiteIntegration_weights", Description="Create a GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermiteIntegration",Description = "Reference to GaussHermiteIntegration")>] 
         gausshermiteintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermiteIntegration = Helper.toCell<GaussHermiteIntegration> gausshermiteintegration "GaussHermiteIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHermiteIntegration.cell :?> GaussHermiteIntegrationModel).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussHermiteIntegration.source + ".Weights") 
                                               [| _GaussHermiteIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermiteIntegration.cell
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
    [<ExcelFunction(Name="_GaussHermiteIntegration_x", Description="Create a GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHermiteIntegration",Description = "Reference to GaussHermiteIntegration")>] 
         gausshermiteintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHermiteIntegration = Helper.toCell<GaussHermiteIntegration> gausshermiteintegration "GaussHermiteIntegration" true 
                let builder () = withMnemonic mnemonic ((_GaussHermiteIntegration.cell :?> GaussHermiteIntegrationModel).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussHermiteIntegration.source + ".X") 
                                               [| _GaussHermiteIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHermiteIntegration.cell
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
    [<ExcelFunction(Name="_GaussHermiteIntegration_Range", Description="Create a range of GaussHermiteIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHermiteIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussHermiteIntegration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussHermiteIntegration> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussHermiteIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussHermiteIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussHermiteIntegration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
