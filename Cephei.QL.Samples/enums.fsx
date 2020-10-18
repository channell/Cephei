let matcher = [|
[|"GFunctionFactory.YieldCurveModel";"Standard, ExactYield, ParallelShifts, NonParallelShifts"|];
[|"BlackIborCouponPricer.TimingAdjustment";"Black76, BivariateLognormal"|];
[|"InterpolationType";"AsIndex, Flat, Linear"|];
[|"Settings.Strategy";"RateBound, VegaRatio, PriceThreshold, BSStdDevs"|];
[|"Replication.Type";"Sub, Central, Super"|];
[|"ExchangeRate.Type";"Direct, Derived"|];
[|"QLNetExceptionEnum";"ArgumentException, NotTradableException, RootNotBracketException, MaxNumberFuncEvalExceeded, InvalidPriceSignException, NullEffectiveDate"|];
[|"MatrixUtilitites.SalvagingAlgorithm";"None, Spectral, Hypersphere, LowerDiagonal, Higham"|];
[|"TqrEigenDecomposition.EigenVectorCalculation";"WithEigenVector, WithoutEigenVector, OnlyFirstRowEigenVector"|];
[|"TqrEigenDecomposition.ShiftStrategy";"NoShift, Overrelaxation, CloseEigenValue"|];
[|"TreeLattice2D.Branches";"branches"|];
[|"TrinomialTree.Branches";"branches"|];
[|"LsmBasisSystem.PolynomType";"Monomial, Laguerre, Hermite, Hyperbolic, Legendre, Chebyshev, Chebyshev2th"|];
[|"AmortizingMethod";"EffectiveInterestRate"|];
[|"Average.Type";"Arithmetic, Geometric, NULL"|];
[|"Barrier.Type";"DownIn, UpIn, DownOut, UpOut, NULL"|];
[|"BasisSwap.Type";"Receiver, Payer"|];
[|"BMASwap.Type";"Receiver, Payer"|];
[|"Price.Type";"Dirty, Clean"|];
[|"Callability.Type";"Call, Put"|];
[|"CPISwap.Type";"Receiver, Payer"|];
[|"Protection.Side";"Buyer, Seller"|];
[|"PricingModel";"Midpoint, ISDA"|];
[|"DoubleBarrier.Type";"KnockIn, KnockOut, KIKO, KOKI"|];
[|"Futures.Type";"IMM, ASX"|];
[|"Loan.Type";"Deposit, Loan"|];
[|"Loan.Amortising";"Bullet, Step, French"|];
[|"OvernightIndexedSwap.Type";"Receiver, Payer"|];
[|"Settlement.Type";"Physical, Cash"|];
[|"Settlement.Method";"PhysicalOTC, PhysicalCleared, CollateralizedCashPrice, ParYieldCurve"|];
[|"VanillaSwap.Type";"Receiver, Payer"|];
[|"YearOnYearInflationSwap.Type";"Receiver, Payer"|];
[|"ZeroCouponInflationSwap.Type";"Receiver, Payer"|];
[|"ConvexMonotoneImpl.SectionType";"EverywhereConstant, ConstantGradient, QuadraticMinimum, QuadraticMaximum"|];
[|"CubicInterpolation.DerivativeApprox";"Spline, SplineOM1, SplineOM2, FourthOrder, Parabolic, FritschButland, Akima, Kruger, Harmonic"|];
[|"CubicInterpolation.BoundaryCondition";"NotAKnot, FirstDerivative, SecondDerivative, Periodic, Lagrange"|];
[|"Behavior";"ShareRanges, SplitRanges"|];
[|"DifferentialEvolution.Strategy";"Rand1Standard, BestMemberWithJitter, CurrentToBest2Diffs, Rand1DiffWithPerVectorDither, Rand1DiffWithDither, EitherOrWithOptimalRecombination, Rand1SelfadaptiveWithRotation"|];
[|"DifferentialEvolution.CrossoverType";"Normal, Binomial, Exponential"|];
[|"EndCriteria.Type";"None, MaxIterations, StationaryPoint, StationaryFunctionValue, StationaryFunctionAccuracy, ZeroGradientNorm, Unknown"|];
[|"SimulatedAnnealing.Scheme";"ConstantFactor, ConstantBudget"|];
[|"SobolRsg.DirectionIntegers";"Unit, Jaeckel, SobolLevitan, SobolLevitanLemieux, JoeKuoD5, JoeKuoD6, JoeKuoD7, Kuo, Kuo2, Kuo3"|];
[|"NumericalDifferentiation.Scheme";"Central, Backward, Forward"|];
[|"Rounding.Type";"None, Up, Down, Closest, Floor, Ceiling"|];
[|"ImplicitEulerScheme.SolverType";"BiCGstab, GMRES"|];
[|"TrBDF2Scheme.SolverType";"BiCGstab, GMRES"|];
[|"FdmSchemeDesc.FdmSchemeType";"HundsdorferType, DouglasType, CraigSneydType, ModifiedCraigSneydType, ImplicitEulerType, ExplicitEulerType, MethodOfLinesType, TrBDF2Type, CrankNicolsonType"|];
[|"BoundaryCondition.Side";"None, Upper, Lower"|];
[|"BinomialTree.Branches";"branches"|];
[|"SobolBrownianGenerator.Ordering";"Factors, Steps, Diagonal"|];
[|"CalibrationHelper.CalibrationErrorType";"RelativePriceError, PriceError, ImpliedVolError"|];
[|"IsdaCdsEngine.NumericalFix";"None, Taylor"|];
[|"IsdaCdsEngine.AccrualBias";"HalfDayBias, NoBias"|];
[|"IsdaCdsEngine.ForwardsInCouponPeriod";"Flat, Piecewise"|];
[|"BlackStyleSwaptionEngine.CashAnnuityModel";"SwapRate, DiscountCurve"|];
[|"Integration.Algorithm";"GaussLobatto, GaussKronrod, Simpson, Trapezoid, GaussLaguerre, GaussLegendre, GaussChebyshev, GaussChebyshev2nd"|];
[|"AnalyticHestonEngine.ComplexLogFormula";"Gatheral, BranchCorrection"|];
[|"FdBlackScholesVanillaEngine.CashDividendModel";"Spot, Escrowed"|];
[|"HestonExpansionEngine.HestonExpansionFormula";"LPP2, LPP3, Forde"|];
[|"HestonProcess.Discretization";"PartialTruncation, FullTruncation, Reflection, NonCentralChiSquareVariance, QuadraticExponential, QuadraticExponentialMartingale, BroadieKayaExactSchemeLobatto, BroadieKayaExactSchemeLaguerre, BroadieKayaExactSchemeTrapezoidal"|];
[|"HybridHestonHullWhiteProcess.Discretization";"Euler, BSMHullWhite"|];
[|"DeltaVolQuote.DeltaType";"Spot, Fwd, PaSpot, PaFwd"|];
[|"DeltaVolQuote.AtmType";"AtmNull, AtmSpot, AtmFwd, AtmDeltaNeutral, AtmVegaMax, AtmGammaMax, AtmPutCall50"|];
[|"BlackVarianceSurface.Extrapolation";"ConstantExtrapolation, InterpolatorDefaultExtrapolation"|];
[|"FixedLocalVolSurface.Extrapolation";"ConstantExtrapolation, InterpolatorDefaultExtrapolation"|];
[|"VolatilityType";"ShiftedLognormal, Normal"|];
[|"SabrApproximationModel";"Obloj2008, Hagan2002"|];
[|"Pillar.Choice";"MaturityDate, LastRelevantDate, CustomDate"|];
[|"Brazil.Market";"Settlement, Exchange"|];
[|"Canada.Market";"Settlement, TSX"|];
[|"China.Market";"SSE, IB"|];
[|"Germany.Market";"Settlement, FrankfurtStockExchange, Xetra, Eurex, Euwax"|];
[|"Indonesia.Market";"BEJ, JSX, IDX"|];
[|"Israel.Market";"Settlement, TASE"|];
[|"Italy.Market";"Settlement, Exchange"|];
[|"JointCalendar.JointCalendarRule";"JoinHolidays, JoinBusinessDays"|];
[|"Russia.Market";"Settlement, MOEX"|];
[|"SouthKorea.Market";"Settlement, KRX"|];
[|"Ukraine.Market";"USE"|];
[|"UnitedKingdom.Market";"Settlement, Exchange, Metals"|];
[|"UnitedStates.Market";"Settlement, NYSE, GovernmentBond, NERC"|];
[|"Actual360.Actual360Convention";"excludeLastDay, includeLastDay"|];
[|"ActualActual.Convention";"ISMA, Bond, ISDA, Historical, Actual365, AFB, Euro"|];
[|"Thirty360.Thirty360Convention";"USA, BondBasis, European, EurobondBasis, Italian"|];
[|"ASX.Months";"F, G, H, J, K, M, N, Q, U, V, X, Z"|];
[|"IMM.Month";"F, G, H, J, K, M, N, Q, U, V, X, Z"|];
[|"Exercise.Type";"American, Bermudan, European"|];
[|"Money.ConversionType";"NoConversion, BaseCurrencyConversion, AutomatedConversion"|];
[|"Option.Type";"Put, Call"|];
[|"Duration.Type";"Simple, Macaulay, Modified"|];
[|"Position.Type";"Long, Short"|];
[|"InterestRateType";"Fixed, Floating"|];
[|"Compounding";"Simple, Compounded, Continuous, SimpleThenCompounded"|];
[|"Month";"January, February, March, April, May, June, July, August, September, October, November, December, Jan, Feb, Mar, Apr, Jun, Jul, Aug, Sep, Oct, Nov, Dec"|];
[|"BusinessDayConvention";"Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest"|];
[|"TimeUnit";"Days, Weeks, Months, Years"|];
[|"Frequency";"NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency"|];
[|"DateGeneration.Rule";"Backward, Forward, Zero, ThirdWednesday, Twentieth, TwentiethIMM, OldCDS, CDS, CDS2015"|];
[|"CapFloorType";"Collar, Cap, Floor"|];
[|"T_BasketOption.BasketType";"MinBasket, MaxBasket, SpreadBasket"|];
[|"T_Bonds.CouponType";"FixedRate, AdjRate, OIS, ZeroCoupon"|];
[|"T_EuropeanOption.EngineType";"Analytic, JR, CRR, EQP, TGEO, TIAN, LR, JOSHI, FiniteDifferences, Integral, PseudoMonteCarlo, QuasiMonteCarlo"|];
[|"T_Optimizers.OptimizationMethodType";"simplex, levenbergMarquardt, levenbergMarquardt2, conjugateGradient, conjugateGradient_goldstein, steepestDescent, steepestDescent_goldstein, bfgs, bfgs_goldstein"|]|]

open System.Text
open System
open System.IO
open System.Collections.Generic
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable replist = [("","")]

        let edit (s : string) = 

            if s.Contains("[<ExcelArgument") then
                let rep =
                    replist
                    |> Seq.filter (fun i -> s.Contains(fst i))
                    |> Seq.map (fun i -> snd i)
                    |> Seq.toList
                if rep = [] then 
                    s
                else
                    let reps = List.head rep
                    let todesc = s.Substring(s.IndexOf("Description"))
                    let startq = todesc.Substring(todesc.IndexOf("\"") + 1)
                    let toend = startq.Substring(0, startq.IndexOf("\""))
                    Console.WriteLine ("Replacing {0} with {1}\n", toend, reps)
                    s.Replace(toend, reps)
            else 
                s
        let lines = 
            File.ReadAllLines s
            |> Array.map edit 
        File.WriteAllLines (s, lines, Encoding.UTF8) 
    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.iter filelines 

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL\Functions" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")
