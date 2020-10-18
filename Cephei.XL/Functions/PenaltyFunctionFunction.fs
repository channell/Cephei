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
(*!! generic 
(* <summary>
penalty function class for solving using a multi-dimensional solver
  </summary> *)
[<AutoSerializable(true)>]
module PenaltyFunctionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PenaltyFunction", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "PenaltyFunction")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="curve",Description = "'T")>] 
         curve : obj)
        ([<ExcelArgument(Name="initialIndex",Description = "int")>] 
         initialIndex : obj)
        ([<ExcelArgument(Name="rateHelpers",Description = "'U")>] 
         rateHelpers : obj)
        ([<ExcelArgument(Name="start",Description = "int")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "int")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _curve = Helper.toCell<'T> curve "curve" 
                let _initialIndex = Helper.toCell<int> initialIndex "initialIndex" 
                let _rateHelpers = Helper.toCell<Generic.List<BootstrapHelper<'U>>> rateHelpers "rateHelpers" 
                let _start = Helper.toCell<int> start "start" 
                let _End = Helper.toCell<int> End "End" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PenaltyFunction 
                                                            _curve.cell 
                                                            _initialIndex.cell 
                                                            _rateHelpers.cell 
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PenaltyFunction>) l

                let source () = Helper.sourceFold "Fun.PenaltyFunction" 
                                               [| _curve.source
                                               ;  _initialIndex.source
                                               ;  _rateHelpers.source
                                               ;  _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _curve.cell
                                ;  _initialIndex.cell
                                ;  _rateHelpers.cell
                                ;  _start.cell
                                ;  _End.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PenaltyFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PenaltyFunction_value", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".Value") 
                                               [| _PenaltyFunction.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
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
    [<ExcelFunction(Name="_PenaltyFunction_values", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).Values
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".Values") 
                                               [| _PenaltyFunction.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PenaltyFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Default epsilon for finite difference method :
    *)
    [<ExcelFunction(Name="_PenaltyFunction_finiteDifferenceEpsilon", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_finiteDifferenceEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).FiniteDifferenceEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".FiniteDifferenceEpsilon") 
                                               [| _PenaltyFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
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
        ! method to overload to compute grad_f, the first derivative of the cost function with respect to x
    *)
    [<ExcelFunction(Name="_PenaltyFunction_gradient", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_gradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="grad",Description = "Vector")>] 
         grad : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _grad = Helper.toCell<Vector> grad "grad" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).Gradient
                                                            _grad.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : PenaltyFunction) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".Gradient") 
                                               [| _PenaltyFunction.source
                                               ;  _grad.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
                                ;  _grad.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x
    *)
    [<ExcelFunction(Name="_PenaltyFunction_jacobian", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_jacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Matrix")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).Jacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : PenaltyFunction) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".Jacobian") 
                                               [| _PenaltyFunction.source
                                               ;  _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
                                ;  _jac.cell
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
        ! method to overload to compute grad_f, the first derivative of the cost function with respect to x and also the cost function
    *)
    [<ExcelFunction(Name="_PenaltyFunction_valueAndGradient", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_valueAndGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="grad",Description = "Vector")>] 
         grad : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _grad = Helper.toCell<Vector> grad "grad" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).ValueAndGradient
                                                            _grad.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".ValueAndGradient") 
                                               [| _PenaltyFunction.source
                                               ;  _grad.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
                                ;  _grad.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x and also the cost function
    *)
    [<ExcelFunction(Name="_PenaltyFunction_valuesAndJacobian", Description="Create a PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_valuesAndJacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PenaltyFunction",Description = "PenaltyFunction")>] 
         penaltyfunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Matrix")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PenaltyFunction = Helper.toCell<PenaltyFunction> penaltyfunction "PenaltyFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((PenaltyFunctionModel.Cast _PenaltyFunction.cell).ValuesAndJacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_PenaltyFunction.source + ".ValuesAndJacobian") 
                                               [| _PenaltyFunction.source
                                               ;  _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PenaltyFunction.cell
                                ;  _jac.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PenaltyFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PenaltyFunction_Range", Description="Create a range of PenaltyFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PenaltyFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PenaltyFunction> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PenaltyFunction>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PenaltyFunction>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PenaltyFunction>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
