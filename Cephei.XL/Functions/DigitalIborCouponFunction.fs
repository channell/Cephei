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
  Ibor rate coupon with digital digital call/put option
  </summary> *)
[<AutoSerializable(true)>]
module DigitalIborCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon1", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "IborCoupon")>] 
         underlying : obj)
        ([<ExcelArgument(Name="callStrike",Description = "double")>] 
         callStrike : obj)
        ([<ExcelArgument(Name="callPosition",Description = "Position.Type: Long, Short or empty")>] 
         callPosition : obj)
        ([<ExcelArgument(Name="isCallATMIncluded",Description = "bool or empty")>] 
         isCallATMIncluded : obj)
        ([<ExcelArgument(Name="callDigitalPayoff",Description = "double")>] 
         callDigitalPayoff : obj)
        ([<ExcelArgument(Name="putStrike",Description = "double")>] 
         putStrike : obj)
        ([<ExcelArgument(Name="putPosition",Description = "Position.Type: Long, Short or empty")>] 
         putPosition : obj)
        ([<ExcelArgument(Name="isPutATMIncluded",Description = "bool or empty")>] 
         isPutATMIncluded : obj)
        ([<ExcelArgument(Name="putDigitalPayoff",Description = "double")>] 
         putDigitalPayoff : obj)
        ([<ExcelArgument(Name="replication",Description = "DigitalReplication or empty")>] 
         replication : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<IborCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.DigitalIborCoupon1 
                                                            _underlying.cell 
                                                            _callStrike.cell 
                                                            _callPosition.cell 
                                                            _isCallATMIncluded.cell 
                                                            _callDigitalPayoff.cell 
                                                            _putStrike.cell 
                                                            _putPosition.cell 
                                                            _isPutATMIncluded.cell 
                                                            _putDigitalPayoff.cell 
                                                            _replication.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborCoupon>) l

                let source () = Helper.sourceFold "Fun.DigitalIborCoupon1" 
                                               [| _underlying.source
                                               ;  _callStrike.source
                                               ;  _callPosition.source
                                               ;  _isCallATMIncluded.source
                                               ;  _callDigitalPayoff.source
                                               ;  _putStrike.source
                                               ;  _putPosition.source
                                               ;  _isPutATMIncluded.source
                                               ;  _putDigitalPayoff.source
                                               ;  _replication.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlying.cell
                                ;  _callStrike.cell
                                ;  _callPosition.cell
                                ;  _isCallATMIncluded.cell
                                ;  _callDigitalPayoff.cell
                                ;  _putStrike.cell
                                ;  _putPosition.cell
                                ;  _isPutATMIncluded.cell
                                ;  _putDigitalPayoff.cell
                                ;  _replication.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.DigitalIborCoupon 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborCoupon>) l

                let source () = Helper.sourceFold "Fun.DigitalIborCoupon" 
                                               [|_evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_factory", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="underlying",Description = "IborCoupon")>] 
         underlying : obj)
        ([<ExcelArgument(Name="callStrike",Description = "double")>] 
         callStrike : obj)
        ([<ExcelArgument(Name="callPosition",Description = "Position.Type: Long, Short or empty")>] 
         callPosition : obj)
        ([<ExcelArgument(Name="isCallATMIncluded",Description = "bool or empty")>] 
         isCallATMIncluded : obj)
        ([<ExcelArgument(Name="callDigitalPayoff",Description = "double")>] 
         callDigitalPayoff : obj)
        ([<ExcelArgument(Name="putStrike",Description = "double")>] 
         putStrike : obj)
        ([<ExcelArgument(Name="putPosition",Description = "Position.Type: Long, Short or empty")>] 
         putPosition : obj)
        ([<ExcelArgument(Name="isPutATMIncluded",Description = "bool or empty")>] 
         isPutATMIncluded : obj)
        ([<ExcelArgument(Name="putDigitalPayoff",Description = "double")>] 
         putDigitalPayoff : obj)
        ([<ExcelArgument(Name="replication",Description = "DigitalReplication or empty")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _underlying = Helper.toCell<IborCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Factory
                                                            _underlying.cell 
                                                            _callStrike.cell 
                                                            _callPosition.cell 
                                                            _isCallATMIncluded.cell 
                                                            _callDigitalPayoff.cell 
                                                            _putStrike.cell 
                                                            _putPosition.cell 
                                                            _isPutATMIncluded.cell 
                                                            _putDigitalPayoff.cell 
                                                            _replication.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Factory") 

                                               [| _underlying.source
                                               ;  _callStrike.source
                                               ;  _callPosition.source
                                               ;  _isCallATMIncluded.source
                                               ;  _callDigitalPayoff.source
                                               ;  _putStrike.source
                                               ;  _putPosition.source
                                               ;  _isPutATMIncluded.source
                                               ;  _putDigitalPayoff.source
                                               ;  _replication.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _underlying.cell
                                ;  _callStrike.cell
                                ;  _callPosition.cell
                                ;  _isCallATMIncluded.cell
                                ;  _callDigitalPayoff.cell
                                ;  _putStrike.cell
                                ;  _putPosition.cell
                                ;  _isPutATMIncluded.cell
                                ;  _putDigitalPayoff.cell
                                ;  _replication.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_callDigitalPayoff", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_callDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".CallDigitalPayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! Returns the call option rate (multiplied by: nominal*accrualperiod*discount is the NPV of the option)
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_callOptionRate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_callOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".CallOptionRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        Digital inspectors
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_callStrike", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_callStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".CallStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_convexityAdjustment", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasCall", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".HasCall") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasCollar", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasCollar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasCollar
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".HasCollar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasPut", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".HasPut") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_isLongCall", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isLongCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsLongCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".IsLongCall") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_isLongPut", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isLongPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsLongPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".IsLongPut") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_putDigitalPayoff", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".PutDigitalPayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! Returns the put option rate (multiplied by: nominal*accrualperiod*discount is the NPV of the option)
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_putOptionRate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".PutOptionRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_putStrike", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".PutStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        Coupon interface
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_rate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_setPricer", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _pricer.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_underlying", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Underlying
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Underlying") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accruedAmount", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _d.cell
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
        ! convexity-adjusted fixing
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_adjustedFixing", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_amount", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_dayCounter", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixing days
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_fixingDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! floating index
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_fixingDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_gearing", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        properties
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_index", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! spread paid over the fixing of the underlying index ! fixing of the underlying index
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_indexFixing", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! whether or not the coupon fixes in arrears
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_isInArrears", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        methods
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_price", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _yts.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_pricer", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_spread", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_update", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Update
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualEndDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualPeriod", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualStartDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accruedDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _d.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_accruedPeriod", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _d.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_date", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_exCouponDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_nominal", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_referencePeriodEnd", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_referencePeriodStart", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_CompareTo", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_Equals", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasOccurred", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_DigitalIborCoupon_tradingExCoupon", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accept", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_registerWith", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_unregisterWith", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toModelReference<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalIborCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_Range", Description="Create a range of DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalIborCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DigitalIborCoupon> (c)) :> ICell
                let format (i : Cephei.Cell.List<DigitalIborCoupon>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DigitalIborCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
