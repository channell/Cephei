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
    [<ExcelFunction(Name="_DigitalCmsCoupon", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        ([<ExcelArgument(Name="callStrike",Description = "Reference to callStrike")>] 
         callStrike : obj)
        ([<ExcelArgument(Name="callPosition",Description = "Reference to callPosition")>] 
         callPosition : obj)
        ([<ExcelArgument(Name="isCallATMIncluded",Description = "Reference to isCallATMIncluded")>] 
         isCallATMIncluded : obj)
        ([<ExcelArgument(Name="callDigitalPayoff",Description = "Reference to callDigitalPayoff")>] 
         callDigitalPayoff : obj)
        ([<ExcelArgument(Name="putStrike",Description = "Reference to putStrike")>] 
         putStrike : obj)
        ([<ExcelArgument(Name="putPosition",Description = "Reference to putPosition")>] 
         putPosition : obj)
        ([<ExcelArgument(Name="isPutATMIncluded",Description = "Reference to isPutATMIncluded")>] 
         isPutATMIncluded : obj)
        ([<ExcelArgument(Name="putDigitalPayoff",Description = "Reference to putDigitalPayoff")>] 
         putDigitalPayoff : obj)
        ([<ExcelArgument(Name="replication",Description = "Reference to replication")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<CmsCoupon> underlying "underlying" true
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toCell<Position.Type> callPosition "callPosition" true
                let _isCallATMIncluded = Helper.toCell<bool> isCallATMIncluded "isCallATMIncluded" true
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toCell<Position.Type> putPosition "putPosition" true
                let _isPutATMIncluded = Helper.toCell<bool> isPutATMIncluded "isPutATMIncluded" true
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toCell<DigitalReplication> replication "replication" true
                let builder () = withMnemonic mnemonic (Fun.DigitalCmsCoupon 
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

                let source = Helper.sourceFold "Fun.DigitalCmsCoupon" 
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon1", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DigitalCmsCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCmsCoupon>) l

                let source = Helper.sourceFold "Fun.DigitalCmsCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_factory", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        ([<ExcelArgument(Name="callStrike",Description = "Reference to callStrike")>] 
         callStrike : obj)
        ([<ExcelArgument(Name="callPosition",Description = "Reference to callPosition")>] 
         callPosition : obj)
        ([<ExcelArgument(Name="isCallATMIncluded",Description = "Reference to isCallATMIncluded")>] 
         isCallATMIncluded : obj)
        ([<ExcelArgument(Name="callDigitalPayoff",Description = "Reference to callDigitalPayoff")>] 
         callDigitalPayoff : obj)
        ([<ExcelArgument(Name="putStrike",Description = "Reference to putStrike")>] 
         putStrike : obj)
        ([<ExcelArgument(Name="putPosition",Description = "Reference to putPosition")>] 
         putPosition : obj)
        ([<ExcelArgument(Name="isPutATMIncluded",Description = "Reference to isPutATMIncluded")>] 
         isPutATMIncluded : obj)
        ([<ExcelArgument(Name="putDigitalPayoff",Description = "Reference to putDigitalPayoff")>] 
         putDigitalPayoff : obj)
        ([<ExcelArgument(Name="replication",Description = "Reference to replication")>] 
         replication : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _underlying = Helper.toCell<CmsCoupon> underlying "underlying" true
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toCell<Position.Type> callPosition "callPosition" true
                let _isCallATMIncluded = Helper.toCell<bool> isCallATMIncluded "isCallATMIncluded" true
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toCell<Position.Type> putPosition "putPosition" true
                let _isPutATMIncluded = Helper.toCell<bool> isPutATMIncluded "isPutATMIncluded" true
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toCell<DigitalReplication> replication "replication" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Factory
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

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Factory") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _underlying.source
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_callDigitalPayoff", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).CallDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallDigitalPayoff") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! Returns the call option rate (multiplied by: nominal*accrualperiod*discount is the NPV of the option)
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_callOptionRate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).CallOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallOptionRate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        Digital inspectors
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_callStrike", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_callStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).CallStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".CallStrike") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_convexityAdjustment", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".ConvexityAdjustment") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasCall", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).HasCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasCall") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasCollar", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasCollar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).HasCollar
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasCollar") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasPut", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).HasPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasPut") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_isLongCall", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isLongCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).IsLongCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsLongCall") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_isLongPut", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isLongPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).IsLongPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsLongPut") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_putDigitalPayoff", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).PutDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutDigitalPayoff") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! Returns the put option rate (multiplied by: nominal*accrualperiod*discount is the NPV of the option)
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_putOptionRate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).PutOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutOptionRate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_putStrike", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_putStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).PutStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".PutStrike") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        Coupon interface
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_rate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Rate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_setPricer", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".SetPricer") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _pricer.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_underlying", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Underlying
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Underlying") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedAmount", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedAmount") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _d.cell
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
        ! convexity-adjusted fixing
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_adjustedFixing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AdjustedFixing") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_amount", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Amount") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_dayCounter", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".DayCounter") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! fixing days
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_fixingDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".FixingDate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! floating index
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_fixingDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".FixingDays") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_gearing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Gearing") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        properties
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_index", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Index") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! spread paid over the fixing of the underlying index ! fixing of the underlying index
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_indexFixing", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".IndexFixing") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! whether or not the coupon fixes in arrears
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_isInArrears", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".IsInArrears") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        methods
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_price", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Price") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _yts.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_pricer", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Pricer") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_spread", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Spread") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_update", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Update
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Update") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualDays") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualEndDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualEndDate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualPeriod", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualPeriod") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accrualStartDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccrualStartDate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedDays", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedDays") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _d.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_accruedPeriod", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".AccruedPeriod") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _d.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_date", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Date") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_exCouponDate", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".ExCouponDate") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_nominal", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Nominal") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_referencePeriodEnd", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".ReferencePeriodEnd") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_referencePeriodStart", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".ReferencePeriodStart") 
                                               [| _DigitalCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_CompareTo", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".CompareTo") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_Equals", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Equals") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_hasOccurred", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".HasOccurred") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_DigitalCmsCoupon_tradingExCoupon", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".TradingExCoupon") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_accept", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".Accept") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_registerWith", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".RegisterWith") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_unregisterWith", Description="Create a DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCmsCoupon",Description = "Reference to DigitalCmsCoupon")>] 
         digitalcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCmsCoupon = Helper.toCell<DigitalCmsCoupon> digitalcmscoupon "DigitalCmsCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DigitalCmsCoupon.cell :?> DigitalCmsCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCmsCoupon.source + ".UnregisterWith") 
                                               [| _DigitalCmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCmsCoupon.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_DigitalCmsCoupon_Range", Description="Create a range of DigitalCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DigitalCmsCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DigitalCmsCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalCmsCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalCmsCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalCmsCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DigitalCmsCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
