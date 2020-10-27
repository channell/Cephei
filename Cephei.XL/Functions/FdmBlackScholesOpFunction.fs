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
module FdmBlackScholesOpFunction =

    (*
        
    *)
    (*!! duplicate add function 
    [<ExcelFunction(Name="_FdmBlackScholesOp_add", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Add
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Add") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_apply", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Apply") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_apply_direction", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_apply_direction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="direction",Description = "int or empty")>] 
         direction : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _direction = Helper.toDefault<int> direction "direction" 0
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Apply_direction
                                                            _direction.cell 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Apply_direction") 

                                               [| _direction.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _direction.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_apply_mixed", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_apply_mixed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Apply_mixed
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Apply_mixed") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_applyTo", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).ApplyTo
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".ApplyTo") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_Clone", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="bsProcess",Description = "GeneralizedBlackScholesProcess")>] 
         bsProcess : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="localVol",Description = "bool or empty")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "double")>] 
         illegalLocalVolOverwrite : obj)
        ([<ExcelArgument(Name="direction",Description = "int or empty")>] 
         direction : obj)
        ([<ExcelArgument(Name="quantoHelper",Description = "FdmQuantoHelper or empty")>] 
         quantoHelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _bsProcess = Helper.toCell<GeneralizedBlackScholesProcess> bsProcess "bsProcess" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _localVol = Helper.toDefault<bool> localVol "localVol" false
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let _direction = Helper.toDefault<int> direction "direction" 0
                let _quantoHelper = Helper.toDefault<FdmQuantoHelper> quantoHelper "quantoHelper" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmBlackScholesOp 
                                                            _mesher.cell 
                                                            _bsProcess.cell 
                                                            _strike.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                            _direction.cell 
                                                            _quantoHelper.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBlackScholesOp>) l

                let source () = Helper.sourceFold "Fun.FdmBlackScholesOp" 
                                               [| _mesher.source
                                               ;  _bsProcess.source
                                               ;  _strike.source
                                               ;  _localVol.source
                                               ;  _illegalLocalVolOverwrite.source
                                               ;  _direction.source
                                               ;  _quantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                ;  _bsProcess.cell
                                ;  _strike.cell
                                ;  _localVol.cell
                                ;  _illegalLocalVolOverwrite.cell
                                ;  _direction.cell
                                ;  _quantoHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_identity", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_identity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Identity
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Identity") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_isTimeDependent", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_isTimeDependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).IsTimeDependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".IsTimeDependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_multiply", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_multiply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="D",Description = "IOperator")>] 
         D : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _a = Helper.toCell<double> a "a" 
                let _D = Helper.toCell<IOperator> D "D" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Multiply
                                                            _a.cell 
                                                            _D.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Multiply") 

                                               [| _a.source
                                               ;  _D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _a.cell
                                ;  _D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_preconditioner", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_preconditioner
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _r = Helper.toCell<Vector> r "r" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Preconditioner
                                                            _r.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Preconditioner") 

                                               [| _r.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _r.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_setTime1", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_setTime1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).SetTime1
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : FdmBlackScholesOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".SetTime1") 

                                               [| _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_setTime", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmBlackScholesOp) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_size", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_solve_splitting", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_solve_splitting
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="direction",Description = "int or empty")>] 
         direction : obj)
        ([<ExcelArgument(Name="r",Description = "Vector")>] 
         r : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _direction = Helper.toDefault<int> direction "direction" 0
                let _r = Helper.toCell<Vector> r "r" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Solve_splitting
                                                            _direction.cell 
                                                            _r.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Solve_splitting") 

                                               [| _direction.source
                                               ;  _r.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _direction.cell
                                ;  _r.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_solveFor", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="rhs",Description = "Vector")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).SolveFor
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".SolveFor") 

                                               [| _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _rhs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_subtract", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        ([<ExcelArgument(Name="A",Description = "IOperator")>] 
         A : obj)
        ([<ExcelArgument(Name="B",Description = "IOperator")>] 
         B : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let _A = Helper.toCell<IOperator> A "A" 
                let _B = Helper.toCell<IOperator> B "B" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).Subtract
                                                            _A.cell 
                                                            _B.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IOperator>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".Subtract") 

                                               [| _A.source
                                               ;  _B.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                ;  _A.cell
                                ;  _B.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesOp_toMatrixDecomp", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_toMatrixDecomp
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).ToMatrixDecomp
                                                       ) :> ICell
                let format (i : Generic.List<ICell<SparseMatrix>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".ToMatrixDecomp") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesOp_toMatrix", Description="Create a FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_toMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesOp",Description = "FdmBlackScholesOp")>] 
         fdmblackscholesop : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesOp = Helper.toCell<FdmBlackScholesOp> fdmblackscholesop "FdmBlackScholesOp"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesOpModel.Cast _FdmBlackScholesOp.cell).ToMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source () = Helper.sourceFold (_FdmBlackScholesOp.source + ".ToMatrix") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesOp.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesOp> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmBlackScholesOp_Range", Description="Create a range of FdmBlackScholesOp",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesOp_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBlackScholesOp> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmBlackScholesOp>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmBlackScholesOp>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmBlackScholesOp>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
