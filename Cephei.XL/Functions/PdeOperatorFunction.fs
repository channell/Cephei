﻿(*
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

  </summary> *)
[<AutoSerializable(true)>]
module PdeOperatorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder () = withMnemonic mnemonic (Fun.PdeOperator 
                                                            _grid.cell 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeOperator>) l

                let source = Helper.sourceFold "Fun.PdeOperator" 
                                               [| _grid.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator1", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="residualTime",Description = "Reference to residualTime")>] 
         residualTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _residualTime = Helper.toCell<double> residualTime "residualTime" 
                let builder () = withMnemonic mnemonic (Fun.PdeOperator1 
                                                            _grid.cell 
                                                            _Process.cell 
                                                            _residualTime.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeOperator>) l

                let source = Helper.sourceFold "Fun.PdeOperator1" 
                                               [| _grid.source
                                               ;  _Process.source
                                               ;  _residualTime.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                ;  _Process.cell
                                ;  _residualTime.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_add", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".Add") 
                                               [| _PdeOperator.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! apply operator to a given array
    *)
    [<ExcelFunction(Name="_PdeOperator_applyTo", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".ApplyTo") 
                                               [| _PdeOperator.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_Clone", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".Clone") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_diagonal", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".Diagonal") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
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
    [<ExcelFunction(Name="_PdeOperator_identity", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".Identity") 
                                               [| _PdeOperator.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_isTimeDependent", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".IsTimeDependent") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_lowerDiagonal", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".LowerDiagonal") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_multiply", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".Multiply") 
                                               [| _PdeOperator.source
                                               ;  _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_setFirstRow", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : PdeOperator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".SetFirstRow") 
                                               [| _PdeOperator.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_setLastRow", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : PdeOperator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".SetLastRow") 
                                               [| _PdeOperator.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_setMidRow", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
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

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : PdeOperator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".SetMidRow") 
                                               [| _PdeOperator.source
                                               ;  _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_setMidRows", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : PdeOperator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".SetMidRows") 
                                               [| _PdeOperator.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_setTime", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : PdeOperator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".SetTime") 
                                               [| _PdeOperator.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_size", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeOperator.source + ".Size") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
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
    [<ExcelFunction(Name="_PdeOperator_solveFor", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".SolveFor") 
                                               [| _PdeOperator.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
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
    [<ExcelFunction(Name="_PdeOperator_SOR", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "Reference to tol")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".SOR") 
                                               [| _PdeOperator.source
                                               ;  _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_subtract", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".Subtract") 
                                               [| _PdeOperator.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeOperator_upperDiagonal", Description="Create a PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeOperator",Description = "Reference to PdeOperator")>] 
         pdeoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeOperator = Helper.toCell<PdeOperator> pdeoperator "PdeOperator"  
                let builder () = withMnemonic mnemonic ((_PdeOperator.cell :?> PdeOperatorModel).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PdeOperator.source + ".UpperDiagonal") 
                                               [| _PdeOperator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeOperator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PdeOperator_Range", Description="Create a range of PdeOperator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeOperator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PdeOperator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PdeOperator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PdeOperator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PdeOperator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PdeOperator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)