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
  findiff
  </summary> *)
[<AutoSerializable(true)>]
module BSMOperatorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator1", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Vector")>] 
         grid : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="residualTime",Description = "double")>] 
         residualTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _residualTime = Helper.toCell<double> residualTime "residualTime" 
                let builder (current : ICell) = (Fun.BSMOperator1 
                                                            _grid.cell 
                                                            _Process.cell 
                                                            _residualTime.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BSMOperator>) l

                let source () = Helper.sourceFold "Fun.BSMOperator1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator2", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.BSMOperator2 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BSMOperator>) l

                let source () = Helper.sourceFold "Fun.BSMOperator2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="q",Description = "double")>] 
         q : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _dx = Helper.toCell<double> dx "dx" 
                let _r = Helper.toCell<double> r "r" 
                let _q = Helper.toCell<double> q "q" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder (current : ICell) = (Fun.BSMOperator
                                                            _size.cell 
                                                            _dx.cell 
                                                            _r.cell 
                                                            _q.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BSMOperator>) l

                let source () = Helper.sourceFold "Fun.BSMOperator" 
                                               [| _size.source
                                               ;  _dx.source
                                               ;  _r.source
                                               ;  _q.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _dx.cell
                                ;  _r.cell
                                ;  _q.cell
                                ;  _sigma.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! name clash with Dictionary Add method 
    [<ExcelFunction(Name="_BSMOperator_add", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
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
    [<ExcelFunction(Name="_BSMOperator_applyTo", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_Clone", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_diagonal", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".Diagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
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
    [<ExcelFunction(Name="_BSMOperator_identity", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_isTimeDependent", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_lowerDiagonal", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_lowerDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).LowerDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".LowerDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_multiply", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="o",Description = "IOperator")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _a = Helper.toCell<double> a "a" 
                let _o = Helper.toCell<IOperator> o "o" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Multiply
                                                            _a.cell 
                                                            _o.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".Multiply") 

                                               [| _a.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _a.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_setFirstRow", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_setFirstRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SetFirstRow
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : BSMOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".SetFirstRow") 

                                               [| _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_setLastRow", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_setLastRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SetLastRow
                                                            _valA.cell 
                                                            _valB.cell 
                                                       ) :> ICell
                let format (o : BSMOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".SetLastRow") 

                                               [| _valA.source
                                               ;  _valB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_setMidRow", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_setMidRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
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

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _i = Helper.toCell<int> i "i" 
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SetMidRow
                                                            _i.cell 
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : BSMOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".SetMidRow") 

                                               [| _i.source
                                               ;  _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_setMidRows", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_setMidRows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="valA",Description = "double")>] 
         valA : obj)
        ([<ExcelArgument(Name="valB",Description = "double")>] 
         valB : obj)
        ([<ExcelArgument(Name="valC",Description = "double")>] 
         valC : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _valA = Helper.toCell<double> valA "valA" 
                let _valB = Helper.toCell<double> valB "valB" 
                let _valC = Helper.toCell<double> valC "valC" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SetMidRows
                                                            _valA.cell 
                                                            _valB.cell 
                                                            _valC.cell 
                                                       ) :> ICell
                let format (o : BSMOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".SetMidRows") 

                                               [| _valA.source
                                               ;  _valB.source
                                               ;  _valC.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_setTime", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BSMOperator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_size", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BSMOperator.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
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
    [<ExcelFunction(Name="_BSMOperator_solveFor", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
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
    [<ExcelFunction(Name="_BSMOperator_SOR", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_SOR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        ([<ExcelArgument(Name="tol",Description = "double")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).SOR
                                                            _rhs.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".SOR") 

                                               [| _rhs.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _rhs.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_subtract", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BSMOperator_upperDiagonal", Description="Create a BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_upperDiagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BSMOperator",Description = "BSMOperator")>] 
         bsmoperator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BSMOperator = Helper.toCell<BSMOperator> bsmoperator "BSMOperator"  
                let builder (current : ICell) = ((BSMOperatorModel.Cast _BSMOperator.cell).UpperDiagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BSMOperator.source + ".UpperDiagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BSMOperator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BSMOperator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BSMOperator_Range", Description="Create a range of BSMOperator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BSMOperator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BSMOperator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BSMOperator> (c)) :> ICell
                let format (i : Cephei.Cell.List<BSMOperator>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BSMOperator>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
