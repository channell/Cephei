namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections
(*
type BondSimple 
    ( coupons : ICell<List>
    , Yield2 : ICell<SimpleQuote>
    , Yield3 : ICell<SimpleQuote>
    , Yield1 : ICell<SimpleQuote>
    , Yield4 : ICell<SimpleQuote>
    ) as this =
    inherit Model ()

(* functions *)
    let _calendar = Fun.TARGET()
    let _Today = (value DateTime.Today)
    let _clock = Fun.Date1 (triv (fun () -> int (_Today.Value.ToOADate())))
    let _priceday = _calendar.Adjust _clock (value BusinessDayConvention.Following)
    let _dayCount = Fun.ActualActual1 (value ActualActual.Convention.ISMA) (value (null :> Schedule))
    let _settlement = (value Convert.ToInt32(3))
    let _coupons = coupons
    let _exCoupon = Fun.Period1()
    let _FreqS = Fun.Period2 (value Frequency.Semiannual)
    let _FreqA = Fun.Period2 (value Frequency.Annual)
    let _Yield2 = Yield2
    let _Yield3 = Yield3
    let _Yield1 = Yield1
    let _Yield4 = Yield4
    let _FlatYield2 = Fun.FlatForward _priceday (triv (fun () -> _Yield2.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _FlatYield3 = Fun.FlatForward _priceday (triv (fun () -> _Yield3.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _FlatYield4 = Fun.FlatForward _priceday (triv (fun () -> _Yield4.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _FlatYield1 = Fun.FlatForward _priceday (triv (fun () -> _Yield1.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _EngineFlatYield3 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield3.Value))) (triv (fun () -> toNullable (True)))
    let _EngineFlatYield1 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield1.Value))) (triv (fun () -> toNullable (True)))
    let _EngineFlatYield4 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield4.Value))) (triv (fun () -> toNullable (True)))
    let _EngineFlatYield2 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield2.Value))) (triv (fun () -> toNullable (True)))
    let _Mat5 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(20))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat1 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(3))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat3 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(10))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat4 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(15))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat2 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(5))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat5FreqS = Fun.Schedule _priceday _Mat5 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat1FreqS = Fun.Schedule _priceday _Mat1 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat2FreqA = Fun.Schedule _priceday _Mat2 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat3FreqS = Fun.Schedule _priceday _Mat3 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat4FreqA = Fun.Schedule _priceday _Mat4 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat1FreqA = Fun.Schedule _priceday _Mat1 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat5FreqA = Fun.Schedule _priceday _Mat5 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat4FreqS = Fun.Schedule _priceday _Mat4 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat2FreqS = Fun.Schedule _priceday _Mat2 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat3FreqA = Fun.Schedule _priceday _Mat3 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Fac13 = (value Convert.ToDouble(9336.68496487688))
    let _Fac12 = (value Convert.ToDouble(34252.707192658))
    let _Fac10 = (value Convert.ToDouble(26406.5746449857))
    let _Fac11 = (value Convert.ToDouble(17760.2413117218))
    let _Fac16 = (value Convert.ToDouble(19594.2256938841))
    let _Fac14 = (value Convert.ToDouble(31947.3761439332))
    let _Fac2 = (value Convert.ToDouble(18868.5515545012))
    let _Fac113 = (value Convert.ToDouble(27032.9207411284))
    let _Fac76 = (value Convert.ToDouble(594.67036729742))
    let _Fac15 = (value Convert.ToDouble(24768.7972519253))
    let _Fac17 = (value Convert.ToDouble(11942.221624917))
    let _Fac18 = (value Convert.ToDouble(11450.1267615791))
    let _Fac1 = (value Convert.ToDouble(23677.0993829041))
    let _Fac23 = (value Convert.ToDouble(9299.63427804422))
    let _Fac24 = (value Convert.ToDouble(16562.3487715438))
    let _Fac25 = (value Convert.ToDouble(40398.8117488773))
    let _Fac20 = (value Convert.ToDouble(25988.0648054146))
    let _Fac21 = (value Convert.ToDouble(9796.5291470347))
    let _Fac22 = (value Convert.ToDouble(2139.27238797699))
    let _Fac120 = (value Convert.ToDouble(16891.4801478031))
    let _Fac29 = (value Convert.ToDouble(25021.7568433054))
    let _Fac110 = (value Convert.ToDouble(38789.2342100362))
    let _Fac100 = (value Convert.ToDouble(41714.5775895623))
    let _Fac26 = (value Convert.ToDouble(25637.2039978275))
    let _Fac27 = (value Convert.ToDouble(22866.5167239178))
    let _Fac28 = (value Convert.ToDouble(13387.5954330693))
    let _Fac103 = (value Convert.ToDouble(34513.8057454933))
    let _Fac99 = (value Convert.ToDouble(24215.6383483017))
    let _Fac5 = (value Convert.ToDouble(14795.6521082294))
    let _Fac98 = (value Convert.ToDouble(38209.9356374133))
    let _Fac96 = (value Convert.ToDouble(19051.2810236733))
    let _Fac97 = (value Convert.ToDouble(26243.6722731294))
    let _Fac53 = (value Convert.ToDouble(17044.8686050631))
    let _Fac54 = (value Convert.ToDouble(19866.1164541203))
    let _Fac52 = (value Convert.ToDouble(29323.3242190309))
    let _Fac50 = (value Convert.ToDouble(11505.8785242249))
    let _Fac51 = (value Convert.ToDouble(163.388590447303))
    let _Fac9 = (value Convert.ToDouble(8102.8546314516))
    let _Fac90 = (value Convert.ToDouble(23392.4081706494))
    let _Fac106 = (value Convert.ToDouble(7867.55853370619))
    let _Fac108 = (value Convert.ToDouble(36564.409818613))
    let _Fac116 = (value Convert.ToDouble(6231.17166817123))
    let _Fac94 = (value Convert.ToDouble(2820.47620974356))
    let _Fac95 = (value Convert.ToDouble(21347.5550105219))
    let _Fac93 = (value Convert.ToDouble(15686.5683837936))
    let _Fac91 = (value Convert.ToDouble(5272.17726839509))
    let _Fac92 = (value Convert.ToDouble(20728.3597519864))
    let _Fac55 = (value Convert.ToDouble(14795.8998369282))
    let _Fac74 = (value Convert.ToDouble(369.10553086698))
    let _Fac73 = (value Convert.ToDouble(4307.2403342053))
    let _Fac75 = (value Convert.ToDouble(40349.8838239723))
    let _Fac77 = (value Convert.ToDouble(23957.7722016716))
    let _Fac118 = (value Convert.ToDouble(1174.3937271594))
    let _Fac7 = (value Convert.ToDouble(35202.5469269384))
    let _Fac19 = (value Convert.ToDouble(2190.35023602813))
    let _Fac70 = (value Convert.ToDouble(1831.48292078218))
    let _Fac72 = (value Convert.ToDouble(30109.8361341935))
    let _Fac71 = (value Convert.ToDouble(10917.2783608199))
    let _Fac59 = (value Convert.ToDouble(20064.1737323121))
    let _Fac115 = (value Convert.ToDouble(31570.276930123))
    let _Fac58 = (value Convert.ToDouble(8379.81640439252))
    let _Fac56 = (value Convert.ToDouble(43453.1082343004))
    let _Fac57 = (value Convert.ToDouble(43719.5976657468))
    let _Fac79 = (value Convert.ToDouble(25297.2011357594))
    let _Fac78 = (value Convert.ToDouble(12133.945222916))
    let _Fac109 = (value Convert.ToDouble(13973.4681761588))
    let _Fac105 = (value Convert.ToDouble(12871.8601504199))
    let _Fac119 = (value Convert.ToDouble(21144.0308545188))
    let _Fac8 = (value Convert.ToDouble(12791.0091959558))
    let _Fac69 = (value Convert.ToDouble(38756.0725899223))
    let _Fac81 = (value Convert.ToDouble(40912.5840524798))
    let _Fac80 = (value Convert.ToDouble(44007.6108321987))
    let _Fac68 = (value Convert.ToDouble(35131.853533475))
    let _Fac65 = (value Convert.ToDouble(15073.6050804882))
    let _Fac64 = (value Convert.ToDouble(32026.4799325125))
    let _Fac67 = (value Convert.ToDouble(42387.6526052449))
    let _Fac66 = (value Convert.ToDouble(41876.2063496681))
    let _Fac88 = (value Convert.ToDouble(33958.5231461119))
    let _Fac87 = (value Convert.ToDouble(13232.6011325369))
    let _Fac4 = (value Convert.ToDouble(21451.0330524369))
    let _Fac89 = (value Convert.ToDouble(9560.38064260791))
    let _Fac86 = (value Convert.ToDouble(19982.8676726513))
    let _Fac83 = (value Convert.ToDouble(16332.6846768757))
    let _Fac82 = (value Convert.ToDouble(10836.4897773399))
    let _Fac85 = (value Convert.ToDouble(5601.82194407309))
    let _Fac84 = (value Convert.ToDouble(9212.67894062828))
    let _Fac37 = (value Convert.ToDouble(39015.8665684088))
    let _Fac33 = (value Convert.ToDouble(38117.7491665757))
    let _Fac39 = (value Convert.ToDouble(12948.0751459132))
    let _Fac38 = (value Convert.ToDouble(33650.1714306544))
    let _Fac34 = (value Convert.ToDouble(39164.1404665446))
    let _Fac36 = (value Convert.ToDouble(39003.5309399284))
    let _Fac61 = (value Convert.ToDouble(7288.12201718174))
    let _Fac35 = (value Convert.ToDouble(5583.63744730353))
    let _Fac62 = (value Convert.ToDouble(38724.2955617217))
    let _Fac30 = (value Convert.ToDouble(33173.914389056))
    let _Fac31 = (value Convert.ToDouble(11712.264636473))
    let _Fac63 = (value Convert.ToDouble(18671.6768348371))
    let _Fac3 = (value Convert.ToDouble(4482.66052985802))
    let _Fac32 = (value Convert.ToDouble(36436.0276929938))
    let _Fac6 = (value Convert.ToDouble(1162.74836452678))
    let _Fac60 = (value Convert.ToDouble(26091.9019393507))
    let _Fac107 = (value Convert.ToDouble(32155.8920972871))
    let _Fac117 = (value Convert.ToDouble(20899.9387215196))
    let _Fac49 = (value Convert.ToDouble(28802.8696480499))
    let _Fac114 = (value Convert.ToDouble(7294.14005439947))
    let _Fac48 = (value Convert.ToDouble(43533.2635164214))
    let _Fac46 = (value Convert.ToDouble(41527.8693984995))
    let _Fac47 = (value Convert.ToDouble(25656.9371336015))
    let _Fac101 = (value Convert.ToDouble(2277.43138326164))
    let _Fac111 = (value Convert.ToDouble(10642.5351265353))
    let _Fac112 = (value Convert.ToDouble(29117.8651895193))
    let _Fac104 = (value Convert.ToDouble(38311.4167972843))
    let _Fac102 = (value Convert.ToDouble(24385.9513759391))
    let _Fac40 = (value Convert.ToDouble(24086.4091432379))
    let _Fac42 = (value Convert.ToDouble(21020.469256735))
    let _Fac41 = (value Convert.ToDouble(20695.3449735044))
    let _Fac44 = (value Convert.ToDouble(28477.9478288378))
    let _Fac45 = (value Convert.ToDouble(40573.1650522694))
    let _Fac43 = (value Convert.ToDouble(26641.5035072357))
    let _Bond90 = Fun.FixedRateBond _settlement _Fac90 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac90 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond91 = Fun.FixedRateBond _settlement _Fac91 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac91 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond92 = Fun.FixedRateBond _settlement _Fac92 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac92 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond6 = Fun.FixedRateBond _settlement _Fac6 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac6 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond32 = Fun.FixedRateBond _settlement _Fac32 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac32 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond88 = Fun.FixedRateBond _settlement _Fac88 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac88 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond28 = Fun.FixedRateBond _settlement _Fac28 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac28 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond29 = Fun.FixedRateBond _settlement _Fac29 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac29 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond23 = Fun.FixedRateBond _settlement _Fac23 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac23 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond86 = Fun.FixedRateBond _settlement _Fac86 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac86 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond16 = Fun.FixedRateBond _settlement _Fac16 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac16 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond80 = Fun.FixedRateBond _settlement _Fac80 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac80 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond87 = Fun.FixedRateBond _settlement _Fac87 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac87 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond85 = Fun.FixedRateBond _settlement _Fac85 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac85 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond89 = Fun.FixedRateBond _settlement _Fac89 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac89 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond93 = Fun.FixedRateBond _settlement _Fac93 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac93 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond33 = Fun.FixedRateBond _settlement _Fac33 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac33 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond84 = Fun.FixedRateBond _settlement _Fac84 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac84 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond7 = Fun.FixedRateBond _settlement _Fac7 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac7 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond21 = Fun.FixedRateBond _settlement _Fac21 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac21 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond96 = Fun.FixedRateBond _settlement _Fac96 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac96 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond20 = Fun.FixedRateBond _settlement _Fac20 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac20 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond27 = Fun.FixedRateBond _settlement _Fac27 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac27 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond37 = Fun.FixedRateBond _settlement _Fac37 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac37 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond98 = Fun.FixedRateBond _settlement _Fac98 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac98 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond30 = Fun.FixedRateBond _settlement _Fac30 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac30 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond99 = Fun.FixedRateBond _settlement _Fac99 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac99 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond95 = Fun.FixedRateBond _settlement _Fac95 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac95 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond94 = Fun.FixedRateBond _settlement _Fac94 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac94 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond36 = Fun.FixedRateBond _settlement _Fac36 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac36 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond34 = Fun.FixedRateBond _settlement _Fac34 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac34 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond35 = Fun.FixedRateBond _settlement _Fac35 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac35 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond39 = Fun.FixedRateBond _settlement _Fac39 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac39 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond22 = Fun.FixedRateBond _settlement _Fac22 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac22 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond38 = Fun.FixedRateBond _settlement _Fac38 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac38 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond97 = Fun.FixedRateBond _settlement _Fac97 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac97 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond26 = Fun.FixedRateBond _settlement _Fac26 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac26 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond25 = Fun.FixedRateBond _settlement _Fac25 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac25 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond31 = Fun.FixedRateBond _settlement _Fac31 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac31 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond24 = Fun.FixedRateBond _settlement _Fac24 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac24 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond60 = Fun.FixedRateBond _settlement _Fac60 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac60 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond61 = Fun.FixedRateBond _settlement _Fac61 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac61 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond62 = Fun.FixedRateBond _settlement _Fac62 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac62 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond65 = Fun.FixedRateBond _settlement _Fac65 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac65 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond66 = Fun.FixedRateBond _settlement _Fac66 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac66 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond67 = Fun.FixedRateBond _settlement _Fac67 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac67 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond108 = Fun.FixedRateBond _settlement _Fac108 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac108 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond118 = Fun.FixedRateBond _settlement _Fac118 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac118 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond117 = Fun.FixedRateBond _settlement _Fac117 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac117 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond63 = Fun.FixedRateBond _settlement _Fac63 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac63 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond102 = Fun.FixedRateBond _settlement _Fac102 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac102 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond112 = Fun.FixedRateBond _settlement _Fac112 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac112 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond45 = Fun.FixedRateBond _settlement _Fac45 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac45 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond44 = Fun.FixedRateBond _settlement _Fac44 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac44 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond49 = Fun.FixedRateBond _settlement _Fac49 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac49 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond40 = Fun.FixedRateBond _settlement _Fac40 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac40 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond47 = Fun.FixedRateBond _settlement _Fac47 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac47 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond46 = Fun.FixedRateBond _settlement _Fac46 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac46 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond68 = Fun.FixedRateBond _settlement _Fac68 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac68 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond69 = Fun.FixedRateBond _settlement _Fac69 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac69 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond64 = Fun.FixedRateBond _settlement _Fac64 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac64 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond48 = Fun.FixedRateBond _settlement _Fac48 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac48 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond42 = Fun.FixedRateBond _settlement _Fac42 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac42 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond43 = Fun.FixedRateBond _settlement _Fac43 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac43 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond5 = Fun.FixedRateBond _settlement _Fac5 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac5 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond9 = Fun.FixedRateBond _settlement _Fac9 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac9 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond3 = Fun.FixedRateBond _settlement _Fac3 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac3 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond18 = Fun.FixedRateBond _settlement _Fac18 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac18 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond119 = Fun.FixedRateBond _settlement _Fac119 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac119 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond109 = Fun.FixedRateBond _settlement _Fac109 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac109 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond83 = Fun.FixedRateBond _settlement _Fac83 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac83 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond82 = Fun.FixedRateBond _settlement _Fac82 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac82 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond81 = Fun.FixedRateBond _settlement _Fac81 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac81 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond120 = Fun.FixedRateBond _settlement _Fac120 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac120 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond110 = Fun.FixedRateBond _settlement _Fac110 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac110 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond100 = Fun.FixedRateBond _settlement _Fac100 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac100 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond13 = Fun.FixedRateBond _settlement _Fac13 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac13 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond12 = Fun.FixedRateBond _settlement _Fac12 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac12 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond11 = Fun.FixedRateBond _settlement _Fac11 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac11 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond107 = Fun.FixedRateBond _settlement _Fac107 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac107 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond115 = Fun.FixedRateBond _settlement _Fac115 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac115 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond105 = Fun.FixedRateBond _settlement _Fac105 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac105 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond15 = Fun.FixedRateBond _settlement _Fac15 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac15 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond14 = Fun.FixedRateBond _settlement _Fac14 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac14 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond19 = Fun.FixedRateBond _settlement _Fac19 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac19 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond10 = Fun.FixedRateBond _settlement _Fac10 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac10 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond17 = Fun.FixedRateBond _settlement _Fac17 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac17 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond41 = Fun.FixedRateBond _settlement _Fac41 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac41 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond74 = Fun.FixedRateBond _settlement _Fac74 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac74 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond75 = Fun.FixedRateBond _settlement _Fac75 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac75 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond78 = Fun.FixedRateBond _settlement _Fac78 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac78 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond79 = Fun.FixedRateBond _settlement _Fac79 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac79 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond70 = Fun.FixedRateBond _settlement _Fac70 _Mat5FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac70 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond103 = Fun.FixedRateBond _settlement _Fac103 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac103 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond76 = Fun.FixedRateBond _settlement _Fac76 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac76 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond77 = Fun.FixedRateBond _settlement _Fac77 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac77 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond114 = Fun.FixedRateBond _settlement _Fac114 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac114 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond101 = Fun.FixedRateBond _settlement _Fac101 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac101 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond8 = Fun.FixedRateBond _settlement _Fac8 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac8 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond104 = Fun.FixedRateBond _settlement _Fac104 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac104 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond106 = Fun.FixedRateBond _settlement _Fac106 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac106 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond116 = Fun.FixedRateBond _settlement _Fac116 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac116 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond111 = Fun.FixedRateBond _settlement _Fac111 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac111 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _Bond2 = Fun.FixedRateBond _settlement _Fac2 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac2 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond71 = Fun.FixedRateBond _settlement _Fac71 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac71 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond56 = Fun.FixedRateBond _settlement _Fac56 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac56 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond1 = Fun.FixedRateBond _settlement _Fac1 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac1 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond50 = Fun.FixedRateBond _settlement _Fac50 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac50 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond57 = Fun.FixedRateBond _settlement _Fac57 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac57 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond59 = Fun.FixedRateBond _settlement _Fac59 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac59 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond58 = Fun.FixedRateBond _settlement _Fac58 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac58 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond55 = Fun.FixedRateBond _settlement _Fac55 _Mat5FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac55 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond54 = Fun.FixedRateBond _settlement _Fac54 _Mat4FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac54 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond52 = Fun.FixedRateBond _settlement _Fac52 _Mat2FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac52 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond73 = Fun.FixedRateBond _settlement _Fac73 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac73 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond53 = Fun.FixedRateBond _settlement _Fac53 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac53 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond51 = Fun.FixedRateBond _settlement _Fac51 _Mat1FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac51 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond4 = Fun.FixedRateBond _settlement _Fac4 _Mat4FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac4 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond72 = Fun.FixedRateBond _settlement _Fac72 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac72 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield3.Value :> IPricingEngine)) _priceday
    let _Bond113 = Fun.FixedRateBond _settlement _Fac113 _Mat3FreqA _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac113 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield4.Value :> IPricingEngine)) _priceday
    let _clean80 = _Bond80.CleanPrice()
    let _clean81 = _Bond81.CleanPrice()
    let _clean83 = _Bond83.CleanPrice()
    let _clean85 = _Bond85.CleanPrice()
    let _clean82 = _Bond82.CleanPrice()
    let _clean86 = _Bond86.CleanPrice()
    let _clean88 = _Bond88.CleanPrice()
    let _clean89 = _Bond89.CleanPrice()
    let _clean114 = _Bond114.CleanPrice()
    let _clean87 = _Bond87.CleanPrice()
    let _clean84 = _Bond84.CleanPrice()
    let _clean29 = _Bond29.CleanPrice()
    let _clean23 = _Bond23.CleanPrice()
    let _clean20 = _Bond20.CleanPrice()
    let _clean21 = _Bond21.CleanPrice()
    let _clean22 = _Bond22.CleanPrice()
    let _clean2 = _Bond2.CleanPrice()
    let _clean1 = _Bond1.CleanPrice()
    let _clean119 = _Bond119.CleanPrice()
    let _clean24 = _Bond24.CleanPrice()
    let _clean25 = _Bond25.CleanPrice()
    let _clean28 = _Bond28.CleanPrice()
    let _clean27 = _Bond27.CleanPrice()
    let _clean104 = _Bond104.CleanPrice()
    let _clean26 = _Bond26.CleanPrice()
    let _clean61 = _Bond61.CleanPrice()
    let _clean19 = _Bond19.CleanPrice()
    let _clean3 = _Bond3.CleanPrice()
    let _clean18 = _Bond18.CleanPrice()
    let _clean14 = _Bond14.CleanPrice()
    let _clean15 = _Bond15.CleanPrice()
    let _clean62 = _Bond62.CleanPrice()
    let _clean63 = _Bond63.CleanPrice()
    let _clean6 = _Bond6.CleanPrice()
    let _clean9 = _Bond9.CleanPrice()
    let _clean5 = _Bond5.CleanPrice()
    let _clean13 = _Bond13.CleanPrice()
    let _clean10 = _Bond10.CleanPrice()
    let _clean12 = _Bond12.CleanPrice()
    let _clean113 = _Bond113.CleanPrice()
    let _clean103 = _Bond103.CleanPrice()
    let _clean115 = _Bond115.CleanPrice()
    let _clean17 = _Bond17.CleanPrice()
    let _clean16 = _Bond16.CleanPrice()
    let _clean105 = _Bond105.CleanPrice()
    let _clean11 = _Bond11.CleanPrice()
    let _clean109 = _Bond109.CleanPrice()
    let _clean66 = _Bond66.CleanPrice()
    let _clean42 = _Bond42.CleanPrice()
    let _clean40 = _Bond40.CleanPrice()
    let _clean43 = _Bond43.CleanPrice()
    let _clean68 = _Bond68.CleanPrice()
    let _clean69 = _Bond69.CleanPrice()
    let _clean65 = _Bond65.CleanPrice()
    let _clean67 = _Bond67.CleanPrice()
    let _clean64 = _Bond64.CleanPrice()
    let _clean45 = _Bond45.CleanPrice()
    let _clean44 = _Bond44.CleanPrice()
    let _clean48 = _Bond48.CleanPrice()
    let _clean60 = _Bond60.CleanPrice()
    let _clean49 = _Bond49.CleanPrice()
    let _clean106 = _Bond106.CleanPrice()
    let _clean41 = _Bond41.CleanPrice()
    let _clean116 = _Bond116.CleanPrice()
    let _clean47 = _Bond47.CleanPrice()
    let _clean46 = _Bond46.CleanPrice()
    let _clean75 = _Bond75.CleanPrice()
    let _clean74 = _Bond74.CleanPrice()
    let _clean78 = _Bond78.CleanPrice()
    let _clean99 = _Bond99.CleanPrice()
    let _clean79 = _Bond79.CleanPrice()
    let _clean70 = _Bond70.CleanPrice()
    let _clean73 = _Bond73.CleanPrice()
    let _clean71 = _Bond71.CleanPrice()
    let _clean77 = _Bond77.CleanPrice()
    let _clean76 = _Bond76.CleanPrice()
    let _clean90 = _Bond90.CleanPrice()
    let _clean91 = _Bond91.CleanPrice()
    let _clean93 = _Bond93.CleanPrice()
    let _clean101 = _Bond101.CleanPrice()
    let _clean92 = _Bond92.CleanPrice()
    let _clean95 = _Bond95.CleanPrice()
    let _clean98 = _Bond98.CleanPrice()
    let _clean94 = _Bond94.CleanPrice()
    let _clean96 = _Bond96.CleanPrice()
    let _clean97 = _Bond97.CleanPrice()
    let _clean72 = _Bond72.CleanPrice()
    let _clean59 = _Bond59.CleanPrice()
    let _clean112 = _Bond112.CleanPrice()
    let _clean58 = _Bond58.CleanPrice()
    let _clean54 = _Bond54.CleanPrice()
    let _clean55 = _Bond55.CleanPrice()
    let _clean100 = _Bond100.CleanPrice()
    let _clean110 = _Bond110.CleanPrice()
    let _clean120 = _Bond120.CleanPrice()
    let _clean102 = _Bond102.CleanPrice()
    let _clean7 = _Bond7.CleanPrice()
    let _clean108 = _Bond108.CleanPrice()
    let _clean52 = _Bond52.CleanPrice()
    let _clean118 = _Bond118.CleanPrice()
    let _clean4 = _Bond4.CleanPrice()
    let _clean8 = _Bond8.CleanPrice()
    let _clean56 = _Bond56.CleanPrice()
    let _clean57 = _Bond57.CleanPrice()
    let _clean51 = _Bond51.CleanPrice()
    let _clean53 = _Bond53.CleanPrice()
    let _clean50 = _Bond50.CleanPrice()
    let _clean117 = _Bond117.CleanPrice()
    let _clean39 = _Bond39.CleanPrice()
    let _clean111 = _Bond111.CleanPrice()
    let _clean36 = _Bond36.CleanPrice()
    let _clean107 = _Bond107.CleanPrice()
    let _clean31 = _Bond31.CleanPrice()
    let _clean38 = _Bond38.CleanPrice()
    let _clean33 = _Bond33.CleanPrice()
    let _clean30 = _Bond30.CleanPrice()
    let _clean37 = _Bond37.CleanPrice()
    let _clean32 = _Bond32.CleanPrice()
    let _clean35 = _Bond35.CleanPrice()
    let _clean34 = _Bond34.CleanPrice()
    let _lapse68 = new TimeLapse<double> _clean68 (value (10 :?> Double))
    let _lapse82 = new TimeLapse<double> _clean82 (value (10 :?> Double))
    let _lapse48 = new TimeLapse<double> _clean48 (value (10 :?> Double))
    let _lapse78 = new TimeLapse<double> _clean78 (value (10 :?> Double))
    let _lapse12 = new TimeLapse<double> _clean12 (value (10 :?> Double))
    let _lapse32 = new TimeLapse<double> _clean32 (value (10 :?> Double))
    let _lapse72 = new TimeLapse<double> _clean72 (value (10 :?> Double))
    let _lapse62 = new TimeLapse<double> _clean62 (value (10 :?> Double))
    let _lapse42 = new TimeLapse<double> _clean42 (value (10 :?> Double))
    let _lapse58 = new TimeLapse<double> _clean58 (value (10 :?> Double))
    let _lapse22 = new TimeLapse<double> _clean22 (value (10 :?> Double))
    let _lapse92 = new TimeLapse<double> _clean92 (value (10 :?> Double))
    let _lapse117 = new TimeLapse<double> _clean117 (value (10 :?> Double))
    let _lapse51 = new TimeLapse<double> _clean51 (value (10 :?> Double))
    let _lapse116 = new TimeLapse<double> _clean116 (value (10 :?> Double))
    let _lapse110 = new TimeLapse<double> _clean110 (value (10 :?> Double))
    let _lapse89 = new TimeLapse<double> _clean89 (value (10 :?> Double))
    let _lapse112 = new TimeLapse<double> _clean112 (value (10 :?> Double))
    let _lapse111 = new TimeLapse<double> _clean111 (value (10 :?> Double))
    let _lapse115 = new TimeLapse<double> _clean115 (value (10 :?> Double))
    let _lapse28 = new TimeLapse<double> _clean28 (value (10 :?> Double))
    let _lapse38 = new TimeLapse<double> _clean38 (value (10 :?> Double))
    let _lapse18 = new TimeLapse<double> _clean18 (value (10 :?> Double))
    let _lapse98 = new TimeLapse<double> _clean98 (value (10 :?> Double))
    let _lapse114 = new TimeLapse<double> _clean114 (value (10 :?> Double))
    let _lapse9 = new TimeLapse<double> _clean9 (value (10 :?> Double))
    let _lapse88 = new TimeLapse<double> _clean88 (value (10 :?> Double))
    let _lapse52 = new TimeLapse<double> _clean52 (value (10 :?> Double))
    let _lapse54 = new TimeLapse<double> _clean54 (value (10 :?> Double))
    let _lapse44 = new TimeLapse<double> _clean44 (value (10 :?> Double))
    let _lapse74 = new TimeLapse<double> _clean74 (value (10 :?> Double))
    let _lapse76 = new TimeLapse<double> _clean76 (value (10 :?> Double))
    let _lapse46 = new TimeLapse<double> _clean46 (value (10 :?> Double))
    let _lapse56 = new TimeLapse<double> _clean56 (value (10 :?> Double))
    let _lapse64 = new TimeLapse<double> _clean64 (value (10 :?> Double))
    let _lapse94 = new TimeLapse<double> _clean94 (value (10 :?> Double))
    let _lapse84 = new TimeLapse<double> _clean84 (value (10 :?> Double))
    let _lapse47 = new TimeLapse<double> _clean47 (value (10 :?> Double))
    let _lapse14 = new TimeLapse<double> _clean14 (value (10 :?> Double))
    let _lapse34 = new TimeLapse<double> _clean34 (value (10 :?> Double))
    let _lapse24 = new TimeLapse<double> _clean24 (value (10 :?> Double))
    let _lapse66 = new TimeLapse<double> _clean66 (value (10 :?> Double))
    let _lapse20 = new TimeLapse<double> _clean20 (value (10 :?> Double))
    let _lapse30 = new TimeLapse<double> _clean30 (value (10 :?> Double))
    let _lapse10 = new TimeLapse<double> _clean10 (value (10 :?> Double))
    let _lapse8 = new TimeLapse<double> _clean8 (value (10 :?> Double))
    let _lapse80 = new TimeLapse<double> _clean80 (value (10 :?> Double))
    let _lapse90 = new TimeLapse<double> _clean90 (value (10 :?> Double))
    let _lapse60 = new TimeLapse<double> _clean60 (value (10 :?> Double))
    let _lapse26 = new TimeLapse<double> _clean26 (value (10 :?> Double))
    let _lapse36 = new TimeLapse<double> _clean36 (value (10 :?> Double))
    let _lapse16 = new TimeLapse<double> _clean16 (value (10 :?> Double))
    let _lapse70 = new TimeLapse<double> _clean70 (value (10 :?> Double))
    let _lapse40 = new TimeLapse<double> _clean40 (value (10 :?> Double))
    let _lapse50 = new TimeLapse<double> _clean50 (value (10 :?> Double))
    let _lapse113 = new TimeLapse<double> _clean113 (value (10 :?> Double))
    let _lapse6 = new TimeLapse<double> _clean6 (value (10 :?> Double))
    let _lapse7 = new TimeLapse<double> _clean7 (value (10 :?> Double))
    let _lapse3 = new TimeLapse<double> _clean3 (value (10 :?> Double))
    let _lapse1 = new TimeLapse<double> _clean1 (value (10 :?> Double))
    let _lapse105 = new TimeLapse<double> _clean105 (value (10 :?> Double))
    let _lapse75 = new TimeLapse<double> _clean75 (value (10 :?> Double))
    let _lapse4 = new TimeLapse<double> _clean4 (value (10 :?> Double))
    let _lapse5 = new TimeLapse<double> _clean5 (value (10 :?> Double))
    let _lapse107 = new TimeLapse<double> _clean107 (value (10 :?> Double))
    let _lapse55 = new TimeLapse<double> _clean55 (value (10 :?> Double))
    let _lapse120 = new TimeLapse<double> _clean120 (value (10 :?> Double))
    let _lapse100 = new TimeLapse<double> _clean100 (value (10 :?> Double))
    let _lapse2 = new TimeLapse<double> _clean2 (value (10 :?> Double))
    let _lapse86 = new TimeLapse<double> _clean86 (value (10 :?> Double))
    let _lapse45 = new TimeLapse<double> _clean45 (value (10 :?> Double))
    let _lapse106 = new TimeLapse<double> _clean106 (value (10 :?> Double))
    let _lapse15 = new TimeLapse<double> _clean15 (value (10 :?> Double))
    let _lapse57 = new TimeLapse<double> _clean57 (value (10 :?> Double))
    let _lapse77 = new TimeLapse<double> _clean77 (value (10 :?> Double))
    let _lapse65 = new TimeLapse<double> _clean65 (value (10 :?> Double))
    let _lapse25 = new TimeLapse<double> _clean25 (value (10 :?> Double))
    let _lapse95 = new TimeLapse<double> _clean95 (value (10 :?> Double))
    let _lapse85 = new TimeLapse<double> _clean85 (value (10 :?> Double))
    let _lapse35 = new TimeLapse<double> _clean35 (value (10 :?> Double))
    let _lapse97 = new TimeLapse<double> _clean97 (value (10 :?> Double))
    let _lapse27 = new TimeLapse<double> _clean27 (value (10 :?> Double))
    let _lapse104 = new TimeLapse<double> _clean104 (value (10 :?> Double))
    let _lapse87 = new TimeLapse<double> _clean87 (value (10 :?> Double))
    let _lapse17 = new TimeLapse<double> _clean17 (value (10 :?> Double))
    let _lapse67 = new TimeLapse<double> _clean67 (value (10 :?> Double))
    let _Clock = cell Cephei.XL.TodayModule+clock@52-3
    let _lapse37 = new TimeLapse<double> _clean37 (value (10 :?> Double))
    let _lapse101 = new TimeLapse<double> _clean101 (value (10 :?> Double))
    let _lapse79 = new TimeLapse<double> _clean79 (value (10 :?> Double))
    let _lapse49 = new TimeLapse<double> _clean49 (value (10 :?> Double))
    let _lapse19 = new TimeLapse<double> _clean19 (value (10 :?> Double))
    let _lapse69 = new TimeLapse<double> _clean69 (value (10 :?> Double))
    let _lapse11 = new TimeLapse<double> _clean11 (value (10 :?> Double))
    let _lapse31 = new TimeLapse<double> _clean31 (value (10 :?> Double))
    let _lapse59 = new TimeLapse<double> _clean59 (value (10 :?> Double))
    let _lapse109 = new TimeLapse<double> _clean109 (value (10 :?> Double))
    let _lapse119 = new TimeLapse<double> _clean119 (value (10 :?> Double))
    let _lapse41 = new TimeLapse<double> _clean41 (value (10 :?> Double))
    let _lapse99 = new TimeLapse<double> _clean99 (value (10 :?> Double))
    let _lapse118 = new TimeLapse<double> _clean118 (value (10 :?> Double))
    let _lapse71 = new TimeLapse<double> _clean71 (value (10 :?> Double))
    let _lapse61 = new TimeLapse<double> _clean61 (value (10 :?> Double))
    let _lapse29 = new TimeLapse<double> _clean29 (value (10 :?> Double))
    let _lapse39 = new TimeLapse<double> _clean39 (value (10 :?> Double))
    let _lapse13 = new TimeLapse<double> _clean13 (value (10 :?> Double))
    let _lapse33 = new TimeLapse<double> _clean33 (value (10 :?> Double))
    let _lapse73 = new TimeLapse<double> _clean73 (value (10 :?> Double))
    let _lapse63 = new TimeLapse<double> _clean63 (value (10 :?> Double))
    let _lapse83 = new TimeLapse<double> _clean83 (value (10 :?> Double))
    let _lapse102 = new TimeLapse<double> _clean102 (value (10 :?> Double))
    let _lapse23 = new TimeLapse<double> _clean23 (value (10 :?> Double))
    let _lapse93 = new TimeLapse<double> _clean93 (value (10 :?> Double))
    let _lapse81 = new TimeLapse<double> _clean81 (value (10 :?> Double))
    let _lapse108 = new TimeLapse<double> _clean108 (value (10 :?> Double))
    let _lapse21 = new TimeLapse<double> _clean21 (value (10 :?> Double))
    let _lapse91 = new TimeLapse<double> _clean91 (value (10 :?> Double))
    let _lapse53 = new TimeLapse<double> _clean53 (value (10 :?> Double))
    let _lapse43 = new TimeLapse<double> _clean43 (value (10 :?> Double))
    let _lapse103 = new TimeLapse<double> _clean103 (value (10 :?> Double))
    let _lapse96 = new TimeLapse<double> _clean96 (value (10 :?> Double))

    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.Today = _Today
    member this.clock = _clock
    member this.coupons = _coupons
    member this.FreqS = _FreqS
    member this.FreqA = _FreqA
    member this.Yield2 = _Yield2
    member this.Yield3 = _Yield3
    member this.Yield1 = _Yield1
    member this.Yield4 = _Yield4
    member this.FlatYield2 = _FlatYield2
    member this.FlatYield3 = _FlatYield3
    member this.FlatYield4 = _FlatYield4
    member this.FlatYield1 = _FlatYield1
    member this.Fac13 = _Fac13
    member this.Fac12 = _Fac12
    member this.Fac10 = _Fac10
    member this.Fac11 = _Fac11
    member this.Fac16 = _Fac16
    member this.Fac14 = _Fac14
    member this.Fac2 = _Fac2
    member this.Fac113 = _Fac113
    member this.Fac76 = _Fac76
    member this.Fac15 = _Fac15
    member this.Fac17 = _Fac17
    member this.Fac18 = _Fac18
    member this.Fac1 = _Fac1
    member this.Fac23 = _Fac23
    member this.Fac24 = _Fac24
    member this.Fac25 = _Fac25
    member this.Fac20 = _Fac20
    member this.Fac21 = _Fac21
    member this.Fac22 = _Fac22
    member this.Fac120 = _Fac120
    member this.Fac29 = _Fac29
    member this.Fac110 = _Fac110
    member this.Fac100 = _Fac100
    member this.Fac26 = _Fac26
    member this.Fac27 = _Fac27
    member this.Fac28 = _Fac28
    member this.Fac103 = _Fac103
    member this.Fac99 = _Fac99
    member this.Fac5 = _Fac5
    member this.Fac98 = _Fac98
    member this.Fac96 = _Fac96
    member this.Fac97 = _Fac97
    member this.Fac53 = _Fac53
    member this.Fac54 = _Fac54
    member this.Fac52 = _Fac52
    member this.Fac50 = _Fac50
    member this.Fac51 = _Fac51
    member this.Fac9 = _Fac9
    member this.Fac90 = _Fac90
    member this.Fac106 = _Fac106
    member this.Fac108 = _Fac108
    member this.Fac116 = _Fac116
    member this.Fac94 = _Fac94
    member this.Fac95 = _Fac95
    member this.Fac93 = _Fac93
    member this.Fac91 = _Fac91
    member this.Fac92 = _Fac92
    member this.Fac55 = _Fac55
    member this.Fac74 = _Fac74
    member this.Fac73 = _Fac73
    member this.Fac75 = _Fac75
    member this.Fac77 = _Fac77
    member this.Fac118 = _Fac118
    member this.Fac7 = _Fac7
    member this.Fac19 = _Fac19
    member this.Fac70 = _Fac70
    member this.Fac72 = _Fac72
    member this.Fac71 = _Fac71
    member this.Fac59 = _Fac59
    member this.Fac115 = _Fac115
    member this.Fac58 = _Fac58
    member this.Fac56 = _Fac56
    member this.Fac57 = _Fac57
    member this.Fac79 = _Fac79
    member this.Fac78 = _Fac78
    member this.Fac109 = _Fac109
    member this.Fac105 = _Fac105
    member this.Fac119 = _Fac119
    member this.Fac8 = _Fac8
    member this.Fac69 = _Fac69
    member this.Fac81 = _Fac81
    member this.Fac80 = _Fac80
    member this.Fac68 = _Fac68
    member this.Fac65 = _Fac65
    member this.Fac64 = _Fac64
    member this.Fac67 = _Fac67
    member this.Fac66 = _Fac66
    member this.Fac88 = _Fac88
    member this.Fac87 = _Fac87
    member this.Fac4 = _Fac4
    member this.Fac89 = _Fac89
    member this.Fac86 = _Fac86
    member this.Fac83 = _Fac83
    member this.Fac82 = _Fac82
    member this.Fac85 = _Fac85
    member this.Fac84 = _Fac84
    member this.Fac37 = _Fac37
    member this.Fac33 = _Fac33
    member this.Fac39 = _Fac39
    member this.Fac38 = _Fac38
    member this.Fac34 = _Fac34
    member this.Fac36 = _Fac36
    member this.Fac61 = _Fac61
    member this.Fac35 = _Fac35
    member this.Fac62 = _Fac62
    member this.Fac30 = _Fac30
    member this.Fac31 = _Fac31
    member this.Fac63 = _Fac63
    member this.Fac3 = _Fac3
    member this.Fac32 = _Fac32
    member this.Fac6 = _Fac6
    member this.Fac60 = _Fac60
    member this.Fac107 = _Fac107
    member this.Fac117 = _Fac117
    member this.Fac49 = _Fac49
    member this.Fac114 = _Fac114
    member this.Fac48 = _Fac48
    member this.Fac46 = _Fac46
    member this.Fac47 = _Fac47
    member this.Fac101 = _Fac101
    member this.Fac111 = _Fac111
    member this.Fac112 = _Fac112
    member this.Fac104 = _Fac104
    member this.Fac102 = _Fac102
    member this.Fac40 = _Fac40
    member this.Fac42 = _Fac42
    member this.Fac41 = _Fac41
    member this.Fac44 = _Fac44
    member this.Fac45 = _Fac45
    member this.Fac43 = _Fac43
    member this.clean80 = _clean80
    member this.clean81 = _clean81
    member this.clean83 = _clean83
    member this.clean85 = _clean85
    member this.clean82 = _clean82
    member this.clean86 = _clean86
    member this.clean88 = _clean88
    member this.clean89 = _clean89
    member this.clean114 = _clean114
    member this.clean87 = _clean87
    member this.clean84 = _clean84
    member this.clean29 = _clean29
    member this.clean23 = _clean23
    member this.clean20 = _clean20
    member this.clean21 = _clean21
    member this.clean22 = _clean22
    member this.clean2 = _clean2
    member this.clean1 = _clean1
    member this.clean119 = _clean119
    member this.clean24 = _clean24
    member this.clean25 = _clean25
    member this.clean28 = _clean28
    member this.clean27 = _clean27
    member this.clean104 = _clean104
    member this.clean26 = _clean26
    member this.clean61 = _clean61
    member this.clean19 = _clean19
    member this.clean3 = _clean3
    member this.clean18 = _clean18
    member this.clean14 = _clean14
    member this.clean15 = _clean15
    member this.clean62 = _clean62
    member this.clean63 = _clean63
    member this.clean6 = _clean6
    member this.clean9 = _clean9
    member this.clean5 = _clean5
    member this.clean13 = _clean13
    member this.clean10 = _clean10
    member this.clean12 = _clean12
    member this.clean113 = _clean113
    member this.clean103 = _clean103
    member this.clean115 = _clean115
    member this.clean17 = _clean17
    member this.clean16 = _clean16
    member this.clean105 = _clean105
    member this.clean11 = _clean11
    member this.clean109 = _clean109
    member this.clean66 = _clean66
    member this.clean42 = _clean42
    member this.clean40 = _clean40
    member this.clean43 = _clean43
    member this.clean68 = _clean68
    member this.clean69 = _clean69
    member this.clean65 = _clean65
    member this.clean67 = _clean67
    member this.clean64 = _clean64
    member this.clean45 = _clean45
    member this.clean44 = _clean44
    member this.clean48 = _clean48
    member this.clean60 = _clean60
    member this.clean49 = _clean49
    member this.clean106 = _clean106
    member this.clean41 = _clean41
    member this.clean116 = _clean116
    member this.clean47 = _clean47
    member this.clean46 = _clean46
    member this.clean75 = _clean75
    member this.clean74 = _clean74
    member this.clean78 = _clean78
    member this.clean99 = _clean99
    member this.clean79 = _clean79
    member this.clean70 = _clean70
    member this.clean73 = _clean73
    member this.clean71 = _clean71
    member this.clean77 = _clean77
    member this.clean76 = _clean76
    member this.clean90 = _clean90
    member this.clean91 = _clean91
    member this.clean93 = _clean93
    member this.clean101 = _clean101
    member this.clean92 = _clean92
    member this.clean95 = _clean95
    member this.clean98 = _clean98
    member this.clean94 = _clean94
    member this.clean96 = _clean96
    member this.clean97 = _clean97
    member this.clean72 = _clean72
    member this.clean59 = _clean59
    member this.clean112 = _clean112
    member this.clean58 = _clean58
    member this.clean54 = _clean54
    member this.clean55 = _clean55
    member this.clean100 = _clean100
    member this.clean110 = _clean110
    member this.clean120 = _clean120
    member this.clean102 = _clean102
    member this.clean7 = _clean7
    member this.clean108 = _clean108
    member this.clean52 = _clean52
    member this.clean118 = _clean118
    member this.clean4 = _clean4
    member this.clean8 = _clean8
    member this.clean56 = _clean56
    member this.clean57 = _clean57
    member this.clean51 = _clean51
    member this.clean53 = _clean53
    member this.clean50 = _clean50
    member this.clean117 = _clean117
    member this.clean39 = _clean39
    member this.clean111 = _clean111
    member this.clean36 = _clean36
    member this.clean107 = _clean107
    member this.clean31 = _clean31
    member this.clean38 = _clean38
    member this.clean33 = _clean33
    member this.clean30 = _clean30
    member this.clean37 = _clean37
    member this.clean32 = _clean32
    member this.clean35 = _clean35
    member this.clean34 = _clean34
    member this.Clock = _Clock


