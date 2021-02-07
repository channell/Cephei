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
  Cms-rate coupon with digital digital call/put option
  </summary> *)
[<AutoSerializable(true)>]
module DigitalCmsCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "CmsCoupon")>] 
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

                let _underlying = Helper.toCell<CmsCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let builder (current : ICell) = (Fun.DigitalCmsCoupon 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsCoupon>) l

                let source () = Helper.sourceFold "Fun.DigitalCmsCoupon" 
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
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
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
    [<ExcelFunction(Name="_DigitalCmsCoupon1", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.DigitalCmsCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsCoupon>) l

                let source () = Helper.sourceFold "Fun.DigitalCmsCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_factory", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="underlying",Description = "CmsCoupon")>] 
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

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _underlying = Helper.toCell<CmsCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Factory") 

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
                                [| _DigitalCmsCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_callDigitalPayoff", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).CallDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallDigitalPayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_callOptionRate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).CallOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallOptionRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_callStrike", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).CallStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_convexityAdjustment", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasCall", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).HasCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasCall") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasCollar", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasCollar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).HasCollar
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasCollar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasPut", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).HasPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasPut") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_isLongCall", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isLongCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).IsLongCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsLongCall") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_isLongPut", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isLongPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).IsLongPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsLongPut") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_putDigitalPayoff", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).PutDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutDigitalPayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_putOptionRate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).PutOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutOptionRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_putStrike", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).PutStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_rate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_setPricer", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_underlying", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Underlying
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Underlying") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedAmount", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_adjustedFixing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_amount", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_dayCounter", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_fixingDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_fixingDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_gearing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_index", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_indexFixing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_isInArrears", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_price", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_pricer", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCmsCoupon> format
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_spread", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_update", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Update
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualEndDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualPeriod", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualStartDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedPeriod", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_date", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_exCouponDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_nominal", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_referencePeriodEnd", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_referencePeriodStart", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_CompareTo", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_Equals", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasOccurred", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_tradingExCoupon", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accept", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_registerWith", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_unregisterWith", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((DigitalCmsCouponModel.Cast _DigitalCmsCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalCmsCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_Range", Description="Create a range of DigitalCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalCmsCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DigitalCmsCoupon> (c)) :> ICell
                let format (i : Cephei.Cell.List<DigitalCmsCoupon>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DigitalCmsCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
