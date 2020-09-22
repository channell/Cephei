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
  The differential operator D_{-} discretizes the first derivative with the first-order formula u_{i}} x} = D_{-} u_{i}  findiff
  </summary> *)
[<AutoSerializable(true)>]
module DMinusFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DMinus", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_create
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
                let builder () = withMnemonic mnemonic (Fun.DMinus 
                                                            _gridPoints.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DMinus>) l

                let source = Helper.sourceFold "Fun.DMinus" 
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
    [<ExcelFunction(Name="_DMinus_add", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DMinus.source + ".Add") 
                                               [| _DMinus.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
        ! apply operator to a given array
    *)
    [<ExcelFunction(Name="_DMinus_applyTo", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".ApplyTo") 
                                               [| _DMinus.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_Clone", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Clone
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".Clone") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_diagonal", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".Diagonal") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_identity", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DMinus.source + ".Identity") 
                                               [| _DMinus.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_isTimeDependent", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".IsTimeDependent") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_lowerDiagonal", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".LowerDiagonal") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_multiply", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _a = Helper.toCell<double> a "a" true
                let _o = Helper.toCell<IOperator> o "o" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DMinus.source + ".Multiply") 
                                               [| _DMinus.source
                                               ;  _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_setFirstRow", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DMinus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".SetFirstRow") 
                                               [| _DMinus.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_setLastRow", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : DMinus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".SetLastRow") 
                                               [| _DMinus.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_setMidRow", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
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

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _i = Helper.toCell<int> i "i" true
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DMinus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".SetMidRow") 
                                               [| _DMinus.source
                                               ;  _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_setMidRows", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _valA = Helper.toCell<double> valA "valA" true
                let _valB = Helper.toCell<double> valB "valB" true
                let _valC = Helper.toCell<double> valC "valC" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DMinus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".SetMidRows") 
                                               [| _DMinus.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_setTime", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DMinus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DMinus.source + ".SetTime") 
                                               [| _DMinus.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_size", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DMinus.source + ".Size") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_solveFor", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".SolveFor") 
                                               [| _DMinus.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_SOR", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "Reference to tol")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let _tol = Helper.toCell<double> tol "tol" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".SOR") 
                                               [| _DMinus.source
                                               ;  _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_subtract", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DMinus.source + ".Subtract") 
                                               [| _DMinus.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_upperDiagonal", Description="Create a DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DMinus",Description = "Reference to DMinus")>] 
         dminus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DMinus = Helper.toCell<DMinus> dminus "DMinus" true 
                let builder () = withMnemonic mnemonic ((_DMinus.cell :?> DMinusModel).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DMinus.source + ".UpperDiagonal") 
                                               [| _DMinus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DMinus.cell
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
    [<ExcelFunction(Name="_DMinus_Range", Description="Create a range of DMinus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DMinus_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DMinus")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DMinus> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DMinus>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DMinus>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DMinus>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
