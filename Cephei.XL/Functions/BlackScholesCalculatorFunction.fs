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
  Black-Scholes 1973 calculator class
  </summary> *)
[<AutoSerializable(true)>]
module BlackScholesCalculatorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="growth",Description = "Reference to growth")>] 
         growth : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _spot = Helper.toCell<double> spot "spot" 
                let _growth = Helper.toCell<double> growth "growth" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic (Fun.BlackScholesCalculator 
                                                            _payoff.cell 
                                                            _spot.cell 
                                                            _growth.cell 
                                                            _stdDev.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesCalculator>) l

                let source = Helper.sourceFold "Fun.BlackScholesCalculator" 
                                               [| _payoff.source
                                               ;  _spot.source
                                               ;  _growth.source
                                               ;  _stdDev.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _spot.cell
                                ;  _growth.cell
                                ;  _stdDev.cell
                                ;  _discount.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesCalculator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Sensitivity to change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_delta", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Delta") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity in percent to a percent change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_elasticity", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Elasticity") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Second order derivative with respect to change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_gamma", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Gamma") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity to time to maturity.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_theta", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Theta
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Theta") 
                                               [| _BlackScholesCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
                                ;  _maturity.cell
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
        ! Sensitivity to time to maturity per day (assuming 365 day in a year).
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_thetaPerDay", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).ThetaPerDay
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".ThetaPerDay") 
                                               [| _BlackScholesCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
                                ;  _maturity.cell
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
    [<ExcelFunction(Name="_BlackScholesCalculator_alpha", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Alpha
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Alpha") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
    [<ExcelFunction(Name="_BlackScholesCalculator_beta", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Beta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Beta") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity to change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_deltaForward", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".DeltaForward") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity to dividend/growth rate.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_dividendRho", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).DividendRho
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".DividendRho") 
                                               [| _BlackScholesCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
                                ;  _maturity.cell
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
        ! Sensitivity in percent to a percent change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_elasticityForward", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_elasticityForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).ElasticityForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".ElasticityForward") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Second order derivative with respect to change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_gammaForward", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_gammaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).GammaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".GammaForward") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Probability of being in the money in the asset martingale measure, i.e. N(d1). It is a risk-neutral probability, not the real world one.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_itmAssetProbability", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_itmAssetProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).ItmAssetProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".ItmAssetProbability") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Probability of being in the money in the bond martingale measure, i.e. N(d2). It is a risk-neutral probability, not the real world one.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_itmCashProbability", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".ItmCashProbability") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity to discounting rate.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_rho", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Rho
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Rho") 
                                               [| _BlackScholesCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
                                ;  _maturity.cell
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
        ! Sensitivity to strike.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_strikeSensitivity", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".StrikeSensitivity") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
    [<ExcelFunction(Name="_BlackScholesCalculator_value", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Value") 
                                               [| _BlackScholesCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
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
        ! Sensitivity to volatility.
    *)
    [<ExcelFunction(Name="_BlackScholesCalculator_vega", Description="Create a BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesCalculator",Description = "Reference to BlackScholesCalculator")>] 
         blackscholescalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesCalculator = Helper.toCell<BlackScholesCalculator> blackscholescalculator "BlackScholesCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((BlackScholesCalculatorModel.Cast _BlackScholesCalculator.cell).Vega
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesCalculator.source + ".Vega") 
                                               [| _BlackScholesCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesCalculator.cell
                                ;  _maturity.cell
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
    [<ExcelFunction(Name="_BlackScholesCalculator_Range", Description="Create a range of BlackScholesCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackScholesCalculator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackScholesCalculator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackScholesCalculator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackScholesCalculator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackScholesCalculator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackScholesCalculator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
