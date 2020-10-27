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
module TripleBandLinearOpFunction =

    (*
        
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_TripleBandLinearOp_add", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
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
    [<ExcelFunction(Name="_TripleBandLinearOp_add", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Add1
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Add") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
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
    [<ExcelFunction(Name="_TripleBandLinearOp_add", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Add2
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Add") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
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
    [<ExcelFunction(Name="_TripleBandLinearOp_apply", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Apply") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_applyTo", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_axpyb", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_axpyb
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
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

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _a = Helper.toCell<Vector> a "a" 
                let _x = Helper.toCell<TripleBandLinearOp> x "x" 
                let _y = Helper.toCell<TripleBandLinearOp> y "y" 
                let _b = Helper.toCell<Vector> b "b"
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Axpyb
                                                            _a.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : TripleBandLinearOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Axpyb") 

                                               [| _a.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_Clone", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_identity", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_isTimeDependent", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_mult", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_mult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Mult
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Mult") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_multiply", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "IOperator")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Multiply") 

                                               [| _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_multR", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_multR
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="u",Description = "Vector")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).MultR
                                                            _u.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".MultR") 

                                               [| _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _u.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_setTime", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : TripleBandLinearOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_size", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_solve_splitting", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double or empty")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toDefault<double> b "b" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Solve_splitting
                                                            _r.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Solve_splitting") 

                                               [| _r.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _r.cell
                                ;  _a.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_solveFor", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_subtract", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp_swap", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).Swap
                                                            _m.cell 
                                                       ) :> ICell
                let format (o : TripleBandLinearOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".Swap") 

                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
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
    [<ExcelFunction(Name="_TripleBandLinearOp_toMatrix", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TripleBandLinearOp",Description = "TripleBandLinearOp")>] 
         triplebandlinearop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TripleBandLinearOp = Helper.toCell<TripleBandLinearOp> triplebandlinearop "TripleBandLinearOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((TripleBandLinearOpModel.Cast _TripleBandLinearOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_TripleBandLinearOp.source + ".ToMatrix") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TripleBandLinearOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "TripleBandLinearOp")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<TripleBandLinearOp> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TripleBandLinearOp 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold "Fun.TripleBandLinearOp" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TripleBandLinearOp1", Description="Create a TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_create1
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TripleBandLinearOp1 
                                                            _direction.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TripleBandLinearOp>) l

                let source () = Helper.sourceFold "Fun.TripleBandLinearOp1" 
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
                    ; subscriber = Helper.subscriberModel<TripleBandLinearOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TripleBandLinearOp_Range", Description="Create a range of TripleBandLinearOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TripleBandLinearOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TripleBandLinearOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TripleBandLinearOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TripleBandLinearOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TripleBandLinearOp>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
