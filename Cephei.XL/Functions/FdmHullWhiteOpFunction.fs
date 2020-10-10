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
module FdmHullWhiteOpFunction =

    (*
        
    *)
    (* duplicate add fucntion
    [<ExcelFunction(Name="_FdmHullWhiteOp_add", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Add") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
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
    [<ExcelFunction(Name="_FdmHullWhiteOp_apply", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Apply") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_apply_direction", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_apply_direction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _direction = Helper.toCell<int> direction "direction" 
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Apply_direction
                                                            _direction.cell 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Apply_direction") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _direction.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _direction.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_apply_mixed", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_apply_mixed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Apply_mixed
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Apply_mixed") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_applyTo", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".ApplyTo") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_Clone", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Clone") 
                                               [| _FdmHullWhiteOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteOp", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _model = Helper.toCell<HullWhite> model "model" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmHullWhiteOp 
                                                            _mesher.cell 
                                                            _model.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmHullWhiteOp>) l

                let source () = Helper.sourceFold "Fun.FdmHullWhiteOp" 
                                               [| _mesher.source
                                               ;  _model.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                ;  _model.cell
                                ;  _direction.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_identity", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Identity") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_isTimeDependent", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".IsTimeDependent") 
                                               [| _FdmHullWhiteOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteOp_multiply", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "Reference to D")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Multiply") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_preconditioner", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_preconditioner
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Preconditioner
                                                            _r.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Preconditioner") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _r.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _r.cell
                                ;  _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Time \f$t1 <= t2\f$ is required
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_setTime", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).SetTime
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : FdmHullWhiteOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".SetTime") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _t1.cell
                                ;  _t2.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteOp_setTime1", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_setTime1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).SetTime1
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmHullWhiteOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".SetTime1") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteOp_size", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Size") 
                                               [| _FdmHullWhiteOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteOp_solve_splitting", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _direction = Helper.toCell<int> direction "direction" 
                let _r = Helper.toCell<Vector> r "r" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Solve_splitting
                                                            _direction.cell 
                                                            _r.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Solve_splitting") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _direction.source
                                               ;  _r.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _direction.cell
                                ;  _r.cell
                                ;  _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_solveFor", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".SolveFor") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_subtract", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "Reference to B")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".Subtract") 
                                               [| _FdmHullWhiteOp.source
                                               ;  _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_toMatrixDecomp", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_toMatrixDecomp
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).ToMatrixDecomp
                                                       ) :> ICell
                let format (i : Generic.List<ICell<SparseMatrix>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".ToMatrixDecomp") 
                                               [| _FdmHullWhiteOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteOp_toMatrix", Description="Create a FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteOp",Description = "Reference to FdmHullWhiteOp")>] 
         fdmhullwhiteop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteOp = Helper.toCell<FdmHullWhiteOp> fdmhullwhiteop "FdmHullWhiteOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmHullWhiteOpModel.Cast _FdmHullWhiteOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_FdmHullWhiteOp.source + ".ToMatrix") 
                                               [| _FdmHullWhiteOp.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmHullWhiteOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmHullWhiteOp_Range", Description="Create a range of FdmHullWhiteOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmHullWhiteOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmHullWhiteOp")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmHullWhiteOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmHullWhiteOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmHullWhiteOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmHullWhiteOp>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
