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
module SecondDerivativeOpFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _direction = Helper.toCell<int> direction "direction" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SecondDerivativeOp 
                                                            _direction.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SecondDerivativeOp>) l

                let source () = Helper.sourceFold "Fun.SecondDerivativeOp" 
                                               [| _direction.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _direction.cell
                                ;  _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp1", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rhs",Description = "SecondDerivativeOp")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rhs = Helper.toCell<SecondDerivativeOp> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SecondDerivativeOp1 
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SecondDerivativeOp>) l

                let source () = Helper.sourceFold "Fun.SecondDerivativeOp1" 
                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
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
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Add1
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! duplicate ad functions 
    [<ExcelFunction(Name="_SecondDerivativeOp_add", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Add2
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Add") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_apply", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Apply") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_applyTo", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_axpyb", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_axpyb
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        ([<ExcelArgument(Name="x",Description = "TripleBandLinearOp")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "TripleBandLinearOp")>] 
         y : obj)
        ([<ExcelArgument(Name="b",Description = "Vector")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _a = Helper.toCell<Vector> a "a" 
                let _x = Helper.toCell<TripleBandLinearOp> x "x" 
                let _y = Helper.toCell<TripleBandLinearOp> y "y" 
                let _b = Helper.toCell<Vector> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Axpyb
                                                            _a.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Axpyb") 

                                               [| _a.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _a.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_Clone", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_identity", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_isTimeDependent", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_mult", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Mult
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Mult") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_multiply", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "IOperator")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Multiply") 

                                               [| _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_multR", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_multR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).MultR
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".MultR") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_setTime", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_size", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_solve_splitting", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Solve_splitting
                                                            _r.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Solve_splitting") 

                                               [| _r.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _r.cell
                                ;  _a.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_solveFor", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_subtract", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SecondDerivativeOp_swap", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : SecondDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".Swap") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                ;  _m.cell
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
    [<ExcelFunction(Name="_SecondDerivativeOp_toMatrix", Description="Create a SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SecondDerivativeOp",Description = "SecondDerivativeOp")>] 
         secondderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SecondDerivativeOp = Helper.toCell<SecondDerivativeOp> secondderivativeop "SecondDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((SecondDerivativeOpModel.Cast _SecondDerivativeOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_SecondDerivativeOp.source + ".ToMatrix") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SecondDerivativeOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SecondDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SecondDerivativeOp_Range", Description="Create a range of SecondDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SecondDerivativeOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SecondDerivativeOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SecondDerivativeOp> (c)) :> ICell
                let format (i : Cephei.Cell.List<SecondDerivativeOp>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SecondDerivativeOp>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
