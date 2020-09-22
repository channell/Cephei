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
  The differential operator D_{0} discretizes the first derivative with the second-order formula  findiff  the correctness of the returned values is tested by checking them against numerical calculations.
  </summary> *)
[<AutoSerializable(true)>]
module DZeroFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DZero", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let _h = Helper.toCell<double> h "h" true
                let builder () = withMnemonic mnemonic (Fun.DZero 
                                                            _gridPoints.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DZero>) l

                let source = Helper.sourceFold "Fun.DZero" 
                                               [| _gridPoints.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _gridPoints.cell
                                ;  _h.cell
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
    (*!! dupliucate add function
    [<ExcelFunction(Name="_DZero_add", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DZero.source + ".Add") 
                                               [| _DZero.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _A.cell
                                ;  _B.cell
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
            *)
    (*
        ! apply operator to a given array
    *)
    [<ExcelFunction(Name="_DZero_applyTo", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".ApplyTo") 
                                               [| _DZero.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DZero_Clone", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".Clone") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_diagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".Diagonal") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
        ! identity instance
    *)
    [<ExcelFunction(Name="_DZero_identity", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DZero.source + ".Identity") 
                                               [| _DZero.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _size.cell
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
    [<ExcelFunction(Name="_DZero_isTimeDependent", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".IsTimeDependent") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_lowerDiagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".LowerDiagonal") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_multiply", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _a = Helper.toCell<double> a "a" true
                let _o = Helper.toCell<IOperator> o "o" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DZero.source + ".Multiply") 
                                               [| _DZero.source
                                               ;  _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _a.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_DZero_setFirstRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".SetFirstRow") 
                                               [| _DZero.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _valB.cell
                                ;  _valC.cell
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
    [<ExcelFunction(Name="_DZero_setLastRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".SetLastRow") 
                                               [| _DZero.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _valA.cell
                                ;  _valB.cell
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
    [<ExcelFunction(Name="_DZero_setMidRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _i = Helper.toCell<int> i "i" true
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".SetMidRow") 
                                               [| _DZero.source
                                               ;  _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _i.cell
                                ;  _valA.cell
                                ;  _valB.cell
                                ;  _valC.cell
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
    [<ExcelFunction(Name="_DZero_setMidRows", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".SetMidRows") 
                                               [| _DZero.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _valA.cell
                                ;  _valB.cell
                                ;  _valC.cell
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
    [<ExcelFunction(Name="_DZero_setTime", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DZero.source + ".SetTime") 
                                               [| _DZero.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_size", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DZero.source + ".Size") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
        ! solve linear system for a given right-hand side
    *)
    [<ExcelFunction(Name="_DZero_solveFor", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".SolveFor") 
                                               [| _DZero.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _rhs.cell
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
        ! solve linear system with SOR approach
    *)
    [<ExcelFunction(Name="_DZero_SOR", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "Reference to tol")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let _tol = Helper.toCell<double> tol "tol" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".SOR") 
                                               [| _DZero.source
                                               ;  _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _rhs.cell
                                ;  _tol.cell
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
    [<ExcelFunction(Name="_DZero_subtract", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DZero.source + ".Subtract") 
                                               [| _DZero.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _A.cell
                                ;  _B.cell
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
    [<ExcelFunction(Name="_DZero_upperDiagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "Reference to DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero" true 
                let builder () = withMnemonic mnemonic ((_DZero.cell :?> DZeroModel).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DZero.source + ".UpperDiagonal") 
                                               [| _DZero.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_Range", Description="Create a range of DZero",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DZero_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DZero")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DZero> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DZero>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DZero>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DZero>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
