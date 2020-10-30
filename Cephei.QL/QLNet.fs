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
module Cephei.QL.Fun  

open Cephei.QL
open QLNet

let Delay<'t>                                   (r : Cephei.Cell.Generic.ICell<'t>) l
                                                = new Delay<'t>(r, l)

let Abcd                                        a b c d aIsFixed bIsFixed cIsFixed dIsFixed vegaWeighted endCriteria optMethod 
                                                = new AbcdModel (a, b, c, d, aIsFixed, bIsFixed, cIsFixed, dIsFixed, vegaWeighted, endCriteria, optMethod)
let AbcdCalibration                             ()
                                                = new AbcdCalibrationModel ()
let AbcdCalibration1                            t blackVols aGuess bGuess cGuess dGuess aIsFixed bIsFixed cIsFixed dIsFixed vegaWeighted endCriteria Method 
                                                = new AbcdCalibrationModel1 (t, blackVols, aGuess, bGuess, cGuess, dGuess, aIsFixed, bIsFixed, cIsFixed, dIsFixed, vegaWeighted, endCriteria, Method)
let AbcdCoeffHolder                             a b c d aIsFixed bIsFixed cIsFixed dIsFixed 
                                                = new AbcdCoeffHolderModel (a, b, c, d, aIsFixed, bIsFixed, cIsFixed, dIsFixed)
let AbcdFunction                                a b c d 
                                                = new AbcdFunctionModel (a, b, c, d)
let AbcdInterpolation                           xBegin size yBegin a b c d aIsFixed bIsFixed cIsFixed dIsFixed vegaWeighted endCriteria optMethod 
                                                = new AbcdInterpolationModel (xBegin, size, yBegin, a, b, c, d, aIsFixed, bIsFixed, cIsFixed, dIsFixed, vegaWeighted, endCriteria, optMethod)
let AbcdMathFunction                            abcd 
                                                = new AbcdMathFunctionModel (abcd)
let AbcdMathFunction1                           a b c d 
                                                = new AbcdMathFunctionModel1 (a, b, c, d)
let AbcdSquared                                 a b c d T S 
                                                = new AbcdSquaredModel (a, b, c, d, T, S)
let Actual360                                   c 
                                                = new Actual360Model (c)
let Actual365Fixed                              ()
                                                = new Actual365FixedModel ()
let Actual365NoLeap                             ()
                                                = new Actual365NoLeapModel ()
let ActualActual                                ()
                                                = new ActualActualModel ()
let ActualActual1                               c schedule 
                                                = new ActualActualModel1 (c, schedule)
let AdditiveEQPBinomialTree                     ()
                                                = new AdditiveEQPBinomialTreeModel ()
let AdditiveEQPBinomialTree1                    Process End steps strike 
                                                = new AdditiveEQPBinomialTreeModel1 (Process, End, steps, strike)
let AkimaCubicInterpolation                     xBegin size yBegin 
                                                = new AkimaCubicInterpolationModel (xBegin, size, yBegin)
let AmericanCondition                           Type strike 
                                                = new AmericanConditionModel (Type, strike)
let AmericanCondition1                          intrinsicValues 
                                                = new AmericanConditionModel1 (intrinsicValues)
let AmericanExercise                            latest payoffAtExpiry 
                                                = new AmericanExerciseModel (latest, payoffAtExpiry)
let AmericanExercise1                           earliestDate latestDate payoffAtExpiry 
                                                = new AmericanExerciseModel1 (earliestDate, latestDate, payoffAtExpiry)
let AmericanPathPricer                          payoff polynomOrder polynomType 
                                                = new AmericanPathPricerModel (payoff, polynomOrder, polynomType)
let AmericanPayoffAtExpiry                      spot discount dividendDiscount variance payoff knock_in 
                                                = new AmericanPayoffAtExpiryModel (spot, discount, dividendDiscount, variance, payoff, knock_in)
let AmericanPayoffAtHit                         spot discount dividendDiscount variance payoff 
                                                = new AmericanPayoffAtHitModel (spot, discount, dividendDiscount, variance, payoff)
let AmortizingBond                              FaceValue MarketValue CouponRate IssueDate MaturityDate TradeDate payFrequency dCounter Method calendar gYield pricingEngine evaluationDate 
                                                = new AmortizingBondModel (FaceValue, MarketValue, CouponRate, IssueDate, MaturityDate, TradeDate, payFrequency, dCounter, Method, calendar, gYield, pricingEngine, evaluationDate)
let AmortizingCmsRateBond                       settlementDays notionals schedule index paymentDayCounter paymentConvention fixingDays gearings spreads caps floors inArrears issueDate pricingEngine evaluationDate 
                                                = new AmortizingCmsRateBondModel (settlementDays, notionals, schedule, index, paymentDayCounter, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, issueDate, pricingEngine, evaluationDate)
let AmortizingFixedRateBond                     settlementDays calendar faceAmount startDate bondTenor sinkingFrequency coupon accrualDayCounter paymentConvention issueDate pricingEngine evaluationDate 
                                                = new AmortizingFixedRateBondModel (settlementDays, calendar, faceAmount, startDate, bondTenor, sinkingFrequency, coupon, accrualDayCounter, paymentConvention, issueDate, pricingEngine, evaluationDate)
let AmortizingFixedRateBond1                    settlementDays notionals schedule coupons accrualDayCounter paymentConvention issueDate pricingEngine evaluationDate 
                                                = new AmortizingFixedRateBondModel1 (settlementDays, notionals, schedule, coupons, accrualDayCounter, paymentConvention, issueDate, pricingEngine, evaluationDate)
let AmortizingFixedRateBond2                    settlementDays notionals schedule coupons accrualDayCounter paymentConvention issueDate pricingEngine evaluationDate 
                                                = new AmortizingFixedRateBondModel2 (settlementDays, notionals, schedule, coupons, accrualDayCounter, paymentConvention, issueDate, pricingEngine, evaluationDate)
let AmortizingFloatingRateBond                  settlementDays notionals schedule index accrualDayCounter paymentConvention fixingDays gearings spreads caps floors inArrears issueDate pricingEngine evaluationDate 
                                                = new AmortizingFloatingRateBondModel (settlementDays, notionals, schedule, index, accrualDayCounter, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, issueDate, pricingEngine, evaluationDate)
let AmortizingPayment                           amount date 
                                                = new AmortizingPaymentModel (amount, date)
let AnalyticBarrierEngine                       Process 
                                                = new AnalyticBarrierEngineModel (Process)
let AnalyticBinaryBarrierEngine                 Process 
                                                = new AnalyticBinaryBarrierEngineModel (Process)
let AnalyticBinaryBarrierEngine_helper          Process payoff exercise arguments 
                                                = new AnalyticBinaryBarrierEngine_helperModel (Process, payoff, exercise, arguments)
let AnalyticBSMHullWhiteEngine                  equityShortRateCorrelation Process model 
                                                = new AnalyticBSMHullWhiteEngineModel (equityShortRateCorrelation, Process, model)
let AnalyticCapFloorEngine                      model 
                                                = new AnalyticCapFloorEngineModel (model)
let AnalyticCapFloorEngine1                     model termStructure 
                                                = new AnalyticCapFloorEngineModel1 (model, termStructure)
let AnalyticCliquetEngine                       Process 
                                                = new AnalyticCliquetEngineModel (Process)
let AnalyticContinuousFixedLookbackEngine       Process 
                                                = new AnalyticContinuousFixedLookbackEngineModel (Process)
let AnalyticContinuousFloatingLookbackEngine    Process 
                                                = new AnalyticContinuousFloatingLookbackEngineModel (Process)
let AnalyticContinuousGeometricAveragePriceAsianEngine  Process 
                                                = new AnalyticContinuousGeometricAveragePriceAsianEngineModel (Process)
let AnalyticContinuousPartialFixedLookbackEngine  Process 
                                                = new AnalyticContinuousPartialFixedLookbackEngineModel (Process)
let AnalyticContinuousPartialFloatingLookbackEngine  Process 
                                                = new AnalyticContinuousPartialFloatingLookbackEngineModel (Process)
let AnalyticDigitalAmericanEngine               Process 
                                                = new AnalyticDigitalAmericanEngineModel (Process)
let AnalyticDigitalAmericanKOEngine             engine 
                                                = new AnalyticDigitalAmericanKOEngineModel (engine)
let AnalyticDiscreteGeometricAveragePriceAsianEngine  Process 
                                                = new AnalyticDiscreteGeometricAveragePriceAsianEngineModel (Process)
let AnalyticDiscreteGeometricAverageStrikeAsianEngine  Process 
                                                = new AnalyticDiscreteGeometricAverageStrikeAsianEngineModel (Process)
let AnalyticDividendEuropeanEngine              Process 
                                                = new AnalyticDividendEuropeanEngineModel (Process)
let AnalyticDoubleBarrierBinaryEngine           Process 
                                                = new AnalyticDoubleBarrierBinaryEngineModel (Process)
let AnalyticDoubleBarrierBinaryEngineHelper     Process payoff arguments 
                                                = new AnalyticDoubleBarrierBinaryEngineHelperModel (Process, payoff, arguments)
let AnalyticDoubleBarrierEngine                 Process series 
                                                = new AnalyticDoubleBarrierEngineModel (Process, series)
let AnalyticEuropeanEngine                      Process 
                                                = new AnalyticEuropeanEngineModel (Process)
let AnalyticH1HWEngine                          model hullWhiteModel rhoSr integrationOrder 
                                                = new AnalyticH1HWEngineModel (model, hullWhiteModel, rhoSr, integrationOrder)
let AnalyticH1HWEngine1                         model hullWhiteModel rhoSr relTolerance maxEvaluations 
                                                = new AnalyticH1HWEngineModel1 (model, hullWhiteModel, rhoSr, relTolerance, maxEvaluations)
let AnalyticHaganPricer                         swaptionVol modelOfYieldCurve meanReversion 
                                                = new AnalyticHaganPricerModel (swaptionVol, modelOfYieldCurve, meanReversion)
let AnalyticHestonEngine                        model relTolerance maxEvaluations 
                                                = new AnalyticHestonEngineModel (model, relTolerance, maxEvaluations)
let AnalyticHestonEngine1                       model integrationOrder 
                                                = new AnalyticHestonEngineModel1 (model, integrationOrder)
let AnalyticHestonEngine2                       model cpxLog integration 
                                                = new AnalyticHestonEngineModel2 (model, cpxLog, integration)
let AnalyticHestonHullWhiteEngine               hestonModel hullWhiteModel relTolerance maxEvaluations 
                                                = new AnalyticHestonHullWhiteEngineModel (hestonModel, hullWhiteModel, relTolerance, maxEvaluations)
let AnalyticHestonHullWhiteEngine1              hestonModel hullWhiteModel integrationOrder 
                                                = new AnalyticHestonHullWhiteEngineModel1 (hestonModel, hullWhiteModel, integrationOrder)
let AnalyticPerformanceEngine                   Process 
                                                = new AnalyticPerformanceEngineModel (Process)
let AnalyticPTDHestonEngine                     model relTolerance maxEvaluations 
                                                = new AnalyticPTDHestonEngineModel (model, relTolerance, maxEvaluations)
let AnalyticPTDHestonEngine1                    model integrationOrder 
                                                = new AnalyticPTDHestonEngineModel1 (model, integrationOrder)
let Aonia                                       h 
                                                = new AoniaModel (h)
let Argentina                                   ()
                                                = new ArgentinaModel ()
let ArithmeticAPOPathPricer                     Type strike discount 
                                                = new ArithmeticAPOPathPricerModel (Type, strike, discount)
let ArithmeticAPOPathPricer1                    Type strike discount runningSum 
                                                = new ArithmeticAPOPathPricerModel1 (Type, strike, discount, runningSum)
let ArithmeticAPOPathPricer2                    Type strike discount runningSum pastFixings 
                                                = new ArithmeticAPOPathPricerModel2 (Type, strike, discount, runningSum, pastFixings)
let ArithmeticASOPathPricer                     Type discount runningSum 
                                                = new ArithmeticASOPathPricerModel (Type, discount, runningSum)
let ArithmeticASOPathPricer1                    Type discount runningSum pastFixings 
                                                = new ArithmeticASOPathPricerModel1 (Type, discount, runningSum, pastFixings)
let ArithmeticASOPathPricer2                    Type discount 
                                                = new ArithmeticASOPathPricerModel2 (Type, discount)
let ArmijoLineSearch                            eps 
                                                = new ArmijoLineSearchModel (eps)
let ArmijoLineSearch1                           eps alpha 
                                                = new ArmijoLineSearchModel1 (eps, alpha)
let ArmijoLineSearch2                           eps alpha beta 
                                                = new ArmijoLineSearchModel2 (eps, alpha, beta)
let ArmijoLineSearch3                           ()
                                                = new ArmijoLineSearchModel3 ()
let ARSCurrency                                 ()
                                                = new ARSCurrencyModel ()
let AssetOrNothingPayoff                        Type strike 
                                                = new AssetOrNothingPayoffModel (Type, strike)
let AssetSwap                                   parAssetSwap bond bondCleanPrice nonParRepayment gearing iborIndex spread floatingDayCount dealMaturity payBondCoupon pricingEngine evaluationDate 
                                                = new AssetSwapModel (parAssetSwap, bond, bondCleanPrice, nonParRepayment, gearing, iborIndex, spread, floatingDayCount, dealMaturity, payBondCoupon, pricingEngine, evaluationDate)
let AssetSwap1                                  payBondCoupon bond bondCleanPrice iborIndex spread floatSchedule floatingDayCount parAssetSwap pricingEngine evaluationDate 
                                                = new AssetSwapModel1 (payBondCoupon, bond, bondCleanPrice, iborIndex, spread, floatSchedule, floatingDayCount, parAssetSwap, pricingEngine, evaluationDate)
let AtmSmileSection                             source atm 
                                                = new AtmSmileSectionModel (source, atm)
let ATSCurrency                                 ()
                                                = new ATSCurrencyModel ()
let AUCPI                                       frequency revised interpolated ts 
                                                = new AUCPIModel (frequency, revised, interpolated, ts)
let AUCPI1                                      frequency revised interpolated 
                                                = new AUCPIModel1 (frequency, revised, interpolated)
let AUDCurrency                                 ()
                                                = new AUDCurrencyModel ()
let AUDLibor                                    tenor 
                                                = new AUDLiborModel (tenor)
let AUDLibor1                                   tenor h 
                                                = new AUDLiborModel1 (tenor, h)
let Australia                                   ()
                                                = new AustraliaModel ()
let AustraliaRegion                             ()
                                                = new AustraliaRegionModel ()
let AverageBasketPayoff                         p a 
                                                = new AverageBasketPayoffModel (p, a)
let AverageBasketPayoff1                        p n 
                                                = new AverageBasketPayoffModel1 (p, n)
let AverageBMACoupon                            paymentDate nominal startDate endDate index gearing spread refPeriodStart refPeriodEnd dayCounter 
                                                = new AverageBMACouponModel (paymentDate, nominal, startDate, endDate, index, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter)
let AverageBMACouponPricer                      ()
                                                = new AverageBMACouponPricerModel ()
let AverageBMALeg                               schedule index 
                                                = new AverageBMALegModel (schedule, index)
let BachelierCapFloorEngine                     discountCurve vol 
                                                = new BachelierCapFloorEngineModel (discountCurve, vol)
let BachelierCapFloorEngine1                    discountCurve vol dc 
                                                = new BachelierCapFloorEngineModel1 (discountCurve, vol, dc)
let BachelierCapFloorEngine2                    discountCurve vol dc 
                                                = new BachelierCapFloorEngineModel2 (discountCurve, vol, dc)
let BachelierSpec                               ()
                                                = new BachelierSpecModel ()
let BachelierSwaptionEngine                     discountCurve vol dc model 
                                                = new BachelierSwaptionEngineModel (discountCurve, vol, dc, model)
let BachelierSwaptionEngine1                    discountCurve vol model 
                                                = new BachelierSwaptionEngineModel1 (discountCurve, vol, model)
let BachelierSwaptionEngine2                    discountCurve vol dc model 
                                                = new BachelierSwaptionEngineModel2 (discountCurve, vol, dc, model)
let BachelierYoYInflationCouponPricer           capletVol 
                                                = new BachelierYoYInflationCouponPricerModel (capletVol)
let BackwardFlat                                ()
                                                = new BackwardFlatModel ()
let BackwardFlatInterpolation                   xBegin size yBegin 
                                                = new BackwardFlatInterpolationModel (xBegin, size, yBegin)
let BackwardflatLinear                          ()
                                                = new BackwardflatLinearModel ()
let BackwardflatLinearInterpolation             xBegin xEnd yBegin yEnd zData 
                                                = new BackwardflatLinearInterpolationModel (xBegin, xEnd, yBegin, yEnd, zData)
let BaroneAdesiWhaleyApproximationEngine        Process 
                                                = new BaroneAdesiWhaleyApproximationEngineModel (Process)
let BarrierOption                               barrierType barrier rebate payoff exercise pricingEngine evaluationDate 
                                                = new BarrierOptionModel (barrierType, barrier, rebate, payoff, exercise, pricingEngine, evaluationDate)
let BarrierPathPricer                           barrierType barrier rebate Type strike discounts diffProcess sequenceGen 
                                                = new BarrierPathPricerModel (barrierType, barrier, rebate, Type, strike, discounts, diffProcess, sequenceGen)
let BasisSwap                                   Type nominal float1Schedule iborIndex1 spread1 float1DayCount float2Schedule iborIndex2 spread2 float2DayCount pricingEngine evaluationDate 
                                                = new BasisSwapModel (Type, nominal, float1Schedule, iborIndex1, spread1, float1DayCount, float2Schedule, iborIndex2, spread2, float2DayCount, pricingEngine, evaluationDate)
let BasisSwap1                                  Type nominal float1Schedule iborIndex1 spread1 float1DayCount float2Schedule iborIndex2 spread2 float2DayCount paymentConvention pricingEngine evaluationDate 
                                                = new BasisSwapModel1 (Type, nominal, float1Schedule, iborIndex1, spread1, float1DayCount, float2Schedule, iborIndex2, spread2, float2DayCount, paymentConvention, pricingEngine, evaluationDate)
let BasisSwapHelper                             spreadQuote settlementDays swapTenor settlementCalendar rollConvention shortIndex longIndex discount eom spreadOnShort 
                                                = new BasisSwapHelperModel (spreadQuote, settlementDays, swapTenor, settlementCalendar, rollConvention, shortIndex, longIndex, discount, eom, spreadOnShort)
let BasketOption                                payoff exercise pricingEngine evaluationDate 
                                                = new BasketOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let Bbsw                                        tenor h 
                                                = new BbswModel (tenor, h)
let Bbsw1M                                      h 
                                                = new Bbsw1MModel (h)
let Bbsw2M                                      h 
                                                = new Bbsw2MModel (h)
let Bbsw3M                                      h 
                                                = new Bbsw3MModel (h)
let Bbsw4M                                      h 
                                                = new Bbsw4MModel (h)
let Bbsw5M                                      h 
                                                = new Bbsw5MModel (h)
let Bbsw6M                                      h 
                                                = new Bbsw6MModel (h)
let BDTCurrency                                 
                                                = new BDTCurrencyModel ()
let BEFCurrency                                 
                                                = new BEFCurrencyModel ()
let BermudanExercise                            dates 
                                                = new BermudanExerciseModel (dates)
let BermudanExercise1                           dates payoffAtExpiry 
                                                = new BermudanExerciseModel1 (dates, payoffAtExpiry)
let BespokeCalendar                             name 
                                                = new BespokeCalendarModel (name)
let BespokeCalendar1                            ()
                                                = new BespokeCalendarModel1 ()
let BFGS                                        lineSearch 
                                                = new BFGSModel (lineSearch)
let BGLCurrency                                 ()
                                                = new BGLCurrencyModel ()
let BiasedBarrierPathPricer                     barrierType barrier rebate Type strike discounts 
                                                = new BiasedBarrierPathPricerModel (barrierType, barrier, rebate, Type, strike, discounts)
let Bibor                                       tenor h 
                                                = new BiborModel (tenor, h)
let BiCGStab                                    A maxIter relTol preConditioner 
                                                = new BiCGStabModel (A, maxIter, relTol, preConditioner)
let BiCGStabResult                              i e xx 
                                                = new BiCGStabResultModel (i, e, xx)
let Bicubic                                     ()
                                                = new BicubicModel ()
let BicubicSpline                               xBegin size yBegin ySize zData 
                                                = new BicubicSplineModel (xBegin, size, yBegin, ySize, zData)
let Bilinear                                    ()
                                                = new BilinearModel ()
let BilinearInterpolation                       xBegin xSize yBegin ySize zData 
                                                = new BilinearInterpolationModel (xBegin, xSize, yBegin, ySize, zData)
let BinomialBarrierEngine                       getTree getAsset Process timeSteps maxTimeSteps 
                                                = new BinomialBarrierEngineModel (getTree, getAsset, Process, timeSteps, maxTimeSteps)
let BinomialConvertibleEngine                   Process timeSteps 
                                                = new BinomialConvertibleEngineModel<'T> (Process, timeSteps)
let BinomialDistribution                        p n 
                                                = new BinomialDistributionModel (p, n)
let BinomialDoubleBarrierEngine                 getTree getAsset Process timeSteps maxTimeSteps 
                                                = new BinomialDoubleBarrierEngineModel (getTree, getAsset, Process, timeSteps, maxTimeSteps)
let BinomialVanillaEngine                       Process timeSteps 
                                                = new BinomialVanillaEngineModel<'T> (Process, timeSteps)
let BivariateCumulativeNormalDistributionDr78   rho 
                                                = new BivariateCumulativeNormalDistributionDr78Model (rho)
let BivariateCumulativeNormalDistributionWe04DP  rho 
                                                = new BivariateCumulativeNormalDistributionWe04DPModel (rho)
let BjerksundStenslandApproximationEngine       Process 
                                                = new BjerksundStenslandApproximationEngineModel (Process)
let Bkbm                                        tenor h 
                                                = new BkbmModel (tenor, h)
let Bkbm1M                                      h 
                                                = new Bkbm1MModel (h)
let Bkbm2M                                      h 
                                                = new Bkbm2MModel (h)
let Bkbm3M                                      h 
                                                = new Bkbm3MModel (h)
let Bkbm4M                                      h 
                                                = new Bkbm4MModel (h)
let Bkbm5M                                      h 
                                                = new Bkbm5MModel (h)
let Bkbm6M                                      h 
                                                = new Bkbm6MModel (h)
let Black76Spec                                 ()
                                                = new Black76SpecModel ()
let BlackCalculator                             payoff forward stdDev discount 
                                                = new BlackCalculatorModel (payoff, forward, stdDev, discount)
let BlackCallableFixedRateBondEngine            fwdYieldVol discountCurve 
                                                = new BlackCallableFixedRateBondEngineModel (fwdYieldVol, discountCurve)
let BlackCallableFixedRateBondEngine1           yieldVolStructure discountCurve 
                                                = new BlackCallableFixedRateBondEngineModel1 (yieldVolStructure, discountCurve)
let BlackCallableZeroCouponBondEngine           yieldVolStructure discountCurve 
                                                = new BlackCallableZeroCouponBondEngineModel (yieldVolStructure, discountCurve)
let BlackCallableZeroCouponBondEngine1          fwdYieldVol discountCurve 
                                                = new BlackCallableZeroCouponBondEngineModel1 (fwdYieldVol, discountCurve)
let BlackCapFloorEngine                         discountCurve vol dc displacement 
                                                = new BlackCapFloorEngineModel (discountCurve, vol, dc, displacement)
let BlackCapFloorEngine1                        discountCurve vol displacement 
                                                = new BlackCapFloorEngineModel1 (discountCurve, vol, displacement)
let BlackCapFloorEngine2                        discountCurve vol dc displacement 
                                                = new BlackCapFloorEngineModel2 (discountCurve, vol, dc, displacement)
let BlackConstantVol                            settlementDays cal volatility dc 
                                                = new BlackConstantVolModel (settlementDays, cal, volatility, dc)
let BlackConstantVol1                           settlementDays cal volatility dc 
                                                = new BlackConstantVolModel1 (settlementDays, cal, volatility, dc)
let BlackConstantVol2                           referenceDate cal volatility dc 
                                                = new BlackConstantVolModel2 (referenceDate, cal, volatility, dc)
let BlackConstantVol3                           referenceDate cal volatility dc 
                                                = new BlackConstantVolModel3 (referenceDate, cal, volatility, dc)
let BlackDeltaCalculator                        ot dt spot dDiscount fDiscount stdDev 
                                                = new BlackDeltaCalculatorModel (ot, dt, spot, dDiscount, fDiscount, stdDev)
let BlackDeltaPremiumAdjustedMaxStrikeClass     ot dt spot dDiscount fDiscount stdDev 
                                                = new BlackDeltaPremiumAdjustedMaxStrikeClassModel (ot, dt, spot, dDiscount, fDiscount, stdDev)
let BlackDeltaPremiumAdjustedSolverClass        ot dt spot dDiscount fDiscount stdDev delta 
                                                = new BlackDeltaPremiumAdjustedSolverClassModel (ot, dt, spot, dDiscount, fDiscount, stdDev, delta)
let BlackIborCouponPricer                       v timingAdjustment correlation 
                                                = new BlackIborCouponPricerModel (v, timingAdjustment, correlation)
let BlackKarasinski                             termStructure a sigma 
                                                = new BlackKarasinskiModel (termStructure, a, sigma)
let BlackKarasinski1                            termStructure 
                                                = new BlackKarasinskiModel1 (termStructure)
let BlackProcess                                x0 riskFreeTS blackVolTS d 
                                                = new BlackProcessModel (x0, riskFreeTS, blackVolTS, d)
let BlackProcess1                               x0 riskFreeTS blackVolTS 
                                                = new BlackProcessModel1 (x0, riskFreeTS, blackVolTS)
let BlackScholesCalculator                      payoff spot growth stdDev discount 
                                                = new BlackScholesCalculatorModel (payoff, spot, growth, stdDev, discount)
let BlackScholesLattice                         tree riskFreeRate End steps 
                                                = new BlackScholesLatticeModel<'T> (tree, riskFreeRate, End, steps)
let BlackScholesMertonProcess                   x0 dividendTS riskFreeTS blackVolTS d 
                                                = new BlackScholesMertonProcessModel (x0, dividendTS, riskFreeTS, blackVolTS, d)
let BlackScholesMertonProcess1                  x0 dividendTS riskFreeTS blackVolTS 
                                                = new BlackScholesMertonProcessModel1 (x0, dividendTS, riskFreeTS, blackVolTS)
let BlackScholesProcess                         x0 riskFreeTS blackVolTS d 
                                                = new BlackScholesProcessModel (x0, riskFreeTS, blackVolTS, d)
let BlackScholesProcess1                        x0 riskFreeTS blackVolTS 
                                                = new BlackScholesProcessModel1 (x0, riskFreeTS, blackVolTS)
let BlackStyleSwaptionEngine                    discountCurve volatility displacement model 
                                                = new BlackStyleSwaptionEngineModel<'Spec> (discountCurve, volatility, displacement, model)
let BlackStyleSwaptionEngine1                   discountCurve vol dc displacement model 
                                                = new BlackStyleSwaptionEngineModel1<'Spec> (discountCurve, vol, dc, displacement, model)
let BlackStyleSwaptionEngine2                   discountCurve vol dc displacement model 
                                                = new BlackStyleSwaptionEngineModel2<'Spec> (discountCurve, vol, dc, displacement, model)
