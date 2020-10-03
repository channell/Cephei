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
  generalized Gauss-Laguerre integration This class performs a 1-dimensional Gauss-Laguerre integration.
  </summary> *)
[<AutoSerializable(true)>]
module GaussLaguerreIntegrationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerreIntegration", Description="Create a GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _s = Helper.toDefault<double> s "s" 0.0
                let builder () = withMnemonic mnemonic (Fun.GaussLaguerreIntegration 
                                                            _n.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLaguerreIntegration>) l

                let source = Helper.sourceFold "Fun.GaussLaguerreIntegration" 
                                               [| _n.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _s.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLaguerreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerreIntegration_order", Description="Create a GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerreIntegration",Description = "Reference to GaussLaguerreIntegration")>] 
         gausslaguerreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerreIntegration = Helper.toCell<GaussLaguerreIntegration> gausslaguerreintegration "GaussLaguerreIntegration"  
                let builder () = withMnemonic mnemonic ((GaussLaguerreIntegrationModel.Cast _GaussLaguerreIntegration.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLaguerreIntegration.source + ".Order") 
                                               [| _GaussLaguerreIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerreIntegration.cell
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
    [<ExcelFunction(Name="_GaussLaguerreIntegration_value", Description="Create a GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerreIntegration",Description = "Reference to GaussLaguerreIntegration")>] 
         gausslaguerreintegration : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerreIntegration = Helper.toCell<GaussLaguerreIntegration> gausslaguerreintegration "GaussLaguerreIntegration"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder () = withMnemonic mnemonic ((GaussLaguerreIntegrationModel.Cast _GaussLaguerreIntegration.cell).Value
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLaguerreIntegration.source + ".Value") 
                                               [| _GaussLaguerreIntegration.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerreIntegration.cell
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
    [<ExcelFunction(Name="_GaussLaguerreIntegration_weights", Description="Create a GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerreIntegration",Description = "Reference to GaussLaguerreIntegration")>] 
         gausslaguerreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerreIntegration = Helper.toCell<GaussLaguerreIntegration> gausslaguerreintegration "GaussLaguerreIntegration"  
                let builder () = withMnemonic mnemonic ((GaussLaguerreIntegrationModel.Cast _GaussLaguerreIntegration.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussLaguerreIntegration.source + ".Weights") 
                                               [| _GaussLaguerreIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerreIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLaguerreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussLaguerreIntegration_x", Description="Create a GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_x
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLaguerreIntegration",Description = "Reference to GaussLaguerreIntegration")>] 
         gausslaguerreintegration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLaguerreIntegration = Helper.toCell<GaussLaguerreIntegration> gausslaguerreintegration "GaussLaguerreIntegration"  
                let builder () = withMnemonic mnemonic ((GaussLaguerreIntegrationModel.Cast _GaussLaguerreIntegration.cell).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GaussLaguerreIntegration.source + ".X") 
                                               [| _GaussLaguerreIntegration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLaguerreIntegration.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLaguerreIntegration> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussLaguerreIntegration_Range", Description="Create a range of GaussLaguerreIntegration",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLaguerreIntegration_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussLaguerreIntegration")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussLaguerreIntegration> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussLaguerreIntegration>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussLaguerreIntegration>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussLaguerreIntegration>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