#if EXCEL
module BondSimpleFunction =

    [<ExcelFunction(Name="__BondSimple", Description="Create a BondSimple",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__coupons",Description = "reference to List")>]
        coupons : obj)
        ([<ExcelArgument(Name="__Yield2",Description = "reference to SimpleQuote")>]
        Yield2 : obj)
        ([<ExcelArgument(Name="__Yield3",Description = "reference to SimpleQuote")>]
        Yield3 : obj)
        ([<ExcelArgument(Name="__Yield1",Description = "reference to SimpleQuote")>]
        Yield1 : obj)
        ([<ExcelArgument(Name="__Yield4",Description = "reference to SimpleQuote")>]
        Yield4 : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _coupons = Helper.toCell<List> coupons "coupons"
                let _Yield2 = Helper.toCell<SimpleQuote> Yield2 "Yield2"
                let _Yield3 = Helper.toCell<SimpleQuote> Yield3 "Yield3"
                let _Yield1 = Helper.toCell<SimpleQuote> Yield1 "Yield1"
                let _Yield4 = Helper.toCell<SimpleQuote> Yield4 "Yield4"

                let builder (current : ICell) = withMnemonic mnemonic (new BondSimple
                                                            _coupons.cell
                                                            _Yield2.cell
                                                            _Yield3.cell
                                                            _Yield1.cell
                                                            _Yield4.cell

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> BondSimple) l
                let source () = Helper.sourceFold "new BondSimple"
                                               [| _coupons.source
                                               ;  _Yield2.source
                                               ;  _Yield3.source
                                               ;  _Yield1.source
                                               ;  _Yield4.source
                                               |]

                let hash = Helper.hashFold
                                [| _coupons.cell
                                ;  _Yield2.cell
                                ;  _Yield3.cell
                                ;  _Yield1.cell
                                ;  _Yield4.cell
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac113", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac113
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac113) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac113) l
            let source () = (_BondSimple.source + ".Fac113")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac76", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac76
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac76) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac76) l
            let source () = (_BondSimple.source + ".Fac76")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac120", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac120
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac120) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac120) l
            let source () = (_BondSimple.source + ".Fac120")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac29", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac29
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac29) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac29) l
            let source () = (_BondSimple.source + ".Fac29")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac110", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac110
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac110) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac110) l
            let source () = (_BondSimple.source + ".Fac110")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac100", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac100
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac100) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac100) l
            let source () = (_BondSimple.source + ".Fac100")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac103", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac103
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac103) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac103) l
            let source () = (_BondSimple.source + ".Fac103")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac99", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac99
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac99) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac99) l
            let source () = (_BondSimple.source + ".Fac99")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac98", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac98
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac98) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac98) l
            let source () = (_BondSimple.source + ".Fac98")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac96", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac96
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac96) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac96) l
            let source () = (_BondSimple.source + ".Fac96")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac97", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac97
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac97) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac97) l
            let source () = (_BondSimple.source + ".Fac97")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac53", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac53
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac53) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac53) l
            let source () = (_BondSimple.source + ".Fac53")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac54", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac54
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac54) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac54) l
            let source () = (_BondSimple.source + ".Fac54")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac52", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac52
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac52) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac52) l
            let source () = (_BondSimple.source + ".Fac52")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac50", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac50
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac50) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac50) l
            let source () = (_BondSimple.source + ".Fac50")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac51", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac51
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac51) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac51) l
            let source () = (_BondSimple.source + ".Fac51")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac90", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac90
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac90) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac90) l
            let source () = (_BondSimple.source + ".Fac90")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac106", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac106
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac106) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac106) l
            let source () = (_BondSimple.source + ".Fac106")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac108", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac108
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac108) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac108) l
            let source () = (_BondSimple.source + ".Fac108")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac116", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac116
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac116) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac116) l
            let source () = (_BondSimple.source + ".Fac116")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac94", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac94
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac94) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac94) l
            let source () = (_BondSimple.source + ".Fac94")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac95", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac95
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac95) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac95) l
            let source () = (_BondSimple.source + ".Fac95")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac93", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac93
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac93) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac93) l
            let source () = (_BondSimple.source + ".Fac93")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac91", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac91
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac91) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac91) l
            let source () = (_BondSimple.source + ".Fac91")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac92", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac92
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac92) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac92) l
            let source () = (_BondSimple.source + ".Fac92")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac55", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac55
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac55) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac55) l
            let source () = (_BondSimple.source + ".Fac55")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac74", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac74
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac74) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac74) l
            let source () = (_BondSimple.source + ".Fac74")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac73", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac73
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac73) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac73) l
            let source () = (_BondSimple.source + ".Fac73")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac75", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac75
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac75) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac75) l
            let source () = (_BondSimple.source + ".Fac75")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac77", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac77
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac77) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac77) l
            let source () = (_BondSimple.source + ".Fac77")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac118", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac118
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac118) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac118) l
            let source () = (_BondSimple.source + ".Fac118")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac70", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac70
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac70) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac70) l
            let source () = (_BondSimple.source + ".Fac70")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac72", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac72
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac72) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac72) l
            let source () = (_BondSimple.source + ".Fac72")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac71", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac71
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac71) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac71) l
            let source () = (_BondSimple.source + ".Fac71")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac59", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac59
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac59) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac59) l
            let source () = (_BondSimple.source + ".Fac59")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac115", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac115
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac115) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac115) l
            let source () = (_BondSimple.source + ".Fac115")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac58", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac58
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac58) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac58) l
            let source () = (_BondSimple.source + ".Fac58")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac56", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac56
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac56) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac56) l
            let source () = (_BondSimple.source + ".Fac56")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac57", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac57
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac57) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac57) l
            let source () = (_BondSimple.source + ".Fac57")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac79", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac79
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac79) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac79) l
            let source () = (_BondSimple.source + ".Fac79")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac78", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac78
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac78) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac78) l
            let source () = (_BondSimple.source + ".Fac78")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac109", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac109
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac109) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac109) l
            let source () = (_BondSimple.source + ".Fac109")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac105", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac105
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac105) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac105) l
            let source () = (_BondSimple.source + ".Fac105")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac119", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac119
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac119) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac119) l
            let source () = (_BondSimple.source + ".Fac119")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac69", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac69
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac69) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac69) l
            let source () = (_BondSimple.source + ".Fac69")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac81", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac81
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac81) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac81) l
            let source () = (_BondSimple.source + ".Fac81")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac80", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac80
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac80) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac80) l
            let source () = (_BondSimple.source + ".Fac80")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac68", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac68
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac68) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac68) l
            let source () = (_BondSimple.source + ".Fac68")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac65", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac65
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac65) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac65) l
            let source () = (_BondSimple.source + ".Fac65")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac64", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac64
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac64) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac64) l
            let source () = (_BondSimple.source + ".Fac64")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac67", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac67
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac67) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac67) l
            let source () = (_BondSimple.source + ".Fac67")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac66", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac66
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac66) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac66) l
            let source () = (_BondSimple.source + ".Fac66")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac88", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac88
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac88) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac88) l
            let source () = (_BondSimple.source + ".Fac88")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac87", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac87
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac87) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac87) l
            let source () = (_BondSimple.source + ".Fac87")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac89", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac89
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac89) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac89) l
            let source () = (_BondSimple.source + ".Fac89")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac86", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac86
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac86) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac86) l
            let source () = (_BondSimple.source + ".Fac86")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac83", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac83
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac83) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac83) l
            let source () = (_BondSimple.source + ".Fac83")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac82", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac82
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac82) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac82) l
            let source () = (_BondSimple.source + ".Fac82")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac85", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac85
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac85) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac85) l
            let source () = (_BondSimple.source + ".Fac85")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac84", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac84
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac84) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac84) l
            let source () = (_BondSimple.source + ".Fac84")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac37", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac37
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac37) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac37) l
            let source () = (_BondSimple.source + ".Fac37")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac33", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac33
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac33) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac33) l
            let source () = (_BondSimple.source + ".Fac33")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac39", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac39
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac39) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac39) l
            let source () = (_BondSimple.source + ".Fac39")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac38", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac38
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac38) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac38) l
            let source () = (_BondSimple.source + ".Fac38")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac34", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac34
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac34) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac34) l
            let source () = (_BondSimple.source + ".Fac34")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac36", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac36
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac36) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac36) l
            let source () = (_BondSimple.source + ".Fac36")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac61", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac61
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac61) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac61) l
            let source () = (_BondSimple.source + ".Fac61")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac35", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac35
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac35) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac35) l
            let source () = (_BondSimple.source + ".Fac35")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac62", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac62
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac62) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac62) l
            let source () = (_BondSimple.source + ".Fac62")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac30", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac30
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac30) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac30) l
            let source () = (_BondSimple.source + ".Fac30")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac31", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac31
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac31) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac31) l
            let source () = (_BondSimple.source + ".Fac31")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac63", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac63
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac63) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac63) l
            let source () = (_BondSimple.source + ".Fac63")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac32", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac32
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac32) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac32) l
            let source () = (_BondSimple.source + ".Fac32")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac60", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac60
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac60) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac60) l
            let source () = (_BondSimple.source + ".Fac60")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac107", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac107
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac107) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac107) l
            let source () = (_BondSimple.source + ".Fac107")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac117", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac117
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac117) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac117) l
            let source () = (_BondSimple.source + ".Fac117")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac49", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac49
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac49) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac49) l
            let source () = (_BondSimple.source + ".Fac49")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac114", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac114
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac114) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac114) l
            let source () = (_BondSimple.source + ".Fac114")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac48", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac48
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac48) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac48) l
            let source () = (_BondSimple.source + ".Fac48")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac46", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac46
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac46) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac46) l
            let source () = (_BondSimple.source + ".Fac46")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac47", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac47
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac47) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac47) l
            let source () = (_BondSimple.source + ".Fac47")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac101", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac101
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac101) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac101) l
            let source () = (_BondSimple.source + ".Fac101")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac111", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac111
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac111) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac111) l
            let source () = (_BondSimple.source + ".Fac111")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac112", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac112
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac112) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac112) l
            let source () = (_BondSimple.source + ".Fac112")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac104", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac104
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac104) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac104) l
            let source () = (_BondSimple.source + ".Fac104")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac102", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac102
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac102) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac102) l
            let source () = (_BondSimple.source + ".Fac102")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac40", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac40
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac40) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac40) l
            let source () = (_BondSimple.source + ".Fac40")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac42", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac42
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac42) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac42) l
            let source () = (_BondSimple.source + ".Fac42")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac41", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac41
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac41) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac41) l
            let source () = (_BondSimple.source + ".Fac41")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac44", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac44
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac44) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac44) l
            let source () = (_BondSimple.source + ".Fac44")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac45", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac45
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac45) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac45) l
            let source () = (_BondSimple.source + ".Fac45")
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac43", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Fac43
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac43) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac43) l
            let source () = (_BondSimple.source + ".Fac43")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean80", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean80
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean80) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean80) l
            let source () = (_BondSimple.source + ".clean80")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean81", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean81
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean81) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean81) l
            let source () = (_BondSimple.source + ".clean81")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean83", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean83
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean83) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean83) l
            let source () = (_BondSimple.source + ".clean83")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean85", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean85
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean85) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean85) l
            let source () = (_BondSimple.source + ".clean85")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean82", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean82
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean82) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean82) l
            let source () = (_BondSimple.source + ".clean82")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean86", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean86
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean86) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean86) l
            let source () = (_BondSimple.source + ".clean86")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean88", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean88
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean88) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean88) l
            let source () = (_BondSimple.source + ".clean88")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean89", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean89
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean89) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean89) l
            let source () = (_BondSimple.source + ".clean89")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean114", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean114
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean114) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean114) l
            let source () = (_BondSimple.source + ".clean114")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean87", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean87
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean87) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean87) l
            let source () = (_BondSimple.source + ".clean87")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean84", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean84
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean84) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean84) l
            let source () = (_BondSimple.source + ".clean84")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean29", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean29
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean29) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean29) l
            let source () = (_BondSimple.source + ".clean29")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean119", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean119
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean119) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean119) l
            let source () = (_BondSimple.source + ".clean119")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean104", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean104
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean104) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean104) l
            let source () = (_BondSimple.source + ".clean104")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean61", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean61
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean61) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean61) l
            let source () = (_BondSimple.source + ".clean61")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean62", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean62
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean62) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean62) l
            let source () = (_BondSimple.source + ".clean62")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean63", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean63
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean63) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean63) l
            let source () = (_BondSimple.source + ".clean63")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean113", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean113
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean113) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean113) l
            let source () = (_BondSimple.source + ".clean113")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean103", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean103
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean103) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean103) l
            let source () = (_BondSimple.source + ".clean103")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean115", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean115
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean115) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean115) l
            let source () = (_BondSimple.source + ".clean115")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean105", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean105
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean105) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean105) l
            let source () = (_BondSimple.source + ".clean105")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean109", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean109
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean109) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean109) l
            let source () = (_BondSimple.source + ".clean109")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean66", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean66
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean66) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean66) l
            let source () = (_BondSimple.source + ".clean66")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean42", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean42
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean42) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean42) l
            let source () = (_BondSimple.source + ".clean42")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean40", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean40
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean40) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean40) l
            let source () = (_BondSimple.source + ".clean40")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean43", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean43
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean43) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean43) l
            let source () = (_BondSimple.source + ".clean43")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean68", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean68
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean68) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean68) l
            let source () = (_BondSimple.source + ".clean68")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean69", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean69
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean69) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean69) l
            let source () = (_BondSimple.source + ".clean69")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean65", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean65
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean65) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean65) l
            let source () = (_BondSimple.source + ".clean65")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean67", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean67
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean67) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean67) l
            let source () = (_BondSimple.source + ".clean67")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean64", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean64
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean64) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean64) l
            let source () = (_BondSimple.source + ".clean64")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean45", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean45
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean45) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean45) l
            let source () = (_BondSimple.source + ".clean45")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean44", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean44
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean44) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean44) l
            let source () = (_BondSimple.source + ".clean44")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean48", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean48
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean48) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean48) l
            let source () = (_BondSimple.source + ".clean48")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean60", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean60
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean60) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean60) l
            let source () = (_BondSimple.source + ".clean60")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean49", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean49
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean49) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean49) l
            let source () = (_BondSimple.source + ".clean49")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean106", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean106
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean106) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean106) l
            let source () = (_BondSimple.source + ".clean106")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean41", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean41
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean41) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean41) l
            let source () = (_BondSimple.source + ".clean41")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean116", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean116
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean116) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean116) l
            let source () = (_BondSimple.source + ".clean116")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean47", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean47
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean47) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean47) l
            let source () = (_BondSimple.source + ".clean47")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean46", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean46
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean46) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean46) l
            let source () = (_BondSimple.source + ".clean46")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean75", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean75
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean75) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean75) l
            let source () = (_BondSimple.source + ".clean75")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean74", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean74
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean74) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean74) l
            let source () = (_BondSimple.source + ".clean74")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean78", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean78
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean78) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean78) l
            let source () = (_BondSimple.source + ".clean78")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean99", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean99
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean99) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean99) l
            let source () = (_BondSimple.source + ".clean99")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean79", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean79
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean79) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean79) l
            let source () = (_BondSimple.source + ".clean79")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean70", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean70
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean70) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean70) l
            let source () = (_BondSimple.source + ".clean70")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean73", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean73
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean73) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean73) l
            let source () = (_BondSimple.source + ".clean73")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean71", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean71
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean71) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean71) l
            let source () = (_BondSimple.source + ".clean71")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean77", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean77
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean77) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean77) l
            let source () = (_BondSimple.source + ".clean77")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean76", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean76
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean76) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean76) l
            let source () = (_BondSimple.source + ".clean76")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean90", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean90
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean90) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean90) l
            let source () = (_BondSimple.source + ".clean90")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean91", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean91
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean91) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean91) l
            let source () = (_BondSimple.source + ".clean91")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean93", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean93
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean93) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean93) l
            let source () = (_BondSimple.source + ".clean93")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean101", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean101
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean101) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean101) l
            let source () = (_BondSimple.source + ".clean101")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean92", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean92
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean92) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean92) l
            let source () = (_BondSimple.source + ".clean92")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean95", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean95
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean95) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean95) l
            let source () = (_BondSimple.source + ".clean95")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean98", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean98
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean98) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean98) l
            let source () = (_BondSimple.source + ".clean98")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean94", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean94
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean94) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean94) l
            let source () = (_BondSimple.source + ".clean94")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean96", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean96
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean96) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean96) l
            let source () = (_BondSimple.source + ".clean96")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean97", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean97
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean97) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean97) l
            let source () = (_BondSimple.source + ".clean97")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean72", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean72
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean72) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean72) l
            let source () = (_BondSimple.source + ".clean72")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean59", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean59
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean59) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean59) l
            let source () = (_BondSimple.source + ".clean59")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean112", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean112
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean112) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean112) l
            let source () = (_BondSimple.source + ".clean112")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean58", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean58
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean58) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean58) l
            let source () = (_BondSimple.source + ".clean58")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean54", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean54
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean54) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean54) l
            let source () = (_BondSimple.source + ".clean54")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean55", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean55
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean55) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean55) l
            let source () = (_BondSimple.source + ".clean55")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean100", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean100
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean100) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean100) l
            let source () = (_BondSimple.source + ".clean100")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean110", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean110
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean110) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean110) l
            let source () = (_BondSimple.source + ".clean110")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean120", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean120
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean120) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean120) l
            let source () = (_BondSimple.source + ".clean120")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean102", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean102
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean102) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean102) l
            let source () = (_BondSimple.source + ".clean102")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean108", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean108
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean108) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean108) l
            let source () = (_BondSimple.source + ".clean108")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean52", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean52
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean52) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean52) l
            let source () = (_BondSimple.source + ".clean52")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean118", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean118
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean118) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean118) l
            let source () = (_BondSimple.source + ".clean118")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean56", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean56
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean56) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean56) l
            let source () = (_BondSimple.source + ".clean56")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean57", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean57
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean57) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean57) l
            let source () = (_BondSimple.source + ".clean57")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean51", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean51
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean51) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean51) l
            let source () = (_BondSimple.source + ".clean51")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean53", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean53
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean53) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean53) l
            let source () = (_BondSimple.source + ".clean53")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean50", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean50
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean50) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean50) l
            let source () = (_BondSimple.source + ".clean50")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean117", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean117
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean117) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean117) l
            let source () = (_BondSimple.source + ".clean117")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean39", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean39
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean39) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean39) l
            let source () = (_BondSimple.source + ".clean39")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean111", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean111
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean111) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean111) l
            let source () = (_BondSimple.source + ".clean111")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean36", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean36
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean36) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean36) l
            let source () = (_BondSimple.source + ".clean36")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean107", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean107
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean107) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean107) l
            let source () = (_BondSimple.source + ".clean107")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean31", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean31
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean31) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean31) l
            let source () = (_BondSimple.source + ".clean31")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean38", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean38
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean38) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean38) l
            let source () = (_BondSimple.source + ".clean38")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean33", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean33
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean33) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean33) l
            let source () = (_BondSimple.source + ".clean33")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean30", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean30
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean30) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean30) l
            let source () = (_BondSimple.source + ".clean30")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean37", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean37
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean37) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean37) l
            let source () = (_BondSimple.source + ".clean37")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean32", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean32
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean32) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean32) l
            let source () = (_BondSimple.source + ".clean32")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean35", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean35
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean35) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean35) l
            let source () = (_BondSimple.source + ".clean35")
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
                            
    [<ExcelFunction(Name="__BondSimple_clean34", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_clean34
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean34) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean34) l
            let source () = (_BondSimple.source + ".clean34")
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
                            
    [<ExcelFunction(Name="__BondSimple_Clock", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_Clock
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "BondSimple")>] 
         BondSimple : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Clock) :> ICell
            let format (o : System.DateTime) (l:string) = o.Helper.Range.fromModel (i :?> Clock) l
            let source () = (_BondSimple.source + ".Clock")
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
*)
