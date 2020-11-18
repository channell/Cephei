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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterApplying1", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterApplying1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _x = Helper.toCell<double> x "x" 
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).ApplyAfterApplying1
                                                            _x.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterApplying1") 

                                               [| _x.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _x.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterApplying", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).ApplyAfterApplying
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterApplying") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyAfterSolving", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyAfterSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).ApplyAfterSolving
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyAfterSolving") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyBeforeApplying", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyBeforeApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _o = Helper.toCell<IOperator> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).ApplyBeforeApplying
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyBeforeApplying") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_applyBeforeSolving", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_applyBeforeSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _o = Helper.toCell<IOperator> o "o" 
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).ApplyBeforeSolving
                                                            _o.cell 
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".ApplyBeforeSolving") 

                                               [| _o.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _o.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="valueOnBoundary",Description = "double")>] 
         valueOnBoundary : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        ([<ExcelArgument(Name="side",Description = ".Side")>] 
         side : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _valueOnBoundary = Helper.toCell<double> valueOnBoundary "valueOnBoundary" 
                let _direction = Helper.toCell<int> direction "direction" 
                let _side = Helper.toCell<BoundaryCondition<FdmLinearOp>.Side> side "side" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmDirichletBoundary 
                                                            _mesher.cell 
                                                            _valueOnBoundary.cell 
                                                            _direction.cell 
                                                            _side.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmDirichletBoundary>) l

                let source () = Helper.sourceFold "Fun.FdmDirichletBoundary" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmDirichletBoundary> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmDirichletBoundary_setTime", Description="Create a FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDirichletBoundary",Description = "FdmDirichletBoundary")>] 
         fdmdirichletboundary : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDirichletBoundary = Helper.toCell<FdmDirichletBoundary> fdmdirichletboundary "FdmDirichletBoundary"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmDirichletBoundaryModel.Cast _FdmDirichletBoundary.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmDirichletBoundary) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmDirichletBoundary.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDirichletBoundary.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmDirichletBoundary_Range", Description="Create a range of FdmDirichletBoundary",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmDirichletBoundary_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmDirichletBoundary> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<FdmDirichletBoundary> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<FdmDirichletBoundary>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmDirichletBoundary>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
