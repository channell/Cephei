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
  Digital-payoff coupon   Implementation of a floating-rate coupon with digital call/put option. Payoffs: - Coupon with cash-or-nothing Digital Call rate + csi * payoffRate * Heaviside(rate-strike) - Coupon with cash-or-nothing Digital Put rate + csi * payoffRate * Heaviside(strike-rate) where csi=+1 or csi=-1. - Coupon with asset-or-nothing Digital Call rate + csi * rate * Heaviside(rate-strike) - Coupon with asset-or-nothing Digital Put rate + csi * rate * Heaviside(strike-rate) where csi=+1 or csi=-1. The evaluation of the coupon is made using the call/put spread replication method.    instruments  - the correctness of the returned value in case of Asset-or-nothing embedded option is tested by pricing the digital option with Cox-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Asset-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of Cash-or-nothing embedded option is tested by pricing the digital option with Reiner-Rubinstein formula. - the correctness of the returned value in case of deep-in-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value in case of deep-out-of-the-money Cash-or-nothing embedded option is tested vs the expected values of coupon and option. - the correctness of the returned value is tested checking the correctness of the call-put parity relation. - the correctness of the returned value is tested by the relationship between prices in case of different replication types.
  </summary> *)
[<AutoSerializable(true)>]
module DigitalCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCoupon_callDigitalPayoff", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_callDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).CallDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".CallDigitalPayoff") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_callOptionRate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_callOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).CallOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".CallOptionRate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_callStrike", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_callStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).CallStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".CallStrike") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_convexityAdjustment", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".ConvexityAdjustment") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
        ! Constructors ! general constructor
    *)
    [<ExcelFunction(Name="_DigitalCoupon", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_create
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

                let _underlying = Helper.toCell<FloatingRateCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let builder () = withMnemonic mnemonic (Fun.DigitalCoupon 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCoupon>) l

                let source = Helper.sourceFold "Fun.DigitalCoupon" 
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
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
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
    [<ExcelFunction(Name="_DigitalCoupon1", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DigitalCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalCoupon>) l

                let source = Helper.sourceFold "Fun.DigitalCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
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
    [<ExcelFunction(Name="_DigitalCoupon_factory", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
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

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _underlying = Helper.toCell<FloatingRateCoupon> underlying "underlying" 
                let _callStrike = Helper.toNullable<double> callStrike "callStrike"
                let _callPosition = Helper.toDefault<Position.Type> callPosition "callPosition" Position.Type.Long
                let _isCallATMIncluded = Helper.toDefault<bool> isCallATMIncluded "isCallATMIncluded" false
                let _callDigitalPayoff = Helper.toNullable<double> callDigitalPayoff "callDigitalPayoff"
                let _putStrike = Helper.toNullable<double> putStrike "putStrike"
                let _putPosition = Helper.toDefault<Position.Type> putPosition "putPosition" Position.Type.Long
                let _isPutATMIncluded = Helper.toDefault<bool> isPutATMIncluded "isPutATMIncluded" false
                let _putDigitalPayoff = Helper.toNullable<double> putDigitalPayoff "putDigitalPayoff"
                let _replication = Helper.toDefault<DigitalReplication> replication "replication" null
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Factory
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

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Factory") 
                                               [| _DigitalCoupon.source
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
                                [| _DigitalCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCoupon_hasCall", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_hasCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).HasCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".HasCall") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_hasCollar", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_hasCollar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).HasCollar
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".HasCollar") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_hasPut", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_hasPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).HasPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".HasPut") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_isLongCall", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_isLongCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).IsLongCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".IsLongCall") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_isLongPut", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_isLongPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).IsLongPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".IsLongPut") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_putDigitalPayoff", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_putDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).PutDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".PutDigitalPayoff") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_putOptionRate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_putOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).PutOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".PutOptionRate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_putStrike", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_putStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).PutStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".PutStrike") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_rate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Rate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_setPricer", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : DigitalCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".SetPricer") 
                                               [| _DigitalCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_underlying", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Underlying
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Underlying") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalCoupon_accruedAmount", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccruedAmount") 
                                               [| _DigitalCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_adjustedFixing", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AdjustedFixing") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_amount", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Amount") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_dayCounter", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DigitalCoupon.source + ".DayCounter") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
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
    [<ExcelFunction(Name="_DigitalCoupon_fixingDate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".FixingDate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_fixingDays", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".FixingDays") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_gearing", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Gearing") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_index", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Index") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
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
    [<ExcelFunction(Name="_DigitalCoupon_indexFixing", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".IndexFixing") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_isInArrears", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".IsInArrears") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_price", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Price") 
                                               [| _DigitalCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_pricer", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Pricer") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalCoupon> format
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
    [<ExcelFunction(Name="_DigitalCoupon_spread", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Spread") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_update", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Update
                                                       ) :> ICell
                let format (o : DigitalCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Update") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accrualDays", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccrualDays") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accrualEndDate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccrualEndDate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accrualPeriod", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccrualPeriod") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accrualStartDate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccrualStartDate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accruedDays", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccruedDays") 
                                               [| _DigitalCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accruedPeriod", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".AccruedPeriod") 
                                               [| _DigitalCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_date", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Date") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_exCouponDate", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".ExCouponDate") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_nominal", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Nominal") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_referencePeriodEnd", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".ReferencePeriodEnd") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_referencePeriodStart", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".ReferencePeriodStart") 
                                               [| _DigitalCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_CompareTo", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".CompareTo") 
                                               [| _DigitalCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_Equals", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Equals") 
                                               [| _DigitalCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_hasOccurred", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".HasOccurred") 
                                               [| _DigitalCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_tradingExCoupon", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".TradingExCoupon") 
                                               [| _DigitalCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_accept", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DigitalCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".Accept") 
                                               [| _DigitalCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_registerWith", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".RegisterWith") 
                                               [| _DigitalCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_unregisterWith", Description="Create a DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalCoupon",Description = "Reference to DigitalCoupon")>] 
         digitalcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalCoupon = Helper.toCell<DigitalCoupon> digitalcoupon "DigitalCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DigitalCouponModel.Cast _DigitalCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalCoupon.source + ".UnregisterWith") 
                                               [| _DigitalCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalCoupon.cell
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
    [<ExcelFunction(Name="_DigitalCoupon_Range", Description="Create a range of DigitalCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DigitalCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DigitalCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
