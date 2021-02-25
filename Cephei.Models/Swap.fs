
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type swapModel 
    (    ) as this =
    inherit Model<VanillaSwap> ()

(* functions *)
    let _calendar = Fun.TARGET()
    let _settlementDate = _calendar.Adjust (value (new Date(int (38252)))) (value BusinessDayConvention.Following)
    let _nfixingDays = (value (Convert.ToInt32(-2)))
    let _todaysDate = _calendar.Advance1 _settlementDate _nfixingDays (value TimeUnit.Days) (value BusinessDayConvention.ModifiedFollowing) (value true)
    let _depositDayCounter = Fun.Actual360 (value false)
    let _swFixedLegDayCounter = Fun.Thirty360 (value Thirty360.Thirty360Convention.European)
    let _futMonths = (value (Convert.ToInt32(3)))
    let _swapFixing = (value (Convert.ToInt32(3)))
    let _swFloatingLegIndex = Fun.Euribor6M1()
    let _fixingDays = (value (Convert.ToInt32(2)))
    let _sratePY5 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0443)))
    let _sratePY3 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0398)))
    let _sratePY15 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.055175)))
    let _sratePY10 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.05165)))
    let _PY5 = Fun.Period (value (Convert.ToInt32(5))) (value TimeUnit.Years)
    let _PY3 = Fun.Period (value (Convert.ToInt32(3))) (value TimeUnit.Years)
    let _PY15 = Fun.Period (value (Convert.ToInt32(15))) (value TimeUnit.Years)
    let _PY10 = Fun.Period (value (Convert.ToInt32(10))) (value TimeUnit.Years)
    let _DepoRD1W = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0382)))
    let _DepoRD1M = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0372)))
    let _D1W = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Weeks)
    let _D1M = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Months)
    let _SPY5 = Fun.SwapRateHelper2 (triv null (fun () -> toHandle ((cast<QLNet.Quote> _sratePY5).Value ))) _PY5 (cast<QLNet.Calendar> _calendar) (value Frequency.Annual) (value BusinessDayConvention.Unadjusted) (cast<QLNet.DayCounter> _swFixedLegDayCounter) (cast<QLNet.IborIndex> _swFloatingLegIndex) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value (null :> QLNet.Period)) (triv null (fun () -> toHandle (null :> QLNet.YieldTermStructure))) (triv null (fun () -> Nullable<int>())) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _SPY3 = Fun.SwapRateHelper2 (triv null (fun () -> toHandle ((cast<QLNet.Quote> _sratePY3).Value ))) _PY3 (cast<QLNet.Calendar> _calendar) (value Frequency.Annual) (value BusinessDayConvention.Unadjusted) (cast<QLNet.DayCounter> _swFixedLegDayCounter) (cast<QLNet.IborIndex> _swFloatingLegIndex) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value (null :> QLNet.Period)) (triv null (fun () -> toHandle (null :> QLNet.YieldTermStructure))) (triv null (fun () -> Nullable<int>())) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _SPY15 = Fun.SwapRateHelper2 (triv null (fun () -> toHandle ((cast<QLNet.Quote> _sratePY15).Value ))) _PY15 (cast<QLNet.Calendar> _calendar) (value Frequency.Annual) (value BusinessDayConvention.Unadjusted) (cast<QLNet.DayCounter> _swFixedLegDayCounter) (cast<QLNet.IborIndex> _swFloatingLegIndex) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value (null :> QLNet.Period)) (triv null (fun () -> toHandle (null :> QLNet.YieldTermStructure))) (triv null (fun () -> Nullable<int>())) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _SPY10 = Fun.SwapRateHelper2 (triv null (fun () -> toHandle ((cast<QLNet.Quote> _sratePY10).Value ))) _PY10 (cast<QLNet.Calendar> _calendar) (value Frequency.Annual) (value BusinessDayConvention.Unadjusted) (cast<QLNet.DayCounter> _swFixedLegDayCounter) (cast<QLNet.IborIndex> _swFloatingLegIndex) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value (null :> QLNet.Period)) (triv null (fun () -> toHandle (null :> QLNet.YieldTermStructure))) (triv null (fun () -> Nullable<int>())) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _DeD1W = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD1W).Value ))) _D1W _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _DeD1M = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD1M).Value ))) _D1M _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _tolerance = (value (Convert.ToDouble(1E-15)))
    let _termStructureDayCounter = Fun.ActualActual1 (value ActualActual.Convention.ISDA) (value (null :> QLNet.Schedule))
    let _LogLinear = Fun.LogLinear ()
    let _Discount = Fun.Discount ()
    let _lenYears = Fun.Period (value (Convert.ToInt32(5))) (value TimeUnit.Years)
    let _maturity = _calendar.Advance _settlementDate _lenYears (value BusinessDayConvention.Following) (value false)
    let _imm8 = Fun.Date1 (value (Convert.ToInt32(38980)))
    let _imm7 = Fun.Date1 (value (Convert.ToInt32(38889)))
    let _imm6 = Fun.Date1 (value (Convert.ToInt32(38791)))
    let _imm5 = Fun.Date1 (value (Convert.ToInt32(38707)))
    let _imm4 = Fun.Date1 (value (Convert.ToInt32(38616)))
    let _imm3 = Fun.Date1 (value (Convert.ToInt32(38518)))
    let _imm2 = Fun.Date1 (value (Convert.ToInt32(38427)))
    let _imm1 = Fun.Date1 (value (Convert.ToInt32(38336)))
    let _futPrice8 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.0875)))
    let _futPrice7 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.2875)))
    let _futPrice6 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.3875)))
    let _futPrice5 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.4875)))
    let _futPrice4 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.6875)))
    let _futPrice3 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.9875)))
    let _futPrice2 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.7875)))
    let _futPrice1 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (96.2875)))
    let _Fut8 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice8).Value ))) _imm8 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut7 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice7).Value ))) _imm7 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut6 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice6).Value ))) _imm6 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut5 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice5).Value ))) _imm5 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut4 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice4).Value ))) _imm4 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut3 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice3).Value ))) _imm3 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut2 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice2).Value ))) _imm2 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _Fut1 = Fun.FuturesRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _futPrice1).Value ))) _imm1 _futMonths (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (triv null (fun () -> toHandle (null :> QLNet.Quote))) (value Futures.Type.IMM) _todaysDate
    let _depoFutSwapInstruments = (new Cephei.Cell.List<RateHelper>([|(cast<QLNet.RateHelper> _DeD1W);(cast<QLNet.RateHelper> _DeD1M);(cast<QLNet.RateHelper> _Fut1);(cast<QLNet.RateHelper> _Fut2);(cast<QLNet.RateHelper> _Fut3);(cast<QLNet.RateHelper> _Fut4);(cast<QLNet.RateHelper> _Fut5);(cast<QLNet.RateHelper> _Fut6);(cast<QLNet.RateHelper> _Fut7);(cast<QLNet.RateHelper> _Fut8);(cast<QLNet.RateHelper> _SPY3);(cast<QLNet.RateHelper> _SPY5);(cast<QLNet.RateHelper> _SPY10);(cast<QLNet.RateHelper> _SPY15)|]))
    let _depoFutSwapTerm = Fun.PiecewiseYieldCurve (cast<QLNet.ITraits<QLNet.YieldTermStructure>> _Discount) _settlementDate _depoFutSwapInstruments (cast<QLNet.DayCounter> _termStructureDayCounter) (triv null (fun () -> (new System.Collections.Generic.List<Handle<QLNet.Quote>>()))) (value (new System.Collections.Generic.List<QLNet.Date>())) _tolerance (cast<QLNet.IInterpolationFactory> _LogLinear) _todaysDate
    let _sratePY2 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.037125)))
    let _PY2 = Fun.Period (value (Convert.ToInt32(2))) (value TimeUnit.Years)
    let _DepoRD3M = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0363)))
    let _D3M = Fun.Period (value (Convert.ToInt32(3))) (value TimeUnit.Months)
    let _SPY2 = Fun.SwapRateHelper2 (triv null (fun () -> toHandle ((cast<QLNet.Quote> _sratePY2).Value ))) _PY2 (cast<QLNet.Calendar> _calendar) (value Frequency.Annual) (value BusinessDayConvention.Unadjusted) (cast<QLNet.DayCounter> _swFixedLegDayCounter) (cast<QLNet.IborIndex> _swFloatingLegIndex) (triv null (fun () ->  toHandle (null :> QLNet.Quote))) (value (null :> QLNet.Period)) (triv null (fun () -> toHandle (null :> QLNet.YieldTermStructure))) (triv null (fun () -> toNullable (_swapFixing.Value))) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _Per6 = Fun.Period (value (Convert.ToInt32(6))) (value TimeUnit.Months)
    let _DeD3M = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD3M).Value ))) _D3M _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _floatingLegFrequency = Fun.Period2 (value Frequency.Semiannual)
    let _fixedLegFrequency = Fun.Period2 (value Frequency.Annual)
    let _spread = (value (Convert.ToDouble(0)))
    let _floatingLegDayCounter = Fun.Actual360 (value false)
    let _floatSchedule = Fun.Schedule _settlementDate _maturity _floatingLegFrequency (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value BusinessDayConvention.ModifiedFollowing) (value DateGeneration.Rule.Forward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _fixedSchedule = Fun.Schedule _settlementDate _maturity _fixedLegFrequency (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Forward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _fixedRate = (value (Convert.ToDouble(0.04)))
    let _euriborIndex = Fun.Euribor6M (triv null (fun () -> toHandle ((cast<QLNet.YieldTermStructure> _depoFutSwapTerm).Value )))
    let _Nominal = (value (Convert.ToDouble(1000000)))
    let _DepoRD9M = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0348)))
    let _DepoRD6M = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0353)))
    let _DepoRD1Y = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0345)))
    let _D9M = Fun.Period (value (Convert.ToInt32(9))) (value TimeUnit.Months)
    let _D6M = Fun.Period (value (Convert.ToInt32(6))) (value TimeUnit.Months)
    let _D1Y = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Years)
    let _DeD9M = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD9M).Value ))) _D9M _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _DeD6M = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD6M).Value ))) _D6M _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _DeD1Y = Fun.DepositRateHelper (triv null (fun () -> toHandle ((cast<QLNet.Quote> _DepoRD1Y).Value ))) _D1Y _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) _todaysDate
    let _Per3 = Fun.Period (value (Convert.ToInt32(3))) (value TimeUnit.Months)
    let _IL9 = (value (Convert.ToInt32(9)))
    let _IL6 = (value (Convert.ToInt32(6)))
    let _IL12 = (value (Convert.ToInt32(12)))
    let _fra6x9 = Fun.FraRateHelper2 (value (Convert.ToDouble(0.037125))) _Per6 _IL9 _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _fra6x12 = Fun.FraRateHelper2 (value (Convert.ToDouble(0.037125))) _Per6 _IL12 _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _fra3x6 = Fun.FraRateHelper2 (value (Convert.ToDouble(0.037125))) _Per3 _IL6 _fixingDays (cast<QLNet.Calendar> _calendar) (value BusinessDayConvention.ModifiedFollowing) (value true) (cast<QLNet.DayCounter> _depositDayCounter) (value Pillar.Choice.LastRelevantDate) (value (null :> QLNet.Date)) _todaysDate
    let _fraSwapInstruments = (new Cephei.Cell.List<RateHelper>([|(cast<QLNet.RateHelper> _DeD1W);(cast<QLNet.RateHelper> _DeD1M);(cast<QLNet.RateHelper> _DeD3M);(cast<QLNet.RateHelper> _fra3x6);(cast<QLNet.RateHelper> _fra6x9);(cast<QLNet.RateHelper> _fra6x12);(cast<QLNet.RateHelper> _SPY2);(cast<QLNet.RateHelper> _SPY3);(cast<QLNet.RateHelper> _SPY5);(cast<QLNet.RateHelper> _SPY10);(cast<QLNet.RateHelper> _SPY15)|]))
    let _depoSwapInstruments = (new Cephei.Cell.List<RateHelper>([|(cast<QLNet.RateHelper> _DeD1W);(cast<QLNet.RateHelper> _DeD1M);(cast<QLNet.RateHelper> _DeD3M);(cast<QLNet.RateHelper> _DeD6M);(cast<QLNet.RateHelper> _DeD9M);(cast<QLNet.RateHelper> _DeD1Y);(cast<QLNet.RateHelper> _SPY2);(cast<QLNet.RateHelper> _SPY3);(cast<QLNet.RateHelper> _SPY5);(cast<QLNet.RateHelper> _SPY10);(cast<QLNet.RateHelper> _SPY15)|]))
    let _fraSwapTerm = Fun.PiecewiseYieldCurve (cast<QLNet.ITraits<QLNet.YieldTermStructure>> _Discount) _settlementDate _fraSwapInstruments (cast<QLNet.DayCounter> _termStructureDayCounter) (triv null (fun () -> Generic.List<Handle<QLNet.Quote>>())) (value (new System.Collections.Generic.List<QLNet.Date>())) _tolerance (cast<QLNet.IInterpolationFactory> _LogLinear) _todaysDate
    let _depoSwapTerm = Fun.PiecewiseYieldCurve (cast<QLNet.ITraits<QLNet.YieldTermStructure>> _Discount) _settlementDate _depoSwapInstruments (cast<QLNet.DayCounter> _termStructureDayCounter) (triv null (fun () -> new Generic.List<Handle<QLNet.Quote>>())) (value (new System.Collections.Generic.List<QLNet.Date>())) _tolerance (cast<QLNet.IInterpolationFactory> _LogLinear) _todaysDate
    let _fraSwapTermEngine = Fun.DiscountingSwapEngine (triv null (fun () -> toHandle ((cast<QLNet.YieldTermStructure> _fraSwapTerm).Value ))) (triv null (fun () -> toNullable (false))) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _depoSwapTermEngine = Fun.DiscountingSwapEngine (triv null (fun () -> toHandle ((cast<QLNet.YieldTermStructure> _depoSwapTerm).Value ))) (triv null (fun () -> toNullable (false))) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _depoFutSwapTermEngine = Fun.DiscountingSwapEngine (triv null (fun () -> toHandle ((cast<QLNet.YieldTermStructure> _depoFutSwapTerm).Value ))) (triv null (fun () -> toNullable (false))) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _fraSwapTermSwap = Fun.VanillaSwap (value VanillaSwap.Type.Payer) _Nominal _fixedSchedule _fixedRate (cast<QLNet.DayCounter> _swFixedLegDayCounter) _floatSchedule (cast<QLNet.IborIndex> _euriborIndex) _spread (cast<QLNet.DayCounter> _floatingLegDayCounter) (triv null (fun () -> nullableNull<QLNet.BusinessDayConvention> ())) (cast<QLNet.IPricingEngine> _fraSwapTermEngine) _todaysDate
    // was using settlement date
    let _depoSwapTermSwap = Fun.VanillaSwap (value VanillaSwap.Type.Payer) _Nominal _fixedSchedule _fixedRate (cast<QLNet.DayCounter> _swFixedLegDayCounter) _floatSchedule (cast<QLNet.IborIndex> _euriborIndex) _spread (cast<QLNet.DayCounter> _floatingLegDayCounter) (triv null (fun () -> nullableNull<QLNet.BusinessDayConvention> ())) (cast<QLNet.IPricingEngine> _depoSwapTermEngine) _todaysDate
    let _depoFutSwapTermSwap = Fun.VanillaSwap (value VanillaSwap.Type.Payer) _Nominal _fixedSchedule _fixedRate (cast<QLNet.DayCounter> _swFixedLegDayCounter) _floatSchedule (cast<QLNet.IborIndex> _euriborIndex) _spread (cast<QLNet.DayCounter> _floatingLegDayCounter) (triv null (fun () -> nullableNull<QLNet.BusinessDayConvention> ())) (cast<QLNet.IPricingEngine> _depoFutSwapTermEngine) _todaysDate
    let _todaysDateD = triv null (fun () ->_todaysDate.Value.serialNumber())
    let _maturityser = triv null (fun () -> _maturity.Value.serialNumber())
    let _fraSwapTermSwapfairSpread = _fraSwapTermSwap.FairSpread
    let _fraSwapTermSwapfairRate = _fraSwapTermSwap.FairRate
    let _fraSwapTermSwapNPV = _fraSwapTermSwap.NPV
    let _fraRate3 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.037125)))
    let _fraRate2 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.037125)))
    let _fraRate1 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.037125)))
    let _depoSwapTermSwapfairSpread = _depoSwapTermSwap.FairSpread
    let _depoSwapTermSwapfairRate = _depoSwapTermSwap.FairRate
    let _depoSwapTermSwapNPV = _depoSwapTermSwap.NPV
    let _depoFutSwapTermSwapfairSpread = _depoFutSwapTermSwap.FairSpread
    let _depoFutSwapTermSwapfairRate = _depoFutSwapTermSwap.FairRate
    let _depoFutSwapTermSwapNPV = _depoFutSwapTermSwap.NPV
    let _SPY5ld = _SPY5.LatestDate
    let _SPY5ed = _SPY5.EarliestDate
    let _SPY3ld = _SPY3.LatestDate
    let _SPY3ed = _SPY3.EarliestDate
    let _SPY2ld = _SPY2.LatestDate
    let _SPY2ed = _SPY2.EarliestDate
    let _SPY15ld = _SPY15.LatestDate
    let _SPY15ed = _SPY15.EarliestDate
    let _SPY10ld = _SPY10.LatestDate
    let _SPY10ed = _SPY10.EarliestDate
    let _DeD9Mld = _DeD9M.LatestDate
    let _DeD9Med = _DeD9M.EarliestDate
    let _DeD6Mld = _DeD6M.LatestDate
    let _DeD6Med = _DeD6M.EarliestDate
    let _DeD3Mld = _DeD3M.LatestDate
    let _DeD3Med = _DeD3M.EarliestDate
    let _DeD1Yld = _DeD1Y.LatestDate
    let _DeD1Yed = _DeD1Y.EarliestDate
    let _DeD1Wld = _DeD1W.LatestDate
    let _DeD1Wed = _DeD1W.EarliestDate
    let _DeD1Mld = _DeD1M.LatestDate
    let _DeD1Med = _DeD1M.EarliestDate

    do this.Bind (_depoSwapTermSwap)

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.settlementDate = _settlementDate
    member this.nfixingDays = _nfixingDays
    member this.todaysDate = _todaysDate
    member this.depositDayCounter = _depositDayCounter
    member this.swFixedLegDayCounter = _swFixedLegDayCounter
    member this.futMonths = _futMonths
    member this.swapFixing = _swapFixing
    member this.swFloatingLegIndex = _swFloatingLegIndex
    member this.fixingDays = _fixingDays
    member this.sratePY5 = _sratePY5
    member this.sratePY3 = _sratePY3
    member this.sratePY15 = _sratePY15
    member this.sratePY10 = _sratePY10
    member this.PY5 = _PY5
    member this.PY3 = _PY3
    member this.PY15 = _PY15
    member this.PY10 = _PY10
    member this.DepoRD1W = _DepoRD1W
    member this.DepoRD1M = _DepoRD1M
    member this.D1W = _D1W
    member this.D1M = _D1M
    member this.SPY5 = _SPY5
    member this.SPY3 = _SPY3
    member this.SPY15 = _SPY15
    member this.SPY10 = _SPY10
    member this.DeD1W = _DeD1W
    member this.DeD1M = _DeD1M
    member this.tolerance = _tolerance
    member this.termStructureDayCounter = _termStructureDayCounter
    member this.LogLinear = _LogLinear
    member this.Discount = _Discount
    member this.lenYears = _lenYears
    member this.maturity = _maturity
    member this.imm8 = _imm8
    member this.imm7 = _imm7
    member this.imm6 = _imm6
    member this.imm5 = _imm5
    member this.imm4 = _imm4
    member this.imm3 = _imm3
    member this.imm2 = _imm2
    member this.imm1 = _imm1
    member this.futPrice8 = _futPrice8
    member this.futPrice7 = _futPrice7
    member this.futPrice6 = _futPrice6
    member this.futPrice5 = _futPrice5
    member this.futPrice4 = _futPrice4
    member this.futPrice3 = _futPrice3
    member this.futPrice2 = _futPrice2
    member this.futPrice1 = _futPrice1
    member this.Fut8 = _Fut8
    member this.Fut7 = _Fut7
    member this.Fut6 = _Fut6
    member this.Fut5 = _Fut5
    member this.Fut4 = _Fut4
    member this.Fut3 = _Fut3
    member this.Fut2 = _Fut2
    member this.Fut1 = _Fut1
    member this.depoFutSwapInstruments = _depoFutSwapInstruments
    member this.depoFutSwapTerm = _depoFutSwapTerm
    member this.sratePY2 = _sratePY2
    member this.PY2 = _PY2
    member this.DepoRD3M = _DepoRD3M
    member this.D3M = _D3M
    member this.SPY2 = _SPY2
    member this.Per6 = _Per6
    member this.DeD3M = _DeD3M
    member this.floatingLegFrequency = _floatingLegFrequency
    member this.fixedLegFrequency = _fixedLegFrequency
    member this.spread = _spread
    member this.floatingLegDayCounter = _floatingLegDayCounter
    member this.floatSchedule = _floatSchedule
    member this.fixedSchedule = _fixedSchedule
    member this.fixedRate = _fixedRate
    member this.euriborIndex = _euriborIndex
    member this.Nominal = _Nominal
    member this.DepoRD9M = _DepoRD9M
    member this.DepoRD6M = _DepoRD6M
    member this.DepoRD1Y = _DepoRD1Y
    member this.D9M = _D9M
    member this.D6M = _D6M
    member this.D1Y = _D1Y
    member this.DeD9M = _DeD9M
    member this.DeD6M = _DeD6M
    member this.DeD1Y = _DeD1Y
    member this.Per3 = _Per3
    member this.IL9 = _IL9
    member this.IL6 = _IL6
    member this.IL12 = _IL12
    member this.fra6x9 = _fra6x9
    member this.fra6x12 = _fra6x12
    member this.fra3x6 = _fra3x6
    member this.fraSwapInstruments = _fraSwapInstruments
    member this.depoSwapInstruments = _depoSwapInstruments
    member this.fraSwapTerm = _fraSwapTerm
    member this.depoSwapTerm = _depoSwapTerm
    member this.fraSwapTermEngine = _fraSwapTermEngine
    member this.depoSwapTermEngine = _depoSwapTermEngine
    member this.depoFutSwapTermEngine = _depoFutSwapTermEngine
    member this.fraSwapTermSwap = _fraSwapTermSwap
    member this.depoSwapTermSwap = _depoSwapTermSwap
    member this.depoFutSwapTermSwap = _depoFutSwapTermSwap
    member this.todaysDateD = _todaysDateD
    member this.maturityser = _maturityser
    member this.fraSwapTermSwapfairSpread = _fraSwapTermSwapfairSpread
    member this.fraSwapTermSwapfairRate = _fraSwapTermSwapfairRate
    member this.fraSwapTermSwapNPV = _fraSwapTermSwapNPV
    member this.fraRate3 = _fraRate3
    member this.fraRate2 = _fraRate2
    member this.fraRate1 = _fraRate1
    member this.depoSwapTermSwapfairSpread = _depoSwapTermSwapfairSpread
    member this.depoSwapTermSwapfairRate = _depoSwapTermSwapfairRate
    member this.depoSwapTermSwapNPV = _depoSwapTermSwapNPV
    member this.depoFutSwapTermSwapfairSpread = _depoFutSwapTermSwapfairSpread
    member this.depoFutSwapTermSwapfairRate = _depoFutSwapTermSwapfairRate
    member this.depoFutSwapTermSwapNPV = _depoFutSwapTermSwapNPV
    member this.SPY5ld = _SPY5ld
    member this.SPY5ed = _SPY5ed
    member this.SPY3ld = _SPY3ld
    member this.SPY3ed = _SPY3ed
    member this.SPY2ld = _SPY2ld
    member this.SPY2ed = _SPY2ed
    member this.SPY15ld = _SPY15ld
    member this.SPY15ed = _SPY15ed
    member this.SPY10ld = _SPY10ld
    member this.SPY10ed = _SPY10ed
    member this.DeD9Mld = _DeD9Mld
    member this.DeD9Med = _DeD9Med
    member this.DeD6Mld = _DeD6Mld
    member this.DeD6Med = _DeD6Med
    member this.DeD3Mld = _DeD3Mld
    member this.DeD3Med = _DeD3Med
    member this.DeD1Yld = _DeD1Yld
    member this.DeD1Yed = _DeD1Yed
    member this.DeD1Wld = _DeD1Wld
    member this.DeD1Wed = _DeD1Wed
    member this.DeD1Mld = _DeD1Mld
    member this.DeD1Med = _DeD1Med


