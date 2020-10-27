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
    [<ExcelFunction(Name="_FirstDerivativeOp", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FirstDerivativeOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rhs",Description = "FirstDerivativeOp")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rhs = Helper.toCell<FirstDerivativeOp> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FirstDerivativeOp 
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FirstDerivativeOp>) l

                let source () = Helper.sourceFold "Fun.FirstDerivativeOp" 
                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp1", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FirstDerivativeOp")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FirstDerivativeOp1 
                                                            _direction.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FirstDerivativeOp>) l

                let source () = Helper.sourceFold "Fun.FirstDerivativeOp1" 
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
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
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
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "TripleBandLinearOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Add1
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Add") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! duplicate add function 
    [<ExcelFunction(Name="_FirstDerivativeOp_add", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "TripleBandLinearOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Add2
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Add") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
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
    [<ExcelFunction(Name="_FirstDerivativeOp_apply", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Apply") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_applyTo", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_axpyb", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_axpyb
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
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

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _a = Helper.toCell<Vector> a "a" 
                let _x = Helper.toCell<TripleBandLinearOp> x "x" 
                let _y = Helper.toCell<TripleBandLinearOp> y "y" 
                let _b = Helper.toCell<Vector> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Axpyb
                                                            _a.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Axpyb") 

                                               [| _a.source
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
    [<ExcelFunction(Name="_FirstDerivativeOp_Clone", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_identity", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_isTimeDependent", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "TripleBandLinearOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_mult", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "TripleBandLinearOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Mult
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Mult") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_multiply", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "IOperator")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Multiply") 

                                               [| _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_multR", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_multR
        ([<ExcelArgument(Name="Mnemonic",Description = "TripleBandLinearOp")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).MultR
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".MultR") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_setTime", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_size", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_solve_splitting", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Solve_splitting
                                                            _r.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Solve_splitting") 

                                               [| _r.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_solveFor", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_subtract", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "IOperator")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FirstDerivativeOp_swap", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "SparseMatrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : FirstDerivativeOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".Swap") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
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
    [<ExcelFunction(Name="_FirstDerivativeOp_toMatrix", Description="Create a FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "SparseMatrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FirstDerivativeOp",Description = "FirstDerivativeOp")>] 
         firstderivativeop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FirstDerivativeOp = Helper.toCell<FirstDerivativeOp> firstderivativeop "FirstDerivativeOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FirstDerivativeOpModel.Cast _FirstDerivativeOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_FirstDerivativeOp.source + ".ToMatrix") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FirstDerivativeOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FirstDerivativeOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FirstDerivativeOp_Range", Description="Create a range of FirstDerivativeOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FirstDerivativeOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FirstDerivativeOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FirstDerivativeOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FirstDerivativeOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FirstDerivativeOp>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
