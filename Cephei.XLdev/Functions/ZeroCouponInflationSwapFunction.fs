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
  Quoted as a fixed rate K  At start: P_n(0,T) N [(1+K)^{T}-1] = P_n(0,T) N -1 where T is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  This inherits from swap and has two very simple legs: a fixed leg, from the quote (K); and an indexed leg.  At maturity the two single cashflows are swapped.  These are the notional versus the inflation-indexed notional Because the coupons are zero there are no accruals (and no coupons).  Inflation is generally available on every day, including holidays and weekends.  Hence there is a variable to state whether the observe/fix dates for inflation are adjusted or not.  The default is not to adjust.  A zero inflation swap is a simple enough instrument that the standard discounting pricing engine that works for a vanilla swap also works.  we do not need Schedules on the legs because they use one or two dates only per leg.
  </summary> *)
[<AutoSerializable(true)>]
module ZeroCouponInflationSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_adjustObservationDates", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_adjustObservationDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).AdjustObservationDates
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".AdjustObservationDates") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_dayCounter", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".DayCounter") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fairRate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FairRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FairRate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fixedCalendar", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fixedCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FixedCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FixedCalendar") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fixedConvention", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fixedConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FixedConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FixedConvention") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        ! just one cashflow (that is not a coupon) in each leg
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fixedLeg", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fixedLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FixedLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FixedLeg") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fixedLegNPV", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FixedLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FixedLegNPV") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        ! \f$ K \f$ in the above formula.
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_fixedRate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".FixedRate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_inflationCalendar", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_inflationCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).InflationCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".InflationCalendar") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_inflationConvention", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_inflationConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).InflationConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".InflationConvention") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_inflationIndex", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_inflationIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).InflationIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".InflationIndex") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        ! just one cashflow (that is not a coupon) in each leg
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_inflationLeg", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_inflationLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).InflationLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".InflationLeg") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_inflationLegNPV", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_inflationLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).InflationLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".InflationLegNPV") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_maturityDate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".MaturityDate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_nominal", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".Nominal") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_observationLag", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".ObservationLag") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_startDate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".StartDate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        ! "payer" or "receiver" refer to the inflation-indexed leg
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_type", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".TYPE") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        Generally inflation indices are available with a lag of 1month and then observed with a lag of 2-3 months depending whether they use an interpolated fixing or not.  Here, we make the swap use the interpolation of the index to avoid incompatibilities.
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="fixCalendar",Description = "Reference to fixCalendar")>] 
         fixCalendar : obj)
        ([<ExcelArgument(Name="fixConvention",Description = "Reference to fixConvention")>] 
         fixConvention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="infIndex",Description = "Reference to infIndex")>] 
         infIndex : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="adjustInfObsDates",Description = "Reference to adjustInfObsDates")>] 
         adjustInfObsDates : obj)
        ([<ExcelArgument(Name="infCalendar",Description = "Reference to infCalendar")>] 
         infCalendar : obj)
        ([<ExcelArgument(Name="infConvention",Description = "Reference to infConvention")>] 
         infConvention : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Type> Type "Type" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _maturity = Helper.toCell<Date> maturity "maturity" true
                let _fixCalendar = Helper.toCell<Calendar> fixCalendar "fixCalendar" true
                let _fixConvention = Helper.toCell<BusinessDayConvention> fixConvention "fixConvention" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" true
                let _infIndex = Helper.toCell<ZeroInflationIndex> infIndex "infIndex" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _adjustInfObsDates = Helper.toCell<bool> adjustInfObsDates "adjustInfObsDates" true
                let _infCalendar = Helper.toCell<Calendar> infCalendar "infCalendar" true
                let _infConvention = Helper.toNullable<Nullable<BusinessDayConvention>> infConvention "infConvention"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.ZeroCouponInflationSwap 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _maturity.cell 
                                                            _fixCalendar.cell 
                                                            _fixConvention.cell 
                                                            _dayCounter.cell 
                                                            _fixedRate.cell 
                                                            _infIndex.cell 
                                                            _observationLag.cell 
                                                            _adjustInfObsDates.cell 
                                                            _infCalendar.cell 
                                                            _infConvention.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroCouponInflationSwap>) l

                let source = Helper.sourceFold "Fun.ZeroCouponInflationSwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _maturity.source
                                               ;  _fixCalendar.source
                                               ;  _fixConvention.source
                                               ;  _dayCounter.source
                                               ;  _fixedRate.source
                                               ;  _infIndex.source
                                               ;  _observationLag.source
                                               ;  _adjustInfObsDates.source
                                               ;  _infCalendar.source
                                               ;  _infConvention.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _maturity.cell
                                ;  _fixCalendar.cell
                                ;  _fixConvention.cell
                                ;  _dayCounter.cell
                                ;  _fixedRate.cell
                                ;  _infIndex.cell
                                ;  _observationLag.cell
                                ;  _adjustInfObsDates.cell
                                ;  _infCalendar.cell
                                ;  _infConvention.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_endDiscounts", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".EndDiscounts") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_engine", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".Engine") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_isExpired", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".IsExpired") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_leg", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".Leg") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_legBPS", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".LegBPS") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_legNPV", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".LegNPV") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_npvDateDiscount", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".NpvDateDiscount") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_payer", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".Payer") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_startDiscounts", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".StartDiscounts") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_CASH", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".CASH") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_errorEstimate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".ErrorEstimate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_NPV", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".NPV") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_result", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".Result") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_setPricingEngine", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ZeroCouponInflationSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".SetPricingEngine") 
                                               [| _ZeroCouponInflationSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_valuationDate", Description="Create a ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwap",Description = "Reference to ZeroCouponInflationSwap")>] 
         zerocouponinflationswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwap = Helper.toCell<ZeroCouponInflationSwap> zerocouponinflationswap "ZeroCouponInflationSwap" true 
                let builder () = withMnemonic mnemonic ((_ZeroCouponInflationSwap.cell :?> ZeroCouponInflationSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwap.source + ".ValuationDate") 
                                               [| _ZeroCouponInflationSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwap.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwap_Range", Description="Create a range of ZeroCouponInflationSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroCouponInflationSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroCouponInflationSwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroCouponInflationSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroCouponInflationSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroCouponInflationSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
