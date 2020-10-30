
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type BondSimple 
    ( Yield1 : ICell<SimpleQuote>
    , coupons : ICell<Generic.List<double>>
    , Yield4 : ICell<SimpleQuote>
    , Yield3 : ICell<SimpleQuote>
    , Yield2 : ICell<SimpleQuote>
    ) as this =
    inherit Model ()

    let True = true
(* functions *)
    let _calendar = Fun.TARGET()
    let _Today = (value DateTime.Today)
    let _clock = Fun.Date1 (triv (fun () -> int (_Today.Value.ToOADate())))
    let _priceday = _calendar.Adjust _clock (value BusinessDayConvention.Following)
    let _dayCount = Fun.ActualActual1 (value ActualActual.Convention.ISMA) (value (null :> Schedule))
    let _Yield1 = Yield1
    let _FlatYield1 = Fun.FlatForward _priceday (triv (fun () -> _Yield1.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _settlement = (value (Convert.ToInt32(3)))
    let _coupons = coupons
    let _exCoupon = Fun.Period1()
    let _EngineFlatYield1 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield1.Value))) (triv (fun () -> toNullable (true)))
    let _FreqS = Fun.Period2 (value Frequency.Semiannual)
    let _FreqA = Fun.Period2 (value Frequency.Annual)
    let _Mat3 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(10))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat1 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(3))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat2 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(5))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat5 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(20))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat4 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(15))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat3FreqA = Fun.Schedule _priceday _Mat3 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat2FreqS = Fun.Schedule _priceday _Mat2 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat5FreqS = Fun.Schedule _priceday _Mat5 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat1FreqA = Fun.Schedule _priceday _Mat1 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat3FreqS = Fun.Schedule _priceday _Mat3 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat1FreqS = Fun.Schedule _priceday _Mat1 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat2FreqA = Fun.Schedule _priceday _Mat2 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat4FreqS = Fun.Schedule _priceday _Mat4 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat4FreqA = Fun.Schedule _priceday _Mat4 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat5FreqA = Fun.Schedule _priceday _Mat5 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Fac18 = (value (Convert.ToDouble(166.428277577212)))
    let _Fac9 = (value (Convert.ToDouble(57.4759329162856)))
    let _Fac7 = (value (Convert.ToDouble(20.931404635316)))
    let _Fac4 = (value (Convert.ToDouble(21.1149024498565)))
    let _Fac8 = (value (Convert.ToDouble(62.3346101960088)))
    let _Fac3 = (value (Convert.ToDouble(18.204664730846)))
    let _Fac1 = (value (Convert.ToDouble(200)))
    let _Fac22 = (value (Convert.ToDouble(197.385462593134)))
    let _Fac23 = (value (Convert.ToDouble(72.6648499948869)))
    let _Fac21 = (value (Convert.ToDouble(101.239491256952)))
    let _Fac6 = (value (Convert.ToDouble(3.31596847291231)))
    let _Fac20 = (value (Convert.ToDouble(174.891668049091)))
    let _Fac24 = (value (Convert.ToDouble(166.284927009337)))
    let _Fac28 = (value (Convert.ToDouble(171.362348661051)))
    let _Fac2 = (value (Convert.ToDouble(83.1808269033236)))
    let _Fac27 = (value (Convert.ToDouble(100.711296313176)))
    let _Fac25 = (value (Convert.ToDouble(104.367548517746)))
    let _Fac26 = (value (Convert.ToDouble(162.374521533832)))
    let _Fac13 = (value (Convert.ToDouble(195.928677625272)))
    let _Fac14 = (value (Convert.ToDouble(173.786882107492)))
    let _Fac15 = (value (Convert.ToDouble(19.9555344362262)))
    let _Fac12 = (value (Convert.ToDouble(175.331077938423)))
    let _Fac5 = (value (Convert.ToDouble(42.702023363669)))
    let _Fac10 = (value (Convert.ToDouble(74.1668177738273)))
    let _Fac11 = (value (Convert.ToDouble(123.466290870449)))
    let _Fac17 = (value (Convert.ToDouble(176.813232833993)))
    let _Fac19 = (value (Convert.ToDouble(147.215577248757)))
    let _Bond18 = Fun.FixedRateBond _settlement _Fac18 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac18 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Fac16 = (value (Convert.ToDouble(111.415982501962)))
    let _Bond21 = Fun.FixedRateBond _settlement _Fac21 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac21 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond20 = Fun.FixedRateBond _settlement _Fac20 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac20 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond22 = Fun.FixedRateBond _settlement _Fac22 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac22 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond17 = Fun.FixedRateBond _settlement _Fac17 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac17 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond23 = Fun.FixedRateBond _settlement _Fac23 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac23 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond8 = Fun.FixedRateBond _settlement _Fac8 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac8 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond24 = Fun.FixedRateBond _settlement _Fac24 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac24 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond26 = Fun.FixedRateBond _settlement _Fac26 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac26 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond27 = Fun.FixedRateBond _settlement _Fac27 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac27 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond25 = Fun.FixedRateBond _settlement _Fac25 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac25 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond1 = Fun.FixedRateBond _settlement _Fac1 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac1 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond6 = Fun.FixedRateBond _settlement _Fac6 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac6 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond4 = Fun.FixedRateBond _settlement _Fac4 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac4 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond2 = Fun.FixedRateBond _settlement _Fac2 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac2 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond9 = Fun.FixedRateBond _settlement _Fac9 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac9 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond15 = Fun.FixedRateBond _settlement _Fac15 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac15 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond16 = Fun.FixedRateBond _settlement _Fac16 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac16 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond5 = Fun.FixedRateBond _settlement _Fac5 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac5 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond19 = Fun.FixedRateBond _settlement _Fac19 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac19 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond14 = Fun.FixedRateBond _settlement _Fac14 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac14 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond28 = Fun.FixedRateBond _settlement _Fac28 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac28 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond3 = Fun.FixedRateBond _settlement _Fac3 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac3 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond11 = Fun.FixedRateBond _settlement _Fac11 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac11 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond7 = Fun.FixedRateBond _settlement _Fac7 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac7 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond13 = Fun.FixedRateBond _settlement _Fac13 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac13 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond12 = Fun.FixedRateBond _settlement _Fac12 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac12 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond10 = Fun.FixedRateBond _settlement _Fac10 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac10 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Yield4 = Yield4
    let _clean18 = _Bond18.CleanPrice
    let _Yield3 = Yield3
    let _Yield2 = Yield2
    let _clean10 = _Bond10.CleanPrice
    let _clean16 = _Bond16.CleanPrice
    let _clean12 = _Bond12.CleanPrice
    let _clean17 = _Bond17.CleanPrice
    let _clean14 = _Bond14.CleanPrice
    let _clean6 = _Bond6.CleanPrice
    let _clean8 = _Bond8.CleanPrice
    let _clean11 = _Bond11.CleanPrice
    let _clean20 = _Bond20.CleanPrice
    let _clean7 = _Bond7.CleanPrice
    let _clean9 = _Bond9.CleanPrice
    let _clean21 = _Bond21.CleanPrice
    let _clean26 = _Bond26.CleanPrice
    let _clean24 = _Bond24.CleanPrice
    let _clean25 = _Bond25.CleanPrice
    let _clean22 = _Bond22.CleanPrice
    let _clean23 = _Bond23.CleanPrice
    let _clean27 = _Bond27.CleanPrice
    let _FlatYield2 = Fun.FlatForward _priceday (triv (fun () -> _Yield2.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _clean1 = _Bond1.CleanPrice
    let _FlatYield4 = Fun.FlatForward _priceday (triv (fun () -> _Yield4.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _clean3 = _Bond3.CleanPrice
    let _clean13 = _Bond13.CleanPrice
    let _clean5 = _Bond5.CleanPrice
    let _FlatYield3 = Fun.FlatForward _priceday (triv (fun () -> _Yield3.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _clean2 = _Bond2.CleanPrice
    let _clean4 = _Bond4.CleanPrice
    let _clean28 = _Bond28.CleanPrice
    let _clean19 = _Bond19.CleanPrice
    let _clean15 = _Bond15.CleanPrice
//    let _EngineFlatYield3 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield3.Value))) (triv (fun () -> toNullable (true)))
(*
    let _lapse12 = new TimeLapse<double> _clean11 (value (10 :?> Double))
    let _lapse8 = new TimeLapse<double> _clean7 (value (10 :?> Double))
    let _lapse21 = new TimeLapse<double> _clean20 (value (10 :?> Double))
    let _EngineFlatYield2 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield2.Value))) (triv (fun () -> toNullable (True)))
    let _lapse28 = new TimeLapse<double> _clean27 (value (10 :?> Double))
    let _EngineFlatYield4 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield4.Value))) (triv (fun () -> toNullable (True)))
    let _lapse18 = new TimeLapse<double> _clean17 (value (10 :?> Double))
    let _lapse22 = new TimeLapse<double> _clean21 (value (10 :?> Double))
    let _lapse16 = new TimeLapse<double> _clean15 (value (10 :?> Double))
    let _lapse26 = new TimeLapse<double> _clean25 (value (10 :?> Double))
    let _lapse10 = new TimeLapse<double> _clean9 (value (10 :?> Double))
    let _lapse25 = new TimeLapse<double> _clean24 (value (10 :?> Double))
    let _lapse15 = new TimeLapse<double> _clean14 (value (10 :?> Double))
    let _lapse20 = new TimeLapse<double> _clean19 (value (10 :?> Double))
    let _lapse24 = new TimeLapse<double> _clean23 (value (10 :?> Double))
    let _lapse29 = new TimeLapse<double> _clean28 (value (10 :?> Double))
    let _lapse17 = new TimeLapse<double> _clean16 (value (10 :?> Double))
    let _lapse19 = new TimeLapse<double> _clean18 (value (10 :?> Double))
    let _lapse13 = new TimeLapse<double> _clean12 (value (10 :?> Double))
    let _lapse23 = new TimeLapse<double> _clean22 (value (10 :?> Double))
    let _lapse6 = new TimeLapse<double> _clean5 (value (10 :?> Double))
    let _lapse7 = new TimeLapse<double> _clean6 (value (10 :?> Double))
    let _lapse3 = new TimeLapse<double> _clean2 (value (10 :?> Double))
    let _lapse9 = new TimeLapse<double> _clean8 (value (10 :?> Double))
    let _lapse2 = new TimeLapse<double> _clean1 (value (10 :?> Double))
    let _lapse27 = new TimeLapse<double> _clean26 (value (10 :?> Double))
    let _lapse14 = new TimeLapse<double> _clean13 (value (10 :?> Double))
    let _lapse11 = new TimeLapse<double> _clean10 (value (10 :?> Double))
    let _lapse4 = new TimeLapse<double> _clean3 (value (10 :?> Double))
    let _lapse5 = new TimeLapse<double> _clean4 (value (10 :?> Double))
*)
    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.Today = _Today
    member this.clock = _clock
    member this.Yield1 = _Yield1
    member this.FlatYield1 = _FlatYield1
    member this.coupons = _coupons
    member this.FreqS = _FreqS
    member this.FreqA = _FreqA
    member this.Fac18 = _Fac18
    member this.Fac9 = _Fac9
    member this.Fac7 = _Fac7
    member this.Fac4 = _Fac4
    member this.Fac8 = _Fac8
    member this.Fac3 = _Fac3
    member this.Fac1 = _Fac1
    member this.Fac22 = _Fac22
    member this.Fac23 = _Fac23
    member this.Fac21 = _Fac21
    member this.Fac6 = _Fac6
    member this.Fac20 = _Fac20
    member this.Fac24 = _Fac24
    member this.Fac28 = _Fac28
    member this.Fac2 = _Fac2
    member this.Fac27 = _Fac27
    member this.Fac25 = _Fac25
    member this.Fac26 = _Fac26
    member this.Fac13 = _Fac13
    member this.Fac14 = _Fac14
    member this.Fac15 = _Fac15
    member this.Fac12 = _Fac12
    member this.Fac5 = _Fac5
    member this.Fac10 = _Fac10
    member this.Fac11 = _Fac11
    member this.Fac17 = _Fac17
    member this.Fac19 = _Fac19
    member this.Fac16 = _Fac16
    member this.Yield4 = _Yield4
    member this.clean18 = _clean18
    member this.Yield3 = _Yield3
    member this.Yield2 = _Yield2
    member this.clean10 = _clean10
    member this.clean16 = _clean16
    member this.clean12 = _clean12
    member this.clean17 = _clean17
    member this.clean14 = _clean14
    member this.clean6 = _clean6
    member this.clean8 = _clean8
    member this.clean11 = _clean11
    member this.clean20 = _clean20
    member this.clean7 = _clean7
    member this.clean9 = _clean9
    member this.clean21 = _clean21
    member this.clean26 = _clean26
    member this.clean24 = _clean24
    member this.clean25 = _clean25
    member this.clean22 = _clean22
    member this.clean23 = _clean23
    member this.clean27 = _clean27
    member this.FlatYield2 = _FlatYield2
    member this.clean1 = _clean1
    member this.FlatYield4 = _FlatYield4
    member this.clean3 = _clean3
    member this.clean13 = _clean13
    member this.clean5 = _clean5
    member this.FlatYield3 = _FlatYield3
    member this.clean2 = _clean2
    member this.clean4 = _clean4
    member this.clean28 = _clean28
    member this.clean19 = _clean19
    member this.clean15 = _clean15