let BlackSwaptionEngine                         discountCurve vol displacement model 
                                                = new BlackSwaptionEngineModel (discountCurve, vol, displacement, model)
let BlackSwaptionEngine1                        discountCurve vol dc displacement model 
                                                = new BlackSwaptionEngineModel1 (discountCurve, vol, dc, displacement, model)
let BlackSwaptionEngine2                        discountCurve vol dc displacement model 
                                                = new BlackSwaptionEngineModel2 (discountCurve, vol, dc, displacement, model)
let BlackVanillaOptionPricer                    forwardValue expiryDate swapTenor volatilityStructure 
                                                = new BlackVanillaOptionPricerModel (forwardValue, expiryDate, swapTenor, volatilityStructure)
let BlackVarianceCurve                          referenceDate dates blackVolCurve dayCounter forceMonotoneVariance 
                                                = new BlackVarianceCurveModel (referenceDate, dates, blackVolCurve, dayCounter, forceMonotoneVariance)
let BlackVarianceSurface                        referenceDate calendar dates strikes blackVolMatrix dayCounter lowerExtrapolation upperExtrapolation 
                                                = new BlackVarianceSurfaceModel (referenceDate, calendar, dates, strikes, blackVolMatrix, dayCounter, lowerExtrapolation, upperExtrapolation)
let BlackVarianceSurface1                       ()
                                                = new BlackVarianceSurfaceModel1 ()
let BlackYoYInflationCouponPricer               capletVol 
                                                = new BlackYoYInflationCouponPricerModel (capletVol)
let BMAIndex                                    h 
                                                = new BMAIndexModel (h)
let BMASwap                                     Type nominal liborSchedule liborFraction liborSpread liborIndex liborDayCount bmaSchedule bmaIndex bmaDayCount pricingEngine evaluationDate 
                                                = new BMASwapModel (Type, nominal, liborSchedule, liborFraction, liborSpread, liborIndex, liborDayCount, bmaSchedule, bmaIndex, bmaDayCount, pricingEngine, evaluationDate)
let BMASwapRateHelper                           liborFraction tenor settlementDays calendar bmaPeriod bmaConvention bmaDayCount bmaIndex iborIndex 
                                                = new BMASwapRateHelperModel (liborFraction, tenor, settlementDays, calendar, bmaPeriod, bmaConvention, bmaDayCount, bmaIndex, iborIndex)
let Bond                                        settlementDays calendar faceAmount maturityDate issueDate cashflows pricingEngine evaluationDate 
                                                = new BondModel (settlementDays, calendar, faceAmount, maturityDate, issueDate, cashflows, pricingEngine, evaluationDate)
let Bond1                                       settlementDays calendar issueDate coupons pricingEngine evaluationDate 
                                                = new BondModel1 (settlementDays, calendar, issueDate, coupons, pricingEngine, evaluationDate)
let BondHelper                                  price bond useCleanPrice 
                                                = new BondHelperModel (price, bond, useCleanPrice)
let BootstrapError                              curve helper segment 
                                                = new BootstrapErrorModel<'T, 'U> (curve, helper, segment)
let BootstrapHelper<'TS>                        ()     
                                                = new BootstrapHelperModel<'TS> ()
let BootstrapHelper1                            quote 
                                                = new BootstrapHelperModel1<'TS> (quote)
let BootstrapHelper2                            quote 
                                                = new BootstrapHelperModel2<'TS> (quote)
let Botswana                                    ()
                                                = new BotswanaModel ()
let BoundaryConditionSchemeHelper               bcSet 
                                                = new BoundaryConditionSchemeHelperModel (bcSet)
let BoundaryConstraint                          low high 
                                                = new BoundaryConstraintModel (low, high)
let Brazil                                      market 
                                                = new BrazilModel (market)
let Brazil1                                     ()
                                                = new BrazilModel1 ()
let BRLCurrency                                 ()
                                                = new BRLCurrencyModel ()
let BrownianBridge                              timeGrid 
                                                = new BrownianBridgeModel (timeGrid)
let BrownianBridge1                             times 
                                                = new BrownianBridgeModel1 (times)
let BrownianBridge2                             steps 
                                                = new BrownianBridgeModel2 (steps)
let BSMOperator                                 size dx r q sigma 
                                                = new BSMOperatorModel (size, dx, r, q, sigma)
let BSMOperator1                                grid Process residualTime 
                                                = new BSMOperatorModel1 (grid, Process, residualTime)
let BSMOperator2                                ()
                                                = new BSMOperatorModel2 ()
let BSpline                                     p n knots 
                                                = new BSplineModel (p, n, knots)
let BTP                                         maturityDate fixedRate redemption startDate issueDate pricingEngine evaluationDate 
                                                = new BTPModel (maturityDate, fixedRate, redemption, startDate, issueDate, pricingEngine, evaluationDate)
let BTP1                                        maturityDate fixedRate startDate issueDate pricingEngine evaluationDate 
                                                = new BTPModel1 (maturityDate, fixedRate, startDate, issueDate, pricingEngine, evaluationDate)
let BulletPricipalLeg                           schedule 
                                                = new BulletPricipalLegModel (schedule)
let Business252                                 c 
                                                = new Business252Model (c)
let BYRCurrency                                 ()
                                                = new BYRCurrencyModel ()
let CADCurrency                                 ()
                                                = new CADCurrencyModel ()
let CADLibor                                    tenor h 
                                                = new CADLiborModel (tenor, h)
let CADLibor1                                   tenor 
                                                = new CADLiborModel1 (tenor)
let CADLiborON                                  h 
                                                = new CADLiborONModel (h)
let CADLiborON1                                 ()
                                                = new CADLiborONModel1 ()
let Calendar                                    ()
                                                = new CalendarModel ()
let Calendar1                                   c 
                                                = new CalendarModel1 (c)
let CalibratedModel                             nArguments 
                                                = new CalibratedModelModel (nArguments)
let Callability                                 price Type date 
                                                = new CallabilityModel (price, Type, date)
let CallableBondConstantVolatility              referenceDate volatility dayCounter 
                                                = new CallableBondConstantVolatilityModel (referenceDate, volatility, dayCounter)
let CallableBondConstantVolatility1             settlementDays calendar volatility dayCounter 
                                                = new CallableBondConstantVolatilityModel1 (settlementDays, calendar, volatility, dayCounter)
let CallableBondConstantVolatility2             settlementDays calendar volatility dayCounter 
                                                = new CallableBondConstantVolatilityModel2 (settlementDays, calendar, volatility, dayCounter)
let CallableBondConstantVolatility3             referenceDate volatility dayCounter 
                                                = new CallableBondConstantVolatilityModel3 (referenceDate, volatility, dayCounter)
let CallableFixedRateBond                       settlementDays faceAmount schedule coupons accrualDayCounter paymentConvention redemption issueDate putCallSchedule pricingEngine evaluationDate 
                                                = new CallableFixedRateBondModel (settlementDays, faceAmount, schedule, coupons, accrualDayCounter, paymentConvention, redemption, issueDate, putCallSchedule, pricingEngine, evaluationDate)
let CallableZeroCouponBond                      settlementDays faceAmount calendar maturityDate dayCounter paymentConvention redemption issueDate putCallSchedule pricingEngine evaluationDate 
                                                = new CallableZeroCouponBondModel (settlementDays, faceAmount, calendar, maturityDate, dayCounter, paymentConvention, redemption, issueDate, putCallSchedule, pricingEngine, evaluationDate)
let Canada                                      m 
                                                = new CanadaModel (m)
let Canada1                                     ()
                                                = new CanadaModel1 ()
let Cap                                         floatingLeg exerciseRates pricingEngine evaluationDate 
                                                = new CapModel (floatingLeg, exerciseRates, pricingEngine, evaluationDate)
let CapFloor                                    Type floatingLeg capRates floorRates pricingEngine evaluationDate 
                                                = new CapFloorModel (Type, floatingLeg, capRates, floorRates, pricingEngine, evaluationDate)
let CapFloor1                                   Type floatingLeg strikes pricingEngine evaluationDate 
                                                = new CapFloorModel1 (Type, floatingLeg, strikes, pricingEngine, evaluationDate)
let CapFloorTermVolCurve                        settlementDays calendar bdc optionTenors vols dc 
                                                = new CapFloorTermVolCurveModel (settlementDays, calendar, bdc, optionTenors, vols, dc)
let CapFloorTermVolCurve1                       settlementDays calendar bdc optionTenors vols dc 
                                                = new CapFloorTermVolCurveModel1 (settlementDays, calendar, bdc, optionTenors, vols, dc)
let CapFloorTermVolCurve2                       settlementDate calendar bdc optionTenors vols dc 
                                                = new CapFloorTermVolCurveModel2 (settlementDate, calendar, bdc, optionTenors, vols, dc)
let CapFloorTermVolCurve3                       settlementDate calendar bdc optionTenors vols dc 
                                                = new CapFloorTermVolCurveModel3 (settlementDate, calendar, bdc, optionTenors, vols, dc)
let CapFloorTermVolSurface                      settlementDate calendar bdc optionTenors strikes vols dc 
                                                = new CapFloorTermVolSurfaceModel (settlementDate, calendar, bdc, optionTenors, strikes, vols, dc)
let CapFloorTermVolSurface1                     settlementDate calendar bdc optionTenors strikes vols dc 
                                                = new CapFloorTermVolSurfaceModel1 (settlementDate, calendar, bdc, optionTenors, strikes, vols, dc)
let CapFloorTermVolSurface2                     settlementDays calendar bdc optionTenors strikes vols dc 
                                                = new CapFloorTermVolSurfaceModel2 (settlementDays, calendar, bdc, optionTenors, strikes, vols, dc)
let CapFloorTermVolSurface3                     settlementDays calendar bdc optionTenors strikes vols dc 
                                                = new CapFloorTermVolSurfaceModel3 (settlementDays, calendar, bdc, optionTenors, strikes, vols, dc)
let CapHelper                                   length volatility index fixedLegFrequency fixedLegDayCounter includeFirstSwaplet termStructure errorType pricingEngine evaluationDate 
                                                = new CapHelperModel (length, volatility, index, fixedLegFrequency, fixedLegDayCounter, includeFirstSwaplet, termStructure, errorType, pricingEngine, evaluationDate)
let CapletVarianceCurve                         referenceDate dates capletVolCurve dayCounter 
                                                = new CapletVarianceCurveModel (referenceDate, dates, capletVolCurve, dayCounter)
