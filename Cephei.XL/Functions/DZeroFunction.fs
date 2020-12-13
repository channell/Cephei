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
    [<ExcelFunction(Name="_DZero", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="h",Description = "double")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _h = Helper.toCell<double> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DZero 
                                                            _gridPoints.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DZero>) l

                let source () = Helper.sourceFold "Fun.DZero" 
                                               [| _gridPoints.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _gridPoints.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
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
    [<ExcelFunction(Name="_DZero_add", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DZero.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
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
    [<ExcelFunction(Name="_DZero_applyTo", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_Clone", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_diagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".Diagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
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
    [<ExcelFunction(Name="_DZero_identity", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DZero.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_isTimeDependent", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    [<ExcelFunction(Name="_DZero_lowerDiagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".LowerDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_multiply", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DZero.source + ".Multiply") 

                                               [| _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_setFirstRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".SetFirstRow") 

                                               [| _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _valB.cell
                                ;  _valC.cell
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
    [<ExcelFunction(Name="_DZero_setLastRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".SetLastRow") 

                                               [| _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _valA.cell
                                ;  _valB.cell
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
    [<ExcelFunction(Name="_DZero_setMidRow", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".SetMidRow") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_DZero_setMidRows", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".SetMidRows") 

                                               [| _valA.source
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
    [<ExcelFunction(Name="_DZero_setTime", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DZero) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DZero.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_size", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DZero.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
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
        ! solve linear system for a given right-hand side
    *)
    [<ExcelFunction(Name="_DZero_solveFor", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
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
    [<ExcelFunction(Name="_DZero_SOR", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "double")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".SOR") 

                                               [| _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_subtract", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DZero.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DZero_upperDiagonal", Description="Create a DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DZero",Description = "DZero")>] 
         dzero : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DZero = Helper.toCell<DZero> dzero "DZero"  
                let builder (current : ICell) = withMnemonic mnemonic ((DZeroModel.Cast _DZero.cell).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DZero.source + ".UpperDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DZero.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DZero> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DZero_Range", Description="Create a range of DZero",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DZero_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DZero> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DZero> (c)) :> ICell
                let format (i : Cephei.Cell.List<DZero>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DZero>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
