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
  for mechanics of par asset swap and market asset swap, refer to "Introduction to Asset Swap", Lehman Brothers European Fixed Income Research - January 2000, D. O'Kane  instruments  bondCleanPrice must be the (forward) price at the floatSchedule start date  fair prices are not calculated correctly when using indexed coupons.
  </summary> *)
[<AutoSerializable(true)>]
module AssetSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="parAssetSwap",Description = "Reference to parAssetSwap")>] 
         parAssetSwap : obj)
        ([<ExcelArgument(Name="bond",Description = "Reference to bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="bondCleanPrice",Description = "Reference to bondCleanPrice")>] 
         bondCleanPrice : obj)
        ([<ExcelArgument(Name="nonParRepayment",Description = "Reference to nonParRepayment")>] 
         nonParRepayment : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "Reference to floatingDayCount")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="dealMaturity",Description = "Reference to dealMaturity")>] 
         dealMaturity : obj)
        ([<ExcelArgument(Name="payBondCoupon",Description = "Reference to payBondCoupon")>] 
         payBondCoupon : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _parAssetSwap = Helper.toCell<bool> parAssetSwap "parAssetSwap" true
                let _bond = Helper.toCell<Bond> bond "bond" true
                let _bondCleanPrice = Helper.toCell<double> bondCleanPrice "bondCleanPrice" true
                let _nonParRepayment = Helper.toCell<double> nonParRepayment "nonParRepayment" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _floatingDayCount = Helper.toCell<DayCounter> floatingDayCount "floatingDayCount" true
                let _dealMaturity = Helper.toCell<Date> dealMaturity "dealMaturity" true
                let _payBondCoupon = Helper.toCell<bool> payBondCoupon "payBondCoupon" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.AssetSwap 
                                                            _parAssetSwap.cell 
                                                            _bond.cell 
                                                            _bondCleanPrice.cell 
                                                            _nonParRepayment.cell 
                                                            _gearing.cell 
                                                            _iborIndex.cell 
                                                            _spread.cell 
                                                            _floatingDayCount.cell 
                                                            _dealMaturity.cell 
                                                            _payBondCoupon.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AssetSwap>) l

                let source = Helper.sourceFold "Fun.AssetSwap" 
                                               [| _parAssetSwap.source
                                               ;  _bond.source
                                               ;  _bondCleanPrice.source
                                               ;  _nonParRepayment.source
                                               ;  _gearing.source
                                               ;  _iborIndex.source
                                               ;  _spread.source
                                               ;  _floatingDayCount.source
                                               ;  _dealMaturity.source
                                               ;  _payBondCoupon.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _parAssetSwap.cell
                                ;  _bond.cell
                                ;  _bondCleanPrice.cell
                                ;  _nonParRepayment.cell
                                ;  _gearing.cell
                                ;  _iborIndex.cell
                                ;  _spread.cell
                                ;  _floatingDayCount.cell
                                ;  _dealMaturity.cell
                                ;  _payBondCoupon.cell
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
    [<ExcelFunction(Name="_AssetSwap1", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payBondCoupon",Description = "Reference to payBondCoupon")>] 
         payBondCoupon : obj)
        ([<ExcelArgument(Name="bond",Description = "Reference to bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="bondCleanPrice",Description = "Reference to bondCleanPrice")>] 
         bondCleanPrice : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatSchedule",Description = "Reference to floatSchedule")>] 
         floatSchedule : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "Reference to floatingDayCount")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="parAssetSwap",Description = "Reference to parAssetSwap")>] 
         parAssetSwap : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payBondCoupon = Helper.toCell<bool> payBondCoupon "payBondCoupon" true
                let _bond = Helper.toCell<Bond> bond "bond" true
                let _bondCleanPrice = Helper.toCell<double> bondCleanPrice "bondCleanPrice" true
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _floatSchedule = Helper.toCell<Schedule> floatSchedule "floatSchedule" true
                let _floatingDayCount = Helper.toCell<DayCounter> floatingDayCount "floatingDayCount" true
                let _parAssetSwap = Helper.toCell<bool> parAssetSwap "parAssetSwap" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.AssetSwap1 
                                                            _payBondCoupon.cell 
                                                            _bond.cell 
                                                            _bondCleanPrice.cell 
                                                            _iborIndex.cell 
                                                            _spread.cell 
                                                            _floatSchedule.cell 
                                                            _floatingDayCount.cell 
                                                            _parAssetSwap.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AssetSwap>) l

                let source = Helper.sourceFold "Fun.AssetSwap1" 
                                               [| _payBondCoupon.source
                                               ;  _bond.source
                                               ;  _bondCleanPrice.source
                                               ;  _iborIndex.source
                                               ;  _spread.source
                                               ;  _floatSchedule.source
                                               ;  _floatingDayCount.source
                                               ;  _parAssetSwap.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payBondCoupon.cell
                                ;  _bond.cell
                                ;  _bondCleanPrice.cell
                                ;  _iborIndex.cell
                                ;  _spread.cell
                                ;  _floatSchedule.cell
                                ;  _floatingDayCount.cell
                                ;  _parAssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_bond", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Bond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold (_AssetSwap.source + ".Bond") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_bondLeg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_bondLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).BondLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AssetSwap.source + ".BondLeg") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_cleanPrice", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".CleanPrice") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_fairCleanPrice", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_fairCleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FairCleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".FairCleanPrice") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_fairNonParRepayment", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_fairNonParRepayment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FairNonParRepayment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".FairNonParRepayment") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
        results
    *)
    [<ExcelFunction(Name="_AssetSwap_fairSpread", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".FairSpread") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLeg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AssetSwap.source + ".FloatingLeg") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLegBPS", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_floatingLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FloatingLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".FloatingLegBPS") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLegNPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_floatingLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).FloatingLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".FloatingLegNPV") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_nonParRepayment", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_nonParRepayment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).NonParRepayment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".NonParRepayment") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_AssetSwap_parSwap", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_parSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).ParSwap
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".ParSwap") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_payBondCoupon", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_payBondCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).PayBondCoupon
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".PayBondCoupon") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_spread", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".Spread") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_endDiscounts", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".EndDiscounts") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    (*!!
    [<ExcelFunction(Name="_AssetSwap_engine", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".Engine") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap_isExpired", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".IsExpired") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_leg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AssetSwap.source + ".Leg") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_legBPS", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".LegBPS") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_legNPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".LegNPV") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_maturityDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".MaturityDate") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_npvDateDiscount", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".NpvDateDiscount") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_payer", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".Payer") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_startDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".StartDate") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_startDiscounts", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".StartDiscounts") 
                                               [| _AssetSwap.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_CASH", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".CASH") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_errorEstimate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".ErrorEstimate") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_NPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".NPV") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_result", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".Result") 
                                               [| _AssetSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_setPricingEngine", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AssetSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".SetPricingEngine") 
                                               [| _AssetSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_valuationDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "Reference to AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap" true 
                let builder () = withMnemonic mnemonic ((_AssetSwap.cell :?> AssetSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AssetSwap.source + ".ValuationDate") 
                                               [| _AssetSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_Range", Description="Create a range of AssetSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AssetSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AssetSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AssetSwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AssetSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AssetSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AssetSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