let CappedFlooredCmsCoupon                      nominal paymentDate startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new CappedFlooredCmsCouponModel (nominal, paymentDate, startDate, endDate, fixingDays, index, gearing, spread, cap, floor, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let CappedFlooredCmsCoupon1                     ()
                                                = new CappedFlooredCmsCouponModel1 ()
let CappedFlooredCmsSpreadCoupon                paymentDate nominal startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new CappedFlooredCmsSpreadCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, index, gearing, spread, cap, floor, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let CappedFlooredCmsSpreadCoupon1               ()
                                                = new CappedFlooredCmsSpreadCouponModel1 ()
let CappedFlooredCoupon                         ()
                                                = new CappedFlooredCouponModel ()
let CappedFlooredCoupon1                        underlying cap floor 
                                                = new CappedFlooredCouponModel1 (underlying, cap, floor)
let CappedFlooredIborCoupon                     ()
                                                = new CappedFlooredIborCouponModel ()
let CappedFlooredIborCoupon1                    paymentDate nominal startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new CappedFlooredIborCouponModel1 (paymentDate, nominal, startDate, endDate, fixingDays, index, gearing, spread, cap, floor, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let CappedFlooredYoYInflationCoupon             paymentDate nominal startDate endDate fixingDays index observationLag dayCounter gearing spread cap floor refPeriodStart refPeriodEnd 
                                                = new CappedFlooredYoYInflationCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, index, observationLag, dayCounter, gearing, spread, cap, floor, refPeriodStart, refPeriodEnd)
let CappedFlooredYoYInflationCoupon1            underlying cap floor 
                                                = new CappedFlooredYoYInflationCouponModel1 (underlying, cap, floor)
let Cash                                        Type nominal principalSchedule paymentConvention pricingEngine evaluationDate 
                                                = new CashModel (Type, nominal, principalSchedule, paymentConvention, pricingEngine, evaluationDate)
let CashOrNothingPayoff                         Type strike cashPayoff 
                                                = new CashOrNothingPayoffModel (Type, strike, cashPayoff)
let CatBond                                     settlementDays calendar issueDate notionalRisk pricingEngine evaluationDate 
                                                = new CatBondModel (settlementDays, calendar, issueDate, notionalRisk, pricingEngine, evaluationDate)
let CCTEU                                       maturityDate spread fwdCurve startDate issueDate pricingEngine evaluationDate 
                                                = new CCTEUModel (maturityDate, spread, fwdCurve, startDate, issueDate, pricingEngine, evaluationDate)
let Cdor                                        tenor h 
                                                = new CdorModel (tenor, h)
let Cdor1                                       tenor 
                                                = new CdorModel1 (tenor)
let CeilingTruncation                           precision digit 
                                                = new CeilingTruncationModel (precision, digit)
let CeilingTruncation1                          precision 
                                                = new CeilingTruncationModel1 (precision)
let CHFCurrency                                 ()
                                                = new CHFCurrencyModel ()
let CHFLibor                                    tenor h 
                                                = new CHFLiborModel (tenor, h)
let CHFLibor1                                   tenor 
                                                = new CHFLiborModel1 (tenor)
let ChfLiborSwapIsdaFix                         tenor h 
                                                = new ChfLiborSwapIsdaFixModel (tenor, h)
let ChfLiborSwapIsdaFix1                        tenor 
                                                = new ChfLiborSwapIsdaFixModel1 (tenor)
let China                                       market 
                                                = new ChinaModel (market)
let ChiSquareDistribution                       df 
                                                = new ChiSquareDistributionModel (df)
let CliquetOption                               payoff maturity resetDates pricingEngine evaluationDate 
                                                = new CliquetOptionModel (payoff, maturity, resetDates, pricingEngine, evaluationDate)
let ClosestRounding                             precision 
                                                = new ClosestRoundingModel (precision)
let ClosestRounding1                            precision digit 
                                                = new ClosestRoundingModel1 (precision, digit)
let CLPCurrency                                 ()
                                                = new CLPCurrencyModel ()
let CmsCoupon                                   ()
                                                = new CmsCouponModel ()
let CmsCoupon1                                  nominal paymentDate startDate endDate fixingDays swapIndex gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new CmsCouponModel1 (nominal, paymentDate, startDate, endDate, fixingDays, swapIndex, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let CmsLeg                                      schedule swapIndex 
                                                = new CmsLegModel (schedule, swapIndex)
let CmsRateBond                                 settlementDays faceAmount schedule index paymentDayCounter paymentConvention fixingDays gearings spreads caps floors inArrears redemption issueDate pricingEngine evaluationDate 
                                                = new CmsRateBondModel (settlementDays, faceAmount, schedule, index, paymentDayCounter, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, redemption, issueDate, pricingEngine, evaluationDate)
let CmsSpreadCoupon                             paymentDate nominal startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new CmsSpreadCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, index, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let CmsSpreadCoupon1                            ()
                                                = new CmsSpreadCouponModel1 ()
let CmsSpreadLeg                                schedule swapSpreadIndex 
                                                = new CmsSpreadLegModel (schedule, swapSpreadIndex)
let CNYCurrency                                 ()
                                                = new CNYCurrencyModel ()
let Collar                                      floatingLeg capRates floorRates pricingEngine evaluationDate 
                                                = new CollarModel (floatingLeg, capRates, floorRates, pricingEngine, evaluationDate)
let ComboHelper                                 quadraticHelper convMonoHelper quadraticity 
                                                = new ComboHelperModel (quadraticHelper, convMonoHelper, quadraticity)
let CommercialPaper                             Type nominal fixedSchedule fixedRate fixedDayCount principalSchedule paymentConvention pricingEngine evaluationDate 
                                                = new CommercialPaperModel (Type, nominal, fixedSchedule, fixedRate, fixedDayCount, principalSchedule, paymentConvention, pricingEngine, evaluationDate)
let CompositeConstraint                         c1 c2 
                                                = new CompositeConstraintModel (c1, c2)
let CompositeInstrument                         pricingEngine evaluationDate
                                                = new CompositeInstrumentModel (pricingEngine, evaluationDate)
let CompositeQuote                              element1 element2 f 
                                                = new CompositeQuoteModel (element1, element2, f)
let CompositeZeroYieldStructure                 h1 h2 f comp freq 
                                                = new CompositeZeroYieldStructureModel (h1, h2, f, comp, freq)
let Concentrating1dMesher                       start End size cPoints tol 
                                                = new Concentrating1dMesherModel (start, End, size, cPoints, tol)
let Concentrating1dMesher1                      start End size cPoints requireCPoint 
                                                = new Concentrating1dMesherModel1 (start, End, size, cPoints, requireCPoint)
let ConjugateGradient                           lineSearch 
                                                = new ConjugateGradientModel (lineSearch)
let ConstantCapFloorTermVolatility              settlementDays cal bdc volatility dc 
                                                = new ConstantCapFloorTermVolatilityModel (settlementDays, cal, bdc, volatility, dc)
let ConstantCapFloorTermVolatility1             referenceDate cal bdc volatility dc 
                                                = new ConstantCapFloorTermVolatilityModel1 (referenceDate, cal, bdc, volatility, dc)
let ConstantCapFloorTermVolatility2             settlementDays cal bdc volatility dc 
                                                = new ConstantCapFloorTermVolatilityModel2 (settlementDays, cal, bdc, volatility, dc)
let ConstantCapFloorTermVolatility3             referenceDate cal bdc volatility dc 
                                                = new ConstantCapFloorTermVolatilityModel3 (referenceDate, cal, bdc, volatility, dc)
let ConstantCPR                                 cpr 
                                                = new ConstantCPRModel (cpr)
let ConstantDefaultIntensity                    constant recovery 
                                                = new ConstantDefaultIntensityModel (constant, recovery)
let ConstantDefaultIntensity1                   constant 
                                                = new ConstantDefaultIntensityModel1 (constant)
let ConstantGradHelper                          fPrev prevPrimitive xPrev xNext fNext 
                                                = new ConstantGradHelperModel (fPrev, prevPrimitive, xPrev, xNext, fNext)
let ConstantOptionletVolatility                 referenceDate cal bdc vol dc 
                                                = new ConstantOptionletVolatilityModel (referenceDate, cal, bdc, vol, dc)
let ConstantOptionletVolatility1                settlementDays cal bdc vol dc 
                                                = new ConstantOptionletVolatilityModel1 (settlementDays, cal, bdc, vol, dc)
let ConstantOptionletVolatility2                referenceDate cal bdc vol dc 
                                                = new ConstantOptionletVolatilityModel2 (referenceDate, cal, bdc, vol, dc)
let ConstantOptionletVolatility3                settlementDays cal bdc vol dc 
                                                = new ConstantOptionletVolatilityModel3 (settlementDays, cal, bdc, vol, dc)
let ConstantParameter                           Constraint 
                                                = new ConstantParameterModel (Constraint)
let ConstantParameter1                          value Constraint 
                                                = new ConstantParameterModel1 (value, Constraint)
let ConstantSwaptionVolatility                  referenceDate cal bdc vol dc Type shift 
                                                = new ConstantSwaptionVolatilityModel (referenceDate, cal, bdc, vol, dc, Type, shift)
let ConstantSwaptionVolatility1                 settlementDays cal bdc vol dc Type shift 
                                                = new ConstantSwaptionVolatilityModel1 (settlementDays, cal, bdc, vol, dc, Type, shift)
let ConstantSwaptionVolatility2                 referenceDate cal bdc vol dc Type shift 
                                                = new ConstantSwaptionVolatilityModel2 (referenceDate, cal, bdc, vol, dc, Type, shift)
let ConstantSwaptionVolatility3                 settlementDays cal bdc vol dc Type shift 
                                                = new ConstantSwaptionVolatilityModel3 (settlementDays, cal, bdc, vol, dc, Type, shift)
let ConstantYoYOptionletVolatility              v settlementDays cal bdc dc observationLag frequency indexIsInterpolated minStrike maxStrike 
                                                = new ConstantYoYOptionletVolatilityModel (v, settlementDays, cal, bdc, dc, observationLag, frequency, indexIsInterpolated, minStrike, maxStrike)
let Constraint                                  impl 
                                                = new ConstraintModel (impl)
let Constraint1                                 ()
                                                = new ConstraintModel1 ()
let ContinuousAveragingAsianOption              averageType payoff exercise pricingEngine evaluationDate 
                                                = new ContinuousAveragingAsianOptionModel (averageType, payoff, exercise, pricingEngine, evaluationDate)
let ContinuousFixedLookbackOption               minmax payoff exercise pricingEngine evaluationDate 
                                                = new ContinuousFixedLookbackOptionModel (minmax, payoff, exercise, pricingEngine, evaluationDate)
let ContinuousFloatingLookbackOption            minmax payoff exercise pricingEngine evaluationDate 
                                                = new ContinuousFloatingLookbackOptionModel (minmax, payoff, exercise, pricingEngine, evaluationDate)
let ContinuousPartialFixedLookbackOption        lookbackPeriodStart payoff exercise pricingEngine evaluationDate 
                                                = new ContinuousPartialFixedLookbackOptionModel (lookbackPeriodStart, payoff, exercise, pricingEngine, evaluationDate)
let ContinuousPartialFloatingLookbackOption     minmax lambda lookbackPeriodEnd payoff exercise pricingEngine evaluationDate 
                                                = new ContinuousPartialFloatingLookbackOptionModel (minmax, lambda, lookbackPeriodEnd, payoff, exercise, pricingEngine, evaluationDate)
let ConvertibleFixedCouponBond                  exercise conversionRatio dividends callability creditSpread issueDate settlementDays coupons dayCounter schedule redemption pricingEngine evaluationDate 
                                                = new ConvertibleFixedCouponBondModel (exercise, conversionRatio, dividends, callability, creditSpread, issueDate, settlementDays, coupons, dayCounter, schedule, redemption, pricingEngine, evaluationDate)
let ConvertibleFloatingRateBond                 exercise conversionRatio dividends callability creditSpread issueDate settlementDays index fixingDays spreads dayCounter schedule redemption pricingEngine evaluationDate 
                                                = new ConvertibleFloatingRateBondModel (exercise, conversionRatio, dividends, callability, creditSpread, issueDate, settlementDays, index, fixingDays, spreads, dayCounter, schedule, redemption, pricingEngine, evaluationDate)
let ConvertibleZeroCouponBond                   exercise conversionRatio dividends callability creditSpread issueDate settlementDays dayCounter schedule redemption pricingEngine evaluationDate 
                                                = new ConvertibleZeroCouponBondModel (exercise, conversionRatio, dividends, callability, creditSpread, issueDate, settlementDays, dayCounter, schedule, redemption, pricingEngine, evaluationDate)
let ConvexMonotone                              quadraticity monotonicity forcePositive 
                                                = new ConvexMonotoneModel (quadraticity, monotonicity, forcePositive)
let ConvexMonotone1                             ()
                                                = new ConvexMonotoneModel1 ()
let ConvexMonotone2Helper                       xPrev xNext gPrev gNext fAverage eta2 prevPrimitive 
                                                = new ConvexMonotone2HelperModel (xPrev, xNext, gPrev, gNext, fAverage, eta2, prevPrimitive)
let ConvexMonotone3Helper                       xPrev xNext gPrev gNext fAverage eta3 prevPrimitive 
                                                = new ConvexMonotone3HelperModel (xPrev, xNext, gPrev, gNext, fAverage, eta3, prevPrimitive)
let ConvexMonotone4Helper                       xPrev xNext gPrev gNext fAverage eta4 prevPrimitive 
                                                = new ConvexMonotone4HelperModel (xPrev, xNext, gPrev, gNext, fAverage, eta4, prevPrimitive)
let ConvexMonotone4MinHelper                    xPrev xNext gPrev gNext fAverage eta4 prevPrimitive 
                                                = new ConvexMonotone4MinHelperModel (xPrev, xNext, gPrev, gNext, fAverage, eta4, prevPrimitive)
let ConvexMonotoneInterpolation                 xBegin size yBegin quadraticity monotonicity forcePositive flatFinalPeriod preExistingHelpers 
                                                = new ConvexMonotoneInterpolationModel (xBegin, size, yBegin, quadraticity, monotonicity, forcePositive, flatFinalPeriod, preExistingHelpers)
let ConvexMonotoneInterpolation1                xBegin size yBegin quadraticity monotonicity forcePositive flatFinalPeriod 
                                                = new ConvexMonotoneInterpolationModel1 (xBegin, size, yBegin, quadraticity, monotonicity, forcePositive, flatFinalPeriod)
let COPCurrency                                 ()
                                                = new COPCurrencyModel ()
let CounterpartyAdjSwapEngine                   discountCurve blackVol ctptyDTS ctptyRecoveryRate invstDTS invstRecoveryRate 
                                                = new CounterpartyAdjSwapEngineModel (discountCurve, blackVol, ctptyDTS, ctptyRecoveryRate, invstDTS, invstRecoveryRate)
let CounterpartyAdjSwapEngine1                  discountCurve blackVol ctptyDTS ctptyRecoveryRate invstDTS invstRecoveryRate 
                                                = new CounterpartyAdjSwapEngineModel1 (discountCurve, blackVol, ctptyDTS, ctptyRecoveryRate, invstDTS, invstRecoveryRate)
let CounterpartyAdjSwapEngine2                  discountCurve swaptionEngine ctptyDTS ctptyRecoveryRate invstDTS invstRecoveryRate 
                                                = new CounterpartyAdjSwapEngineModel2 (discountCurve, swaptionEngine, ctptyDTS, ctptyRecoveryRate, invstDTS, invstRecoveryRate)
let CouponConversion                            date rate 
                                                = new CouponConversionModel (date, rate)
let CoxIngersollRoss                            r0 theta k sigma 
                                                = new CoxIngersollRossModel (r0, theta, k, sigma)
let CoxRossRubinstein                           ()
                                                = new CoxRossRubinsteinModel ()
let CoxRossRubinstein1                          Process End steps strike 
                                                = new CoxRossRubinsteinModel1 (Process, End, steps, strike)
let CPIBond                                     settlementDays faceAmount growthOnly baseCPI observationLag cpiIndex observationInterpolation schedule fixedRate accrualDayCounter paymentConvention issueDate paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth pricingEngine evaluationDate 
                                                = new CPIBondModel (settlementDays, faceAmount, growthOnly, baseCPI, observationLag, cpiIndex, observationInterpolation, schedule, fixedRate, accrualDayCounter, paymentConvention, issueDate, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, pricingEngine, evaluationDate)
let CPIBondHelper                               price settlementDays faceAmount growthOnly baseCPI observationLag cpiIndex observationInterpolation schedule fixedRate accrualDayCounter paymentConvention issueDate paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth useCleanPrice 
                                                = new CPIBondHelperModel (price, settlementDays, faceAmount, growthOnly, baseCPI, observationLag, cpiIndex, observationInterpolation, schedule, fixedRate, accrualDayCounter, paymentConvention, issueDate, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, useCleanPrice)
let CPICapFloor                                 Type nominal startDate baseCPI maturity fixCalendar fixConvention payCalendar payConvention strike infIndex observationLag observationInterpolation pricingEngine evaluationDate 
                                                = new CPICapFloorModel (Type, nominal, startDate, baseCPI, maturity, fixCalendar, fixConvention, payCalendar, payConvention, strike, infIndex, observationLag, observationInterpolation, pricingEngine, evaluationDate)
let CPICashFlow                                 notional index baseDate baseFixing fixingDate paymentDate growthOnly interpolation frequency 
                                                = new CPICashFlowModel (notional, index, baseDate, baseFixing, fixingDate, paymentDate, growthOnly, interpolation, frequency)
let CPICoupon                                   baseCPI paymentDate nominal startDate endDate fixingDays index observationLag observationInterpolation dayCounter fixedRate spread refPeriodStart refPeriodEnd exCouponDate 
                                                = new CPICouponModel (baseCPI, paymentDate, nominal, startDate, endDate, fixingDays, index, observationLag, observationInterpolation, dayCounter, fixedRate, spread, refPeriodStart, refPeriodEnd, exCouponDate)
let CPICouponPricer                             capletVol 
                                                = new CPICouponPricerModel (capletVol)
let CPILeg                                      schedule index baseCPI observationLag 
                                                = new CPILegModel (schedule, index, baseCPI, observationLag)
let CPISwap                                     Type nominal subtractInflationNominal spread floatDayCount floatSchedule floatPaymentRoll fixingDays floatIndex fixedRate baseCPI fixedDayCount fixedSchedule fixedPaymentRoll observationLag fixedIndex observationInterpolation inflationNominal pricingEngine evaluationDate 
                                                = new CPISwapModel (Type, nominal, subtractInflationNominal, spread, floatDayCount, floatSchedule, floatPaymentRoll, fixingDays, floatIndex, fixedRate, baseCPI, fixedDayCount, fixedSchedule, fixedPaymentRoll, observationLag, fixedIndex, observationInterpolation, inflationNominal, pricingEngine, evaluationDate)
let CraigSneydScheme                            theta mu map bcSet 
                                                = new CraigSneydSchemeModel (theta, mu, map, bcSet)
let CraigSneydScheme1                           ()
                                                = new CraigSneydSchemeModel1 ()
let CrankNicolson<'Operator when 'Operator :> IOperator> ()
                                                = new CrankNicolsonModel<'Operator> ()
let CrankNicolson1                              L bcs 
                                                = new CrankNicolsonModel1<'Operator> (L, bcs)
let CrankNicolsonScheme                         theta map bcSet relTol solverType 
                                                = new CrankNicolsonSchemeModel (theta, map, bcSet, relTol, solverType)
let CrankNicolsonScheme1                        ()
                                                = new CrankNicolsonSchemeModel1 ()
let CreditDefaultSwap                           side notional spread schedule convention dayCounter settlesAccrual paysAtDefaultTime protectionStart claim lastPeriodDayCounter rebatesAccrual pricingEngine evaluationDate 
                                                = new CreditDefaultSwapModel (side, notional, spread, schedule, convention, dayCounter, settlesAccrual, paysAtDefaultTime, protectionStart, claim, lastPeriodDayCounter, rebatesAccrual, pricingEngine, evaluationDate)
let CreditDefaultSwap1                          side notional upfront runningSpread schedule convention dayCounter settlesAccrual paysAtDefaultTime protectionStart upfrontDate claim lastPeriodDayCounter rebatesAccrual pricingEngine evaluationDate 
                                                = new CreditDefaultSwapModel1 (side, notional, upfront, runningSpread, schedule, convention, dayCounter, settlesAccrual, paysAtDefaultTime, protectionStart, upfrontDate, claim, lastPeriodDayCounter, rebatesAccrual, pricingEngine, evaluationDate)
let Cubic                                       da monotonic leftCondition leftConditionValue rightCondition rightConditionValue 
                                                = new CubicModel (da, monotonic, leftCondition, leftConditionValue, rightCondition, rightConditionValue)
let Cubic1                                      ()
                                                = new CubicModel1 ()
let CubicBSplinesFitting                        knots constrainAtZero weights optimizationMethod 
                                                = new CubicBSplinesFittingModel (knots, constrainAtZero, weights, optimizationMethod)
let CubicInterpolation                          xBegin size yBegin da monotonic leftCond leftConditionValue rightCond rightConditionValue 
                                                = new CubicInterpolationModel (xBegin, size, yBegin, da, monotonic, leftCond, leftConditionValue, rightCond, rightConditionValue)
let CubicNaturalSpline                          xBegin size yBegin 
                                                = new CubicNaturalSplineModel (xBegin, size, yBegin)
let CubicSplineOvershootingMinimization1        xBegin size yBegin 
                                                = new CubicSplineOvershootingMinimization1Model (xBegin, size, yBegin)
let CubicSplineOvershootingMinimization2        xBegin size yBegin 
                                                = new CubicSplineOvershootingMinimization2Model (xBegin, size, yBegin)
let CumulativeBinomialDistribution              p n 
                                                = new CumulativeBinomialDistributionModel (p, n)
let CumulativeChiSquareDistribution             df 
                                                = new CumulativeChiSquareDistributionModel (df)
let CumulativeGammaDistribution                 a 
                                                = new CumulativeGammaDistributionModel (a)
let CumulativeNormalDistribution                ()
                                                = new CumulativeNormalDistributionModel ()
let CumulativeNormalDistribution1               average sigma 
                                                = new CumulativeNormalDistributionModel1 (average, sigma)
let Currency                                    ()
                                                = new CurrencyModel ()
let Currency1                                   name code numericCode symbol fractionSymbol fractionsPerUnit rounding formatString 
                                                = new CurrencyModel1 (name, code, numericCode, symbol, fractionSymbol, fractionsPerUnit, rounding, formatString)
let Currency2                                   name code numericCode symbol fractionSymbol fractionsPerUnit rounding formatString triangulationCurrency 
                                                = new CurrencyModel2 (name, code, numericCode, symbol, fractionSymbol, fractionsPerUnit, rounding, formatString, triangulationCurrency)
let CYPCurrency                                 ()
                                                = new CYPCurrencyModel ()
let CzechRepublic                               ()
                                                = new CzechRepublicModel ()
let CZKCurrency                                 ()
                                                = new CZKCurrencyModel ()
let DailyTenorCHFLibor                          settlementDays h 
                                                = new DailyTenorCHFLiborModel (settlementDays, h)
let DailyTenorEURLibor                          settlementDays h 
                                                = new DailyTenorEURLiborModel (settlementDays, h)
let DailyTenorEURLibor1                         ()
                                                = new DailyTenorEURLiborModel1 ()
let DailyTenorEURLibor2                         settlementDays 
                                                = new DailyTenorEURLiborModel2 (settlementDays)
let DailyTenorGBPLibor                          settlementDays h 
                                                = new DailyTenorGBPLiborModel (settlementDays, h)
let DailyTenorJPYLibor                          settlementDays 
                                                = new DailyTenorJPYLiborModel (settlementDays)
let DailyTenorJPYLibor1                         settlementDays h 
                                                = new DailyTenorJPYLiborModel1 (settlementDays, h)
let DailyTenorLibor                             familyName settlementDays currency financialCenterCalendar dayCounter 
                                                = new DailyTenorLiborModel (familyName, settlementDays, currency, financialCenterCalendar, dayCounter)
let DailyTenorLibor1                            familyName settlementDays currency financialCenterCalendar dayCounter h 
                                                = new DailyTenorLiborModel1 (familyName, settlementDays, currency, financialCenterCalendar, dayCounter, h)
let DailyTenorUSDLibor                          settlementDays h 
                                                = new DailyTenorUSDLiborModel (settlementDays, h)
let DailyTenorUSDLibor1                         settlementDays 
                                                = new DailyTenorUSDLiborModel1 (settlementDays)
let Date                                        ()
                                                = new DateModel ()
let Date1                                       serialNumber 
                                                = new DateModel1 (serialNumber)
let Date2                                       d m y h mi s ms 
                                                = new DateModel2 (d, m, y, h, mi, s, ms)
let Date3                                       d m y 
                                                = new DateModel3 (d, m, y)
let Date4                                       d 
                                                = new DateModel4 (d)
let Date5                                       d m y h mi s ms 
                                                = new DateModel5 (d, m, y, h, mi, s, ms)
let DatedOISRateHelper                          startDate endDate fixedRate overnightIndex 
                                                = new DatedOISRateHelperModel (startDate, endDate, fixedRate, overnightIndex)
let DayCounter                                  d 
                                                = new DayCounterModel (d)
let DayCounter1                                 ()
                                                = new DayCounterModel1 ()
let Default                                     ()
                                                = new DefaultModel ()
let DefaultDensity                              ()
                                                = new DefaultDensityModel ()
let DeltaVolQuote                               vol deltaType maturity atmType 
                                                = new DeltaVolQuoteModel (vol, deltaType, maturity, atmType)
let DeltaVolQuote1                              delta vol maturity deltaType 
                                                = new DeltaVolQuoteModel1 (delta, vol, maturity, deltaType)
let DEMCurrency                                 ()
                                                = new DEMCurrencyModel ()
let Denmark                                     ()
                                                = new DenmarkModel ()
let DepositRateHelper                           rate tenor fixingDays calendar convention endOfMonth dayCounter 
                                                = new DepositRateHelperModel (rate, tenor, fixingDays, calendar, convention, endOfMonth, dayCounter)
let DepositRateHelper1                          rate i 
                                                = new DepositRateHelperModel1 (rate, i)
let DepositRateHelper2                          rate i 
                                                = new DepositRateHelperModel2 (rate, i)
let DepositRateHelper3                          rate tenor fixingDays calendar convention endOfMonth dayCounter 
                                                = new DepositRateHelperModel3 (rate, tenor, fixingDays, calendar, convention, endOfMonth, dayCounter)
let DerivedQuote                                element f 
                                                = new DerivedQuoteModel (element, f)
let DifferentialEvolution                       configuration 
                                                = new DifferentialEvolutionModel (configuration)
let DigitalCmsCoupon                            underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
                                                = new DigitalCmsCouponModel (underlying, callStrike, callPosition, isCallATMIncluded, callDigitalPayoff, putStrike, putPosition, isPutATMIncluded, putDigitalPayoff, replication)
let DigitalCmsCoupon1                           ()
                                                = new DigitalCmsCouponModel1 ()
let DigitalCmsLeg                               schedule index 
                                                = new DigitalCmsLegModel (schedule, index)
let DigitalCoupon                               underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
                                                = new DigitalCouponModel (underlying, callStrike, callPosition, isCallATMIncluded, callDigitalPayoff, putStrike, putPosition, isPutATMIncluded, putDigitalPayoff, replication)
let DigitalCoupon1                              ()
                                                = new DigitalCouponModel1 ()
let DigitalIborCoupon                           ()
                                                = new DigitalIborCouponModel ()
let DigitalIborCoupon1                          underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
                                                = new DigitalIborCouponModel1 (underlying, callStrike, callPosition, isCallATMIncluded, callDigitalPayoff, putStrike, putPosition, isPutATMIncluded, putDigitalPayoff, replication)
let DigitalIborLeg                              schedule index 
                                                = new DigitalIborLegModel (schedule, index)
let DigitalNotionalRisk                         paymentOffset threshold 
                                                = new DigitalNotionalRiskModel (paymentOffset, threshold)
let DigitalReplication                          t gap 
                                                = new DigitalReplicationModel (t, gap)
let Discount                                    ()
                                                = new DiscountModel ()
let DiscountingBasisSwapEngine                  discountCurve1 discountCurve2 
                                                = new DiscountingBasisSwapEngineModel (discountCurve1, discountCurve2)
let DiscountingBondEngine                       discountCurve includeSettlementDateFlows 
                                                = new DiscountingBondEngineModel (discountCurve, includeSettlementDateFlows)
let DiscountingLoanEngine                       discountCurve includeSettlementDateFlows 
                                                = new DiscountingLoanEngineModel (discountCurve, includeSettlementDateFlows)
let DiscountingSwapEngine                       discountCurve includeSettlementDateFlows settlementDate npvDate 
                                                = new DiscountingSwapEngineModel (discountCurve, includeSettlementDateFlows, settlementDate, npvDate)
let DiscrepancyStatistics                       dimension 
                                                = new DiscrepancyStatisticsModel (dimension)
let DiscreteAveragingAsianOption                averageType runningAccumulator pastFixings fixingDates payoff exercise pricingEngine evaluationDate 
                                                = new DiscreteAveragingAsianOptionModel (averageType, runningAccumulator, pastFixings, fixingDates, payoff, exercise, pricingEngine, evaluationDate)
let DiscreteSimpsonIntegral                     ()
                                                = new DiscreteSimpsonIntegralModel ()
let DiscreteSimpsonIntegrator                   evaluations 
                                                = new DiscreteSimpsonIntegratorModel (evaluations)
let DiscreteTrapezoidIntegral                   ()
                                                = new DiscreteTrapezoidIntegralModel ()
let DiscreteTrapezoidIntegrator                 evaluations 
                                                = new DiscreteTrapezoidIntegratorModel (evaluations)
let DiscretizedBarrierOption                    args Process grid 
                                                = new DiscretizedBarrierOptionModel (args, Process, grid)
let DiscretizedCallableFixedRateBond            args referenceDate dayCounter 
                                                = new DiscretizedCallableFixedRateBondModel (args, referenceDate, dayCounter)
let DiscretizedCapFloor                         args referenceDate dayCounter 
                                                = new DiscretizedCapFloorModel (args, referenceDate, dayCounter)
let DiscretizedConvertible                      args Process grid 
                                                = new DiscretizedConvertibleModel (args, Process, grid)
let DiscretizedDermanKaniBarrierOption          args Process grid 
                                                = new DiscretizedDermanKaniBarrierOptionModel (args, Process, grid)
let DiscretizedDermanKaniDoubleBarrierOption    args Process grid 
                                                = new DiscretizedDermanKaniDoubleBarrierOptionModel (args, Process, grid)
let DiscretizedDiscountBond                     ()
                                                = new DiscretizedDiscountBondModel ()
let DiscretizedDoubleBarrierOption              args Process grid 
                                                = new DiscretizedDoubleBarrierOptionModel (args, Process, grid)
let DiscretizedOption                           underlying exerciseType exerciseTimes 
                                                = new DiscretizedOptionModel (underlying, exerciseType, exerciseTimes)
let DiscretizedSwap                             args referenceDate dayCounter 
                                                = new DiscretizedSwapModel (args, referenceDate, dayCounter)
let DiscretizedSwaption                         args referenceDate dayCounter 
                                                = new DiscretizedSwaptionModel (args, referenceDate, dayCounter)
let DiscretizedVanillaOption                    args Process grid 
                                                = new DiscretizedVanillaOptionModel (args, Process, grid)
let DividendBarrierOption                       barrierType barrier rebate payoff exercise dividendDates dividends pricingEngine evaluationDate 
                                                = new DividendBarrierOptionModel (barrierType, barrier, rebate, payoff, exercise, dividendDates, dividends, pricingEngine, evaluationDate)
let DividendVanillaOption                       payoff exercise dividendDates dividends pricingEngine evaluationDate 
                                                = new DividendVanillaOptionModel (payoff, exercise, dividendDates, dividends, pricingEngine, evaluationDate)
let DKKCurrency                                 ()
                                                = new DKKCurrencyModel ()
let DKKLibor                                    tenor h 
                                                = new DKKLiborModel (tenor, h)
let DKKLibor1                                   tenor 
                                                = new DKKLiborModel1 (tenor)
let DMinus                                      gridPoints h 
                                                = new DMinusModel (gridPoints, h)
let DoubleBarrierOption                         barrierType barrier_lo barrier_hi rebate payoff exercise pricingEngine evaluationDate 
                                                = new DoubleBarrierOptionModel (barrierType, barrier_lo, barrier_hi, rebate, payoff, exercise, pricingEngine, evaluationDate)
let DoublingConvergenceSteps                    ()
                                                = new DoublingConvergenceStepsModel ()
let DouglasScheme                               theta map bcSet 
                                                = new DouglasSchemeModel (theta, map, bcSet)
let DouglasScheme1                              ()
                                                = new DouglasSchemeModel1 ()
let DownRounding                                precision digit 
                                                = new DownRoundingModel (precision, digit)
let DownRounding1                               precision 
                                                = new DownRoundingModel1 (precision)
let DPlus                                       gridPoints h 
                                                = new DPlusModel (gridPoints, h)
let DPlusDMinus                                 gridPoints h 
                                                = new DPlusDMinusModel (gridPoints, h)
let DZero                                       gridPoints h 
                                                = new DZeroModel (gridPoints, h)
let EarlyExercise                               Type payoffAtExpiry 
                                                = new EarlyExerciseModel (Type, payoffAtExpiry)
let EEKCurrency                                 ()
                                                = new EEKCurrencyModel ()
let EndCriteria                                 maxIterations maxStationaryStateIterations rootEpsilon functionEpsilon gradientNormEpsilon 
                                                = new EndCriteriaModel (maxIterations, maxStationaryStateIterations, rootEpsilon, functionEpsilon, gradientNormEpsilon)
let Eonia                                       h 
                                                = new EoniaModel (h)
let Eonia1                                      ()
                                                = new EoniaModel1 ()
let eqn3                                        h k Asr 
                                                = new eqn3Model (h, k, Asr)
let eqn6                                        a c d bs hk 
                                                = new eqn6Model (a, c, d, bs, hk)
let equal_on_first                              ()
                                                = new equal_on_firstModel ()
let EqualJumpsBinomialTree                      Process End steps 
                                                = new EqualJumpsBinomialTreeModel<'T> (Process, End, steps)
let EqualJumpsBinomialTree1<'T>                 ()    
                                                = new EqualJumpsBinomialTreeModel1<'T> ()
let EqualProbabilitiesBinomialTree<'T>          ()   
                                                = new EqualProbabilitiesBinomialTreeModel<'T> ()
let EqualProbabilitiesBinomialTree1             Process End steps 
                                                = new EqualProbabilitiesBinomialTreeModel1<'T> (Process, End, steps)
let ESPCurrency                                 ()
                                                = new ESPCurrencyModel ()
let EUHICP                                      interpolated 
                                                = new EUHICPModel (interpolated)
let EUHICP1                                     interpolated ts 
                                                = new EUHICPModel1 (interpolated, ts)
let EulerDiscretization                         ()
                                                = new EulerDiscretizationModel ()
let EURCurrency                                 ()
                                                = new EURCurrencyModel ()
let EURegion                                    ()
                                                = new EURegionModel ()
let Euribor                                     tenor h 
                                                = new EuriborModel (tenor, h)
let Euribor1                                    tenor 
                                                = new EuriborModel1 (tenor)
let Euribor1M                                   h 
                                                = new Euribor1MModel (h)
let Euribor1M1                                  ()
                                                = new Euribor1MModel1 ()
let Euribor1Y                                   h 
                                                = new Euribor1YModel (h)
let Euribor1Y1                                  ()
                                                = new Euribor1YModel1 ()
let Euribor2M                                   ()
                                                = new Euribor2MModel ()
let Euribor2M1                                  h 
                                                = new Euribor2MModel1 (h)
let Euribor2W                                   h 
                                                = new Euribor2WModel (h)
let Euribor2W1                                  ()
                                                = new Euribor2WModel1 ()
let Euribor365                                  tenor h 
                                                = new Euribor365Model (tenor, h)
let Euribor3651                                 tenor 
                                                = new Euribor365Model1 (tenor)
let Euribor3M                                   ()
                                                = new Euribor3MModel ()
let Euribor3M1                                  h 
                                                = new Euribor3MModel1 (h)
let Euribor3W                                   h 
                                                = new Euribor3WModel (h)
let Euribor3W1                                  ()
                                                = new Euribor3WModel1 ()
let Euribor4M                                   h 
                                                = new Euribor4MModel (h)
let Euribor4M1                                  ()
                                                = new Euribor4MModel1 ()
let Euribor5M                                   h 
                                                = new Euribor5MModel (h)
let Euribor5M1                                  ()
                                                = new Euribor5MModel1 ()
let Euribor6M                                   h 
                                                = new Euribor6MModel (h)
let Euribor6M1                                  ()
                                                = new Euribor6MModel1 ()
let EuriborSW                                   h 
                                                = new EuriborSWModel (h)
let EuriborSW1                                  ()
                                                = new EuriborSWModel1 ()
let EuriborSwapIfrFix                           tenor forwarding discounting 
                                                = new EuriborSwapIfrFixModel (tenor, forwarding, discounting)
let EuriborSwapIfrFix1                          tenor h 
                                                = new EuriborSwapIfrFixModel1 (tenor, h)
let EuriborSwapIfrFix2                          tenor 
                                                = new EuriborSwapIfrFixModel2 (tenor)
let EuriborSwapIsdaFixA                         tenor 
                                                = new EuriborSwapIsdaFixAModel (tenor)
let EuriborSwapIsdaFixA1                        tenor h 
                                                = new EuriborSwapIsdaFixAModel1 (tenor, h)
let EuriborSwapIsdaFixA2                        tenor forwarding discounting 
                                                = new EuriborSwapIsdaFixAModel2 (tenor, forwarding, discounting)
let EuriborSwapIsdaFixB                         tenor 
                                                = new EuriborSwapIsdaFixBModel (tenor)
let EuriborSwapIsdaFixB1                        tenor forwarding discounting 
                                                = new EuriborSwapIsdaFixBModel1 (tenor, forwarding, discounting)
let EuriborSwapIsdaFixB2                        tenor h 
                                                = new EuriborSwapIsdaFixBModel2 (tenor, h)
let EURLibor                                    tenor 
                                                = new EURLiborModel (tenor)
let EURLibor1                                   tenor h 
                                                = new EURLiborModel1 (tenor, h)
let EURLibor10M                                 ()
                                                = new EURLibor10MModel ()
let EURLibor10M1                                h 
                                                = new EURLibor10MModel1 (h)
let EURLibor11M                                 ()
                                                = new EURLibor11MModel ()
let EURLibor11M1                                h 
                                                = new EURLibor11MModel1 (h)
let EURLibor1M                                  h 
                                                = new EURLibor1MModel (h)
let EURLibor1M1                                 ()
                                                = new EURLibor1MModel1 ()
let EURLibor1Y                                  h 
                                                = new EURLibor1YModel (h)
let EURLibor1Y1                                 ()
                                                = new EURLibor1YModel1 ()
let EURLibor2M                                  h 
                                                = new EURLibor2MModel (h)
let EURLibor2M1                                 ()
                                                = new EURLibor2MModel1 ()
let EURLibor2W                                  h 
                                                = new EURLibor2WModel (h)
let EURLibor2W1                                 ()
                                                = new EURLibor2WModel1 ()
let EURLibor3M                                  h 
                                                = new EURLibor3MModel (h)
let EURLibor3M1                                 ()
                                                = new EURLibor3MModel1 ()
let EURLibor4M                                  ()
                                                = new EURLibor4MModel ()
let EURLibor4M1                                 h 
                                                = new EURLibor4MModel1 (h)
let EURLibor5M                                  h 
                                                = new EURLibor5MModel (h)
let EURLibor5M1                                 ()
                                                = new EURLibor5MModel1 ()
let EURLibor6M                                  h 
                                                = new EURLibor6MModel (h)
let EURLibor6M1                                 ()
                                                = new EURLibor6MModel1 ()
let EURLibor7M                                  h 
                                                = new EURLibor7MModel (h)
let EURLibor7M1                                 ()
                                                = new EURLibor7MModel1 ()
let EURLibor8M                                  h 
                                                = new EURLibor8MModel (h)
let EURLibor8M1                                 ()
                                                = new EURLibor8MModel1 ()
let EURLibor9M                                  h 
                                                = new EURLibor9MModel (h)
let EURLibor9M1                                 ()
                                                = new EURLibor9MModel1 ()
let EURLiborON                                  h 
                                                = new EURLiborONModel (h)
let EURLiborON1                                 
                                                = new EURLiborONModel1 ()
let EURLiborSW                                  h 
                                                = new EURLiborSWModel (h)
let EURLiborSW1                                 ()
                                                = new EURLiborSWModel1 ()
let EurLiborSwapIfrFix                          tenor h 
                                                = new EurLiborSwapIfrFixModel (tenor, h)
let EurLiborSwapIfrFix1                         tenor 
                                                = new EurLiborSwapIfrFixModel1 (tenor)
let EurLiborSwapIfrFix2                         tenor forwarding discounting 
                                                = new EurLiborSwapIfrFixModel2 (tenor, forwarding, discounting)
let EurLiborSwapIsdaFixA                        tenor forwarding discounting 
                                                = new EurLiborSwapIsdaFixAModel (tenor, forwarding, discounting)
let EurLiborSwapIsdaFixA1                       tenor h 
                                                = new EurLiborSwapIsdaFixAModel1 (tenor, h)
let EurLiborSwapIsdaFixA2                       tenor 
                                                = new EurLiborSwapIsdaFixAModel2 (tenor)
let EurLiborSwapIsdaFixB                        tenor h 
                                                = new EurLiborSwapIsdaFixBModel (tenor, h)
let EurLiborSwapIsdaFixB1                       tenor 
                                                = new EurLiborSwapIsdaFixBModel1 (tenor)
let EurLiborSwapIsdaFixB2                       tenor forwarding discounting 
                                                = new EurLiborSwapIsdaFixBModel2 (tenor, forwarding, discounting)
let EuropeanExercise                            date 
                                                = new EuropeanExerciseModel (date)
let EuropeanHestonPathPricer                    Type strike discount 
                                                = new EuropeanHestonPathPricerModel (Type, strike, discount)
let EuropeanOption                              payoff exercise pricingEngine evaluationDate 
                                                = new EuropeanOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let EuropeanPathPricer                          Type strike discount 
                                                = new EuropeanPathPricerModel (Type, strike, discount)
let EventSet                                    events eventsStart eventsEnd 
                                                = new EventSetModel (events, eventsStart, eventsEnd)
let EventSetSimulation                          events eventsStart eventsEnd start End 
                                                = new EventSetSimulationModel (events, eventsStart, eventsEnd, start, End)
let EverywhereConstantHelper                    value prevPrimitive xPrev 
                                                = new EverywhereConstantHelperModel (value, prevPrimitive, xPrev)
let ExchangeRate                                source target rate 
                                                = new ExchangeRateModel (source, target, rate)
let ExchangeRate1                               ()
                                                = new ExchangeRateModel1 ()
let Exercise                                    Type 
                                                = new ExerciseModel (Type)
let ExplicitEuler<'Operator when 'Operator :> IOperator>                               
                                                = new ExplicitEulerModel<'Operator> ()
let ExplicitEuler1                              L bcs 
                                                = new ExplicitEulerModel1<'Operator> (L, bcs)
let ExplicitEulerScheme                         map bcSet 
                                                = new ExplicitEulerSchemeModel (map, bcSet)
let ExplicitEulerScheme1                        ()
                                                = new ExplicitEulerSchemeModel1 ()
let ExponentialSplinesFitting                   constrainAtZero weights optimizationMethod 
                                                = new ExponentialSplinesFittingModel (constrainAtZero, weights, optimizationMethod)
let FaceValueAccrualClaim                       referenceSecurity 
                                                = new FaceValueAccrualClaimModel (referenceSecurity)
let FaceValueClaim                              ()
                                                = new FaceValueClaimModel ()
let FastFourierTransform                        order 
                                                = new FastFourierTransformModel (order)
let FDAmericanCondition<'baseEngine when 'baseEngine :> FDConditionEngineTemplate and 'baseEngine : (new : unit -> 'baseEngine)>                         
                                                = new FDAmericanConditionModel<'baseEngine> ()
let FDAmericanCondition1                        Process timeSteps gridPoints timeDependent 
                                                = new FDAmericanConditionModel1<'baseEngine> (Process, timeSteps, gridPoints, timeDependent)
let FDAmericanEngine                            ()
                                                = new FDAmericanEngineModel ()
let FDAmericanEngine1                           Process timeSteps gridPoints timeDependent 
                                                = new FDAmericanEngineModel1 (Process, timeSteps, gridPoints, timeDependent)
let FDBermudanEngine                            Process timeSteps gridPoints timeDependent 
                                                = new FDBermudanEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FdBlackScholesBarrierEngine                 Process tGrid xGrid dampingSteps schemeDesc localVol illegalLocalVolOverwrite 
                                                = new FdBlackScholesBarrierEngineModel (Process, tGrid, xGrid, dampingSteps, schemeDesc, localVol, illegalLocalVolOverwrite)
let FdBlackScholesRebateEngine                  Process tGrid xGrid dampingSteps schemeDesc localVol illegalLocalVolOverwrite 
                                                = new FdBlackScholesRebateEngineModel (Process, tGrid, xGrid, dampingSteps, schemeDesc, localVol, illegalLocalVolOverwrite)
let FdBlackScholesVanillaEngine                 Process tGrid xGrid dampingSteps schemeDesc localVol illegalLocalVolOverwrite cashDividendModel 
                                                = new FdBlackScholesVanillaEngineModel (Process, tGrid, xGrid, dampingSteps, schemeDesc, localVol, illegalLocalVolOverwrite, cashDividendModel)
let FdBlackScholesVanillaEngine1                Process quantoHelper tGrid xGrid dampingSteps schemeDesc localVol illegalLocalVolOverwrite cashDividendModel 
                                                = new FdBlackScholesVanillaEngineModel1 (Process, quantoHelper, tGrid, xGrid, dampingSteps, schemeDesc, localVol, illegalLocalVolOverwrite, cashDividendModel)
let FDConditionEngineTemplate                   ()
                                                = new FDConditionEngineTemplateModel ()
let FDConditionEngineTemplate1                  Process timeSteps gridPoints timeDependent 
                                                = new FDConditionEngineTemplateModel1 (Process, timeSteps, gridPoints, timeDependent)
let FDConditionTemplate<'baseEngine when 'baseEngine :> FDConditionEngineTemplate and 'baseEngine : (new : unit -> 'baseEngine)>                         
                                                = new FDConditionTemplateModel<'baseEngine> ()
