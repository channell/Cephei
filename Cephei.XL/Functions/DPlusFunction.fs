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
  The differential operator D_{+} discretizes the first derivative with the first-order formula u_{i}} x} = D_{+} u_{i}  findiff
  </summary> *)
[<AutoSerializable(true)>]
module DPlusFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DPlus", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _h = Helper.toCell<double> h "h" 
                let builder () = withMnemonic mnemonic (Fun.DPlus 
                                                            _gridPoints.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DPlus>) l

                let source = Helper.sourceFold "Fun.DPlus" 
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
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! duplicate Add function
    [<ExcelFunction(Name="_DPlus_add", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DPlus.source + ".Add") 
                                               [| _DPlus.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
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
    [<ExcelFunction(Name="_DPlus_applyTo", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".ApplyTo") 
                                               [| _DPlus.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_Clone", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".Clone") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_diagonal", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".Diagonal") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
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
    [<ExcelFunction(Name="_DPlus_identity", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DPlus.source + ".Identity") 
                                               [| _DPlus.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_isTimeDependent", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".IsTimeDependent") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_lowerDiagonal", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".LowerDiagonal") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_multiply", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DPlus.source + ".Multiply") 
                                               [| _DPlus.source
                                               ;  _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_setFirstRow", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".SetFirstRow") 
                                               [| _DPlus.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_setLastRow", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : DPlus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".SetLastRow") 
                                               [| _DPlus.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_setMidRow", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
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

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".SetMidRow") 
                                               [| _DPlus.source
                                               ;  _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_setMidRows", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="valA",Description = "Reference to valA")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "Reference to valB")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "Reference to valC")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : DPlus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".SetMidRows") 
                                               [| _DPlus.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_setTime", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DPlus) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DPlus.source + ".SetTime") 
                                               [| _DPlus.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_size", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DPlus.source + ".Size") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
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
    [<ExcelFunction(Name="_DPlus_solveFor", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".SolveFor") 
                                               [| _DPlus.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
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
    [<ExcelFunction(Name="_DPlus_SOR", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "Reference to tol")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".SOR") 
                                               [| _DPlus.source
                                               ;  _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_subtract", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_DPlus.source + ".Subtract") 
                                               [| _DPlus.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DPlus_upperDiagonal", Description="Create a DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DPlus",Description = "Reference to DPlus")>] 
         dplus : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DPlus = Helper.toCell<DPlus> dplus "DPlus"  
                let builder () = withMnemonic mnemonic ((_DPlus.cell :?> DPlusModel).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DPlus.source + ".UpperDiagonal") 
                                               [| _DPlus.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DPlus.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DPlus> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DPlus_Range", Description="Create a range of DPlus",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DPlus_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DPlus")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DPlus> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DPlus>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DPlus>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DPlus>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
