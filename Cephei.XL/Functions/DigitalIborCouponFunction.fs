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
                let builder () = withMnemonic mnemonic (Fun.DigitalIborCoupon1 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborCoupon>) l

                let source = Helper.sourceFold "Fun.DigitalIborCoupon1" 
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.DigitalIborCoupon ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalIborCoupon>) l

                let source = Helper.sourceFold "Fun.DigitalIborCoupon" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
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

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
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
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Factory
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

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Factory") 
                                               [| _DigitalIborCoupon.source
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
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".CallDigitalPayoff") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_callOptionRate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_callOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".CallOptionRate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_callStrike", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_callStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CallStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".CallStrike") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_convexityAdjustment", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".ConvexityAdjustment") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasCall", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".HasCall") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasCollar", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasCollar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasCollar
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".HasCollar") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasPut", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".HasPut") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_isLongCall", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isLongCall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsLongCall
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".IsLongCall") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_isLongPut", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isLongPut
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsLongPut
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".IsLongPut") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_putDigitalPayoff", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putDigitalPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutDigitalPayoff
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".PutDigitalPayoff") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_putOptionRate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putOptionRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutOptionRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".PutOptionRate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_putStrike", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_putStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).PutStrike
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".PutStrike") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_rate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Rate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_setPricer", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".SetPricer") 
                                               [| _DigitalIborCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_underlying", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Underlying
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Underlying") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedAmount") 
                                               [| _DigitalIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_adjustedFixing", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AdjustedFixing") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_amount", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Amount") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_dayCounter", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".DayCounter") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".FixingDate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_fixingDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".FixingDays") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_gearing", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Gearing") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_index", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Index") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".IndexFixing") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_isInArrears", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".IsInArrears") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_price", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Price") 
                                               [| _DigitalIborCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_pricer", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Pricer") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Spread") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_update", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Update
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Update") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualDays") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualEndDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualEndDate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualPeriod", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualPeriod") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accrualStartDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccrualStartDate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accruedDays", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedDays") 
                                               [| _DigitalIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accruedPeriod", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".AccruedPeriod") 
                                               [| _DigitalIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_date", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Date") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_exCouponDate", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".ExCouponDate") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_nominal", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Nominal") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_referencePeriodEnd", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".ReferencePeriodEnd") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_referencePeriodStart", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".ReferencePeriodStart") 
                                               [| _DigitalIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_CompareTo", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".CompareTo") 
                                               [| _DigitalIborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_Equals", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Equals") 
                                               [| _DigitalIborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_hasOccurred", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".HasOccurred") 
                                               [| _DigitalIborCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_tradingExCoupon", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".TradingExCoupon") 
                                               [| _DigitalIborCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_accept", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".Accept") 
                                               [| _DigitalIborCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_registerWith", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".RegisterWith") 
                                               [| _DigitalIborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_unregisterWith", Description="Create a DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalIborCoupon",Description = "Reference to DigitalIborCoupon")>] 
         digitaliborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalIborCoupon = Helper.toCell<DigitalIborCoupon> digitaliborcoupon "DigitalIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((DigitalIborCouponModel.Cast _DigitalIborCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DigitalIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DigitalIborCoupon.source + ".UnregisterWith") 
                                               [| _DigitalIborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalIborCoupon.cell
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
    [<ExcelFunction(Name="_DigitalIborCoupon_Range", Description="Create a range of DigitalIborCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalIborCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DigitalIborCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalIborCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalIborCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalIborCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DigitalIborCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