let FDConditionTemplate1                        Process timeSteps gridPoints timeDependent 
                                                = new FDConditionTemplateModel1<'baseEngine> (Process, timeSteps, gridPoints, timeDependent)
let FDDividendAmericanEngine                    Process timeSteps gridPoints timeDependent 
                                                = new FDDividendAmericanEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FDDividendAmericanEngine1                   ()
                                                = new FDDividendAmericanEngineModel1 ()
let FDDividendEngine                            ()
                                                = new FDDividendEngineModel ()
let FDDividendEngine1                           Process timeSteps gridPoints timeDependent 
                                                = new FDDividendEngineModel1 (Process, timeSteps, gridPoints, timeDependent)
let FDDividendEngineMerton73                    Process timeSteps gridPoints timeDependent 
                                                = new FDDividendEngineMerton73Model (Process, timeSteps, gridPoints, timeDependent)
let FDDividendEngineMerton731                   ()
                                                = new FDDividendEngineMerton73Model1 ()
let FDDividendEngineShiftScale                  Process timeSteps gridPoints timeDependent 
                                                = new FDDividendEngineShiftScaleModel (Process, timeSteps, gridPoints, timeDependent)
let FDDividendEuropeanEngine                    ()
                                                = new FDDividendEuropeanEngineModel ()
let FDDividendEuropeanEngine1                   Process timeSteps gridPoints timeDependent 
                                                = new FDDividendEuropeanEngineModel1 (Process, timeSteps, gridPoints, timeDependent)
let FDEngineAdapter                             Process timeSteps gridPoints timeDependent 
                                                = new FDEngineAdapterModel<'Base, 'Engine> (Process, timeSteps, gridPoints, timeDependent)
let FDEngineAdapter1<'Base, 'Engine when 'Base :> FDConditionEngineTemplate and 'Base : (new : unit -> 'Base) and 'Engine :> IGenericEngine and 'Engine : (new : unit -> 'Engine)>                            
                                                = new FDEngineAdapterModel1<'Base, 'Engine> ()
let FDEuropeanEngine                            Process timeSteps gridPoints timeDependent 
                                                = new FDEuropeanEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FDEuropeanEngine1                           Process timeSteps gridPoints 
                                                = new FDEuropeanEngineModel1 (Process, timeSteps, gridPoints)
let FdHullWhiteSwaptionEngine                   model tGrid xGrid dampingSteps invEps schemeDesc 
                                                = new FdHullWhiteSwaptionEngineModel (model, tGrid, xGrid, dampingSteps, invEps, schemeDesc)
let Fdm1DimSolver                               solverDesc schemeDesc op 
                                                = new Fdm1DimSolverModel (solverDesc, schemeDesc, op)
let Fdm1dMesher                                 size 
                                                = new Fdm1dMesherModel (size)
let FdmAffineModelSwapInnerValue                disModel fwdModel swap exerciseDates mesher direction 
                                                = new FdmAffineModelSwapInnerValueModel<'ModelType> (disModel, fwdModel, swap, exerciseDates, mesher, direction)
let FdmAffineModelTermStructure                 r cal dayCounter referenceDate modelReferenceDate model 
                                                = new FdmAffineModelTermStructureModel (r, cal, dayCounter, referenceDate, modelReferenceDate, model)
let FdmAmericanStepCondition                    mesher calculator 
                                                = new FdmAmericanStepConditionModel (mesher, calculator)
let FdmBackwardSolver                           map bcSet condition schemeDesc 
                                                = new FdmBackwardSolverModel (map, bcSet, condition, schemeDesc)
let FdmBermudanStepCondition                    exerciseDates referenceDate dayCounter mesher calculator 
                                                = new FdmBermudanStepConditionModel (exerciseDates, referenceDate, dayCounter, mesher, calculator)
let FdmBlackScholesMesher                       size Process maturity strike xMinConstraint xMaxConstraint eps scaleFactor cPoint dividendSchedule fdmQuantoHelper spotAdjustment 
                                                = new FdmBlackScholesMesherModel (size, Process, maturity, strike, xMinConstraint, xMaxConstraint, eps, scaleFactor, cPoint, dividendSchedule, fdmQuantoHelper, spotAdjustment)
let FdmBlackScholesOp                           mesher bsProcess strike localVol illegalLocalVolOverwrite direction quantoHelper 
                                                = new FdmBlackScholesOpModel (mesher, bsProcess, strike, localVol, illegalLocalVolOverwrite, direction, quantoHelper)
let FdmBlackScholesSolver                       Process strike solverDesc schemeDesc localVol illegalLocalVolOverwrite quantoHelper 
                                                = new FdmBlackScholesSolverModel (Process, strike, solverDesc, schemeDesc, localVol, illegalLocalVolOverwrite, quantoHelper)
let FdmDirichletBoundary                        mesher valueOnBoundary direction side 
                                                = new FdmDirichletBoundaryModel (mesher, valueOnBoundary, direction, side)
let FdmDividendHandler                          schedule mesher referenceDate dayCounter equityDirection 
                                                = new FdmDividendHandlerModel (schedule, mesher, referenceDate, dayCounter, equityDirection)
let FdmHullWhiteOp                              mesher model direction 
                                                = new FdmHullWhiteOpModel (mesher, model, direction)
let FdmHullWhiteSolver                          model solverDesc schemeDesc 
                                                = new FdmHullWhiteSolverModel (model, solverDesc, schemeDesc)
let FdmIndicesOnBoundary                        layout direction side 
                                                = new FdmIndicesOnBoundaryModel (layout, direction, side)
let FdmLinearOpIterator                         index 
                                                = new FdmLinearOpIteratorModel (index)
let FdmLinearOpIterator1                        dim 
                                                = new FdmLinearOpIteratorModel1 (dim)
let FdmLinearOpIterator2                        dim coordinates index 
                                                = new FdmLinearOpIteratorModel2 (dim, coordinates, index)
let FdmLinearOpIterator3                        iter 
                                                = new FdmLinearOpIteratorModel3 (iter)
let FdmLinearOpLayout                           dim 
                                                = new FdmLinearOpLayoutModel (dim)
let FdmLogBasketInnerValue                      payoff mesher 
                                                = new FdmLogBasketInnerValueModel (payoff, mesher)
let FdmLogInnerValue                            payoff mesher direction 
                                                = new FdmLogInnerValueModel (payoff, mesher, direction)
let FdmMesherComposite                          layout mesher 
                                                = new FdmMesherCompositeModel (layout, mesher)
let FdmMesherComposite1                         mesher 
                                                = new FdmMesherCompositeModel1 (mesher)
let FdmMesherComposite2                         m1 m2 m3 m4 
                                                = new FdmMesherCompositeModel2 (m1, m2, m3, m4)
let FdmMesherComposite3                         mesher 
                                                = new FdmMesherCompositeModel3 (mesher)
let FdmMesherComposite4                         m1 m2 
                                                = new FdmMesherCompositeModel4 (m1, m2)
let FdmMesherComposite5                         m1 m2 m3 
                                                = new FdmMesherCompositeModel5 (m1, m2, m3)
let FdmMesherIntegral                           mesher integrator1d 
                                                = new FdmMesherIntegralModel (mesher, integrator1d)
let FdmQuantoHelper                             rTS fTS fxVolTS equityFxCorrelation exchRateATMlevel 
                                                = new FdmQuantoHelperModel (rTS, fTS, fxVolTS, equityFxCorrelation, exchRateATMlevel)
let FdmSchemeDesc                               Type theta mu 
                                                = new FdmSchemeDescModel (Type, theta, mu)
let FdmSchemeDesc1                              ()
                                                = new FdmSchemeDescModel1 ()
let FdmSimpleProcess1DMesher                    size Process maturity tAvgSteps epsilon mandatoryPoint 
                                                = new FdmSimpleProcess1DMesherModel (size, Process, maturity, tAvgSteps, epsilon, mandatoryPoint)
let FdmSnapshotCondition                        t 
                                                = new FdmSnapshotConditionModel (t)
let FdmSolverDesc                               ()
                                                = new FdmSolverDescModel ()
let FdmStepConditionComposite                   ()
                                                = new FdmStepConditionCompositeModel ()
let FdmStepConditionComposite1                  stoppingTimes conditions 
                                                = new FdmStepConditionCompositeModel1 (stoppingTimes, conditions)
let FDMultiPeriodEngine                         ()
                                                = new FDMultiPeriodEngineModel ()
let FdmZeroInnerValue                           ()
                                                = new FdmZeroInnerValueModel ()
let FDShoutCondition                            Process timeSteps gridPoints timeDependent 
                                                = new FDShoutConditionModel<'baseEngine> (Process, timeSteps, gridPoints, timeDependent)
let FDShoutCondition1<'baseEngine when 'baseEngine :> FDConditionEngineTemplate and 'baseEngine : (new : unit -> 'baseEngine)>                           
                                                = new FDShoutConditionModel1<'baseEngine> ()
let FDShoutEngine                               Process timeSteps gridPoints timeDependent 
                                                = new FDShoutEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FDShoutEngine1                              ()
                                                = new FDShoutEngineModel1 ()
let FDStepConditionEngine                       Process timeSteps gridPoints timeDependent 
                                                = new FDStepConditionEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FDStepConditionEngine1                      ()
                                                = new FDStepConditionEngineModel1 ()
let FDVanillaEngine                             Process timeSteps gridPoints timeDependent 
                                                = new FDVanillaEngineModel (Process, timeSteps, gridPoints, timeDependent)
let FDVanillaEngine1                            ()
                                                = new FDVanillaEngineModel1 ()
let FedFunds                                    h 
                                                = new FedFundsModel (h)
let FIMCurrency                                 ()
                                                = new FIMCurrencyModel ()
let FiniteDifferenceModel                       L bcs stoppingTimes 
                                                = new FiniteDifferenceModelModel<'Evolver> (L, bcs, stoppingTimes)
let FiniteDifferenceModel1                      L bcs 
                                                = new FiniteDifferenceModelModel1<'Evolver> (L, bcs)
let FiniteDifferenceModel2                      evolver stoppingTimes 
                                                = new FiniteDifferenceModelModel2<'Evolver> (evolver, stoppingTimes)
let Finland                                     ()
                                                = new FinlandModel ()
let FirstDerivativeOp                           rhs 
                                                = new FirstDerivativeOpModel (rhs)
let FirstDerivativeOp1                          direction mesher 
                                                = new FirstDerivativeOpModel1 (direction, mesher)
let FittedBondDiscountCurve                     settlementDays calendar bondHelpers dayCounter fittingMethod accuracy maxEvaluations guess simplexLambda maxStationaryStateIterations 
                                                = new FittedBondDiscountCurveModel (settlementDays, calendar, bondHelpers, dayCounter, fittingMethod, accuracy, maxEvaluations, guess, simplexLambda, maxStationaryStateIterations)
let FittedBondDiscountCurve1                    referenceDate bondHelpers dayCounter fittingMethod accuracy maxEvaluations guess simplexLambda maxStationaryStateIterations 
                                                = new FittedBondDiscountCurveModel1 (referenceDate, bondHelpers, dayCounter, fittingMethod, accuracy, maxEvaluations, guess, simplexLambda, maxStationaryStateIterations)
let FixedDividend                               amount date 
                                                = new FixedDividendModel (amount, date)
let FixedLoan                                   Type nominal fixedSchedule fixedRate fixedDayCount principalSchedule paymentConvention pricingEngine evaluationDate 
                                                = new FixedLoanModel (Type, nominal, fixedSchedule, fixedRate, fixedDayCount, principalSchedule, paymentConvention, pricingEngine, evaluationDate)
let FixedLocalVolSurface                        referenceDate times strikes localVolMatrix dayCounter lowerExtrapolation upperExtrapolation 
                                                = new FixedLocalVolSurfaceModel (referenceDate, times, strikes, localVolMatrix, dayCounter, lowerExtrapolation, upperExtrapolation)
let FixedLocalVolSurface1                       referenceDate times strikes localVolMatrix dayCounter lowerExtrapolation upperExtrapolation 
                                                = new FixedLocalVolSurfaceModel1 (referenceDate, times, strikes, localVolMatrix, dayCounter, lowerExtrapolation, upperExtrapolation)
let FixedLocalVolSurface2                       referenceDate dates strikes localVolMatrix dayCounter lowerExtrapolation upperExtrapolation 
                                                = new FixedLocalVolSurfaceModel2 (referenceDate, dates, strikes, localVolMatrix, dayCounter, lowerExtrapolation, upperExtrapolation)
let FixedRateBond                               settlementDays faceAmount schedule coupons accrualDayCounter paymentConvention redemption issueDate paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth pricingEngine evaluationDate 
                                                = new FixedRateBondModel (settlementDays, faceAmount, schedule, coupons, accrualDayCounter, paymentConvention, redemption, issueDate, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, pricingEngine, evaluationDate)
let FixedRateBond1                              settlementDays calendar faceAmount startDate maturityDate tenor coupons accrualDayCounter accrualConvention paymentConvention redemption issueDate stubDate rule endOfMonth paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth pricingEngine evaluationDate 
                                                = new FixedRateBondModel1 (settlementDays, calendar, faceAmount, startDate, maturityDate, tenor, coupons, accrualDayCounter, accrualConvention, paymentConvention, redemption, issueDate, stubDate, rule, endOfMonth, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, pricingEngine, evaluationDate)
let FixedRateBond2                              settlementDays faceAmount schedule coupons paymentConvention redemption issueDate paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth pricingEngine evaluationDate 
                                                = new FixedRateBondModel2 (settlementDays, faceAmount, schedule, coupons, paymentConvention, redemption, issueDate, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, pricingEngine, evaluationDate)
let FixedRateBondForward                        valueDate maturityDate Type strike settlementDays dayCounter calendar businessDayConvention fixedCouponBond discountCurve incomeDiscountCurve pricingEngine evaluationDate 
                                                = new FixedRateBondForwardModel (valueDate, maturityDate, Type, strike, settlementDays, dayCounter, calendar, businessDayConvention, fixedCouponBond, discountCurve, incomeDiscountCurve, pricingEngine, evaluationDate)
let FixedRateBondHelper                         price settlementDays faceAmount schedule coupons dayCounter paymentConvention redemption issueDate paymentCalendar exCouponPeriod exCouponCalendar exCouponConvention exCouponEndOfMonth useCleanPrice 
                                                = new FixedRateBondHelperModel (price, settlementDays, faceAmount, schedule, coupons, dayCounter, paymentConvention, redemption, issueDate, paymentCalendar, exCouponPeriod, exCouponCalendar, exCouponConvention, exCouponEndOfMonth, useCleanPrice)
let FixedRateCoupon                             paymentDate nominal interestRate accrualStartDate accrualEndDate refPeriodStart refPeriodEnd exCouponDate amount 
                                                = new FixedRateCouponModel (paymentDate, nominal, interestRate, accrualStartDate, accrualEndDate, refPeriodStart, refPeriodEnd, exCouponDate, amount)
let FixedRateCoupon1                            paymentDate nominal rate dayCounter accrualStartDate accrualEndDate refPeriodStart refPeriodEnd exCouponDate 
                                                = new FixedRateCouponModel1 (paymentDate, nominal, rate, dayCounter, accrualStartDate, accrualEndDate, refPeriodStart, refPeriodEnd, exCouponDate)
let FixedRateLeg                                schedule 
                                                = new FixedRateLegModel (schedule)
let FlatExtrapolator2D                          decoratedInterpolation 
                                                = new FlatExtrapolator2DModel (decoratedInterpolation)
let FlatForward                                 referenceDate forward dayCounter 
                                                = new FlatForwardModel (referenceDate, forward, dayCounter)
let FlatForward1                                settlementDays calendar forward dayCounter 
                                                = new FlatForwardModel1 (settlementDays, calendar, forward, dayCounter)
let FlatForward2                                settlementDays calendar forward dayCounter compounding frequency 
                                                = new FlatForwardModel2 (settlementDays, calendar, forward, dayCounter, compounding, frequency)
let FlatForward3                                settlementDays calendar forward dayCounter compounding 
                                                = new FlatForwardModel3 (settlementDays, calendar, forward, dayCounter, compounding)
let FlatForward4                                settlementDays calendar forward dayCounter 
                                                = new FlatForwardModel4 (settlementDays, calendar, forward, dayCounter)
let FlatForward5                                settlementDays calendar forward dayCounter compounding frequency 
                                                = new FlatForwardModel5 (settlementDays, calendar, forward, dayCounter, compounding, frequency)
let FlatForward6                                settlementDays calendar forward dayCounter compounding 
                                                = new FlatForwardModel6 (settlementDays, calendar, forward, dayCounter, compounding)
let FlatForward7                                referenceDate forward dayCounter compounding frequency 
                                                = new FlatForwardModel7 (referenceDate, forward, dayCounter, compounding, frequency)
let FlatForward8                                referenceDate forward dayCounter compounding 
                                                = new FlatForwardModel8 (referenceDate, forward, dayCounter, compounding)
let FlatForward9                                referenceDate forward dayCounter 
                                                = new FlatForwardModel9 (referenceDate, forward, dayCounter)
let FlatForward10                               referenceDate forward dayCounter compounding frequency 
                                                = new FlatForwardModel10 (referenceDate, forward, dayCounter, compounding, frequency)
let FlatForward11                               referenceDate forward dayCounter compounding 
                                                = new FlatForwardModel11 (referenceDate, forward, dayCounter, compounding)
let FlatHazardRate                              settlementDays calendar hazardRate dc 
                                                = new FlatHazardRateModel (settlementDays, calendar, hazardRate, dc)
let FlatHazardRate1                             referenceDate hazardRate dc 
                                                = new FlatHazardRateModel1 (referenceDate, hazardRate, dc)
let FlatHazardRate2                             referenceDate hazardRate dc 
                                                = new FlatHazardRateModel2 (referenceDate, hazardRate, dc)
let FlatHazardRate3                             settlementDays calendar hazardRate dc 
                                                = new FlatHazardRateModel3 (settlementDays, calendar, hazardRate, dc)
let FlatSmileSection                            exerciseTime vol dc atmLevel Type shift 
                                                = new FlatSmileSectionModel (exerciseTime, vol, dc, atmLevel, Type, shift)
let FlatSmileSection1                           d vol dc referenceDate atmLevel Type shift 
                                                = new FlatSmileSectionModel1 (d, vol, dc, referenceDate, atmLevel, Type, shift)
let FloatFloatSwap                              Type nominal1 nominal2 schedule1 index1 dayCount1 schedule2 index2 dayCount2 intermediateCapitalExchange finalCapitalExchange gearing1 spread1 cappedRate1 flooredRate1 gearing2 spread2 cappedRate2 flooredRate2 paymentConvention1 paymentConvention2 pricingEngine evaluationDate 
                                                = new FloatFloatSwapModel (Type, nominal1, nominal2, schedule1, index1, dayCount1, schedule2, index2, dayCount2, intermediateCapitalExchange, finalCapitalExchange, gearing1, spread1, cappedRate1, flooredRate1, gearing2, spread2, cappedRate2, flooredRate2, paymentConvention1, paymentConvention2, pricingEngine, evaluationDate)
let FloatFloatSwap1                             Type nominal1 nominal2 schedule1 index1 dayCount1 schedule2 index2 dayCount2 intermediateCapitalExchange finalCapitalExchange gearing1 spread1 cappedRate1 flooredRate1 gearing2 spread2 cappedRate2 flooredRate2 paymentConvention1 paymentConvention2 pricingEngine evaluationDate 
                                                = new FloatFloatSwapModel1 (Type, nominal1, nominal2, schedule1, index1, dayCount1, schedule2, index2, dayCount2, intermediateCapitalExchange, finalCapitalExchange, gearing1, spread1, cappedRate1, flooredRate1, gearing2, spread2, cappedRate2, flooredRate2, paymentConvention1, paymentConvention2, pricingEngine, evaluationDate)
let FloatingCatBond                             settlementDays faceAmount startDate maturityDate couponFrequency calendar iborIndex accrualDayCounter notionalRisk accrualConvention paymentConvention fixingDays gearings spreads caps floors inArrears redemption issueDate stubDate rule endOfMonth pricingEngine evaluationDate 
                                                = new FloatingCatBondModel (settlementDays, faceAmount, startDate, maturityDate, couponFrequency, calendar, iborIndex, accrualDayCounter, notionalRisk, accrualConvention, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, redemption, issueDate, stubDate, rule, endOfMonth, pricingEngine, evaluationDate)
let FloatingCatBond1                            settlementDays faceAmount schedule iborIndex paymentDayCounter notionalRisk paymentConvention fixingDays gearings spreads caps floors inArrears redemption issueDate pricingEngine evaluationDate 
                                                = new FloatingCatBondModel1 (settlementDays, faceAmount, schedule, iborIndex, paymentDayCounter, notionalRisk, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, redemption, issueDate, pricingEngine, evaluationDate)
let FloatingLoan                                Type nominal floatingSchedule floatingSpread floatingDayCount principalSchedule paymentConvention index pricingEngine evaluationDate 
                                                = new FloatingLoanModel (Type, nominal, floatingSchedule, floatingSpread, floatingDayCount, principalSchedule, paymentConvention, index, pricingEngine, evaluationDate)
let FloatingRateBond                            settlementDays faceAmount schedule index paymentDayCounter pricingEngine evaluationDate 
                                                = new FloatingRateBondModel (settlementDays, faceAmount, schedule, index, paymentDayCounter, pricingEngine, evaluationDate)
let FloatingRateBond1                           settlementDays faceAmount schedule index paymentDayCounter paymentConvention fixingDays gearings spreads pricingEngine evaluationDate 
                                                = new FloatingRateBondModel1 (settlementDays, faceAmount, schedule, index, paymentDayCounter, paymentConvention, fixingDays, gearings, spreads, pricingEngine, evaluationDate)
let FloatingRateBond2                           settlementDays faceAmount schedule index paymentDayCounter paymentConvention fixingDays gearings spreads caps floors inArrears redemption issueDate pricingEngine evaluationDate 
                                                = new FloatingRateBondModel2 (settlementDays, faceAmount, schedule, index, paymentDayCounter, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, redemption, issueDate, pricingEngine, evaluationDate)
let FloatingRateBond3                           settlementDays faceAmount startDate maturityDate couponFrequency calendar index accrualDayCounter accrualConvention paymentConvention fixingDays gearings spreads caps floors inArrears redemption issueDate stubDate rule endOfMonth pricingEngine evaluationDate 
                                                = new FloatingRateBondModel3 (settlementDays, faceAmount, startDate, maturityDate, couponFrequency, calendar, index, accrualDayCounter, accrualConvention, paymentConvention, fixingDays, gearings, spreads, caps, floors, inArrears, redemption, issueDate, stubDate, rule, endOfMonth, pricingEngine, evaluationDate)
let FloatingRateCoupon                          paymentDate nominal startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new FloatingRateCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, index, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let FloatingRateCoupon1                         ()
                                                = new FloatingRateCouponModel1 ()
let FloatingTypePayoff                          Type 
                                                = new FloatingTypePayoffModel (Type)
let Floor                                       floatingLeg exerciseRates pricingEngine evaluationDate 
                                                = new FloorModel (floatingLeg, exerciseRates, pricingEngine, evaluationDate)
let FloorTruncation                             precision digit 
                                                = new FloorTruncationModel (precision, digit)
let FloorTruncation1                            precision 
                                                = new FloorTruncationModel1 (precision)
let FordeHestonExpansion                        kappa theta sigma v0 rho term 
                                                = new FordeHestonExpansionModel (kappa, theta, sigma, v0, rho, term)
let ForwardFlat                                 ()
                                                = new ForwardFlatModel ()
let ForwardFlatInterpolation                    xBegin size yBegin 
                                                = new ForwardFlatInterpolationModel (xBegin, size, yBegin)
let ForwardPerformanceVanillaEngine             Process getEngine pricingEngine evaluationDate 
                                                = new ForwardPerformanceVanillaEngineModel (Process, getEngine)
let ForwardRate                                 ()
                                                = new ForwardRateModel ()
let ForwardRateAgreement                        valueDate maturityDate Type strikeForwardRate notionalAmount index discountCurve pricingEngine evaluationDate 
                                                = new ForwardRateAgreementModel (valueDate, maturityDate, Type, strikeForwardRate, notionalAmount, index, discountCurve, pricingEngine, evaluationDate)
let ForwardSpreadedTermStructure                h spread 
                                                = new ForwardSpreadedTermStructureModel (h, spread)
let ForwardTypePayoff                           Type strike 
                                                = new ForwardTypePayoffModel (Type, strike)
let ForwardVanillaEngine                        Process getEngine pricingEngine evaluationDate 
                                                = new ForwardVanillaEngineModel (Process, getEngine, pricingEngine, evaluationDate)
let ForwardVanillaOption                        moneyness resetDate payoff exercise pricingEngine evaluationDate 
                                                = new ForwardVanillaOptionModel (moneyness, resetDate, payoff, exercise, pricingEngine, evaluationDate)
let FractionalDividend                          rate nominal date 
                                                = new FractionalDividendModel (rate, nominal, date)
let FractionalDividend1                         rate date 
                                                = new FractionalDividendModel1 (rate, date)
let FranceRegion                                ()
                                                = new FranceRegionModel ()
let FraRateHelper                               rate periodToStart iborIndex pillarChoice customPillarDate 
                                                = new FraRateHelperModel (rate, periodToStart, iborIndex, pillarChoice, customPillarDate)
