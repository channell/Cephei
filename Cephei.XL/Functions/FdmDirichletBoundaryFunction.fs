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

  </summary> *)
[<AutoSerializable(true)>]
module FdmDirichletBoundaryFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterApplying1", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterApplying1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _x = Helper.toCell<double> x "x" true
                let _value = Helper.toCell<double> value "value" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).ApplyAfterApplying1
                                                            _x.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterApplying1") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _x.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _x.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterApplying", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).ApplyAfterApplying
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterApplying") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterSolving", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).ApplyAfterSolving
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterSolving") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyBeforeApplying", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyBeforeApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _o = Helper.toCell<IOperator> o "o" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).ApplyBeforeApplying
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyBeforeApplying") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyBeforeSolving", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyBeforeSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _o = Helper.toCell<IOperator> o "o" true
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).ApplyBeforeSolving
                                                            _o.cell 
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyBeforeSolving") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _o.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _o.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="valueOnBoundary",Description = "Reference to valueOnBoundary")>] 
         valueOnBoundary : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="side",Description = "Reference to side")>] 
         side : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" true
                let _valueOnBoundary = Helper.toCell<double> valueOnBoundary "valueOnBoundary" true
                let _direction = Helper.toCell<int> direction "direction" true
                let _side = Helper.toCell<BoundaryCondition<FdmLinearOp>.Side> side "side" true
                let builder () = withMnemonic mnemonic (Fun.FdmDirichletBoundary 
                                                            _mesher.cell 
                                                            _valueOnBoundary.cell 
                                                            _direction.cell 
                                                            _side.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmDirichletBoundary>) l

                let source = Helper.sourceFold "Fun.FdmDirichletBoundary" 
                                               [| _mesher.source
                                               ;  _valueOnBoundary.source
                                               ;  _direction.source
                                               ;  _side.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                ;  _valueOnBoundary.cell
                                ;  _direction.cell
                                ;  _side.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_setTime", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "Reference to FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_FdmDirichletBoundary.cell :?> FdmDirichletBoundaryModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDirichletBoundary.source + ".SetTime") 
                                               [| _FdmDirichletBoundary.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_Range", Description="Create a range of FdmDirichletBoundary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmDirichletBoundary")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmDirichletBoundary> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmDirichletBoundary>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmDirichletBoundary>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmDirichletBoundary>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
