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
    [<ExcelFunction(Name="_AssetSwap", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "AssetSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="parAssetSwap",Description = "AssetSwap")>] 
         parAssetSwap : obj)
        ([<ExcelArgument(Name="bond",Description = "Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="bondCleanPrice",Description = "double")>] 
         bondCleanPrice : obj)
        ([<ExcelArgument(Name="nonParRepayment",Description = "double")>] 
         nonParRepayment : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "AssetSwap")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "AssetSwap")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="dealMaturity",Description = "AssetSwap")>] 
         dealMaturity : obj)
        ([<ExcelArgument(Name="payBondCoupon",Description = "AssetSwap")>] 
         payBondCoupon : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _parAssetSwap = Helper.toDefault<bool> parAssetSwap "parAssetSwap" true
                let _bond = Helper.toCell<Bond> bond "bond" 
                let _bondCleanPrice = Helper.toCell<double> bondCleanPrice "bondCleanPrice" 
                let _nonParRepayment = Helper.toCell<double> nonParRepayment "nonParRepayment" 
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _floatingDayCount = Helper.toDefault<DayCounter> floatingDayCount "floatingDayCount" null
                let _dealMaturity = Helper.toDefault<Date> dealMaturity "dealMaturity" null
                let _payBondCoupon = Helper.toDefault<bool> payBondCoupon "payBondCoupon" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AssetSwap 
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

                let source () = Helper.sourceFold "Fun.AssetSwap" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AssetSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap1", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "AssetSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payBondCoupon",Description = "AssetSwap")>] 
         payBondCoupon : obj)
        ([<ExcelArgument(Name="bond",Description = "Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="bondCleanPrice",Description = "double")>] 
         bondCleanPrice : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "AssetSwap")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatSchedule",Description = "AssetSwap")>] 
         floatSchedule : obj)
        ([<ExcelArgument(Name="floatingDayCount",Description = "AssetSwap")>] 
         floatingDayCount : obj)
        ([<ExcelArgument(Name="parAssetSwap",Description = "AssetSwap")>] 
         parAssetSwap : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payBondCoupon = Helper.toDefault<bool> payBondCoupon "payBondCoupon" false
                let _bond = Helper.toCell<Bond> bond "bond" 
                let _bondCleanPrice = Helper.toCell<double> bondCleanPrice "bondCleanPrice" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _floatSchedule = Helper.toDefault<Schedule> floatSchedule "floatSchedule" null
                let _floatingDayCount = Helper.toDefault<DayCounter> floatingDayCount "floatingDayCount" null
                let _parAssetSwap = Helper.toDefault<bool> parAssetSwap "parAssetSwap" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AssetSwap1 
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

                let source () = Helper.sourceFold "Fun.AssetSwap1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AssetSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap_bond", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Bond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Bond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source () = Helper.sourceFold (_AssetSwap.source + ".Bond") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AssetSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap_bondLeg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_bondLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).BondLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_AssetSwap.source + ".BondLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_cleanPrice", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_fairCleanPrice", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_fairCleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FairCleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".FairCleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_fairNonParRepayment", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_fairNonParRepayment
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FairNonParRepayment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".FairNonParRepayment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
        results
    *)
    [<ExcelFunction(Name="_AssetSwap_fairSpread", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".FairSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLeg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_floatingLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FloatingLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_AssetSwap.source + ".FloatingLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLegBPS", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_floatingLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FloatingLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".FloatingLegBPS") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_floatingLegNPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_floatingLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).FloatingLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".FloatingLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_nonParRepayment", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_nonParRepayment
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).NonParRepayment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".NonParRepayment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_AssetSwap_parSwap", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_parSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).ParSwap
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".ParSwap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_payBondCoupon", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_payBondCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).PayBondCoupon
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".PayBondCoupon") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_spread", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_endDiscounts", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    (*!!
    [<ExcelFunction(Name="_AssetSwap_engine", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_AssetSwap_isExpired", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_leg", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_AssetSwap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_AssetSwap_legBPS", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_AssetSwap_legNPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_AssetSwap_maturityDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_npvDateDiscount", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_payer", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_AssetSwap_startDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_startDiscounts", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_AssetSwap_CASH", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_errorEstimate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_NPV", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_AssetSwap_result", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_AssetSwap_setPricingEngine", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AssetSwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_AssetSwap_valuationDate", Description="Create a AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetSwap",Description = "AssetSwap")>] 
         assetswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetSwap = Helper.toCell<AssetSwap> assetswap "AssetSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetSwapModel.Cast _AssetSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AssetSwap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AssetSwap.cell
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
    [<ExcelFunction(Name="_AssetSwap_Range", Description="Create a range of AssetSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AssetSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AssetSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AssetSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AssetSwap>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