let FraRateHelper1                              rate periodToStart iborIndex pillarChoice customPillarDate 
                                                = new FraRateHelperModel1 (rate, periodToStart, iborIndex, pillarChoice, customPillarDate)
let FraRateHelper2                              rate periodToStart lengthInMonths fixingDays calendar convention endOfMonth dayCounter pillarChoice customPillarDate 
                                                = new FraRateHelperModel2 (rate, periodToStart, lengthInMonths, fixingDays, calendar, convention, endOfMonth, dayCounter, pillarChoice, customPillarDate)
let FraRateHelper3                              rate periodToStart lengthInMonths fixingDays calendar convention endOfMonth dayCounter pillarChoice customPillarDate 
                                                = new FraRateHelperModel3 (rate, periodToStart, lengthInMonths, fixingDays, calendar, convention, endOfMonth, dayCounter, pillarChoice, customPillarDate)
let FraRateHelper4                              rate monthsToStart i pillarChoice customPillarDate 
                                                = new FraRateHelperModel4 (rate, monthsToStart, i, pillarChoice, customPillarDate)
let FraRateHelper5                              rate monthsToStart i pillarChoice customPillarDate 
                                                = new FraRateHelperModel5 (rate, monthsToStart, i, pillarChoice, customPillarDate)
let FraRateHelper6                              rate monthsToStart monthsToEnd fixingDays calendar convention endOfMonth dayCounter pillarChoice customPillarDate 
                                                = new FraRateHelperModel6 (rate, monthsToStart, monthsToEnd, fixingDays, calendar, convention, endOfMonth, dayCounter, pillarChoice, customPillarDate)
let FraRateHelper7                              rate monthsToStart monthsToEnd fixingDays calendar convention endOfMonth dayCounter pillarChoice customPillarDate 
                                                = new FraRateHelperModel7 (rate, monthsToStart, monthsToEnd, fixingDays, calendar, convention, endOfMonth, dayCounter, pillarChoice, customPillarDate)
let FRFCurrency                                 ()
                                                = new FRFCurrencyModel ()
let FRHICP                                      interpolated ts 
                                                = new FRHICPModel (interpolated, ts)
let FRHICP1                                     interpolated 
                                                = new FRHICPModel1 (interpolated)
let FritschButlandCubic                         xBegin size yBegin 
                                                = new FritschButlandCubicModel (xBegin, size, yBegin)
let FuturesRateHelper                           price iborStartDate lengthInMonths calendar convention endOfMonth dayCounter convAdj Type 
                                                = new FuturesRateHelperModel (price, iborStartDate, lengthInMonths, calendar, convention, endOfMonth, dayCounter, convAdj, Type)
let FuturesRateHelper1                          price iborStartDate i convAdj Type 
                                                = new FuturesRateHelperModel1 (price, iborStartDate, i, convAdj, Type)
let FuturesRateHelper2                          price iborStartDate i convAdj Type 
                                                = new FuturesRateHelperModel2 (price, iborStartDate, i, convAdj, Type)
let FuturesRateHelper3                          price iborStartDate iborEndDate dayCounter convAdj Type 
                                                = new FuturesRateHelperModel3 (price, iborStartDate, iborEndDate, dayCounter, convAdj, Type)
let FuturesRateHelper4                          price iborStartDate iborEndDate dayCounter convAdj Type 
                                                = new FuturesRateHelperModel4 (price, iborStartDate, iborEndDate, dayCounter, convAdj, Type)
let FuturesRateHelper5                          price iborStartDate lengthInMonths calendar convention endOfMonth dayCounter convexityAdjustment Type 
                                                = new FuturesRateHelperModel5 (price, iborStartDate, lengthInMonths, calendar, convention, endOfMonth, dayCounter, convexityAdjustment, Type)
let FxSwapRateHelper                            fwdPoint spotFx tenor fixingDays calendar convention endOfMonth isFxBaseCurrencyCollateralCurrency coll 
                                                = new FxSwapRateHelperModel (fwdPoint, spotFx, tenor, fixingDays, calendar, convention, endOfMonth, isFxBaseCurrencyCollateralCurrency, coll)
let G2                                          termStructure a sigma b 
                                                = new G2Model (termStructure, a, sigma, b)
let G21                                         termStructure 
                                                = new G2Model1 (termStructure)
let G22                                         termStructure a sigma 
                                                = new G2Model2 (termStructure, a, sigma)
let G23                                         termStructure a sigma b eta 
                                                = new G2Model3 (termStructure, a, sigma, b, eta)
let G24                                         termStructure a sigma b eta rho 
                                                = new G2Model4 (termStructure, a, sigma, b, eta, rho)
let G25                                         termStructure a 
                                                = new G2Model5 (termStructure, a)
let G2SwaptionEngine                            model range intervals 
                                                = new G2SwaptionEngineModel (model, range, intervals)
let GammaDistribution                           a 
                                                = new GammaDistributionModel (a)
let GapPayoff                                   Type strike secondStrike 
                                                = new GapPayoffModel (Type, strike, secondStrike)
let GarmanKohlagenProcess                       x0 foreignRiskFreeTS domesticRiskFreeTS blackVolTS localVolTS d 
                                                = new GarmanKohlagenProcessModel (x0, foreignRiskFreeTS, domesticRiskFreeTS, blackVolTS, localVolTS, d)
let GarmanKohlagenProcess1                      x0 foreignRiskFreeTS domesticRiskFreeTS blackVolTS d 
                                                = new GarmanKohlagenProcessModel1 (x0, foreignRiskFreeTS, domesticRiskFreeTS, blackVolTS, d)
let GarmanKohlagenProcess2                      x0 foreignRiskFreeTS domesticRiskFreeTS blackVolTS 
                                                = new GarmanKohlagenProcessModel2 (x0, foreignRiskFreeTS, domesticRiskFreeTS, blackVolTS)
let GaussChebyshev2ndIntegration                n 
                                                = new GaussChebyshev2ndIntegrationModel (n)
let GaussChebyshev2ndPolynomial                 
                                                = new GaussChebyshev2ndPolynomialModel ()
let GaussChebyshevIntegration                   n 
                                                = new GaussChebyshevIntegrationModel (n)
let GaussChebyshevPolynomial                    ()
                                                = new GaussChebyshevPolynomialModel ()
let GaussGegenbauerIntegration                  n lambda 
                                                = new GaussGegenbauerIntegrationModel (n, lambda)
let GaussGegenbauerPolynomial                   lambda 
                                                = new GaussGegenbauerPolynomialModel (lambda)
let GaussHermiteIntegration                     n mu 
                                                = new GaussHermiteIntegrationModel (n, mu)
let GaussHermitePolynomial                      mu 
                                                = new GaussHermitePolynomialModel (mu)
let GaussHermitePolynomial1                     ()
                                                = new GaussHermitePolynomialModel1 ()
let GaussHyperbolicIntegration                  n 
                                                = new GaussHyperbolicIntegrationModel (n)
let GaussHyperbolicPolynomial                   ()
                                                = new GaussHyperbolicPolynomialModel ()
let GaussianKernel                              average sigma 
                                                = new GaussianKernelModel (average, sigma)
let GaussianQuadrature                          n orthPoly 
                                                = new GaussianQuadratureModel (n, orthPoly)
let GaussJacobiIntegration                      n alpha beta 
                                                = new GaussJacobiIntegrationModel (n, alpha, beta)
let GaussJacobiPolynomial                       alpha beta 
                                                = new GaussJacobiPolynomialModel (alpha, beta)
let GaussKronrodAdaptive                        absoluteAccuracy maxEvaluations 
                                                = new GaussKronrodAdaptiveModel (absoluteAccuracy, maxEvaluations)
let GaussKronrodNonAdaptive                     absoluteAccuracy maxEvaluations relativeAccuracy 
                                                = new GaussKronrodNonAdaptiveModel (absoluteAccuracy, maxEvaluations, relativeAccuracy)
let GaussLaguerreIntegration                    n s 
                                                = new GaussLaguerreIntegrationModel (n, s)
let GaussLaguerrePolynomial                     ()
                                                = new GaussLaguerrePolynomialModel ()
let GaussLaguerrePolynomial1                    s 
                                                = new GaussLaguerrePolynomialModel1 (s)
let GaussLegendreIntegration                    n 
                                                = new GaussLegendreIntegrationModel (n)
let GaussLegendrePolynomial                     
                                                = new GaussLegendrePolynomialModel ()
let GaussLobattoIntegral                        maxIterations absAccuracy relAccuracy useConvergenceEstimate 
                                                = new GaussLobattoIntegralModel (maxIterations, absAccuracy, relAccuracy, useConvergenceEstimate)
let GBPCurrency                                 ()
                                                = new GBPCurrencyModel ()
let GBPLibor                                    tenor h 
                                                = new GBPLiborModel (tenor, h)
let GBPLibor1                                   tenor 
                                                = new GBPLiborModel1 (tenor)
let GBPLiborON                                  h 
                                                = new GBPLiborONModel (h)
let GbpLiborSwapIsdaFix                         tenor h 
                                                = new GbpLiborSwapIsdaFixModel (tenor, h)
let GbpLiborSwapIsdaFix1                        tenor 
                                                = new GbpLiborSwapIsdaFixModel1 (tenor)
let GeneralizedBlackScholesProcess              x0 dividendTS riskFreeTS blackVolTS localVolTS disc 
                                                = new GeneralizedBlackScholesProcessModel (x0, dividendTS, riskFreeTS, blackVolTS, localVolTS, disc)
let GeneralizedBlackScholesProcess1             x0 dividendTS riskFreeTS blackVolTS disc 
                                                = new GeneralizedBlackScholesProcessModel1 (x0, dividendTS, riskFreeTS, blackVolTS, disc)
let GeneralStatistics                           ()
                                                = new GeneralStatisticsModel ()
let GenericGaussianStatistics                   s 
                                                = new GenericGaussianStatisticsModel<'Stat> (s)
let GenericGaussianStatistics1<'Stat when 'Stat :> IGeneralStatistics and 'Stat : (new : unit -> 'Stat)> ()
                                                = new GenericGaussianStatisticsModel1<'Stat> ()
let GenericLowDiscrepancy<'URSG, 'IC when 'URSG :> IRNG and 'URSG : (new : unit -> 'URSG) and 'IC :> IValue and 'IC : (new : unit -> 'IC)> ()
                                                = new GenericLowDiscrepancyModel<'URSG, 'IC> ()
let GenericModelEngine<'ModelType, 'ArgumentsType, 'ResultsType when 'ModelType :> IObservable and 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>                          
                                                = new GenericModelEngineModel<'ModelType, 'ArgumentsType, 'ResultsType> ()
let GenericModelEngine1                         model 
                                                = new GenericModelEngineModel1<'ModelType, 'ArgumentsType, 'ResultsType> (model)
let GenericModelEngine2                         model 
                                                = new GenericModelEngineModel2<'ModelType, 'ArgumentsType, 'ResultsType> (model)
let GenericPseudoRandom<'URNG, 'IC when 'URNG :> IRNGTraits and 'URNG : (new : unit -> 'URNG) and 'IC :> IValue and 'IC : (new : unit -> 'IC)> ()
                                                = new GenericPseudoRandomModel<'URNG, 'IC> ()
let GenericRiskStatistics<'Stat when 'Stat :> IGeneralStatistics and 'Stat : (new : unit -> 'Stat)> ()
                                                = new GenericRiskStatisticsModel<'Stat> ()
let GenericSequenceStatistics                   dimension 
                                                = new GenericSequenceStatisticsModel<'S> (dimension)
let GenericTimeSetter                           grid Process 
                                                = new GenericTimeSetterModel<'PdeClass> (grid, Process)
let GeometricAPOPathPricer                      Type strike discount 
                                                = new GeometricAPOPathPricerModel (Type, strike, discount)
let GeometricAPOPathPricer1                     Type strike discount runningProduct 
                                                = new GeometricAPOPathPricerModel1 (Type, strike, discount, runningProduct)
let GeometricAPOPathPricer2                     Type strike discount runningProduct pastFixings 
                                                = new GeometricAPOPathPricerModel2 (Type, strike, discount, runningProduct, pastFixings)
let GeometricBrownianMotionProcess              initialValue mue sigma 
                                                = new GeometricBrownianMotionProcessModel (initialValue, mue, sigma)
let Germany                                     m 
                                                = new GermanyModel (m)
let Germany1                                    ()
                                                = new GermanyModel1 ()
let GMRES                                       A maxIter relTol preConditioner 
                                                = new GMRESModel (A, maxIter, relTol, preConditioner)
let GMRESResult                                 e xx 
                                                = new GMRESResultModel (e, xx)
let GoldsteinLineSearch                         eps alpha beta extrapolation 
                                                = new GoldsteinLineSearchModel (eps, alpha, beta, extrapolation)
let GRDCurrency                                 ()
                                                = new GRDCurrencyModel ()
let HaltonRsg                                   dimensionality seed randomStart randomShift 
                                                = new HaltonRsgModel (dimensionality, seed, randomStart, randomShift)
let Handle<'T when 'T :> IObservable>           ()                           
                                                = new HandleModel<'T> ()
let Handle1                                     h registerAsObserver 
                                                = new HandleModel1<'T> (h, registerAsObserver)
let Handle2                                     h 
                                                = new HandleModel2<'T> (h)
let HarmonicCubic                               xBegin size yBegin 
                                                = new HarmonicCubicModel (xBegin, size, yBegin)
let HazardRate                                  ()
                                                = new HazardRateModel ()
let Helper                                      i xMin dx discountBondPrice tree 
                                                = new HelperModel (i, xMin, dx, discountBondPrice, tree)
let HestonBlackVolSurface                       hestonModel 
                                                = new HestonBlackVolSurfaceModel (hestonModel)
let HestonExpansionEngine                       model formula 
                                                = new HestonExpansionEngineModel (model, formula)
let HestonHullWhitePathPricer                   exerciseTime payoff Process 
                                                = new HestonHullWhitePathPricerModel (exerciseTime, payoff, Process)
let HestonModel                                 Process 
                                                = new HestonModelModel (Process)
let HestonModelHelper                           maturity calendar s0 strikePrice volatility riskFreeRate dividendYield errorType pricingEngine evaluationDate 
                                                = new HestonModelHelperModel (maturity, calendar, s0, strikePrice, volatility, riskFreeRate, dividendYield, errorType, pricingEngine, evaluationDate)
let HestonModelHelper1                          maturity calendar s0 strikePrice volatility riskFreeRate dividendYield errorType pricingEngine evaluationDate 
                                                = new HestonModelHelperModel1 (maturity, calendar, s0, strikePrice, volatility, riskFreeRate, dividendYield, errorType, pricingEngine, evaluationDate)
let HestonProcess                               riskFreeRate dividendYield s0 v0 kappa theta sigma rho d 
                                                = new HestonProcessModel (riskFreeRate, dividendYield, s0, v0, kappa, theta, sigma, rho, d)
let HKDCurrency                                 ()
                                                = new HKDCurrencyModel ()
let HongKong                                    ()
                                                = new HongKongModel ()
let HUFCurrency                                 ()
                                                = new HUFCurrencyModel ()
let HullWhite                                   termStructure a sigma 
                                                = new HullWhiteModel (termStructure, a, sigma)
let HullWhite1                                  termStructure 
                                                = new HullWhiteModel1 (termStructure)
let HullWhite2                                  termStructure a 
                                                = new HullWhiteModel2 (termStructure, a)
let HullWhiteForwardProcess                     h a sigma 
                                                = new HullWhiteForwardProcessModel (h, a, sigma)
let HullWhiteProcess                            h a sigma 
                                                = new HullWhiteProcessModel (h, a, sigma)
let HundsdorferScheme                           theta mu map bcSet 
                                                = new HundsdorferSchemeModel (theta, mu, map, bcSet)
let HundsdorferScheme1                          ()
                                                = new HundsdorferSchemeModel1 ()
let Hungary                                     ()
                                                = new HungaryModel ()
let HybridHestonHullWhiteProcess                hestonProcess hullWhiteProcess corrEquityShortRate discretization 
                                                = new HybridHestonHullWhiteProcessModel (hestonProcess, hullWhiteProcess, corrEquityShortRate, discretization)
let IborCoupon                                  paymentDate nominal startDate endDate fixingDays iborIndex gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
                                                = new IborCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, iborIndex, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter, isInArrears)
let IborCoupon1                                 ()
                                                = new IborCouponModel1 ()
let IborIndex                                   ()
                                                = new IborIndexModel ()
let IborIndex1                                  familyName tenor settlementDays currency fixingCalendar convention endOfMonth dayCounter h 
                                                = new IborIndexModel1 (familyName, tenor, settlementDays, currency, fixingCalendar, convention, endOfMonth, dayCounter, h)
let IborLeg                                     schedule index 
                                                = new IborLegModel (schedule, index)
let Iceland                                     ()
                                                = new IcelandModel ()
let IDRCurrency                                 ()
                                                = new IDRCurrencyModel ()
let IEPCurrency                                 ()
                                                = new IEPCurrencyModel ()
let ILSCurrency                                 ()
                                                = new ILSCurrencyModel ()
let ImplicitEuler                               L bcs 
                                                = new ImplicitEulerModel<'Operator> (L, bcs)
let ImplicitEuler1<'Operator when 'Operator :> IOperator>                              
                                                = new ImplicitEulerModel1<'Operator> ()
let ImplicitEulerScheme                         map bcSet relTol solverType 
                                                = new ImplicitEulerSchemeModel (map, bcSet, relTol, solverType)
let ImplicitEulerScheme1                        ()
                                                = new ImplicitEulerSchemeModel1 ()
let ImpliedTermStructure                        h referenceDate 
                                                = new ImpliedTermStructureModel (h, referenceDate)
let ImpliedVolHelper                            cap discountCurve targetValue displacement Type 
                                                = new ImpliedVolHelperModel (cap, discountCurve, targetValue, displacement, Type)
let ImpliedVolHelper_                           swaption discountCurve targetValue displacement Type 
                                                = new ImpliedVolHelper_Model (swaption, discountCurve, targetValue, displacement, Type)
let ImpliedVolTermStructure                     originalTS referenceDate 
                                                = new ImpliedVolTermStructureModel (originalTS, referenceDate)
let IncrementalStatistics                       ()
                                                = new IncrementalStatisticsModel ()
let IndexedCashFlow                             notional index baseDate fixingDate paymentDate growthOnly 
                                                = new IndexedCashFlowModel (notional, index, baseDate, fixingDate, paymentDate, growthOnly)
let India                                       ()
                                                = new IndiaModel ()
let Indonesia                                   m 
                                                = new IndonesiaModel (m)
let Indonesia1                                  ()
                                                = new IndonesiaModel1 ()
let InflationCoupon                             paymentDate nominal startDate endDate fixingDays index observationLag dayCounter refPeriodStart refPeriodEnd exCouponDate 
                                                = new InflationCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, index, observationLag, dayCounter, refPeriodStart, refPeriodEnd, exCouponDate)
let InflationCouponPricer                       ()
                                                = new InflationCouponPricerModel ()
let InflationIndex                              familyName region revised interpolated frequency availabilitiyLag currency 
                                                = new InflationIndexModel (familyName, region, revised, interpolated, frequency, availabilitiyLag, currency)
let INRCurrency                                 ()
                                                = new INRCurrencyModel ()
let Instrument                                  pricingEngine evaluationDate
                                                = new InstrumentModel (pricingEngine, evaluationDate)
let IntegralCdsEngine                           step probability recoveryRate discountCurve includeSettlementDateFlows 
                                                = new IntegralCdsEngineModel (step, probability, recoveryRate, discountCurve, includeSettlementDateFlows)
let IntegralEngine                              Process 
                                                = new IntegralEngineModel (Process)
let Integrand                                   payoff s0 drift variance 
                                                = new IntegrandModel (payoff, s0, drift, variance)
let InterestRate                                r dc comp freq 
                                                = new InterestRateModel (r, dc, comp, freq)
let InterestRate1                               ()
                                                = new InterestRateModel1 ()
let InterpolatedCPICapFloorTermPriceSurface     nominal startRate observationLag cal bdc dc zii yts cStrikes fStrikes cfMaturities cPrice fPrice 
                                                = new InterpolatedCPICapFloorTermPriceSurfaceModel<'Interpolator2D> (nominal, startRate, observationLag, cal, bdc, dc, zii, yts, cStrikes, fStrikes, cfMaturities, cPrice, fPrice)
let InterpolatedDiscountCurve                   referenceDate dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedDiscountCurveModel<'Interpolator> (referenceDate, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedDiscountCurve1                  dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedDiscountCurveModel1<'Interpolator> (dayCounter, jumps, jumpDates, interpolator)
let InterpolatedDiscountCurve2                  settlementDays calendar dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedDiscountCurveModel2<'Interpolator> (settlementDays, calendar, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedDiscountCurve3                  dates discounts dayCounter calendar interpolator 
                                                = new InterpolatedDiscountCurveModel3<'Interpolator> (dates, discounts, dayCounter, calendar, interpolator)
let InterpolatedDiscountCurve4                  dates discounts dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedDiscountCurveModel4<'Interpolator> (dates, discounts, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedDiscountCurve5                  dates discounts dayCounter interpolator 
                                                = new InterpolatedDiscountCurveModel5<'Interpolator> (dates, discounts, dayCounter, interpolator)
