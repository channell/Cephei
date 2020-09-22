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
module FirstDerivativeOpFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rhs = Helper.toCell<FirstDerivativeOp> rhs "rhs" true
                let builder () = withMnemonic mnemonic (Fun.FirstDerivativeOp 
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FirstDerivativeOp>) l

                let source = Helper.sourceFold "Fun.FirstDerivativeOp" 
                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rhs.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp1", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _direction = Helper.toCell<int> direction "direction" true
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" true
                let builder () = withMnemonic mnemonic (Fun.FirstDerivativeOp1 
                                                            _direction.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FirstDerivativeOp>) l

                let source = Helper.sourceFold "Fun.FirstDerivativeOp1" 
                                               [| _direction.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _direction.cell
                                ;  _mesher.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Add") 
                                               [| _FirstDerivativeOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Add1
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Add1") 
                                               [| _FirstDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _m = Helper.toCell<TripleBandLinearOp> m "m" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Add2
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Add2") 
                                               [| _FirstDerivativeOp.source
                                               ;  _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _m.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_apply", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _r = Helper.toCell<Vector> r "r" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Apply") 
                                               [| _FirstDerivativeOp.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _r.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_applyTo", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".ApplyTo") 
                                               [| _FirstDerivativeOp.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_axpyb", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_axpyb
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _a = Helper.toCell<Vector> a "a" true
                let _x = Helper.toCell<TripleBandLinearOp> x "x" true
                let _y = Helper.toCell<TripleBandLinearOp> y "y" true
                let _b = Helper.toCell<Vector> b "b" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Axpyb
                                                            _a.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Axpyb") 
                                               [| _FirstDerivativeOp.source
                                               ;  _a.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _a.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_Clone", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Clone
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Clone") 
                                               [| _FirstDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_identity", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _size = Helper.toCell<int> size "size" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Identity") 
                                               [| _FirstDerivativeOp.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_isTimeDependent", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".IsTimeDependent") 
                                               [| _FirstDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_mult", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Mult
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Mult") 
                                               [| _FirstDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_multiply", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "Reference to D")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _a = Helper.toCell<double> a "a" true
                let _D = Helper.toCell<IOperator> D "D" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Multiply") 
                                               [| _FirstDerivativeOp.source
                                               ;  _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _a.cell
                                ;  _D.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_multR", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_multR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _u = Helper.toCell<Vector> u "u" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).MultR
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".MultR") 
                                               [| _FirstDerivativeOp.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_setTime", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".SetTime") 
                                               [| _FirstDerivativeOp.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_size", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Size") 
                                               [| _FirstDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_solve_splitting", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _r = Helper.toCell<Vector> r "r" true
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Solve_splitting
                                                            _r.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Solve_splitting") 
                                               [| _FirstDerivativeOp.source
                                               ;  _r.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _r.cell
                                ;  _a.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_solveFor", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _rhs = Helper.toCell<Vector> rhs "rhs" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".SolveFor") 
                                               [| _FirstDerivativeOp.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_subtract", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _A = Helper.toCell<IOperator> A "A" true
                let _B = Helper.toCell<IOperator> B "B" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Subtract") 
                                               [| _FirstDerivativeOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_swap", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let _m = Helper.toCell<TripleBandLinearOp> m "m" true
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".Swap") 
                                               [| _FirstDerivativeOp.source
                                               ;  _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _m.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_toMatrix", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "Reference to FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp" true 
                let builder () = withMnemonic mnemonic ((_FirstDerivativeOp.cell :?> FirstDerivativeOpModel).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source = Helper.sourceFold (_FirstDerivativeOp.source + ".ToMatrix") 
                                               [| _FirstDerivativeOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_Range", Description="Create a range of FirstDerivativeOp",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FirstDerivativeOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FirstDerivativeOp")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FirstDerivativeOp> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FirstDerivativeOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FirstDerivativeOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FirstDerivativeOp>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
