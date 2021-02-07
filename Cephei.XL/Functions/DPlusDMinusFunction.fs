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
  The differential operator  D_{+}D_{-} discretizes the second derivative with the second-order formula  findiff  the correctness of the returned values is tested by checking them against numerical calculations.
  </summary> *)
[<AutoSerializable(true)>]
module DPlusDMinusFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_create
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
                let builder (current : ICell) = (Fun.DPlusDMinus 
                                                            _gridPoints.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DPlusDMinus>) l

                let source () = Helper.sourceFold "Fun.DPlusDMinus" 
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
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (* duplicate add function
    [<ExcelFunction(Name="_DPlusDMinus_add", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
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
    [<ExcelFunction(Name="_DPlusDMinus_applyTo", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_Clone", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_diagonal", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Diagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
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
    [<ExcelFunction(Name="_DPlusDMinus_identity", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_isTimeDependent", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_lowerDiagonal", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".LowerDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_multiply", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Multiply") 

                                               [| _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_setFirstRow", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlusDMinus) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SetFirstRow") 

                                               [| _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_setLastRow", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : DPlusDMinus) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SetLastRow") 

                                               [| _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_setMidRow", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
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

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlusDMinus) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SetMidRow") 

                                               [| _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_setMidRows", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlusDMinus) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SetMidRows") 

                                               [| _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_setTime", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DPlusDMinus) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_size", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
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
    [<ExcelFunction(Name="_DPlusDMinus_solveFor", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
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
    [<ExcelFunction(Name="_DPlusDMinus_SOR", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "double")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".SOR") 

                                               [| _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_subtract", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlusDMinus_upperDiagonal", Description="Create a DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlusDMinus",Description = "DPlusDMinus")>] 
         dplusdminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlusDMinus = Helper.toCell<DPlusDMinus> dplusdminus "DPlusDMinus"  
                let builder (current : ICell) = ((DPlusDMinusModel.Cast _DPlusDMinus.cell).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DPlusDMinus.source + ".UpperDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DPlusDMinus.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlusDMinus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DPlusDMinus_Range", Description="Create a range of DPlusDMinus",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DPlusDMinus_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DPlusDMinus> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DPlusDMinus> (c)) :> ICell
                let format (i : Cephei.Cell.List<DPlusDMinus>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DPlusDMinus>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