#if EXCEL
module BondSimpleFunction =

    [<ExcelFunction(Name="__BondSimple", Description="Create a BondSimple",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__Yield1",Description = "reference to SimpleQuote")>]
        Yield1 : obj)
        ([<ExcelArgument(Name="__coupons",Description = "reference to List")>]
        coupons : obj)
        ([<ExcelArgument(Name="__Yield4",Description = "reference to SimpleQuote")>]
        Yield4 : obj)
        ([<ExcelArgument(Name="__Yield3",Description = "reference to SimpleQuote")>]
        Yield3 : obj)
        ([<ExcelArgument(Name="__Yield2",Description = "reference to SimpleQuote")>]
        Yield2 : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _Yield1 = Helper.toCell<SimpleQuote> Yield1 "Yield1"
                let _coupons = Helper.toCell<List> coupons "coupons"
                let _Yield4 = Helper.toCell<SimpleQuote> Yield4 "Yield4"
                let _Yield3 = Helper.toCell<SimpleQuote> Yield3 "Yield3"
                let _Yield2 = Helper.toCell<SimpleQuote> Yield2 "Yield2"

                let builder (current : ICell) = withMnemonic mnemonic (new BondSimple
                                                            _Yield1.cell
                                                            _coupons.cell
                                                            _Yield4.cell
                                                            _Yield3.cell
                                                            _Yield2.cell

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> BondSimple) l
                let source () = Helper.sourceFold "new BondSimple"
                                               [| _Yield1.source
                                               ;  _coupons.source
                                               ;  _Yield4.source
                                               ;  _Yield3.source
                                               ;  _Yield2.source
                                               |]

                let hash = Helper.hashFold
                                [| _Yield1.cell
                                ;  _coupons.cell
                                ;  _Yield4.cell
                                ;  _Yield3.cell
                                ;  _Yield2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BondSimple> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__BondSimple_Today", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Today
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Today) :> ICell
            let format (o : System.DateTime) (l:string) = o.Helper.Range.fromModel (i :?> Today) l
            let source () = (_BondSimple.source + ".Today")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clock", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clock
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clock) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> clock) l
            let source () = (_BondSimple.source + ".clock")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield1", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FlatYield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield1) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield1) l
            let source () = (_BondSimple.source + ".FlatYield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FreqS", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FreqS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FreqS) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> FreqS) l
            let source () = (_BondSimple.source + ".FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FreqA", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FreqA
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FreqA) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> FreqA) l
            let source () = (_BondSimple.source + ".FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac18", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac18
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac18) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac18) l
            let source () = (_BondSimple.source + ".Fac18")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac9", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac9) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac9) l
            let source () = (_BondSimple.source + ".Fac9")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac7", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac7) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac7) l
            let source () = (_BondSimple.source + ".Fac7")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac4", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac4) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac4) l
            let source () = (_BondSimple.source + ".Fac4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac8", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac8) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac8) l
            let source () = (_BondSimple.source + ".Fac8")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac3) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac3) l
            let source () = (_BondSimple.source + ".Fac3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac1) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac1) l
            let source () = (_BondSimple.source + ".Fac1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac22", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac22
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac22) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac22) l
            let source () = (_BondSimple.source + ".Fac22")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac23", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac23
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac23) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac23) l
            let source () = (_BondSimple.source + ".Fac23")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac21", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac21
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac21) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac21) l
            let source () = (_BondSimple.source + ".Fac21")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac6", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac6) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac6) l
            let source () = (_BondSimple.source + ".Fac6")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac20", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac20
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac20) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac20) l
            let source () = (_BondSimple.source + ".Fac20")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac24", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac24
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac24) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac24) l
            let source () = (_BondSimple.source + ".Fac24")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac28", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac28
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac28) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac28) l
            let source () = (_BondSimple.source + ".Fac28")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac2) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac2) l
            let source () = (_BondSimple.source + ".Fac2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac27", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac27
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac27) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac27) l
            let source () = (_BondSimple.source + ".Fac27")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac25", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac25
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac25) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac25) l
            let source () = (_BondSimple.source + ".Fac25")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac26", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac26
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac26) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac26) l
            let source () = (_BondSimple.source + ".Fac26")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac13", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac13
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac13) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac13) l
            let source () = (_BondSimple.source + ".Fac13")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac14", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac14
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac14) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac14) l
            let source () = (_BondSimple.source + ".Fac14")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac15", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac15
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac15) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac15) l
            let source () = (_BondSimple.source + ".Fac15")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac12", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac12
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac12) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac12) l
            let source () = (_BondSimple.source + ".Fac12")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac5", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac5) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac5) l
            let source () = (_BondSimple.source + ".Fac5")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac10", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac10) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac10) l
            let source () = (_BondSimple.source + ".Fac10")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac11", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac11
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac11) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac11) l
            let source () = (_BondSimple.source + ".Fac11")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac17", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac17
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac17) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac17) l
            let source () = (_BondSimple.source + ".Fac17")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac19", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac19
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac19) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac19) l
            let source () = (_BondSimple.source + ".Fac19")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac16", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac16
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac16) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac16) l
            let source () = (_BondSimple.source + ".Fac16")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean18", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean18
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean18) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean18) l
            let source () = (_BondSimple.source + ".clean18")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean10", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean10) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean10) l
            let source () = (_BondSimple.source + ".clean10")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean16", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean16
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean16) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean16) l
            let source () = (_BondSimple.source + ".clean16")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean12", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean12
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean12) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean12) l
            let source () = (_BondSimple.source + ".clean12")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean17", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean17
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean17) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean17) l
            let source () = (_BondSimple.source + ".clean17")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean14", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean14
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean14) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean14) l
            let source () = (_BondSimple.source + ".clean14")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean6", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean6) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean6) l
            let source () = (_BondSimple.source + ".clean6")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean8", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean8) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean8) l
            let source () = (_BondSimple.source + ".clean8")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean11", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean11
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean11) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean11) l
            let source () = (_BondSimple.source + ".clean11")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean20", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean20
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean20) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean20) l
            let source () = (_BondSimple.source + ".clean20")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean7", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean7) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean7) l
            let source () = (_BondSimple.source + ".clean7")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean9", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean9) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean9) l
            let source () = (_BondSimple.source + ".clean9")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean21", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean21
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean21) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean21) l
            let source () = (_BondSimple.source + ".clean21")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean26", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean26
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean26) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean26) l
            let source () = (_BondSimple.source + ".clean26")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean24", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean24
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean24) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean24) l
            let source () = (_BondSimple.source + ".clean24")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean25", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean25
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean25) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean25) l
            let source () = (_BondSimple.source + ".clean25")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean22", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean22
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean22) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean22) l
            let source () = (_BondSimple.source + ".clean22")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean23", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean23
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean23) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean23) l
            let source () = (_BondSimple.source + ".clean23")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean27", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean27
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean27) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean27) l
            let source () = (_BondSimple.source + ".clean27")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield2", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FlatYield2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield2) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield2) l
            let source () = (_BondSimple.source + ".FlatYield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean1) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean1) l
            let source () = (_BondSimple.source + ".clean1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield4", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FlatYield4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield4) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield4) l
            let source () = (_BondSimple.source + ".FlatYield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean3) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean3) l
            let source () = (_BondSimple.source + ".clean3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean13", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean13
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean13) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean13) l
            let source () = (_BondSimple.source + ".clean13")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean5", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean5) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean5) l
            let source () = (_BondSimple.source + ".clean5")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield3", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_FlatYield3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield3) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield3) l
            let source () = (_BondSimple.source + ".FlatYield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean2) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean2) l
            let source () = (_BondSimple.source + ".clean2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean4", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean4) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean4) l
            let source () = (_BondSimple.source + ".clean4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean28", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean28
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean28) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean28) l
            let source () = (_BondSimple.source + ".clean28")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean19", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean19
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean19) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean19) l
            let source () = (_BondSimple.source + ".clean19")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean15", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean15
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean15) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean15) l
            let source () = (_BondSimple.source + ".clean15")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