#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module swapModelFunction =

    [<ExcelFunction(Name="__swap", Description="Create a swap",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)

        = 
        if not (Model.IsInFunctionWizard()) then
            try

                let builder (current : ICell) = (new swapModel
                                                            ()

                                                                      ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> swapModel) l
                let source () = Helper.sourceFold "new swap"
                                               [|                                               |]

                let hash = Helper.hashFold
                                [|                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Swap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__swap_calendar", Description="Create a Cephei.QL.TARGETModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).calendar :> ICell
                let format (o : Cephei.QL.TARGETModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".calendar")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_settlementDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).settlementDate :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".settlementDate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_nfixingDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_nfixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).nfixingDays :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".nfixingDays")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_todaysDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_todaysDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).todaysDate :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".todaysDate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depositDayCounter", Description="Create a Cephei.QL.Actual360Model",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depositDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depositDayCounter :> ICell
                let format (o : Cephei.QL.Actual360Model) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depositDayCounter")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_swFixedLegDayCounter", Description="Create a Cephei.QL.Thirty360Model",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_swFixedLegDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).swFixedLegDayCounter :> ICell
                let format (o : Cephei.QL.Thirty360Model) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".swFixedLegDayCounter")
                let hash = Helper.hashFold [| _swap.cell |]
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
                                                       
    [<ExcelFunction(Name="__swap_futMonths", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futMonths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futMonths :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futMonths")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_swapFixing", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_swapFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).swapFixing :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".swapFixing")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_swFloatingLegIndex", Description="Create a Cephei.QL.Euribor6MModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_swFloatingLegIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).swFloatingLegIndex :> ICell
                let format (o : Cephei.QL.Euribor6MModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".swFloatingLegIndex")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fixingDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fixingDays :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fixingDays")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_sratePY5", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_sratePY5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).sratePY5 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".sratePY5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_sratePY3", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_sratePY3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).sratePY3 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".sratePY3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_sratePY15", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_sratePY15
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).sratePY15 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".sratePY15")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_sratePY10", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_sratePY10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).sratePY10 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".sratePY10")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_PY5", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_PY5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).PY5 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".PY5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_PY3", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_PY3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).PY3 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".PY3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_PY15", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_PY15
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).PY15 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".PY15")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_PY10", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_PY10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).PY10 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".PY10")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD1W", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD1W
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD1W :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD1W")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD1M", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD1M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD1M :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD1M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D1W", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D1W
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D1W :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D1W")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D1M", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D1M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D1M :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D1M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY5", Description="Create a Cephei.QL.SwapRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY5 :> ICell
                let format (o : Cephei.QL.SwapRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY3", Description="Create a Cephei.QL.SwapRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY3 :> ICell
                let format (o : Cephei.QL.SwapRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY15", Description="Create a Cephei.QL.SwapRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY15
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY15 :> ICell
                let format (o : Cephei.QL.SwapRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY15")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY10", Description="Create a Cephei.QL.SwapRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY10 :> ICell
                let format (o : Cephei.QL.SwapRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY10")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1W", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1W
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1W :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1W")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1M", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1M :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_tolerance", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_tolerance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).tolerance :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".tolerance")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_termStructureDayCounter", Description="Create a Cephei.QL.ActualActualModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_termStructureDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).termStructureDayCounter :> ICell
                let format (o : Cephei.QL.ActualActualModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".termStructureDayCounter")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_LogLinear", Description="Create a Cephei.QL.LogLinearModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_LogLinear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).LogLinear :> ICell
                let format (o : Cephei.QL.LogLinearModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".LogLinear")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Discount", Description="Create a Cephei.QL.DiscountModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Discount :> ICell
                let format (o : Cephei.QL.DiscountModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Discount")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_lenYears", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_lenYears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).lenYears :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".lenYears")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_maturity", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_maturity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).maturity :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".maturity")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm8", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm8 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm8")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm7", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm7 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm7")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm6", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm6 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm5", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm5 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm4", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm4 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm4")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm3", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm3 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm2", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm2 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_imm1", Description="Create a Cephei.QL.DateModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_imm1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).imm1 :> ICell
                let format (o : Cephei.QL.DateModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".imm1")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice8", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice8 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice8")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice7", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice7 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice7")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice6", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice6 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice5", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice5 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice4", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice4 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice4")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice3", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice3 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice2", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice2 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_futPrice1", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_futPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).futPrice1 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".futPrice1")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut8", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut8 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut8")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut7", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut7 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut7")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut6", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut6 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut5", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut5 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut5")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut4", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut4 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut4")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut3", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut3 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut2", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut2 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Fut1", Description="Create a Cephei.QL.FuturesRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Fut1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Fut1 :> ICell
                let format (o : Cephei.QL.FuturesRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Fut1")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapInstruments", Description="Create a QLNet.RateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapInstruments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapInstruments :> ICell
                let format (o : QLNet.RateHelper) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapInstruments")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTerm", Description="Create a Cephei.QL.PiecewiseYieldCurveModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTerm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTerm :> ICell
                let format (o : Cephei.QL.PiecewiseYieldCurveModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTerm")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_sratePY2", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_sratePY2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).sratePY2 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".sratePY2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_PY2", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_PY2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).PY2 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".PY2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD3M", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD3M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD3M :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD3M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D3M", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D3M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D3M :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D3M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY2", Description="Create a Cephei.QL.SwapRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY2 :> ICell
                let format (o : Cephei.QL.SwapRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Per6", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Per6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Per6 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Per6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD3M", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD3M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD3M :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD3M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_floatingLegFrequency", Description="Create a Cephei.QL.PeriodModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_floatingLegFrequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).floatingLegFrequency :> ICell
                let format (o : Cephei.QL.PeriodModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".floatingLegFrequency")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fixedLegFrequency", Description="Create a Cephei.QL.PeriodModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fixedLegFrequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fixedLegFrequency :> ICell
                let format (o : Cephei.QL.PeriodModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fixedLegFrequency")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_spread", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).spread :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".spread")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_floatingLegDayCounter", Description="Create a Cephei.QL.Actual360Model",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_floatingLegDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).floatingLegDayCounter :> ICell
                let format (o : Cephei.QL.Actual360Model) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".floatingLegDayCounter")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_floatSchedule", Description="Create a Cephei.QL.ScheduleModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_floatSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).floatSchedule :> ICell
                let format (o : Cephei.QL.ScheduleModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".floatSchedule")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fixedSchedule", Description="Create a Cephei.QL.ScheduleModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fixedSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fixedSchedule :> ICell
                let format (o : Cephei.QL.ScheduleModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fixedSchedule")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fixedRate", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fixedRate :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fixedRate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_euriborIndex", Description="Create a Cephei.QL.Euribor6MModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_euriborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).euriborIndex :> ICell
                let format (o : Cephei.QL.Euribor6MModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".euriborIndex")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Nominal", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Nominal :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Nominal")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD9M", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD9M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD9M :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD9M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD6M", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD6M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD6M :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD6M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DepoRD1Y", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DepoRD1Y
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DepoRD1Y :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DepoRD1Y")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D9M", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D9M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D9M :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D9M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D6M", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D6M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D6M :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D6M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_D1Y", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_D1Y
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).D1Y :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".D1Y")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD9M", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD9M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD9M :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD9M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD6M", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD6M
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD6M :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD6M")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Y", Description="Create a Cephei.QL.DepositRateHelperModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Y
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Y :> ICell
                let format (o : Cephei.QL.DepositRateHelperModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Y")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_Per3", Description="Create a Cephei.QL.PeriodModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_Per3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).Per3 :> ICell
                let format (o : Cephei.QL.PeriodModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".Per3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_IL9", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_IL9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).IL9 :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".IL9")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_IL6", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_IL6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).IL6 :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".IL6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_IL12", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_IL12
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).IL12 :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".IL12")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fra6x9", Description="Create a Cephei.QL.FraRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fra6x9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fra6x9 :> ICell
                let format (o : Cephei.QL.FraRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fra6x9")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fra6x12", Description="Create a Cephei.QL.FraRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fra6x12
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fra6x12 :> ICell
                let format (o : Cephei.QL.FraRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fra6x12")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fra3x6", Description="Create a Cephei.QL.FraRateHelperModel2",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fra3x6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fra3x6 :> ICell
                let format (o : Cephei.QL.FraRateHelperModel2) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fra3x6")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapInstruments", Description="Create a QLNet.RateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapInstruments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapInstruments :> ICell
                let format (o : QLNet.RateHelper) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapInstruments")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapInstruments", Description="Create a QLNet.RateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapInstruments
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapInstruments :> ICell
                let format (o : QLNet.RateHelper) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapInstruments")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTerm", Description="Create a Cephei.QL.PiecewiseYieldCurveModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTerm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTerm :> ICell
                let format (o : Cephei.QL.PiecewiseYieldCurveModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTerm")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTerm", Description="Create a Cephei.QL.PiecewiseYieldCurveModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTerm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTerm :> ICell
                let format (o : Cephei.QL.PiecewiseYieldCurveModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTerm")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTermEngine", Description="Create a Cephei.QL.DiscountingSwapEngineModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTermEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTermEngine :> ICell
                let format (o : Cephei.QL.DiscountingSwapEngineModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTermEngine")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTermEngine", Description="Create a Cephei.QL.DiscountingSwapEngineModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTermEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTermEngine :> ICell
                let format (o : Cephei.QL.DiscountingSwapEngineModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTermEngine")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTermEngine", Description="Create a Cephei.QL.DiscountingSwapEngineModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTermEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTermEngine :> ICell
                let format (o : Cephei.QL.DiscountingSwapEngineModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTermEngine")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTermSwap", Description="Create a Cephei.QL.VanillaSwapModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTermSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTermSwap :> ICell
                let format (o : Cephei.QL.VanillaSwapModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTermSwap")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTermSwap", Description="Create a Cephei.QL.VanillaSwapModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTermSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTermSwap :> ICell
                let format (o : Cephei.QL.VanillaSwapModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTermSwap")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTermSwap", Description="Create a Cephei.QL.VanillaSwapModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTermSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTermSwap :> ICell
                let format (o : Cephei.QL.VanillaSwapModel) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTermSwap")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_todaysDateD", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_todaysDateD
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).todaysDateD :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".todaysDateD")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_maturityser", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_maturityser
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).maturityser :> ICell
                let format (o : System.Int32) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".maturityser")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTermSwapfairSpread", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTermSwapfairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTermSwapfairSpread :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTermSwapfairSpread")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTermSwapfairRate", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTermSwapfairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTermSwapfairRate :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTermSwapfairRate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraSwapTermSwapNPV", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraSwapTermSwapNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraSwapTermSwapNPV :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraSwapTermSwapNPV")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraRate3", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraRate3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraRate3 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraRate3")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraRate2", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraRate2 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraRate2")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_fraRate1", Description="Create a Cephei.QL.SimpleQuoteModel1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_fraRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).fraRate1 :> ICell
                let format (o : Cephei.QL.SimpleQuoteModel1) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".fraRate1")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTermSwapfairSpread", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTermSwapfairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTermSwapfairSpread :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTermSwapfairSpread")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTermSwapfairRate", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTermSwapfairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTermSwapfairRate :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTermSwapfairRate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoSwapTermSwapNPV", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoSwapTermSwapNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoSwapTermSwapNPV :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoSwapTermSwapNPV")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTermSwapfairSpread", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTermSwapfairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTermSwapfairSpread :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTermSwapfairSpread")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTermSwapfairRate", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTermSwapfairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTermSwapfairRate :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTermSwapfairRate")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_depoFutSwapTermSwapNPV", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_depoFutSwapTermSwapNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).depoFutSwapTermSwapNPV :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".depoFutSwapTermSwapNPV")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY5ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY5ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY5ld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY5ld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY5ed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY5ed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY5ed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY5ed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY3ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY3ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY3ld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY3ld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY3ed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY3ed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY3ed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY3ed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY2ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY2ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY2ld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY2ld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY2ed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY2ed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY2ed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY2ed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY15ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY15ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY15ld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY15ld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY15ed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY15ed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY15ed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY15ed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY10ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY10ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY10ld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY10ld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_SPY10ed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_SPY10ed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).SPY10ed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".SPY10ed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD9Mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD9Mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD9Mld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD9Mld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD9Med", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD9Med
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD9Med :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD9Med")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD6Mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD6Mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD6Mld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD6Mld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD6Med", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD6Med
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD6Med :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD6Med")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD3Mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD3Mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD3Mld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD3Mld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD3Med", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD3Med
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD3Med :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD3Med")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Yld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Yld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Yld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Yld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Yed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Yed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Yed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Yed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Wld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Wld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Wld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Wld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Wed", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Wed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Wed :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Wed")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Mld :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Mld")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
    [<ExcelFunction(Name="__swap_DeD1Med", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let swap_DeD1Med
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swap",Description = "swap")>] 
         swap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then
            try
                let _swap = Helper.toModel<swapModel, VanillaSwap> swap "swap"  
                let builder (current : ICell) = (_swap.cell :?> swapModel).DeD1Med :> ICell
                let format (o : QLNet.Date) (l:string) = Model.genericFormat o
                let source () = (_swap.source + ".DeD1Med")
                let hash = Helper.hashFold [| _swap.cell |]
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
                            
#endif
