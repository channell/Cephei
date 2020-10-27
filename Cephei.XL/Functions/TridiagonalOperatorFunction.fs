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
  to use real time-dependant algebra, you must overload the corresponding operators in the inheriting time-dependent class.  findiff
  </summary> *)
[<AutoSerializable(true)>]
module TridiagonalOperatorFunction =

    (*
        
    *)
    (*!! duplicate add function)
    [<ExcelFunction(Name="_TridiagonalOperator_add", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_add
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
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
    [<ExcelFunction(Name="_TridiagonalOperator_applyTo", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_Clone", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_diagonal", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Diagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
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
    [<ExcelFunction(Name="_TridiagonalOperator_identity", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_isTimeDependent", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_lowerDiagonal", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".LowerDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_multiply", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Multiply") 

                                               [| _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_setFirstRow", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : TridiagonalOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SetFirstRow") 

                                               [| _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_setLastRow", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : TridiagonalOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SetLastRow") 

                                               [| _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_setMidRow", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
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

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : TridiagonalOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SetMidRow") 

                                               [| _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_setMidRows", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : TridiagonalOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SetMidRows") 

                                               [| _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_setTime", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : TridiagonalOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_size", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
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
    [<ExcelFunction(Name="_TridiagonalOperator_solveFor", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
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
    [<ExcelFunction(Name="_TridiagonalOperator_SOR", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "double")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".SOR") 

                                               [| _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_subtract", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator1", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "TridiagonalOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="low",Description = "Vector")>] 
         low : obj)
        ([<ExcelArgument(Name="mid",Description = "Vector")>] 
         mid : obj)
        ([<ExcelArgument(Name="high",Description = "Vector")>] 
         high : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _low = Helper.toCell<Vector> low "low" 
                let _mid = Helper.toCell<Vector> mid "mid" 
                let _high = Helper.toCell<Vector> high "high" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TridiagonalOperator1 
                                                            _low.cell 
                                                            _mid.cell 
                                                            _high.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TridiagonalOperator>) l

                let source () = Helper.sourceFold "Fun.TridiagonalOperator1" 
                                               [| _low.source
                                               ;  _mid.source
                                               ;  _high.source
                                               |]
                let hash = Helper.hashFold 
                                [| _low.cell
                                ;  _mid.cell
                                ;  _high.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator2", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "TridiagonalOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TridiagonalOperator2
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TridiagonalOperator>) l

                let source () = Helper.sourceFold "Fun.TridiagonalOperator2" 
                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TridiagonalOperator")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.TridiagonalOperator ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TridiagonalOperator>) l

                let source () = Helper.sourceFold "Fun.TridiagonalOperator" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TridiagonalOperator_upperDiagonal", Description="Create a TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TridiagonalOperator",Description = "TridiagonalOperator")>] 
         tridiagonaloperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TridiagonalOperator = Helper.toCell<TridiagonalOperator> tridiagonaloperator "TridiagonalOperator"  
                let builder (current : ICell) = withMnemonic mnemonic ((TridiagonalOperatorModel.Cast _TridiagonalOperator.cell).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TridiagonalOperator.source + ".UpperDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TridiagonalOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TridiagonalOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TridiagonalOperator_Range", Description="Create a range of TridiagonalOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TridiagonalOperator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TridiagonalOperator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TridiagonalOperator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TridiagonalOperator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TridiagonalOperator>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