let InterpolatedDiscountCurve6                  dates discounts dayCounter calendar jumps jumpDates interpolator 
                                                = new InterpolatedDiscountCurveModel6<'Interpolator> (dates, discounts, dayCounter, calendar, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve                    dates forwards dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedForwardCurveModel<'Interpolator> (dates, forwards, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve1                   dates forwards dayCounter calendar interpolator 
                                                = new InterpolatedForwardCurveModel1<'Interpolator> (dates, forwards, dayCounter, calendar, interpolator)
let InterpolatedForwardCurve2                   dates forwards dayCounter calendar jumps jumpDates interpolator 
                                                = new InterpolatedForwardCurveModel2<'Interpolator> (dates, forwards, dayCounter, calendar, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve3                   settlementDays calendar dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedForwardCurveModel3<'Interpolator> (settlementDays, calendar, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve4                   referenceDate dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedForwardCurveModel4<'Interpolator> (referenceDate, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve5                   dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedForwardCurveModel5<'Interpolator> (dayCounter, jumps, jumpDates, interpolator)
let InterpolatedForwardCurve6                   dates forwards dayCounter interpolator 
                                                = new InterpolatedForwardCurveModel6<'Interpolator> (dates, forwards, dayCounter, interpolator)
let InterpolatedHazardRateCurve                 dates hazardRates dayCounter cal jumps jumpDates interpolator 
                                                = new InterpolatedHazardRateCurveModel<'Interpolator> (dates, hazardRates, dayCounter, cal, jumps, jumpDates, interpolator)
let InterpolatedHazardRateCurve1                dates hazardRates dayCounter calendar interpolator 
                                                = new InterpolatedHazardRateCurveModel1<'Interpolator> (dates, hazardRates, dayCounter, calendar, interpolator)
let InterpolatedHazardRateCurve2                dates hazardRates dayCounter interpolator 
                                                = new InterpolatedHazardRateCurveModel2<'Interpolator> (dates, hazardRates, dayCounter, interpolator)
let InterpolatedPiecewiseZeroSpreadedTermStructure  h spreads dates compounding frequency dc factory 
                                                = new InterpolatedPiecewiseZeroSpreadedTermStructureModel<'Interpolator> (h, spreads, dates, compounding, frequency, dc, factory)
let InterpolatedSmileSection                    d strikes stdDevs atmLevel dc interpolator referenceDate shift 
                                                = new InterpolatedSmileSectionModel<'Interpolator> (d, strikes, stdDevs, atmLevel, dc, interpolator, referenceDate, shift)
let InterpolatedSmileSection1                   d strikes stdDevHandles atmLevel dc interpolator referenceDate Type shift 
                                                = new InterpolatedSmileSectionModel1<'Interpolator> (d, strikes, stdDevHandles, atmLevel, dc, interpolator, referenceDate, Type, shift)
let InterpolatedSmileSection2                   timeToExpiry strikes stdDevs atmLevel interpolator dc Type shift 
                                                = new InterpolatedSmileSectionModel2<'Interpolator> (timeToExpiry, strikes, stdDevs, atmLevel, interpolator, dc, Type, shift)
let InterpolatedSmileSection3                   timeToExpiry strikes stdDevHandles atmLevel interpolator dc Type shift 
                                                = new InterpolatedSmileSectionModel3<'Interpolator> (timeToExpiry, strikes, stdDevHandles, atmLevel, interpolator, dc, Type, shift)
let InterpolatedSurvivalProbabilityCurve        dates probabilities dayCounter calendar jumps jumpDates interpolator 
                                                = new InterpolatedSurvivalProbabilityCurveModel<'Interpolator> (dates, probabilities, dayCounter, calendar, jumps, jumpDates, interpolator)
let InterpolatedYoYInflationCurve               referenceDate calendar dayCounter lag frequency indexIsInterpolated yTS dates rates interpolator 
                                                = new InterpolatedYoYInflationCurveModel<'Interpolator> (referenceDate, calendar, dayCounter, lag, frequency, indexIsInterpolated, yTS, dates, rates, interpolator)
let InterpolatedYoYInflationCurve1              referenceDate calendar dayCounter lag frequency indexIsInterpolated yTS dates rates 
                                                = new InterpolatedYoYInflationCurveModel1<'Interpolator> (referenceDate, calendar, dayCounter, lag, frequency, indexIsInterpolated, yTS, dates, rates)
let InterpolatedZeroCurve                       dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedZeroCurveModel<'Interpolator> (dayCounter, jumps, jumpDates, interpolator)
let InterpolatedZeroCurve1                      dates yields dayCounter interpolator compounding frequency refDate 
                                                = new InterpolatedZeroCurveModel1<'Interpolator> (dates, yields, dayCounter, interpolator, compounding, frequency, refDate)
let InterpolatedZeroCurve2                      dates yields dayCounter calendar interpolator compounding frequency 
                                                = new InterpolatedZeroCurveModel2<'Interpolator> (dates, yields, dayCounter, calendar, interpolator, compounding, frequency)
let InterpolatedZeroCurve3                      dates yields dayCounter calendar jumps jumpDates interpolator compounding frequency 
                                                = new InterpolatedZeroCurveModel3<'Interpolator> (dates, yields, dayCounter, calendar, jumps, jumpDates, interpolator, compounding, frequency)
let InterpolatedZeroCurve4                      settlementDays calendar dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedZeroCurveModel4<'Interpolator> (settlementDays, calendar, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedZeroCurve5                      referenceDate dayCounter jumps jumpDates interpolator 
                                                = new InterpolatedZeroCurveModel5<'Interpolator> (referenceDate, dayCounter, jumps, jumpDates, interpolator)
let InterpolatedZeroInflationCurve              referenceDate calendar dayCounter lag frequency indexIsInterpolated yTS dates rates interpolator 
                                                = new InterpolatedZeroInflationCurveModel<'Interpolator> (referenceDate, calendar, dayCounter, lag, frequency, indexIsInterpolated, yTS, dates, rates, interpolator)
let InterpolatingCPICapFloorEngine              priceSurf 
                                                = new InterpolatingCPICapFloorEngineModel (priceSurf)
let InvalidPriceSignException                   ()
                                                = new InvalidPriceSignExceptionModel ()
let InvalidPriceSignException1                  message 
                                                = new InvalidPriceSignExceptionModel1 (message)
let InvalidPriceSignException2                  message inner 
                                                = new InvalidPriceSignExceptionModel2 (message, inner)
let InverseCumulativeNormal                     ()
                                                = new InverseCumulativeNormalModel ()
let InverseCumulativeNormal1                    average sigma 
                                                = new InverseCumulativeNormalModel1 (average, sigma)
let InverseCumulativePoisson                    ()
                                                = new InverseCumulativePoissonModel ()
let InverseCumulativePoisson1                   lambda 
                                                = new InverseCumulativePoissonModel1 (lambda)
let InverseCumulativeRng                        uniformGenerator 
                                                = new InverseCumulativeRngModel<'RNG, 'IC> (uniformGenerator)
let InverseCumulativeRsg                        uniformSequenceGenerator inverseCumulative 
                                                = new InverseCumulativeRsgModel<'USG, 'IC> (uniformSequenceGenerator, inverseCumulative)
let InverseCumulativeRsg1                       uniformSequenceGenerator 
                                                = new InverseCumulativeRsgModel1<'USG, 'IC> (uniformSequenceGenerator)
let InverseNonCentralChiSquareDistribution      df ncp 
                                                = new InverseNonCentralChiSquareDistributionModel (df, ncp)
let InverseNonCentralChiSquareDistribution1     df ncp maxEvaluations 
                                                = new InverseNonCentralChiSquareDistributionModel1 (df, ncp, maxEvaluations)
let InverseNonCentralChiSquareDistribution2     df ncp maxEvaluations accuracy 
                                                = new InverseNonCentralChiSquareDistributionModel2 (df, ncp, maxEvaluations, accuracy)
let InverseNonCentralCumulativeChiSquareDistribution  df ncp maxEvaluations accuracy 
                                                = new InverseNonCentralCumulativeChiSquareDistributionModel (df, ncp, maxEvaluations, accuracy)
let IQDCurrency                                 ()
                                                = new IQDCurrencyModel ()
let IRRCurrency                                 ()
                                                = new IRRCurrencyModel ()
let IsdaCdsEngine                               probability recoveryRate discountCurve includeSettlementDateFlows numericalFix accrualBias forwardsInCouponPeriod 
                                                = new IsdaCdsEngineModel (probability, recoveryRate, discountCurve, includeSettlementDateFlows, numericalFix, accrualBias, forwardsInCouponPeriod)
let ISKCurrency                                 ()
                                                = new ISKCurrencyModel ()
let Israel                                      m 
                                                = new IsraelModel (m)
let Italy                                       m 
                                                = new ItalyModel (m)
let Italy1                                      ()
                                                = new ItalyModel1 ()
let IterativeBootstrap<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure>                          
                                                = new IterativeBootstrapModel<'T, 'U> ()
let ITLCurrency                                 ()
                                                = new ITLCurrencyModel ()
let JamshidianSwaptionEngine                    model 
                                                = new JamshidianSwaptionEngineModel (model)
let JamshidianSwaptionEngine1                   model termStructure 
                                                = new JamshidianSwaptionEngineModel1 (model, termStructure)
let Japan                                       ()
                                                = new JapanModel ()
let JarrowRudd                                  ()
                                                = new JarrowRuddModel ()
let JarrowRudd1                                 Process End steps strike 
                                                = new JarrowRuddModel1 (Process, End, steps, strike)
let Jibar                                       tenor h 
                                                = new JibarModel (tenor, h)
let Jibar1                                      tenor 
                                                = new JibarModel1 (tenor)
let JointCalendar                               c1 c2 r 
                                                = new JointCalendarModel (c1, c2, r)
let JointCalendar1                              c1 c2 c3 
                                                = new JointCalendarModel1 (c1, c2, c3)
let JointCalendar2                              c1 c2 c3 r 
                                                = new JointCalendarModel2 (c1, c2, c3, r)
let JointCalendar3                              c1 c2 c3 c4 r 
                                                = new JointCalendarModel3 (c1, c2, c3, c4, r)
let JointCalendar4                              c1 c2 c3 c4 
                                                = new JointCalendarModel4 (c1, c2, c3, c4)
let JointCalendar5                              c1 c2 
                                                = new JointCalendarModel5 (c1, c2)
let Joshi4                                      Process End steps strike 
                                                = new Joshi4Model (Process, End, steps, strike)
let Joshi41                                     ()
                                                = new Joshi4Model1 ()
let JPYCurrency                                 ()
                                                = new JPYCurrencyModel ()
let JPYLibor                                    tenor 
                                                = new JPYLiborModel (tenor)
let JPYLibor1                                   tenor h 
                                                = new JPYLiborModel1 (tenor, h)
let JpyLiborSwapIsdaFixAm                       tenor h 
                                                = new JpyLiborSwapIsdaFixAmModel (tenor, h)
let JpyLiborSwapIsdaFixAm1                      tenor 
                                                = new JpyLiborSwapIsdaFixAmModel1 (tenor)
let JpyLiborSwapIsdaFixPm                       tenor h 
                                                = new JpyLiborSwapIsdaFixPmModel (tenor, h)
let JpyLiborSwapIsdaFixPm1                      tenor 
                                                = new JpyLiborSwapIsdaFixPmModel1 (tenor)
let JuQuadraticApproximationEngine              Process 
                                                = new JuQuadraticApproximationEngineModel (Process)
let KerkhofSeasonality                          seasonalityBaseDate seasonalityFactors 
                                                = new KerkhofSeasonalityModel (seasonalityBaseDate, seasonalityFactors)
let KernelInterpolation                         xBegin size yBegin kernel 
                                                = new KernelInterpolationModel (xBegin, size, yBegin, kernel)
let KernelInterpolation2D                       xBegin size yBegin ySize zData kernel 
                                                = new KernelInterpolation2DModel (xBegin, size, yBegin, ySize, zData, kernel)
let KirkEngine                                  process1 process2 correlation 
                                                = new KirkEngineModel (process1, process2, correlation)
let KirkSpreadOptionEngine                      process1 process2 correlation 
                                                = new KirkSpreadOptionEngineModel (process1, process2, correlation)
let KrugerCubic                                 xBegin size yBegin 
                                                = new KrugerCubicModel (xBegin, size, yBegin)
let KRWCurrency                                 ()
                                                = new KRWCurrencyModel ()
let KWDCurrency                                 ()
                                                = new KWDCurrencyModel ()
let LatticeShortRateModelEngine                 model timeGrid 
                                                = new LatticeShortRateModelEngineModel<'ArgumentsType, 'ResultsType> (model, timeGrid)
let LatticeShortRateModelEngine1                model timeSteps 
                                                = new LatticeShortRateModelEngineModel1<'ArgumentsType, 'ResultsType> (model, timeSteps)
let LeastSquareFunction                         lsp 
                                                = new LeastSquareFunctionModel (lsp)
let LeisenReimer                                Process End steps strike 
                                                = new LeisenReimerModel (Process, End, steps, strike)
let LeisenReimer1                               ()
                                                = new LeisenReimerModel1 ()
let LevenbergMarquardt                          ()
                                                = new LevenbergMarquardtModel ()
let LevenbergMarquardt1                         epsfcn xtol gtol useCostFunctionsJacobian 
                                                = new LevenbergMarquardtModel1 (epsfcn, xtol, gtol, useCostFunctionsJacobian)
let LfmCovarianceProxy                          volaModel corrModel 
                                                = new LfmCovarianceProxyModel (volaModel, corrModel)
let LfmHullWhiteParameterization                Process capletVol correlation factors 
                                                = new LfmHullWhiteParameterizationModel (Process, capletVol, correlation, factors)
let LfmHullWhiteParameterization1               Process capletVol 
                                                = new LfmHullWhiteParameterizationModel1 (Process, capletVol)
let LfmSwaptionEngine                           model discountCurve 
                                                = new LfmSwaptionEngineModel (model, discountCurve)
let Libor                                       familyName tenor settlementDays currency financialCenterCalendar dayCounter h 
                                                = new LiborModel (familyName, tenor, settlementDays, currency, financialCenterCalendar, dayCounter, h)
let LiborForwardModel                           Process volaModel corrModel 
                                                = new LiborForwardModelModel (Process, volaModel, corrModel)
let LiborForwardModelProcess                    size index disc 
                                                = new LiborForwardModelProcessModel (size, index, disc)
let LiborForwardModelProcess1                   size index 
                                                = new LiborForwardModelProcessModel1 (size, index)
let Linear                                      ()
                                                = new LinearModel ()
let LinearInterpolation                         xBegin size yBegin 
                                                = new LinearInterpolationModel (xBegin, size, yBegin)
let LinearLeastSquaresRegression                x y v 
                                                = new LinearLeastSquaresRegressionModel (x, y, v)
let LinearRegression                            x y 
                                                = new LinearRegressionModel (x, y)
let LinearRegression1                           x y 
                                                = new LinearRegressionModel1 (x, y)
let LinearTsrPricer                             swaptionVol meanReversion couponDiscountCurve settings integrator 
                                                = new LinearTsrPricerModel (swaptionVol, meanReversion, couponDiscountCurve, settings, integrator)
let LineSearchBasedMethod                       lineSearch 
                                                = new LineSearchBasedMethodModel (lineSearch)
let LmConstWrapperCorrelationModel              corrModel 
                                                = new LmConstWrapperCorrelationModelModel (corrModel)
let LmConstWrapperVolatilityModel               volaModel 
                                                = new LmConstWrapperVolatilityModelModel (volaModel)
let LmExponentialCorrelationModel               size rho 
                                                = new LmExponentialCorrelationModelModel (size, rho)
let LmExtLinearExponentialVolModel              fixingTimes a b c d 
                                                = new LmExtLinearExponentialVolModelModel (fixingTimes, a, b, c, d)
let LmFixedVolatilityModel                      volatilities startTimes 
                                                = new LmFixedVolatilityModelModel (volatilities, startTimes)
let LmLinearExponentialCorrelationModel         size rho beta factors 
                                                = new LmLinearExponentialCorrelationModelModel (size, rho, beta, factors)
let LmLinearExponentialVolatilityModel          fixingTimes a b c d 
                                                = new LmLinearExponentialVolatilityModelModel (fixingTimes, a, b, c, d)
let Loan                                        legs pricingEngine evaluationDate 
                                                = new LoanModel (legs, pricingEngine, evaluationDate)
let LocalBootstrap                              localisation forcePositive 
                                                = new LocalBootstrapModel<'T, 'U> (localisation, forcePositive)
let LocalBootstrap1<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure> ()                            
                                                = new LocalBootstrapModel1<'T, 'U> ()
let LocalConstantVol                            settlementDays calendar volatility dayCounter 
                                                = new LocalConstantVolModel (settlementDays, calendar, volatility, dayCounter)
let LocalConstantVol1                           referenceDate volatility dc 
                                                = new LocalConstantVolModel1 (referenceDate, volatility, dc)
let LocalConstantVol2                           referenceDate volatility dc 
                                                = new LocalConstantVolModel2 (referenceDate, volatility, dc)
let LocalConstantVol3                           settlementDays calendar volatility dayCounter 
                                                = new LocalConstantVolModel3 (settlementDays, calendar, volatility, dayCounter)
let LocalVolCurve                               curve 
                                                = new LocalVolCurveModel (curve)
let LocalVolSurface                             blackTS riskFreeTS dividendTS underlying 
                                                = new LocalVolSurfaceModel (blackTS, riskFreeTS, dividendTS, underlying)
let LocalVolSurface1                            blackTS riskFreeTS dividendTS underlying 
                                                = new LocalVolSurfaceModel1 (blackTS, riskFreeTS, dividendTS, underlying)
let LogCubic                                    da monotonic leftCondition leftConditionValue rightCondition rightConditionValue 
                                                = new LogCubicModel (da, monotonic, leftCondition, leftConditionValue, rightCondition, rightConditionValue)
let LogCubic1                                   ()
                                                = new LogCubicModel1 ()
let LogCubicInterpolation                       xBegin size yBegin da monotonic leftC leftConditionValue rightC rightConditionValue 
                                                = new LogCubicInterpolationModel (xBegin, size, yBegin, da, monotonic, leftC, leftConditionValue, rightC, rightConditionValue)
let LogGrid                                     grid 
                                                = new LogGridModel (grid)
let LogLinear                                   ()
                                                = new LogLinearModel ()
let LogLinearInterpolation                      xBegin size yBegin 
                                                = new LogLinearInterpolationModel (xBegin, size, yBegin)
let LongstaffSchwartzPathPricer                 times pathPricer termStructure 
                                                = new LongstaffSchwartzPathPricerModel<'PathType> (times, pathPricer, termStructure)
let LPP2HestonExpansion                         kappa theta sigma v0 rho term 
                                                = new LPP2HestonExpansionModel (kappa, theta, sigma, v0, rho, term)
let LPP3HestonExpansion                         kappa theta sigma v0 rho term 
                                                = new LPP3HestonExpansionModel (kappa, theta, sigma, v0, rho, term)
let LTLCurrency                                 ()
                                                = new LTLCurrencyModel ()
let LUFCurrency                                 ()
                                                = new LUFCurrencyModel ()
let LVLCurrency                                 ()
                                                = new LVLCurrencyModel ()
let Matrix                                      rows columns value 
                                                = new MatrixModel (rows, columns, value)
let Matrix1                                     rows columns 
                                                = new MatrixModel1 (rows, columns)
let Matrix2                                     from 
                                                = new MatrixModel2 (from)
let Matrix3                                     ()
                                                = new MatrixModel3 ()
let MaxBasketPayoff                             p 
                                                = new MaxBasketPayoffModel (p)
let MaxNumberFuncEvalExceeded                   message inner 
                                                = new MaxNumberFuncEvalExceededModel (message, inner)
let MaxNumberFuncEvalExceeded1                  message 
                                                = new MaxNumberFuncEvalExceededModel1 (message)
let MaxNumberFuncEvalExceeded2                  ()
                                                = new MaxNumberFuncEvalExceededModel2 ()
let MBSFixedRateBond                            settlementDays calendar faceAmount startDate bondTenor originalLength sinkingFrequency WACRate PassThroughRate accrualDayCounter prepayModel paymentConvention issueDate pricingEngine evaluationDate 
                                                = new MBSFixedRateBondModel (settlementDays, calendar, faceAmount, startDate, bondTenor, originalLength, sinkingFrequency, WACRate, PassThroughRate, accrualDayCounter, prepayModel, paymentConvention, issueDate, pricingEngine, evaluationDate)
let MCAmericanEngine                            Process timeSteps timeStepsPerYear antitheticVariate controlVariate requiredSamples requiredTolerance maxSamples seed polynomOrder polynomType nCalibrationSamples 
                                                = new MCAmericanEngineModel<'RNG, 'S> (Process, timeSteps, timeStepsPerYear, antitheticVariate, controlVariate, requiredSamples, requiredTolerance, maxSamples, seed, polynomOrder, polynomType, nCalibrationSamples)
let MCBarrierEngine                             Process timeSteps timeStepsPerYear brownianBridge antitheticVariate requiredSamples requiredTolerance maxSamples isBiased seed 
                                                = new MCBarrierEngineModel<'RNG, 'S> (Process, timeSteps, timeStepsPerYear, brownianBridge, antitheticVariate, requiredSamples, requiredTolerance, maxSamples, isBiased, seed)
let MCDiscreteArithmeticAPEngine                Process maxTimeStepPerYear brownianBridge antitheticVariate controlVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCDiscreteArithmeticAPEngineModel<'RNG, 'S> (Process, maxTimeStepPerYear, brownianBridge, antitheticVariate, controlVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCDiscreteArithmeticASEngine                Process brownianBridge antitheticVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCDiscreteArithmeticASEngineModel<'RNG, 'S> (Process, brownianBridge, antitheticVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCDiscreteAveragingAsianEngine              Process maxTimeStepsPerYear brownianBridge antitheticVariate controlVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCDiscreteAveragingAsianEngineModel<'RNG, 'S> (Process, maxTimeStepsPerYear, brownianBridge, antitheticVariate, controlVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCDiscreteGeometricAPEngine                 Process maxTimeStepPerYear brownianBridge antitheticVariate controlVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCDiscreteGeometricAPEngineModel<'RNG, 'S> (Process, maxTimeStepPerYear, brownianBridge, antitheticVariate, controlVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCEuropeanEngine                            Process timeSteps timeStepsPerYear brownianBridge antitheticVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCEuropeanEngineModel<'RNG, 'S> (Process, timeSteps, timeStepsPerYear, brownianBridge, antitheticVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCEuropeanHestonEngine                      Process timeSteps timeStepsPerYear antitheticVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCEuropeanHestonEngineModel<'RNG, 'S> (Process, timeSteps, timeStepsPerYear, antitheticVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MCHestonHullWhiteEngine                     Process timeSteps timeStepsPerYear antitheticVariate controlVariate requiredSamples requiredTolerance maxSamples seed 
                                                = new MCHestonHullWhiteEngineModel<'RNG, 'S> (Process, timeSteps, timeStepsPerYear, antitheticVariate, controlVariate, requiredSamples, requiredTolerance, maxSamples, seed)
let MersenneTwisterUniformRng                   seed 
                                                = new MersenneTwisterUniformRngModel (seed)
let MersenneTwisterUniformRng1                  ()
                                                = new MersenneTwisterUniformRngModel1 ()
let MersenneTwisterUniformRng2                  seeds 
                                                = new MersenneTwisterUniformRngModel2 (seeds)
let MethodOfLinesScheme                         eps relInitStepSize map bcSet 
                                                = new MethodOfLinesSchemeModel (eps, relInitStepSize, map, bcSet)
let MethodOfLinesScheme1                        ()
                                                = new MethodOfLinesSchemeModel1 ()
let Mexico                                      ()
                                                = new MexicoModel ()
let MidPoint                                    ()
                                                = new MidPointModel ()
let MidPointCdsEngine                           probability recoveryRate discountCurve includeSettlementDateFlows 
                                                = new MidPointCdsEngineModel (probability, recoveryRate, discountCurve, includeSettlementDateFlows)
let MinBasketPayoff                             p 
                                                = new MinBasketPayoffModel (p)
let MixedLinearCubic                            n behavior da monotonic leftCondition leftConditionValue rightCondition rightConditionValue 
                                                = new MixedLinearCubicModel (n, behavior, da, monotonic, leftCondition, leftConditionValue, rightCondition, rightConditionValue)
let MixedLinearCubicInterpolation               xBegin xEnd yBegin n behavior da monotonic leftC leftConditionValue rightC rightConditionValue 
                                                = new MixedLinearCubicInterpolationModel (xBegin, xEnd, yBegin, n, behavior, da, monotonic, leftC, leftConditionValue, rightC, rightConditionValue)
let MixedLinearCubicNaturalSpline               xBegin xEnd yBegin n behavior 
                                                = new MixedLinearCubicNaturalSplineModel (xBegin, xEnd, yBegin, n, behavior)
let MixedLinearFritschButlandCubic              xBegin xEnd yBegin n behavior 
                                                = new MixedLinearFritschButlandCubicModel (xBegin, xEnd, yBegin, n, behavior)
let MixedLinearKrugerCubic                      xBegin xEnd yBegin n behavior 
                                                = new MixedLinearKrugerCubicModel (xBegin, xEnd, yBegin, n, behavior)
let MixedLinearMonotonicCubicNaturalSpline      xBegin xEnd yBegin n behavior 
                                                = new MixedLinearMonotonicCubicNaturalSplineModel (xBegin, xEnd, yBegin, n, behavior)
let MixedLinearMonotonicParabolic               xBegin xEnd yBegin n behavior 
                                                = new MixedLinearMonotonicParabolicModel (xBegin, xEnd, yBegin, n, behavior)
let MixedLinearParabolic                        xBegin xEnd yBegin n behavior 
                                                = new MixedLinearParabolicModel (xBegin, xEnd, yBegin, n, behavior)
let MixedScheme<'Operator when 'Operator :> IOperator> ()
                                                = new MixedSchemeModel<'Operator> ()
let MixedScheme1                                L theta bcs 
                                                = new MixedSchemeModel1<'Operator> (L, theta, bcs)
let ModifiedCraigSneydScheme                    ()
                                                = new ModifiedCraigSneydSchemeModel ()
let ModifiedCraigSneydScheme1                   theta mu map bcSet 
                                                = new ModifiedCraigSneydSchemeModel1 (theta, mu, map, bcSet)
let Money                                       ()
                                                = new MoneyModel ()
let Money1                                      currency value 
                                                = new MoneyModel1 (currency, value)
let Money2                                      value currency 
                                                = new MoneyModel2 (value, currency)
let MonomialFct                                 order 
                                                = new MonomialFctModel (order)
let MonotonicCubicNaturalSpline                 xBegin size yBegin 
                                                = new MonotonicCubicNaturalSplineModel (xBegin, size, yBegin)
let MonotonicParabolic                          xBegin size yBegin 
                                                = new MonotonicParabolicModel (xBegin, size, yBegin)
let MonteCarloCatBondEngine                     catRisk discountCurve includeSettlementDateFlows 
                                                = new MonteCarloCatBondEngineModel (catRisk, discountCurve, includeSettlementDateFlows)
let MonteCarloModel                             pathGenerator pathPricer sampleAccumulator antitheticVariate cvPathPricer cvOptionValue cvPathGenerator 
                                                = new MonteCarloModelModel<'MC, 'RNG, 'S> (pathGenerator, pathPricer, sampleAccumulator, antitheticVariate, cvPathPricer, cvOptionValue, cvPathGenerator)
let MonthlyYieldFinder                          faceAmount cashflows settlement 
                                                = new MonthlyYieldFinderModel (faceAmount, cashflows, settlement)
let MoroInverseCumulativeNormal                 average sigma 
                                                = new MoroInverseCumulativeNormalModel (average, sigma)
let MTLCurrency                                 ()
                                                = new MTLCurrencyModel ()
let MultiAssetOption                            payoff exercise pricingEngine evaluationDate 
                                                = new MultiAssetOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let MultiPath                                   nAsset timeGrid 
                                                = new MultiPathModel (nAsset, timeGrid)
let MultiPath1                                  ()
                                                = new MultiPathModel1 ()
let MultiPath2                                  multiPath 
                                                = new MultiPathModel2 (multiPath)
let MultiPathGenerator                          Process times generator brownianBridge 
                                                = new MultiPathGeneratorModel<'GSG> (Process, times, generator, brownianBridge)
let MultiplicativePriceSeasonality              seasonalityBaseDate frequency seasonalityFactors 
                                                = new MultiplicativePriceSeasonalityModel (seasonalityBaseDate, frequency, seasonalityFactors)
let MultiplicativePriceSeasonality1             ()
                                                = new MultiplicativePriceSeasonalityModel1 ()
let MXNCurrency                                 ()
                                                = new MXNCurrencyModel ()
let MYRCurrency                                 ()
                                                = new MYRCurrencyModel ()
let NegativePowerDefaultIntensity               alpha p 
                                                = new NegativePowerDefaultIntensityModel (alpha, p)
let NegativePowerDefaultIntensity1              alpha p recovery 
                                                = new NegativePowerDefaultIntensityModel1 (alpha, p, recovery)
let NelsonSiegelFitting                         weights optimizationMethod 
                                                = new NelsonSiegelFittingModel (weights, optimizationMethod)
let NeumannBC                                   value side 
                                                = new NeumannBCModel (value, side)
let NewZealand                                  ()
                                                = new NewZealandModel ()
let NinePointLinearOp                           m 
                                                = new NinePointLinearOpModel (m)
let NinePointLinearOp1                          d0 d1 mesher 
                                                = new NinePointLinearOpModel1 (d0, d1, mesher)
let NLGCurrency                                 ()
                                                = new NLGCurrencyModel ()
let NoConstraint                                ()
                                                = new NoConstraintModel ()
let NoExceptLocalVolSurface                     blackTS riskFreeTS dividendTS underlying illegalLocalVolOverwrite 
                                                = new NoExceptLocalVolSurfaceModel (blackTS, riskFreeTS, dividendTS, underlying, illegalLocalVolOverwrite)
let NoExceptLocalVolSurface1                    blackTS riskFreeTS dividendTS underlying illegalLocalVolOverwrite 
                                                = new NoExceptLocalVolSurfaceModel1 (blackTS, riskFreeTS, dividendTS, underlying, illegalLocalVolOverwrite)
let NOKCurrency                                 ()
                                                = new NOKCurrencyModel ()
let NonCentralChiSquareDistribution             df ncp 
                                                = new NonCentralChiSquareDistributionModel (df, ncp)
let NonCentralCumulativeChiSquareDistribution   df ncp 
                                                = new NonCentralCumulativeChiSquareDistributionModel (df, ncp)
let NonCentralCumulativeChiSquareSankaranApprox  df ncp 
                                                = new NonCentralCumulativeChiSquareSankaranApproxModel (df, ncp)
let NonhomogeneousBoundaryConstraint            low high 
                                                = new NonhomogeneousBoundaryConstraintModel (low, high)
let NonLinearLeastSquare                        c accuracy maxiter om 
                                                = new NonLinearLeastSquareModel (c, accuracy, maxiter, om)
let NonLinearLeastSquare1                       c accuracy 
                                                = new NonLinearLeastSquareModel1 (c, accuracy)
let NonLinearLeastSquare2                       c accuracy maxiter 
                                                = new NonLinearLeastSquareModel2 (c, accuracy, maxiter)
let NonLinearLeastSquare3                       c 
                                                = new NonLinearLeastSquareModel3 (c)
let NoOffset                                    ()
                                                = new NoOffsetModel ()
let NormalDistribution                          ()
                                                = new NormalDistributionModel ()
let NormalDistribution1                         average sigma 
                                                = new NormalDistributionModel1 (average, sigma)
let Norway                                      ()
                                                = new NorwayModel ()
let NotionalPath                                ()
                                                = new NotionalPathModel ()
let NotTradableException                        message inner 
                                                = new NotTradableExceptionModel (message, inner)
let NotTradableException1                       message 
                                                = new NotTradableExceptionModel1 (message)
let NotTradableException2                       ()
                                                = new NotTradableExceptionModel2 ()
let NoXABRConstraint                            ()
                                                = new NoXABRConstraintModel ()
let NPRCurrency                                 ()
                                                = new NPRCurrencyModel ()
let NullCalendar                                ()
                                                = new NullCalendarModel ()
let NullCondition<'array_type when 'array_type :> Vector>                               
                                                = new NullConditionModel<'array_type> ()
let NullEffectiveDateException                  ()
                                                = new NullEffectiveDateExceptionModel ()
let NullEffectiveDateException1                 message 
                                                = new NullEffectiveDateExceptionModel1 (message)
let NullEffectiveDateException2                 message inner 
                                                = new NullEffectiveDateExceptionModel2 (message, inner)
let NullParameter                               ()
                                                = new NullParameterModel ()
let NumericalDifferentiation                    f orderOfDerivative stepSize steps scheme 
                                                = new NumericalDifferentiationModel (f, orderOfDerivative, stepSize, steps, scheme)
let NumericalDifferentiation1                   f orderOfDerivative x_offsets 
                                                = new NumericalDifferentiationModel1 (f, orderOfDerivative, x_offsets)
let NumericHaganPricer                          swaptionVol modelOfYieldCurve meanReversion lowerLimit upperLimit precision hardUpperLimit 
                                                = new NumericHaganPricerModel (swaptionVol, modelOfYieldCurve, meanReversion, lowerLimit, upperLimit, precision, hardUpperLimit)
let NZDCurrency                                 ()
                                                = new NZDCurrencyModel ()
let NZDLibor                                    tenor h 
                                                = new NZDLiborModel (tenor, h)
let NZDLibor1                                   tenor 
                                                = new NZDLiborModel1 (tenor)
let Nzocr                                       h 
                                                = new NzocrModel (h)
let OISRateHelper                               settlementDays tenor fixedRate overnightIndex 
                                                = new OISRateHelperModel (settlementDays, tenor, fixedRate, overnightIndex)
let OneAssetOption                              payoff exercise pricingEngine evaluationDate 
                                                = new OneAssetOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let OneDayCounter                               ()
                                                = new OneDayCounterModel ()
let Option                                      payoff exercise pricingEngine evaluationDate 
                                                = new OptionModel (payoff, exercise, pricingEngine, evaluationDate)
let OptionletStripper1                          termVolSurface index switchStrike accuracy maxIter discount Type displacement dontThrow 
                                                = new OptionletStripper1Model (termVolSurface, index, switchStrike, accuracy, maxIter, discount, Type, displacement, dontThrow)
let OptionletStripper2                          optionletStripper1 atmCapFloorTermVolCurve 
                                                = new OptionletStripper2Model (optionletStripper1, atmCapFloorTermVolCurve)
let OrnsteinUhlenbeckProcess                    speed vol x0 level 
                                                = new OrnsteinUhlenbeckProcessModel (speed, vol, x0, level)
let OvernightIndex                              familyName settlementDays currency fixingCalendar dayCounter h 
                                                = new OvernightIndexModel (familyName, settlementDays, currency, fixingCalendar, dayCounter, h)
let OvernightIndexedCoupon                      paymentDate nominal startDate endDate overnightIndex gearing spread refPeriodStart refPeriodEnd dayCounter 
                                                = new OvernightIndexedCouponModel (paymentDate, nominal, startDate, endDate, overnightIndex, gearing, spread, refPeriodStart, refPeriodEnd, dayCounter)
let OvernightIndexedCouponPricer                ()
                                                = new OvernightIndexedCouponPricerModel ()
let OvernightIndexedSwap                        Type fixedNominal fixedSchedule fixedRate fixedDC overnightNominal overnightSchedule overnightIndex spread pricingEngine evaluationDate 
                                                = new OvernightIndexedSwapModel (Type, fixedNominal, fixedSchedule, fixedRate, fixedDC, overnightNominal, overnightSchedule, overnightIndex, spread, pricingEngine, evaluationDate)
let OvernightIndexedSwap1                       Type nominal schedule fixedRate fixedDC overnightIndex spread pricingEngine evaluationDate 
                                                = new OvernightIndexedSwapModel1 (Type, nominal, schedule, fixedRate, fixedDC, overnightIndex, spread, pricingEngine, evaluationDate)
let OvernightIndexedSwapIndex                   familyName tenor settlementDays currency overnightIndex 
                                                = new OvernightIndexedSwapIndexModel (familyName, tenor, settlementDays, currency, overnightIndex)
let OvernightLeg                                schedule overnightIndex 
                                                = new OvernightLegModel (schedule, overnightIndex)
let Pair                                        first second 
                                                = new PairModel<'TFirst, 'TSecond> (first, second)
let pair_double                                 first second 
                                                = new pair_doubleModel (first, second)
let Parabolic                                   xBegin size yBegin 
                                                = new ParabolicModel (xBegin, size, yBegin)
let ParallelEvolver<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)> ()
                                                = new ParallelEvolverModel<'Evolver> ()
let ParallelEvolver1                            L bcs 
                                                = new ParallelEvolverModel1<'Evolver> (L, bcs)
let Parameter                                   ()
                                                = new ParameterModel ()
let PathGenerator                               Process timeGrid generator brownianBridge 
                                                = new PathGeneratorModel<'GSG> (Process, timeGrid, generator, brownianBridge)
let PathGenerator1                              Process length timeSteps generator brownianBridge 
                                                = new PathGeneratorModel1<'GSG> (Process, length, timeSteps, generator, brownianBridge)
let Payoff                                      ()
                                                = new PayoffModel ()
let PdeBSM                                      ()
                                                = new PdeBSMModel ()
let PdeBSM1                                     Process 
                                                = new PdeBSMModel1 (Process)
let PdeConstantCoeff                            Process t x 
                                                = new PdeConstantCoeffModel<'PdeClass> (Process, t, x)
let PdeOperator                                 grid Process 
                                                = new PdeOperatorModel<'PdeClass> (grid, Process)
let PdeOperator1                                grid Process residualTime 
                                                = new PdeOperatorModel1<'PdeClass> (grid, Process, residualTime)
let PdeShortRate                                d 
                                                = new PdeShortRateModel (d)
let PdeShortRate1                               ()
                                                = new PdeShortRateModel1 ()
let PEHCurrency                                 ()
                                                = new PEHCurrencyModel ()
let PEICurrency                                 ()
                                                = new PEICurrencyModel ()
let PenaltyFunction                             curve initialIndex rateHelpers start End 
                                                = new PenaltyFunctionModel<'T, 'U> (curve, initialIndex, rateHelpers, start, End)
let PENCurrency                                 ()
                                                = new PENCurrencyModel ()
let PercentageStrikePayoff                      Type moneyness 
                                                = new PercentageStrikePayoffModel (Type, moneyness)
let Period                                      n u 
                                                = new PeriodModel (n, u)
let Period1                                     ()
                                                = new PeriodModel1 ()
let Period2                                     f 
                                                = new PeriodModel2 (f)
let Period3                                     periodString 
                                                = new PeriodModel3 (periodString)
let PiecewiseConstantParameter                  times Constraint 
                                                = new PiecewiseConstantParameterModel (times, Constraint)
let PiecewiseTimeDependentHestonModel           riskFreeRate dividendYield s0 v0 theta kappa sigma rho timeGrid 
                                                = new PiecewiseTimeDependentHestonModelModel (riskFreeRate, dividendYield, s0, v0, theta, kappa, sigma, rho, timeGrid)
let PiecewiseYieldCurve                         ()
                                                = new PiecewiseYieldCurveModel ()
let PiecewiseYieldCurve1                        settlementDays cal dc jumps jumpDates 
                                                = new PiecewiseYieldCurveModel1 (settlementDays, cal, dc, jumps, jumpDates)
let PiecewiseYieldCurve2                        referenceDate cal dc jumps jumpDates 
                                                = new PiecewiseYieldCurveModel2 (referenceDate, cal, dc, jumps, jumpDates)
let PiecewiseYoYInflationCurve                  dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseYoYInflationCurveModel (dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseYoYInflationCurve1                 referenceDate calendar dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseYoYInflationCurveModel1 (referenceDate, calendar, dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseYoYInflationCurve2                 settlementDays calendar dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseYoYInflationCurveModel2 (settlementDays, calendar, dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseYoYInflationCurve3                 ()
                                                = new PiecewiseYoYInflationCurveModel3 ()
let PiecewiseZeroInflationCurve                 referenceDate calendar dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseZeroInflationCurveModel (referenceDate, calendar, dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseZeroInflationCurve1                settlementDays calendar dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseZeroInflationCurveModel1 (settlementDays, calendar, dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseZeroInflationCurve2                dayCounter baseZeroRate observationLag frequency indexIsInterpolated yTS 
                                                = new PiecewiseZeroInflationCurveModel2 (dayCounter, baseZeroRate, observationLag, frequency, indexIsInterpolated, yTS)
let PiecewiseZeroInflationCurve3                ()
                                                = new PiecewiseZeroInflationCurveModel3 ()
let PiecewiseZeroSpreadedTermStructure          h spreads dates compounding frequency dc 
                                                = new PiecewiseZeroSpreadedTermStructureModel (h, spreads, dates, compounding, frequency, dc)
let PKRCurrency                                 ()
                                                = new PKRCurrencyModel ()
let PlainVanillaPayoff                          Type strike 
                                                = new PlainVanillaPayoffModel (Type, strike)
let PLNCurrency                                 ()
                                                = new PLNCurrencyModel ()
let Poland                                      ()
                                                = new PolandModel ()
let PolynomialFunction                          coeff 
                                                = new PolynomialFunctionModel (coeff)
let PositiveConstraint                          ()
                                                = new PositiveConstraintModel ()
let PriceError                                  engine vol targetValue 
                                                = new PriceErrorModel (engine, vol, targetValue)
let PricerSetter                                pricer 
                                                = new PricerSetterModel (pricer)
let PricipalLeg                                 schedule paymentDayCounter 
                                                = new PricipalLegModel (schedule, paymentDayCounter)
let Principal                                   ()
                                                = new PrincipalModel ()
let Principal1                                  amount nominal paymentDate accrualStartDate accrualEndDate dayCounter refPeriodStart refPeriodEnd 
                                                = new PrincipalModel1 (amount, nominal, paymentDate, accrualStartDate, accrualEndDate, dayCounter, refPeriodStart, refPeriodEnd)
let Problem                                     costFunction Constraint initialValue 
                                                = new ProblemModel (costFunction, Constraint, initialValue)
let ProjectedConstraint                         Constraint projection 
                                                = new ProjectedConstraintModel (Constraint, projection)
let ProjectedConstraint1                        Constraint parameterValues fixParameters 
                                                = new ProjectedConstraintModel1 (Constraint, parameterValues, fixParameters)
let ProjectedCostFunction                       costFunction parametersValues parametersFreedoms 
                                                = new ProjectedCostFunctionModel (costFunction, parametersValues, parametersFreedoms)
let Projection                                  parameterValues fixParameters 
                                                = new ProjectionModel (parameterValues, fixParameters)
let ProportionalNotionalRisk                    paymentOffset attachement exhaustion 
                                                = new ProportionalNotionalRiskModel (paymentOffset, attachement, exhaustion)
let PSACurve                                    startdate multiplier 
                                                = new PSACurveModel (startdate, multiplier)
let PSACurve1                                   startdate 
                                                = new PSACurveModel1 (startdate)
let PTECurrency                                 ()
                                                = new PTECurrencyModel ()
let QuadraticHelper                             xPrev xNext fPrev fNext fAverage prevPrimitive 
                                                = new QuadraticHelperModel (xPrev, xNext, fPrev, fNext, fAverage, prevPrimitive)
let QuadraticMinHelper                          xPrev xNext fPrev fNext fAverage prevPrimitive 
                                                = new QuadraticMinHelperModel (xPrev, xNext, fPrev, fNext, fAverage, prevPrimitive)
let QuantoTermStructure                         underlyingDividendTS riskFreeTS foreignRiskFreeTS underlyingBlackVolTS strike exchRateBlackVolTS exchRateATMlevel underlyingExchRateCorrelation 
                                                = new QuantoTermStructureModel (underlyingDividendTS, riskFreeTS, foreignRiskFreeTS, underlyingBlackVolTS, strike, exchRateBlackVolTS, exchRateATMlevel, underlyingExchRateCorrelation)
let Quote                                       ()
                                                = new QuoteModel ()
let RandomSequenceGenerator                     dimensionality seed 
                                                = new RandomSequenceGeneratorModel<'RNG> (dimensionality, seed)
let RandomSequenceGenerator1                    dimensionality rng 
                                                = new RandomSequenceGeneratorModel1<'RNG> (dimensionality, rng)
let RangeAccrualFloatersCoupon                  paymentDate nominal index startDate endDate fixingDays dayCounter gearing spread refPeriodStart refPeriodEnd observationsSchedule lowerTrigger upperTrigger 
                                                = new RangeAccrualFloatersCouponModel (paymentDate, nominal, index, startDate, endDate, fixingDays, dayCounter, gearing, spread, refPeriodStart, refPeriodEnd, observationsSchedule, lowerTrigger, upperTrigger)
let RangeAccrualLeg                             schedule index 
                                                = new RangeAccrualLegModel (schedule, index)
let RangeAccrualPricer                          ()
                                                = new RangeAccrualPricerModel ()
let RangeAccrualPricerByBgm                     correlation smilesOnExpiry smilesOnPayment withSmile byCallSpread 
                                                = new RangeAccrualPricerByBgmModel (correlation, smilesOnExpiry, smilesOnPayment, withSmile, byCallSpread)
let RateHelper                                  quote 
                                                = new RateHelperModel (quote)
let RateHelper1                                 quote 
                                                = new RateHelperModel1 (quote)
let RateHelper2                                 ()
                                                = new RateHelperModel2 ()
let Redemption                                  amount date 
                                                = new RedemptionModel (amount, date)
let RelinkableHandle                            h 
                                                = new RelinkableHandleModel<'T> (h)
let RelinkableHandle1<'T when 'T :> IObservable> ()                          
                                                = new RelinkableHandleModel1<'T> ()
let RelinkableHandle2                           h registerAsObserver 
                                                = new RelinkableHandleModel2<'T> (h, registerAsObserver)
let RendistatoBasket                            btps outstandings cleanPriceQuotes 
                                                = new RendistatoBasketModel (btps, outstandings, cleanPriceQuotes)
let RendistatoCalculator                        basket euriborIndex discountCurve 
                                                = new RendistatoCalculatorModel (basket, euriborIndex, discountCurve)
let RendistatoEquivalentSwapLengthQuote         r 
                                                = new RendistatoEquivalentSwapLengthQuoteModel (r)
let RendistatoEquivalentSwapSpreadQuote         r 
                                                = new RendistatoEquivalentSwapSpreadQuoteModel (r)
let RichardsonEqn                               fh ft fs t s 
                                                = new RichardsonEqnModel (fh, ft, fs, t, s)
let RiskStatistics                              ()
                                                = new RiskStatisticsModel ()
let ROLCurrency                                 ()
                                                = new ROLCurrencyModel ()
let Romania                                     ()
                                                = new RomaniaModel ()
let RONCurrency                                 ()
                                                = new RONCurrencyModel ()
let RootNotBracketException                     message inner 
                                                = new RootNotBracketExceptionModel (message, inner)
let RootNotBracketException1                    message 
                                                = new RootNotBracketExceptionModel1 (message)
let RootNotBracketException2                    ()
                                                = new RootNotBracketExceptionModel2 ()
let Rounding                                    precision Type digit 
                                                = new RoundingModel (precision, Type, digit)
let Rounding1                                   ()
                                                = new RoundingModel1 ()
let Rounding2                                   precision Type 
                                                = new RoundingModel2 (precision, Type)
let Rounding3                                   precision 
                                                = new RoundingModel3 (precision)
let RUBCurrency                                 ()
                                                = new RUBCurrencyModel ()
let Russia                                      m 
                                                = new RussiaModel (m)
let Russia1                                     ()
                                                = new RussiaModel1 ()
let SABR                                        t forward alpha beta nu rho alphaIsFixed betaIsFixed nuIsFixed rhoIsFixed vegaWeighted endCriteria optMethod errorAccept useMaxError maxGuesses shift volatilityType approximationModel 
                                                = new SABRModel (t, forward, alpha, beta, nu, rho, alphaIsFixed, betaIsFixed, nuIsFixed, rhoIsFixed, vegaWeighted, endCriteria, optMethod, errorAccept, useMaxError, maxGuesses, shift, volatilityType, approximationModel)
let SabrInterpolatedSmileSection                optionDate forward strikes hasFloatingStrikes atmVolatility volHandles alpha beta nu rho isAlphaFixed isBetaFixed isNuFixed isRhoFixed vegaWeighted endCriteria Method dc shift 
                                                = new SabrInterpolatedSmileSectionModel (optionDate, forward, strikes, hasFloatingStrikes, atmVolatility, volHandles, alpha, beta, nu, rho, isAlphaFixed, isBetaFixed, isNuFixed, isRhoFixed, vegaWeighted, endCriteria, Method, dc, shift)
let SabrInterpolatedSmileSection1               optionDate forward strikes hasFloatingStrikes atmVolatility volHandles alpha beta nu rho isAlphaFixed isBetaFixed isNuFixed isRhoFixed vegaWeighted endCriteria Method dc shift 
                                                = new SabrInterpolatedSmileSectionModel1 (optionDate, forward, strikes, hasFloatingStrikes, atmVolatility, volHandles, alpha, beta, nu, rho, isAlphaFixed, isBetaFixed, isNuFixed, isRhoFixed, vegaWeighted, endCriteria, Method, dc, shift)
let SABRInterpolation                           xBegin xEnd yBegin t forward alpha beta nu rho alphaIsFixed betaIsFixed nuIsFixed rhoIsFixed vegaWeighted endCriteria optMethod errorAccept useMaxError maxGuesses shift volatilityType approximationModel 
                                                = new SABRInterpolationModel (xBegin, xEnd, yBegin, t, forward, alpha, beta, nu, rho, alphaIsFixed, betaIsFixed, nuIsFixed, rhoIsFixed, vegaWeighted, endCriteria, optMethod, errorAccept, useMaxError, maxGuesses, shift, volatilityType, approximationModel)
let SabrSmileSection                            d forward sabrParams dc volatilityType shift 
                                                = new SabrSmileSectionModel (d, forward, sabrParams, dc, volatilityType, shift)
let SabrSmileSection1                           timeToExpiry forward sabrParams volatilityType shift 
                                                = new SabrSmileSectionModel1 (timeToExpiry, forward, sabrParams, volatilityType, shift)
let SABRSpecs                                   ()
                                                = new SABRSpecsModel ()
let SABRWrapper                                 t forward param addParams 
                                                = new SABRWrapperModel (t, forward, param, addParams)
let Sample                                      value_ weight_ 
                                                = new SampleModel<'T> (value_, weight_)
let SampledCurve                                grid 
                                                = new SampledCurveModel (grid)
let SampledCurve1                               gridSize 
                                                = new SampledCurveModel1 (gridSize)
let SARCurrency                                 ()
                                                = new SARCurrencyModel ()
let SaudiArabia                                 ()
                                                = new SaudiArabiaModel ()
let SavedSettings                               ()
                                                = new SavedSettingsModel ()
let Schedule                                    effectiveDate terminationDate tenor calendar convention terminationDateConvention rule endOfMonth firstDate nextToLastDate 
                                                = new ScheduleModel (effectiveDate, terminationDate, tenor, calendar, convention, terminationDateConvention, rule, endOfMonth, firstDate, nextToLastDate)
let Schedule1                                   dates calendar convention terminationDateConvention tenor rule endOfMonth isRegular 
                                                = new ScheduleModel1 (dates, calendar, convention, terminationDateConvention, tenor, rule, endOfMonth, isRegular)
let Schedule2                                   ()
                                                = new ScheduleModel2 ()
let Seasonality                                 ()
                                                = new SeasonalityModel ()
let SecondDerivativeOp                          direction mesher 
                                                = new SecondDerivativeOpModel (direction, mesher)
let SecondDerivativeOp1                         rhs 
                                                = new SecondDerivativeOpModel1 (rhs)
let SecondOrderMixedDerivativeOp                d0 d1 mesher 
                                                = new SecondOrderMixedDerivativeOpModel (d0, d1, mesher)
let SegmentIntegral                             intervals 
                                                = new SegmentIntegralModel (intervals)
let SEKCurrency                                 ()
                                                = new SEKCurrencyModel ()
let SEKLibor                                    tenor 
                                                = new SEKLiborModel (tenor)
let SEKLibor1                                   tenor h 
                                                = new SEKLiborModel1 (tenor, h)
let SequenceStatistics                          dimension 
                                                = new SequenceStatisticsModel (dimension)
let SGDCurrency                                 ()
                                                = new SGDCurrencyModel ()
let Shibor                                      tenor h 
                                                = new ShiborModel (tenor, h)
let Shibor1                                     tenor 
                                                = new ShiborModel1 (tenor)
let ShiftedBlackVolTermStructure                varianceOffset volTS 
                                                = new ShiftedBlackVolTermStructureModel (varianceOffset, volTS)
let ShoutCondition                              Type strike resTime rate 
                                                = new ShoutConditionModel (Type, strike, resTime, rate)
let ShoutCondition1                             intrinsicValues resTime rate 
                                                = new ShoutConditionModel1 (intrinsicValues, resTime, rate)
let simple_event                                date 
                                                = new simple_eventModel (date)
let SimpleCashFlow                              amount date 
                                                = new SimpleCashFlowModel (amount, date)
let SimpleDayCounter                            ()
                                                = new SimpleDayCounterModel ()
let SimplePolynomialFitting                     degree constrainAtZero weights optimizationMethod 
                                                = new SimplePolynomialFittingModel (degree, constrainAtZero, weights, optimizationMethod)
let SimpleQuote                                 ()
                                                = new SimpleQuoteModel ()
let SimpleQuote1                                value 
                                                = new SimpleQuoteModel1 (value)
let Simplex                                     lambda 
                                                = new SimplexModel (lambda)
let SimpsonIntegral                             accuracy maxIterations 
                                                = new SimpsonIntegralModel (accuracy, maxIterations)
let SimulatedAnnealing                          lambda T0 K alpha rng 
                                                = new SimulatedAnnealingModel<'RNG> (lambda, T0, K, alpha, rng)
let SimulatedAnnealing1                         lambda T0 epsilon m rng 
                                                = new SimulatedAnnealingModel1<'RNG> (lambda, T0, epsilon, m, rng)
let Singapore                                   ()
                                                = new SingaporeModel ()
let SITCurrency                                 ()
                                                = new SITCurrencyModel ()
let SKKCurrency                                 ()
                                                = new SKKCurrencyModel ()
let Slovakia                                    ()
                                                = new SlovakiaModel ()
let SobolBrownianBridgeRsg                      factors steps ordering seed directionIntegers 
                                                = new SobolBrownianBridgeRsgModel (factors, steps, ordering, seed, directionIntegers)
let SobolBrownianGenerator                      factors steps ordering seed directionIntegers 
                                                = new SobolBrownianGeneratorModel (factors, steps, ordering, seed, directionIntegers)
let SobolBrownianGeneratorFactory               ordering seed integers 
                                                = new SobolBrownianGeneratorFactoryModel (ordering, seed, integers)
let SobolRsg                                    dimensionality 
                                                = new SobolRsgModel (dimensionality)
let SobolRsg1                                   ()
                                                = new SobolRsgModel1 ()
let SobolRsg2                                   dimensionality seed directionIntegers 
                                                = new SobolRsgModel2 (dimensionality, seed, directionIntegers)
let SobolRsg3                                   dimensionality seed 
                                                = new SobolRsgModel3 (dimensionality, seed)
let SoftCallability                             price date trigger 
                                                = new SoftCallabilityModel (price, date, trigger)
let Sonia                                       h 
                                                = new SoniaModel (h)
let SouthAfrica                                 ()
                                                = new SouthAfricaModel ()
let SouthKorea                                  ()
                                                = new SouthKoreaModel ()
let SouthKorea1                                 m 
                                                = new SouthKoreaModel1 (m)
let SparseMatrix                                lhs 
                                                = new SparseMatrixModel (lhs)
let SparseMatrix1                               rows columns 
                                                = new SparseMatrixModel1 (rows, columns)
let SparseMatrix2                               ()
                                                = new SparseMatrixModel2 ()
let SpreadBasketPayoff                          p 
                                                = new SpreadBasketPayoffModel (p)
let SpreadedOptionletVolatility                 baseVol spread 
                                                = new SpreadedOptionletVolatilityModel (baseVol, spread)
let SpreadedSmileSection                        underlyingSection spread 
                                                = new SpreadedSmileSectionModel (underlyingSection, spread)
let SpreadedSwaptionVolatility                  baseVol spread 
                                                = new SpreadedSwaptionVolatilityModel (baseVol, spread)
let SpreadFittingMethod                         Method discountCurve 
                                                = new SpreadFittingMethodModel (Method, discountCurve)
let SpreadOption                                payoff exercise pricingEngine evaluationDate 
                                                = new SpreadOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let SquareRootProcess                           b a sigma x0 disc 
                                                = new SquareRootProcessModel (b, a, sigma, x0, disc)
let SquareRootProcess1                          b a sigma 
                                                = new SquareRootProcessModel1 (b, a, sigma)
let SquareRootProcess2                          b a sigma x0 
                                                = new SquareRootProcessModel2 (b, a, sigma, x0)
let StatsHolder                                 mean standardDeviation 
                                                = new StatsHolderModel (mean, standardDeviation)
let StatsHolder1                                ()
                                                = new StatsHolderModel1 ()
let SteepestDescent                             lineSearch 
                                                = new SteepestDescentModel (lineSearch)
let StepConditionSet<'array_type when 'array_type :> Vector>                            
                                                = new StepConditionSetModel<'array_type> ()
let StochasticProcessArray                      processes correlation 
                                                = new StochasticProcessArrayModel (processes, correlation)
let Stock                                       quote pricingEngine evaluationDate 
                                                = new StockModel (quote, pricingEngine, evaluationDate)
let StrikedTypePayoff                           p 
                                                = new StrikedTypePayoffModel (p)
let StrikedTypePayoff1                          Type strike 
                                                = new StrikedTypePayoffModel1 (Type, strike)
let StrippedOptionletAdapter                    s 
                                                = new StrippedOptionletAdapterModel (s)
let StulzEngine                                 process1 process2 correlation 
                                                = new StulzEngineModel (process1, process2, correlation)
let SuperFundPayoff                             strike secondStrike 
                                                = new SuperFundPayoffModel (strike, secondStrike)
let SuperSharePayoff                            strike secondStrike cashPayoff 
                                                = new SuperSharePayoffModel (strike, secondStrike, cashPayoff)
let SurvivalProbability                         ()
                                                = new SurvivalProbabilityModel ()
let SVD                                         M 
                                                = new SVDModel (M)
let SvenssonFitting                             weights optimizationMethod 
                                                = new SvenssonFittingModel (weights, optimizationMethod)
let SVI                                         t forward a b sigma rho m aIsFixed bIsFixed sigmaIsFixed rhoIsFixed mIsFixed vegaWeighted endCriteria optMethod errorAccept useMaxError maxGuesses addParams 
                                                = new SVIModel (t, forward, a, b, sigma, rho, m, aIsFixed, bIsFixed, sigmaIsFixed, rhoIsFixed, mIsFixed, vegaWeighted, endCriteria, optMethod, errorAccept, useMaxError, maxGuesses, addParams)
let SviInterpolatedSmileSection                 optionDate forward strikes hasFloatingStrikes atmVolatility volHandles a b sigma rho m isAFixed isBFixed isSigmaFixed isRhoFixed isMFixed vegaWeighted endCriteria Method dc 
                                                = new SviInterpolatedSmileSectionModel (optionDate, forward, strikes, hasFloatingStrikes, atmVolatility, volHandles, a, b, sigma, rho, m, isAFixed, isBFixed, isSigmaFixed, isRhoFixed, isMFixed, vegaWeighted, endCriteria, Method, dc)
let SviInterpolatedSmileSection1                optionDate forward strikes hasFloatingStrikes atmVolatility volHandles a b sigma rho m isAFixed isBFixed isSigmaFixed isRhoFixed isMFixed vegaWeighted endCriteria Method dc 
                                                = new SviInterpolatedSmileSectionModel1 (optionDate, forward, strikes, hasFloatingStrikes, atmVolatility, volHandles, a, b, sigma, rho, m, isAFixed, isBFixed, isSigmaFixed, isRhoFixed, isMFixed, vegaWeighted, endCriteria, Method, dc)
let SviInterpolation                            xBegin size yBegin t forward a b sigma rho m aIsFixed bIsFixed sigmaIsFixed rhoIsFixed mIsFixed vegaWeighted endCriteria optMethod errorAccept useMaxError maxGuesses addParams 
                                                = new SviInterpolationModel (xBegin, size, yBegin, t, forward, a, b, sigma, rho, m, aIsFixed, bIsFixed, sigmaIsFixed, rhoIsFixed, mIsFixed, vegaWeighted, endCriteria, optMethod, errorAccept, useMaxError, maxGuesses, addParams)
let SviSmileSection                             timeToExpiry forward sviParameters 
                                                = new SviSmileSectionModel (timeToExpiry, forward, sviParameters)
let SviSmileSection1                            d forward sviParameters dc 
                                                = new SviSmileSectionModel1 (d, forward, sviParameters, dc)
let SVISpecs                                    ()
                                                = new SVISpecsModel ()
let SVIWrapper                                  t forward param addParams 
                                                = new SVIWrapperModel (t, forward, param, addParams)
let Swap                                        legs payer pricingEngine evaluationDate 
                                                = new SwapModel (legs, payer, pricingEngine, evaluationDate)
let Swap1                                       firstLeg secondLeg pricingEngine evaluationDate 
                                                = new SwapModel1 (firstLeg, secondLeg, pricingEngine, evaluationDate)
let SwapIndex                                   familyName tenor settlementDays currency calendar fixedLegTenor fixedLegConvention fixedLegDayCounter iborIndex discountingTermStructure 
                                                = new SwapIndexModel (familyName, tenor, settlementDays, currency, calendar, fixedLegTenor, fixedLegConvention, fixedLegDayCounter, iborIndex, discountingTermStructure)
let SwapIndex1                                  familyName tenor settlementDays currency calendar fixedLegTenor fixedLegConvention fixedLegDayCounter iborIndex 
                                                = new SwapIndexModel1 (familyName, tenor, settlementDays, currency, calendar, fixedLegTenor, fixedLegConvention, fixedLegDayCounter, iborIndex)
let SwapIndex2                                  ()
                                                = new SwapIndexModel2 ()
let SwapRateHelper                              rate tenor calendar fixedFrequency fixedConvention fixedDayCount iborIndex spread fwdStart discount settlementDays pillarChoice customPillarDate 
                                                = new SwapRateHelperModel (rate, tenor, calendar, fixedFrequency, fixedConvention, fixedDayCount, iborIndex, spread, fwdStart, discount, settlementDays, pillarChoice, customPillarDate)
let SwapRateHelper1                             rate swapIndex spread fwdStart discount pillarChoice customPillarDate 
                                                = new SwapRateHelperModel1 (rate, swapIndex, spread, fwdStart, discount, pillarChoice, customPillarDate)
let SwapRateHelper2                             rate tenor calendar fixedFrequency fixedConvention fixedDayCount iborIndex spread fwdStart discount settlementDays pillarChoice customPillarDate 
                                                = new SwapRateHelperModel2 (rate, tenor, calendar, fixedFrequency, fixedConvention, fixedDayCount, iborIndex, spread, fwdStart, discount, settlementDays, pillarChoice, customPillarDate)
let SwapRateHelper3                             rate swapIndex spread fwdStart discount pillarChoice customPillarDate 
                                                = new SwapRateHelperModel3 (rate, swapIndex, spread, fwdStart, discount, pillarChoice, customPillarDate)
let SwapSpreadIndex                             familyName swapIndex1 swapIndex2 gearing1 gearing2 
                                                = new SwapSpreadIndexModel (familyName, swapIndex1, swapIndex2, gearing1, gearing2)
let SwapSpreadIndex1                            ()
                                                = new SwapSpreadIndexModel1 ()
let Swaption                                    swap exercise delivery settlementMethod pricingEngine evaluationDate 
                                                = new SwaptionModel (swap, exercise, delivery, settlementMethod, pricingEngine, evaluationDate)
let SwaptionHelper                              maturity length volatility index fixedLegTenor fixedLegDayCounter floatingLegDayCounter termStructure errorType strike nominal Type shift pricingEngine evaluationDate 
                                                = new SwaptionHelperModel (maturity, length, volatility, index, fixedLegTenor, fixedLegDayCounter, floatingLegDayCounter, termStructure, errorType, strike, nominal, Type, shift, pricingEngine, evaluationDate)
let SwaptionHelper1                             exerciseDate endDate volatility index fixedLegTenor fixedLegDayCounter floatingLegDayCounter termStructure errorType strike nominal Type shift pricingEngine evaluationDate 
                                                = new SwaptionHelperModel1 (exerciseDate, endDate, volatility, index, fixedLegTenor, fixedLegDayCounter, floatingLegDayCounter, termStructure, errorType, strike, nominal, Type, shift, pricingEngine, evaluationDate)
let SwaptionHelper2                             exerciseDate length volatility index fixedLegTenor fixedLegDayCounter floatingLegDayCounter termStructure errorType strike nominal Type shift pricingEngine evaluationDate 
                                                = new SwaptionHelperModel2 (exerciseDate, length, volatility, index, fixedLegTenor, fixedLegDayCounter, floatingLegDayCounter, termStructure, errorType, strike, nominal, Type, shift, pricingEngine, evaluationDate)
let SwaptionVolatilityMatrix                    today optionDates swapTenors vols dayCounter flatExtrapolation Type shifts 
                                                = new SwaptionVolatilityMatrixModel (today, optionDates, swapTenors, vols, dayCounter, flatExtrapolation, Type, shifts)
let SwaptionVolatilityMatrix1                   referenceDate calendar bdc optionTenors swapTenors vols dayCounter flatExtrapolation Type shifts 
                                                = new SwaptionVolatilityMatrixModel1 (referenceDate, calendar, bdc, optionTenors, swapTenors, vols, dayCounter, flatExtrapolation, Type, shifts)
let SwaptionVolatilityMatrix2                   calendar bdc optionTenors swapTenors vols dayCounter flatExtrapolation Type shifts 
                                                = new SwaptionVolatilityMatrixModel2 (calendar, bdc, optionTenors, swapTenors, vols, dayCounter, flatExtrapolation, Type, shifts)
let SwaptionVolatilityMatrix3                   referenceDate calendar bdc optionTenors swapTenors vols dayCounter flatExtrapolation Type shifts 
                                                = new SwaptionVolatilityMatrixModel3 (referenceDate, calendar, bdc, optionTenors, swapTenors, vols, dayCounter, flatExtrapolation, Type, shifts)
let SwaptionVolatilityMatrix4                   calendar bdc optionTenors swapTenors vols dayCounter flatExtrapolation Type shifts 
                                                = new SwaptionVolatilityMatrixModel4 (calendar, bdc, optionTenors, swapTenors, vols, dayCounter, flatExtrapolation, Type, shifts)
let SwaptionVolCube1x                           atmVolStructure optionTenors swapTenors strikeSpreads volSpreads swapIndexBase shortSwapIndexBase vegaWeightedSmileFit parametersGuess isParameterFixed isAtmCalibrated endCriteria maxErrorTolerance optMethod errorAccept useMaxError maxGuesses backwardFlat cutoffStrike 
                                                = new SwaptionVolCube1xModel (atmVolStructure, optionTenors, swapTenors, strikeSpreads, volSpreads, swapIndexBase, shortSwapIndexBase, vegaWeightedSmileFit, parametersGuess, isParameterFixed, isAtmCalibrated, endCriteria, maxErrorTolerance, optMethod, errorAccept, useMaxError, maxGuesses, backwardFlat, cutoffStrike)
let SwaptionVolCube2                            atmVolStructure optionTenors swapTenors strikeSpreads volSpreads swapIndexBase shortSwapIndexBase vegaWeightedSmileFit 
                                                = new SwaptionVolCube2Model (atmVolStructure, optionTenors, swapTenors, strikeSpreads, volSpreads, swapIndexBase, shortSwapIndexBase, vegaWeightedSmileFit)
let Sweden                                      ()
                                                = new SwedenModel ()
let Switzerland                                 ()
                                                = new SwitzerlandModel ()
let SymmetricSchurDecomposition                 s 
                                                = new SymmetricSchurDecompositionModel (s)
let TabulatedGaussLegendre                      n 
                                                = new TabulatedGaussLegendreModel (n)
let Taiwan                                      ()
                                                = new TaiwanModel ()
let TARGET                                      ()
                                                = new TARGETModel ()
let TermStructureConsistentModel                termStructure 
                                                = new TermStructureConsistentModelModel (termStructure)
let TermStructureFittingParameter               impl 
                                                = new TermStructureFittingParameterModel (impl)
let TermStructureFittingParameter1              term 
                                                = new TermStructureFittingParameterModel1 (term)
let Thailand                                    ()
                                                = new ThailandModel ()
let THBCurrency                                 ()
                                                = new THBCurrencyModel ()
let Thirty360                                   c 
                                                = new Thirty360Model (c)
let Thirty3601                                  ()
                                                = new Thirty360Model1 ()
let Tian                                        Process End steps strike 
                                                = new TianModel (Process, End, steps, strike)
let Tian1                                       ()
                                                = new TianModel1 ()
let Tibor                                       tenor 
                                                = new TiborModel (tenor)
let Tibor1                                      tenor h 
                                                = new TiborModel1 (tenor, h)
let TimeGrid                                    End steps 
                                                = new TimeGridModel (End, steps)
let TimeGrid1                                   times 
                                                = new TimeGridModel1 (times)
let TimeGrid2                                   times steps 
                                                = new TimeGridModel2 (times, steps)
let TimeGrid3                                   times offset steps 
                                                = new TimeGridModel3 (times, offset, steps)
let TimeSeries<'T>                              ()    
                                                = new TimeSeriesModel<'T> ()
let TimeSeries1                                 size 
                                                = new TimeSeriesModel1<'T> (size)
let TqrEigenDecomposition                       diag sub calc strategy 
                                                = new TqrEigenDecompositionModel (diag, sub, calc, strategy)
let TransformedGrid                             grid 
                                                = new TransformedGridModel (grid)
let TransformedGrid1                            grid func 
                                                = new TransformedGridModel1 (grid, func)
let TrapezoidIntegral                           accuracy maxIterations 
                                                = new TrapezoidIntegralModel<'IntegrationPolicy> (accuracy, maxIterations)
let Trbdf2                                      L bcs 
                                                = new Trbdf2Model<'Operator> (L, bcs)
let Trbdf21<'Operator when 'Operator :> IOperator> ()                                     
                                                = new Trbdf2Model1<'Operator> ()
let TrBDF2Scheme                                alpha map trapezoidalScheme bcSet relTol solverType 
                                                = new TrBDF2SchemeModel<'TrapezoidalScheme> (alpha, map, trapezoidalScheme, bcSet, relTol, solverType)
let TrBDF2Scheme1<'TrapezoidalScheme when 'TrapezoidalScheme : not struct and 'TrapezoidalScheme :> IMixedScheme> ()
                                                = new TrBDF2SchemeModel1<'TrapezoidalScheme> ()
let Tree                                        columns 
                                                = new TreeModel<'T> (columns)
let Tree1<'T>                                   ()    
                                                = new TreeModel1<'T> ()
let TreeCallableFixedRateBondEngine             model timeSteps termStructure 
                                                = new TreeCallableFixedRateBondEngineModel (model, timeSteps, termStructure)
let TreeCallableFixedRateBondEngine1            model timeGrid termStructure 
                                                = new TreeCallableFixedRateBondEngineModel1 (model, timeGrid, termStructure)
let TreeLattice                                 timeGrid n 
                                                = new TreeLatticeModel<'T> (timeGrid, n)
let TreeLattice1D                               timeGrid n 
                                                = new TreeLattice1DModel<'T> (timeGrid, n)
let TreeLattice2D                               tree1 tree2 correlation 
                                                = new TreeLattice2DModel<'T, 'Tl> (tree1, tree2, correlation)
let TreeSwaptionEngine                          model timeGrid termStructure 
                                                = new TreeSwaptionEngineModel (model, timeGrid, termStructure)
let TreeSwaptionEngine1                         model timeGrid 
                                                = new TreeSwaptionEngineModel1 (model, timeGrid)
let TreeSwaptionEngine2                         model timeSteps termStructure 
                                                = new TreeSwaptionEngineModel2 (model, timeSteps, termStructure)
let TreeSwaptionEngine3                         model timeSteps 
                                                = new TreeSwaptionEngineModel3 (model, timeSteps)
let TreeVanillaSwapEngine                       model timeSteps termStructure 
                                                = new TreeVanillaSwapEngineModel (model, timeSteps, termStructure)
let TreeVanillaSwapEngine1                      model timeGrid termStructure 
                                                = new TreeVanillaSwapEngineModel1 (model, timeGrid, termStructure)
let TridiagonalOperator                         ()
                                                = new TridiagonalOperatorModel ()
let TridiagonalOperator1                        low mid high 
                                                = new TridiagonalOperatorModel1 (low, mid, high)
let TridiagonalOperator2                        size 
                                                = new TridiagonalOperatorModel2 (size)
let Trigeorgis                                  ()
                                                = new TrigeorgisModel ()
let Trigeorgis1                                 Process End steps strike 
                                                = new TrigeorgisModel1 (Process, End, steps, strike)
let TrinomialTree                               Process timeGrid 
                                                = new TrinomialTreeModel (Process, timeGrid)
let TrinomialTree1                              Process timeGrid isPositive 
                                                = new TrinomialTreeModel1 (Process, timeGrid, isPositive)
let TripleBandLinearOp                          m 
                                                = new TripleBandLinearOpModel (m)
let TripleBandLinearOp1                         direction mesher 
                                                = new TripleBandLinearOpModel1 (direction, mesher)
let TRLCurrency                                 ()
                                                = new TRLCurrencyModel ()
let TRLibor                                     tenor 
                                                = new TRLiborModel (tenor)
let TRLibor1                                    tenor h 
                                                = new TRLiborModel1 (tenor, h)
let TRYCurrency                                 ()
                                                = new TRYCurrencyModel ()
let TsiveriotisFernandesLattice                 tree riskFreeRate End steps creditSpread sigma divYield 
                                                = new TsiveriotisFernandesLatticeModel<'T> (tree, riskFreeRate, End, steps, creditSpread, sigma, divYield)
let TTDCurrency                                 ()
                                                = new TTDCurrencyModel ()
let Turkey                                      ()
                                                = new TurkeyModel ()
let TWDCurrency                                 ()
                                                = new TWDCurrencyModel ()
let TypePayoff                                  Type 
                                                = new TypePayoffModel (Type)
let UAHCurrency                                 ()
                                                = new UAHCurrencyModel ()
let Ukraine                                     m 
                                                = new UkraineModel (m)
let UKRegion                                    ()
                                                = new UKRegionModel ()
let UKRPI                                       interpolated ts 
                                                = new UKRPIModel (interpolated, ts)
let UKRPI1                                      interpolated 
                                                = new UKRPIModel1 (interpolated)
let Uniform1dMesher                             start End size 
                                                = new Uniform1dMesherModel (start, End, size)
let UniformGridMesher                           layout boundaries 
                                                = new UniformGridMesherModel (layout, boundaries)
let UnitDisplacedBlackYoYInflationCouponPricer  capletVol 
                                                = new UnitDisplacedBlackYoYInflationCouponPricerModel (capletVol)
let UnitedKingdom                               ()
                                                = new UnitedKingdomModel ()
let UnitedKingdom1                              m 
                                                = new UnitedKingdomModel1 (m)
let UnitedStates                                m 
                                                = new UnitedStatesModel (m)
let UnitedStates1                               ()
                                                = new UnitedStatesModel1 ()
let UpRounding                                  precision 
                                                = new UpRoundingModel (precision)
let UpRounding1                                 precision digit 
                                                = new UpRoundingModel1 (precision, digit)
let USCPI                                       interpolated 
                                                = new USCPIModel (interpolated)
let USCPI1                                      interpolated ts 
                                                = new USCPIModel1 (interpolated, ts)
let USDCurrency                                 ()
                                                = new USDCurrencyModel ()
let USDLibor                                    tenor 
                                                = new USDLiborModel (tenor)
let USDLibor1                                   tenor h 
                                                = new USDLiborModel1 (tenor, h)
let USDLiborON                                  ()
                                                = new USDLiborONModel ()
let USDLiborON1                                 h 
                                                = new USDLiborONModel1 (h)
let UsdLiborSwapIsdaFixAm                       tenor h 
                                                = new UsdLiborSwapIsdaFixAmModel (tenor, h)
let UsdLiborSwapIsdaFixAm1                      tenor 
                                                = new UsdLiborSwapIsdaFixAmModel1 (tenor)
let UsdLiborSwapIsdaFixPm                       tenor h 
                                                = new UsdLiborSwapIsdaFixPmModel (tenor, h)
let UsdLiborSwapIsdaFixPm1                      tenor 
                                                = new UsdLiborSwapIsdaFixPmModel1 (tenor)
let USRegion                                    ()
                                                = new USRegionModel ()
let VanillaOption                               payoff exercise pricingEngine evaluationDate 
                                                = new VanillaOptionModel (payoff, exercise, pricingEngine, evaluationDate)
let VanillaSwap                                 Type nominal fixedSchedule fixedRate fixedDayCount floatSchedule iborIndex spread floatingDayCount paymentConvention pricingEngine evaluationDate 
                                                = new VanillaSwapModel (Type, nominal, fixedSchedule, fixedRate, fixedDayCount, floatSchedule, iborIndex, spread, floatingDayCount, paymentConvention, pricingEngine, evaluationDate)
let VannaVolga                                  spot dDiscount fDiscount T 
                                                = new VannaVolgaModel (spot, dDiscount, fDiscount, T)
let VannaVolgaBarrierEngine                     atmVol vol25Put vol25Call spotFX domesticTS foreignTS adaptVanDelta bsPriceWithSmile 
                                                = new VannaVolgaBarrierEngineModel (atmVol, vol25Put, vol25Call, spotFX, domesticTS, foreignTS, adaptVanDelta, bsPriceWithSmile)
let VannaVolgaDoubleBarrierEngine               atmVol vol25Put vol25Call spotFX domesticTS foreignTS getEngine adaptVanDelta bsPriceWithSmile series pricingEngine evaluationDate 
                                                = new VannaVolgaDoubleBarrierEngineModel (atmVol, vol25Put, vol25Call, spotFX, domesticTS, foreignTS, getEngine, adaptVanDelta, bsPriceWithSmile, series, pricingEngine, evaluationDate)
let VannaVolgaInterpolation                     xBegin size yBegin spot dDiscount fDiscount T 
                                                = new VannaVolgaInterpolationModel (xBegin, size, yBegin, spot, dDiscount, fDiscount, T)
let VarProxy_Helper                             proxy i j 
                                                = new VarProxy_HelperModel (proxy, i, j)
let Vasicek                                     r0 a b sigma lambda 
                                                = new VasicekModel (r0, a, b, sigma, lambda)
let VEBCurrency                                 ()
                                                = new VEBCurrencyModel ()
let Vector                                      ()
                                                = new VectorModel ()
let Vector1                                     from 
                                                = new VectorModel1 (from)
let Vector2                                     from 
                                                = new VectorModel2 (from)
let Vector3                                     size value increment 
                                                = new VectorModel3 (size, value, increment)
let Vector4                                     size 
                                                = new VectorModel4 (size)
let Vector5                                     size value 
                                                = new VectorModel5 (size, value)
let VNDCurrency                                 ()
                                                = new VNDCurrencyModel ()
let VoluntaryPrepay                             amount date 
                                                = new VoluntaryPrepayModel (amount, date)
let WeakEventSource                             ()
                                                = new WeakEventSourceModel ()
let WeekendsOnly                                ()
                                                = new WeekendsOnlyModel ()
let WulinYongDoubleBarrierEngine                Process series 
                                                = new WulinYongDoubleBarrierEngineModel (Process, series)
let XABRCoeffHolder                             t forward _params paramIsFixed addParams 
                                                = new XABRCoeffHolderModel<'Model> (t, forward, _params, paramIsFixed, addParams)
let XABRConstraint                              impl 
                                                = new XABRConstraintModel (impl)
let XABRConstraint1                             ()
                                                = new XABRConstraintModel1 ()
let YearOnYearInflationSwap                     Type nominal fixedSchedule fixedRate fixedDayCount yoySchedule yoyIndex observationLag spread yoyDayCount paymentCalendar paymentConvention pricingEngine evaluationDate 
                                                = new YearOnYearInflationSwapModel (Type, nominal, fixedSchedule, fixedRate, fixedDayCount, yoySchedule, yoyIndex, observationLag, spread, yoyDayCount, paymentCalendar, paymentConvention, pricingEngine, evaluationDate)
let YearOnYearInflationSwapHelper               quote swapObsLag maturity calendar paymentConvention dayCounter yii 
                                                = new YearOnYearInflationSwapHelperModel (quote, swapObsLag, maturity, calendar, paymentConvention, dayCounter, yii)
let YoYInflationBachelierCapFloorEngine         index vol 
                                                = new YoYInflationBachelierCapFloorEngineModel (index, vol)
let YoYInflationBlackCapFloorEngine             index volatility 
                                                = new YoYInflationBlackCapFloorEngineModel (index, volatility)
let YoYInflationCap                             yoyLeg exerciseRates pricingEngine evaluationDate 
                                                = new YoYInflationCapModel (yoyLeg, exerciseRates, pricingEngine, evaluationDate)
let YoYInflationCapFloor                        Type yoyLeg strikes pricingEngine evaluationDate 
                                                = new YoYInflationCapFloorModel (Type, yoyLeg, strikes, pricingEngine, evaluationDate)
let YoYInflationCapFloor1                       Type yoyLeg capRates floorRates pricingEngine evaluationDate 
                                                = new YoYInflationCapFloorModel1 (Type, yoyLeg, capRates, floorRates, pricingEngine, evaluationDate)
let YoYInflationCapFloorEngine                  index vol 
                                                = new YoYInflationCapFloorEngineModel (index, vol)
let YoYInflationCollar                          yoyLeg capRates floorRates pricingEngine evaluationDate 
                                                = new YoYInflationCollarModel (yoyLeg, capRates, floorRates, pricingEngine, evaluationDate)
let YoYInflationCoupon                          paymentDate nominal startDate endDate fixingDays yoyIndex observationLag dayCounter gearing spread refPeriodStart refPeriodEnd 
                                                = new YoYInflationCouponModel (paymentDate, nominal, startDate, endDate, fixingDays, yoyIndex, observationLag, dayCounter, gearing, spread, refPeriodStart, refPeriodEnd)
let YoYInflationCouponPricer                    capletVol 
                                                = new YoYInflationCouponPricerModel (capletVol)
let YoYInflationFloor                           yoyLeg exerciseRates pricingEngine evaluationDate 
                                                = new YoYInflationFloorModel (yoyLeg, exerciseRates, pricingEngine, evaluationDate)
let YoYInflationIndex                           familyName region revised interpolated ratio frequency availabilityLag currency yoyInflation 
                                                = new YoYInflationIndexModel (familyName, region, revised, interpolated, ratio, frequency, availabilityLag, currency, yoyInflation)
let yoyInflationLeg                             schedule cal index observationLag 
                                                = new yoyInflationLegModel (schedule, cal, index, observationLag)
let YoYInflationTraits                          ()
                                                = new YoYInflationTraitsModel ()
let YoYInflationUnitDisplacedBlackCapFloorEngine  index vol 
                                                = new YoYInflationUnitDisplacedBlackCapFloorEngineModel (index, vol)
let YYAUCPI                                     frequency revised interpolated 
                                                = new YYAUCPIModel (frequency, revised, interpolated)
let YYAUCPI1                                    frequency revised interpolated ts 
                                                = new YYAUCPIModel1 (frequency, revised, interpolated, ts)
let YYAUCPIr                                    frequency revised interpolated 
                                                = new YYAUCPIrModel (frequency, revised, interpolated)
let YYAUCPIr1                                   frequency revised interpolated ts 
                                                = new YYAUCPIrModel1 (frequency, revised, interpolated, ts)
let YYEUHICP                                    interpolated 
                                                = new YYEUHICPModel (interpolated)
let YYEUHICP1                                   interpolated ts 
                                                = new YYEUHICPModel1 (interpolated, ts)
let YYEUHICPr                                   interpolated 
                                                = new YYEUHICPrModel (interpolated)
let YYEUHICPr1                                  interpolated ts 
                                                = new YYEUHICPrModel1 (interpolated, ts)
let YYFRHICP                                    interpolated ts 
                                                = new YYFRHICPModel (interpolated, ts)
let YYFRHICP1                                   interpolated 
                                                = new YYFRHICPModel1 (interpolated)
let YYFRHICPr                                   interpolated ts 
                                                = new YYFRHICPrModel (interpolated, ts)
let YYFRHICPr1                                  interpolated 
                                                = new YYFRHICPrModel1 (interpolated)
let YYUKRPI                                     interpolated ts 
                                                = new YYUKRPIModel (interpolated, ts)
let YYUKRPI1                                    interpolated 
                                                = new YYUKRPIModel1 (interpolated)
let YYUKRPIr                                    interpolated 
                                                = new YYUKRPIrModel (interpolated)
let YYUKRPIr1                                   interpolated ts 
                                                = new YYUKRPIrModel1 (interpolated, ts)
let YYUSCPI                                     interpolated ts 
                                                = new YYUSCPIModel (interpolated, ts)
let YYUSCPI1                                    interpolated 
                                                = new YYUSCPIModel1 (interpolated)
let YYUSCPIr                                    interpolated 
                                                = new YYUSCPIrModel (interpolated)
let YYUSCPIr1                                   interpolated ts 
                                                = new YYUSCPIrModel1 (interpolated, ts)
let YYZACPI                                     interpolated ts 
                                                = new YYZACPIModel (interpolated, ts)
let YYZACPI1                                    interpolated 
                                                = new YYZACPIModel1 (interpolated)
let YYZACPIr                                    interpolated 
                                                = new YYZACPIrModel (interpolated)
let YYZACPIr1                                   interpolated ts 
                                                = new YYZACPIrModel1 (interpolated, ts)
let ZACPI                                       interpolated 
                                                = new ZACPIModel (interpolated)
let ZACPI1                                      interpolated ts 
                                                = new ZACPIModel1 (interpolated, ts)
let ZARCurrency                                 ()
                                                = new ZARCurrencyModel ()
let ZARegion                                    ()
                                                = new ZARegionModel ()
let ZeroCondition<'array_type when 'array_type :> Vector>                               
                                                = new ZeroConditionModel<'array_type> ()
let ZeroCouponBond                              settlementDays calendar faceAmount maturityDate paymentConvention redemption issueDate pricingEngine evaluationDate 
                                                = new ZeroCouponBondModel (settlementDays, calendar, faceAmount, maturityDate, paymentConvention, redemption, issueDate, pricingEngine, evaluationDate)
let ZeroCouponInflationSwap                     Type nominal startDate maturity fixCalendar fixConvention dayCounter fixedRate infIndex observationLag adjustInfObsDates infCalendar infConvention pricingEngine evaluationDate 
                                                = new ZeroCouponInflationSwapModel (Type, nominal, startDate, maturity, fixCalendar, fixConvention, dayCounter, fixedRate, infIndex, observationLag, adjustInfObsDates, infCalendar, infConvention, pricingEngine, evaluationDate)
let ZeroCouponInflationSwapHelper               quote swapObsLag maturity calendar paymentConvention dayCounter zii 
                                                = new ZeroCouponInflationSwapHelperModel (quote, swapObsLag, maturity, calendar, paymentConvention, dayCounter, zii)
let ZeroInflationIndex                          familyName region revised interpolated frequency availabilityLag currency ts 
                                                = new ZeroInflationIndexModel (familyName, region, revised, interpolated, frequency, availabilityLag, currency, ts)
let ZeroInflationTraits                         ()
                                                = new ZeroInflationTraitsModel ()
let ZeroSpreadedTermStructure                   h spread comp freq dc 
                                                = new ZeroSpreadedTermStructureModel (h, spread, comp, freq, dc)
let ZeroYield                                   ()
                                                = new ZeroYieldModel ()
let Zibor                                       tenor h 
                                                = new ZiborModel (tenor, h)
let Zibor1                                      tenor 
                                                = new ZiborModel1 (tenor)

