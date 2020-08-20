/* 
    Copyright (c) 2020 Cepheis Ltd
    All rights reserves
*/
/*
using System;
using QLNet;

namespace Cephei.QLNetHelper
{
    public static class Extensions
    {
        public static bool GLOBAL(this Abcd THIS)
        {
            return THIS.global;
        }
        public static VolatilityType TYPE(this BachelierSpec THIS)
        {
            return THIS.type();
        }
        public static bool GLOBAL(this BackwardFlat THIS)
        {
            return THIS.global;
        }
        public static VolatilityType TYPE(this Black76Spec THIS)
        {
            return THIS.type();
        }
        public static BMASwap.Type TYPE(this BMASwap THIS)
        {
            return THIS.type();
        }
        public static double YIELD(this Bond THIS, DayCounter dc, Compounding comp, Frequency freq, double accuracy, int maxEvaluations)
        {
            return THIS.yield(dc, comp, freq, accuracy, maxEvaluations);
        }
        public static double YIELD(this Bond THIS, double cleanPrice, DayCounter dc, Compounding comp, Frequency freq, Date settlement, double accuracy, int maxEvaluations)
        {
            return THIS.yield(cleanPrice, dc, comp, freq, settlement, accuracy, maxEvaluations);
        }
        public static double YIELD(this BTP THIS, double cleanPrice, Date settlementDate, double accuracy, int maxEvaluations)
        {
            return THIS.yield(cleanPrice, settlementDate, accuracy, maxEvaluations);
        }
        public static Constraint CONSTRAINT(this CalibratedModel THIS)
        {
            return THIS.constraint();
        }
        public static Callability.Type TYPE(this Callability THIS)
        {
            return THIS.type();
        }
        public static double YIELD(this CashFlows THIS, System.Collections.Generic.List<QLNet.CashFlow> leg, double npv, DayCounter dayCounter, Compounding compounding, Frequency frequency, bool includeSettlementDateFlows, Date settlementDate, Date npvDate, double accuracy, int maxIterations, double guess)
        {
            return THIS.yield(leg, npv, dayCounter, compounding, frequency, includeSettlementDateFlows, settlementDate, npvDate, accuracy, maxIterations, guess);
        }
        public static bool GLOBAL(this ConvexMonotone THIS)
        {
            return THIS.global;
        }
        public static Option.Type TYPE(this CPICapFloor THIS)
        {
            return THIS.type();
        }
        public static CPISwap.Type TYPE(this CPISwap THIS)
        {
            return THIS.type();
        }
        public static bool GLOBAL(this Cubic THIS)
        {
            return THIS.global;
        }
        public static Lattice METHOD(this DiscretizedAsset THIS)
        {
            return THIS.method();
        }
        public static GeneralizedBlackScholesProcess PROCESS(this DiscretizedConvertible THIS)
        {
            return THIS.process();
        }
        public static ExchangeRate.Type TYPE(this ExchangeRate THIS)
        {
            return THIS.type;
        }
        public static Exercise.Type TYPE(this Exercise THIS)
        {
            return THIS.type();
        }
        public static FdmLinearOpIterator BEGIN(this FdmLinearOpLayout THIS)
        {
            return THIS.begin();
        }
        public static FdmLinearOpIterator END(this FdmLinearOpLayout THIS)
        {
            return THIS.end();
        }
        public static FdmSchemeDesc.FdmSchemeType TYPE(this FdmSchemeDesc THIS)
        {
            return THIS.type;
        }
        public static VanillaSwap.Type TYPE(this FloatFloatSwap THIS)
        {
            return THIS.type();
        }
        public static bool GLOBAL(this ForwardFlat THIS)
        {
            return THIS.global;
        }
        public static HestonProcess PROCESS(this HestonModel THIS)
        {
            return THIS.process();
        }
        public static bool GLOBAL(this IInterpolationFactory THIS)
        {
            return THIS.global;
        }
        public static VolatilityType TYPE(this ISwaptionEngineSpec THIS)
        {
            return THIS.type();
        }
        public static bool GLOBAL(this Linear THIS)
        {
            return THIS.global;
        }
        public static bool GLOBAL(this LogCubic THIS)
        {
            return THIS.global;
        }
        public static bool GLOBAL(this LogLinear THIS)
        {
            return THIS.global;
        }
        public static MakeSchedule TO(this MakeSchedule THIS, Date terminationDate)
        {
            return THIS.to(terminationDate);
        }
        public static bool GLOBAL(this MixedLinearCubic THIS)
        {
            return THIS.global;
        }
        public static OvernightIndexedSwap.Type TYPE(this OvernightIndexedSwap THIS)
        {
            return THIS.type();
        }
        public static Constraint CONSTRAINT(this Parameter THIS)
        {
            return THIS.constraint();
        }
        public static Callability.Price.Type TYPE(this Callability.Price THIS)
        {
            return THIS.type();
        }
        public static Constraint CONSTRAINT(this Problem THIS)
        {
            return THIS.constraint();
        }
        public static Vector INCLUDE(this ProjectedCostFunction THIS, Vector projectedParameters)
        {
            return THIS.include(projectedParameters);
        }
        public static Vector INCLUDE(this Projection THIS, Vector projectedParameters)
        {
            return THIS.include(projectedParameters);
        }
        public static double YIELD(this RendistatoCalculator THIS)
        {
            return THIS.yield();
        }
        public static StochasticProcess PROCESS(this TwoFactorModel.ShortRateDynamics THIS)
        {
            return THIS.process();
        }
        public static StochasticProcess1D PROCESS(this StochasticProcessArray THIS, int i)
        {
            return THIS.process(i);
        }
        public static VanillaSwap.Type TYPE(this Swaption THIS)
        {
            return THIS.type();
        }
        public static YearOnYearInflationSwap.Type TYPE(this YearOnYearInflationSwap THIS)
        {
            return THIS.type();
        }
        public static CapFloorType TYPE(this YoYInflationCapFloor THIS)
        {
            return THIS.type();
        }
        public static ZeroCouponInflationSwap.Type TYPE(this ZeroCouponInflationSwap THIS)
        {
            return THIS.type();
        }
    }
}

*/