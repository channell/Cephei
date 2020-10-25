namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type BondSimple 
    (coupons : ICell<System.Collections.Generic.List<System.Double>>
    ,Yield3 : ICell<QLNet.SimpleQuote>
    ,Yield1 : ICell<QLNet.SimpleQuote>
    ,Yield2 : ICell<QLNet.SimpleQuote>
    ,Yield4 : ICell<QLNet.SimpleQuote>) as this =
    inherit Model ()

(* functions *)
    let _calendar = Fun.TARGET () //1
    let _Today = (value DateTime.Today)
    let _clock = Fun.Date1 (triv (fun () ->  int (_Today.Value.ToOADate())))
    let _priceday = _calendar.Adjust _clock (value BusinessDayConvention.Following)
    let _dayCount = Fun.ActualActual1 (value Convention.ISMA) (value (null :> Schedule)
    let _exCoupon = Fun.Period1
    let _settlement = (value 3)
    let _coupons = coupons
    let _FreqS = Fun.Period2 (value Frequency.Semiannual)
    let _FreqA = Fun.Period2 (value Frequency.Annual)
    let _EngineFlatYield1 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield1))) (triv (fun () -> toNullable (True))
    let _EngineFlatYield2 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield2))) (triv (fun () -> toNullable (True))
    let _EngineFlatYield3 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield3))) (triv (fun () -> toNullable (True))
    let _EngineFlatYield4 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield4))) (triv (fun () -> toNullable (True))
    let _Mat1 = _calendar.Advance1 _calendar _priceday (triv (fun () -> Convert.ToInt32(3))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value (False :?> Boolean))
    let _Mat2 = _calendar.Advance1 _calendar _priceday (triv (fun () -> Convert.ToInt32(5))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value (False :?> Boolean))
    let _Mat4 = _calendar.Advance1 _calendar _priceday (triv (fun () -> Convert.ToInt32(15))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value (False :?> Boolean))
    let _Mat5 = _calendar.Advance1 _calendar _priceday (triv (fun () -> Convert.ToInt32(20))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value (False :?> Boolean))
    let _Mat3 = _calendar.Advance1 _calendar _priceday (triv (fun () -> Convert.ToInt32(10))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value (False :?> Boolean))
    let _Mat1FreqS = Fun.Schedule _priceday _Mat1 _FreqS _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat2FreqS = Fun.Schedule _priceday _Mat2 _FreqS _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat5FreqA = Fun.Schedule _priceday _Mat5 _FreqA _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat4FreqA = Fun.Schedule _priceday _Mat4 _FreqA _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat5FreqS = Fun.Schedule _priceday _Mat5 _FreqS _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat1FreqA = Fun.Schedule _priceday _Mat1 _FreqA _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat2FreqA = Fun.Schedule _priceday _Mat2 _FreqA _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat3FreqS = Fun.Schedule _priceday _Mat3 _FreqS _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat4FreqS = Fun.Schedule _priceday _Mat4 _FreqS _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Mat3FreqA = Fun.Schedule _priceday _Mat3 _FreqA _calendar (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value Rule.Backward) (value (False :?> Boolean)) (value (null :> Date) (value (null :> Date)
    let _Fac1 = (value 1000)
    let _Fac2 = (value 200)
    let _Fac116 = (value 100)
    let _Fac88 = (value 100)
    let _Fac27 = (value 100)
    let _Fac117 = (value 100)
    let _Fac24 = (value 100)
    let _Fac25 = (value 100)
    let _Fac26 = (value 100)
    let _Fac76 = (value 100)
    let _Fac77 = (value 100)
    let _Fac78 = (value 100)
    let _Fac28 = (value 100)
    let _Fac106 = (value 100)
    let _Fac7 = (value 100)
    let _Fac75 = (value 100)
    let _Fac71 = (value 100)
    let _Fac48 = (value 100)
    let _Fac22 = (value 100)
    let _Fac108 = (value 100)
    let _Fac70 = (value 100)
    let _Fac20 = (value 100)
    let _Fac21 = (value 100)
    let _Fac23 = (value 100)
    let _Fac107 = (value 100)
    let _Fac74 = (value 100)
    let _Fac49 = (value 100)
    let _Fac72 = (value 100)
    let _Fac79 = (value 100)
    let _Fac73 = (value 100)
    let _Fac39 = (value 100)
    let _Fac14 = (value 100)
    let _Fac101 = (value 100)
    let _Fac13 = (value 100)
    let _Fac11 = (value 100)
    let _Fac12 = (value 100)
    let _Fac15 = (value 100)
    let _Fac103 = (value 100)
    let _Fac18 = (value 100)
    let _Fac17 = (value 100)
    let _Fac111 = (value 100)
    let _Fac16 = (value 100)
    let _Fac95 = (value 100)
    let _Fac96 = (value 100)
    let _Fac119 = (value 100)
    let _Fac94 = (value 100)
    let _Fac109 = (value 100)
    let _Fac97 = (value 100)
    let _Fac91 = (value 100)
    let _Fac10 = (value 100)
    let _Fac92 = (value 100)
    let _Fac98 = (value 100)
    let _Fac99 = (value 100)
    let _Fac84 = (value 100)
    let _Fac85 = (value 100)
    let _Fac83 = (value 100)
    let _Fac81 = (value 100)
    let _Fac82 = (value 100)
    let _Fac86 = (value 100)
    let _Fac38 = (value 100)
    let _Fac29 = (value 100)
    let _Fac89 = (value 100)
    let _Fac87 = (value 100)
    let _Fac93 = (value 100)
    let _Fac33 = (value 100)
    let _Fac32 = (value 100)
    let _Fac113 = (value 100)
    let _Fac34 = (value 100)
    let _Fac19 = (value 100)
    let _Fac35 = (value 100)
    let _Fac30 = (value 100)
    let _Fac80 = (value 100)
    let _Fac37 = (value 100)
    let _Fac31 = (value 100)
    let _Fac36 = (value 100)
    let _Fac51 = (value 100)
    let _Fac50 = (value 100)
    let _Fac60 = (value 100)
    let _Fac54 = (value 100)
    let _Fac53 = (value 100)
    let _Fac52 = (value 100)
    let _Fac41 = (value 100)
    let _Fac63 = (value 100)
    let _Fac104 = (value 100)
    let _Fac61 = (value 100)
    let _Fac62 = (value 100)
    let _Fac40 = (value 100)
    let _Fac105 = (value 100)
    let _Fac59 = (value 100)
    let _Fac9 = (value 100)
    let _Fac4 = (value 100)
    let _Fac112 = (value 100)
    let _Fac102 = (value 100)
    let _Fac3 = (value 100)
    let _Fac56 = (value 100)
    let _Fac55 = (value 100)
    let _Fac115 = (value 100)
    let _Fac8 = (value 100)
    let _Fac58 = (value 100)
    let _Fac57 = (value 100)
    let _Fac120 = (value 100)
    let _Fac44 = (value 100)
    let _Fac90 = (value 100)
    let _Fac100 = (value 100)
    let _Fac110 = (value 100)
    let _Fac46 = (value 100)
    let _Fac47 = (value 100)
    let _Fac6 = (value 100)
    let _Fac118 = (value 100)
    let _Fac45 = (value 100)
    let _Fac69 = (value 100)
    let _Fac64 = (value 100)
    let _Fac114 = (value 100)
    let _Fac66 = (value 100)
    let _Fac65 = (value 100)
    let _Fac5 = (value 100)
    let _Fac67 = (value 100)
    let _Fac68 = (value 100)
    let _Fac43 = (value 100)
    let _Fac42 = (value 100)
    let _Bond43 = Fun.FixedRateBond _settlement _Fac43 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac43 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond64 = Fun.FixedRateBond _settlement _Fac64 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac64 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond74 = Fun.FixedRateBond _settlement _Fac74 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac74 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond76 = Fun.FixedRateBond _settlement _Fac76 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac76 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond75 = Fun.FixedRateBond _settlement _Fac75 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac75 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond77 = Fun.FixedRateBond _settlement _Fac77 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac77 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond79 = Fun.FixedRateBond _settlement _Fac79 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac79 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond78 = Fun.FixedRateBond _settlement _Fac78 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac78 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond70 = Fun.FixedRateBond _settlement _Fac70 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac70 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond99 = Fun.FixedRateBond _settlement _Fac99 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac99 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond9 = Fun.FixedRateBond _settlement _Fac9 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac9 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond106 = Fun.FixedRateBond _settlement _Fac106 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac106 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond94 = Fun.FixedRateBond _settlement _Fac94 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac94 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond98 = Fun.FixedRateBond _settlement _Fac98 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac98 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond107 = Fun.FixedRateBond _settlement _Fac107 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac107 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond117 = Fun.FixedRateBond _settlement _Fac117 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac117 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond1 = Fun.FixedRateBond _settlement _Fac1 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac1 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond8 = Fun.FixedRateBond _settlement _Fac8 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac8 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond95 = Fun.FixedRateBond _settlement _Fac95 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac95 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond92 = Fun.FixedRateBond _settlement _Fac92 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac92 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond6 = Fun.FixedRateBond _settlement _Fac6 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac6 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond108 = Fun.FixedRateBond _settlement _Fac108 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac108 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond93 = Fun.FixedRateBond _settlement _Fac93 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac93 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond91 = Fun.FixedRateBond _settlement _Fac91 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac91 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond116 = Fun.FixedRateBond _settlement _Fac116 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac116 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond96 = Fun.FixedRateBond _settlement _Fac96 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac96 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond90 = Fun.FixedRateBond _settlement _Fac90 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac90 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond97 = Fun.FixedRateBond _settlement _Fac97 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac97 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond41 = Fun.FixedRateBond _settlement _Fac41 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac41 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond42 = Fun.FixedRateBond _settlement _Fac42 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac42 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond68 = Fun.FixedRateBond _settlement _Fac68 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac68 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond69 = Fun.FixedRateBond _settlement _Fac69 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac69 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond7 = Fun.FixedRateBond _settlement _Fac7 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac7 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond72 = Fun.FixedRateBond _settlement _Fac72 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac72 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond71 = Fun.FixedRateBond _settlement _Fac71 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac71 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond118 = Fun.FixedRateBond _settlement _Fac118 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac118 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond73 = Fun.FixedRateBond _settlement _Fac73 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac73 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond120 = Fun.FixedRateBond _settlement _Fac120 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac120 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond44 = Fun.FixedRateBond _settlement _Fac44 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac44 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond45 = Fun.FixedRateBond _settlement _Fac45 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac45 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond48 = Fun.FixedRateBond _settlement _Fac48 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac48 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond49 = Fun.FixedRateBond _settlement _Fac49 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac49 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond100 = Fun.FixedRateBond _settlement _Fac100 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac100 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond47 = Fun.FixedRateBond _settlement _Fac47 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac47 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond40 = Fun.FixedRateBond _settlement _Fac40 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac40 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond46 = Fun.FixedRateBond _settlement _Fac46 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac46 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond110 = Fun.FixedRateBond _settlement _Fac110 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac110 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond17 = Fun.FixedRateBond _settlement _Fac17 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac17 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond10 = Fun.FixedRateBond _settlement _Fac10 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac10 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond15 = Fun.FixedRateBond _settlement _Fac15 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac15 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond16 = Fun.FixedRateBond _settlement _Fac16 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac16 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond5 = Fun.FixedRateBond _settlement _Fac5 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac5 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond13 = Fun.FixedRateBond _settlement _Fac13 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac13 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond113 = Fun.FixedRateBond _settlement _Fac113 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac113 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond11 = Fun.FixedRateBond _settlement _Fac11 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac11 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond12 = Fun.FixedRateBond _settlement _Fac12 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac12 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond30 = Fun.FixedRateBond _settlement _Fac30 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac30 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond37 = Fun.FixedRateBond _settlement _Fac37 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac37 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond32 = Fun.FixedRateBond _settlement _Fac32 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac32 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond31 = Fun.FixedRateBond _settlement _Fac31 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac31 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond36 = Fun.FixedRateBond _settlement _Fac36 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac36 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond39 = Fun.FixedRateBond _settlement _Fac39 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac39 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond38 = Fun.FixedRateBond _settlement _Fac38 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac38 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond35 = Fun.FixedRateBond _settlement _Fac35 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac35 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond34 = Fun.FixedRateBond _settlement _Fac34 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac34 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond103 = Fun.FixedRateBond _settlement _Fac103 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac103 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond2 = Fun.FixedRateBond _settlement _Fac2 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac2 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond119 = Fun.FixedRateBond _settlement _Fac119 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac119 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond83 = Fun.FixedRateBond _settlement _Fac83 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac83 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond109 = Fun.FixedRateBond _settlement _Fac109 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac109 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond112 = Fun.FixedRateBond _settlement _Fac112 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac112 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond3 = Fun.FixedRateBond _settlement _Fac3 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac3 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond111 = Fun.FixedRateBond _settlement _Fac111 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac111 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond102 = Fun.FixedRateBond _settlement _Fac102 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac102 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond101 = Fun.FixedRateBond _settlement _Fac101 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac101 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond84 = Fun.FixedRateBond _settlement _Fac84 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac84 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond85 = Fun.FixedRateBond _settlement _Fac85 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac85 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond88 = Fun.FixedRateBond _settlement _Fac88 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac88 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond89 = Fun.FixedRateBond _settlement _Fac89 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac89 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond86 = Fun.FixedRateBond _settlement _Fac86 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac86 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond81 = Fun.FixedRateBond _settlement _Fac81 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac81 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond82 = Fun.FixedRateBond _settlement _Fac82 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac82 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond87 = Fun.FixedRateBond _settlement _Fac87 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac87 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond80 = Fun.FixedRateBond _settlement _Fac80 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac80 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond33 = Fun.FixedRateBond _settlement _Fac33 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac33 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond105 = Fun.FixedRateBond _settlement _Fac105 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac105 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond56 = Fun.FixedRateBond _settlement _Fac56 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac56 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond51 = Fun.FixedRateBond _settlement _Fac51 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac51 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond50 = Fun.FixedRateBond _settlement _Fac50 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac50 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond115 = Fun.FixedRateBond _settlement _Fac115 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac115 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond59 = Fun.FixedRateBond _settlement _Fac59 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac59 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond4 = Fun.FixedRateBond _settlement _Fac4 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac4 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond55 = Fun.FixedRateBond _settlement _Fac55 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac55 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond54 = Fun.FixedRateBond _settlement _Fac54 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac54 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond60 = Fun.FixedRateBond _settlement _Fac60 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac60 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond61 = Fun.FixedRateBond _settlement _Fac61 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac61 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond66 = Fun.FixedRateBond _settlement _Fac66 _Mat1FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac66 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond67 = Fun.FixedRateBond _settlement _Fac67 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac67 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond65 = Fun.FixedRateBond _settlement _Fac65 _Mat5FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac65 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond53 = Fun.FixedRateBond _settlement _Fac53 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac53 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond52 = Fun.FixedRateBond _settlement _Fac52 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac52 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond114 = Fun.FixedRateBond _settlement _Fac114 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac114 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond104 = Fun.FixedRateBond _settlement _Fac104 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac104 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield4 _priceday
    let _Bond26 = Fun.FixedRateBond _settlement _Fac26 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac26 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond25 = Fun.FixedRateBond _settlement _Fac25 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac25 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond20 = Fun.FixedRateBond _settlement _Fac20 _Mat5FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac20 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond57 = Fun.FixedRateBond _settlement _Fac57 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac57 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond24 = Fun.FixedRateBond _settlement _Fac24 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac24 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond19 = Fun.FixedRateBond _settlement _Fac19 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac19 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond14 = Fun.FixedRateBond _settlement _Fac14 _Mat4FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac14 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond29 = Fun.FixedRateBond _settlement _Fac29 _Mat4FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac29 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond28 = Fun.FixedRateBond _settlement _Fac28 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac28 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond63 = Fun.FixedRateBond _settlement _Fac63 _Mat3FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac63 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond27 = Fun.FixedRateBond _settlement _Fac27 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac27 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond58 = Fun.FixedRateBond _settlement _Fac58 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac58 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield2 _priceday
    let _Bond62 = Fun.FixedRateBond _settlement _Fac62 _Mat2FreqS _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac62 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield3 _priceday
    let _Bond22 = Fun.FixedRateBond _settlement _Fac22 _Mat2FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac22 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond21 = Fun.FixedRateBond _settlement _Fac21 _Mat1FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac21 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond18 = Fun.FixedRateBond _settlement _Fac18 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac18 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Bond23 = Fun.FixedRateBond _settlement _Fac23 _Mat3FreqA _coupons _dayCount (value BusinessDayConvention.ModifiedFollowing) _Fac23 _priceday _calendar _exCoupon _calendar (value BusinessDayConvention.Following) (value (False :?> Boolean)) _EngineFlatYield1 _priceday
    let _Yield3 = Yield3
    let _Yield1 = Yield1
    let _Yield2 = Yield2
    let _Yield4 = Yield4
    let _FlatYield3 = Fun.FlatForward _priceday _Yield3 _dayCount
    let _clean62 = -Bond62.CleanPrice _Bond62
    let _clean63 = -Bond63.CleanPrice _Bond63
    let _clean2 = -Bond2.CleanPrice _Bond2
    let _clean60 = -Bond60.CleanPrice _Bond60
    let _clean112 = -Bond112.CleanPrice _Bond112
    let _clean102 = -Bond102.CleanPrice _Bond102
    let _FlatYield2 = Fun.FlatForward _priceday _Yield2 _dayCount
    let _FlatYield1 = Fun.FlatForward _priceday _Yield1 _dayCount
    let _clean105 = -Bond105.CleanPrice _Bond105
    let _clean115 = -Bond115.CleanPrice _Bond115
    let _clean104 = -Bond104.CleanPrice _Bond104
    let _clean99 = -Bond99.CleanPrice _Bond99
    let _clean98 = -Bond98.CleanPrice _Bond98
    let _clean114 = -Bond114.CleanPrice _Bond114
    let _clean10 = -Bond10.CleanPrice _Bond10
    let _clean13 = -Bond13.CleanPrice _Bond13
    let _clean12 = -Bond12.CleanPrice _Bond12
    let _clean91 = -Bond91.CleanPrice _Bond91
    let _clean90 = -Bond90.CleanPrice _Bond90
    let _clean93 = -Bond93.CleanPrice _Bond93
    let _clean96 = -Bond96.CleanPrice _Bond96
    let _clean95 = -Bond95.CleanPrice _Bond95
    let _clean94 = -Bond94.CleanPrice _Bond94
    let _clean97 = -Bond97.CleanPrice _Bond97
    let _clean117 = -Bond117.CleanPrice _Bond117
    let _clean107 = -Bond107.CleanPrice _Bond107
    let _clean19 = -Bond19.CleanPrice _Bond19
    let _clean5 = -Bond5.CleanPrice _Bond5
    let _FlatYield4 = Fun.FlatForward _priceday _Yield4 _dayCount
    let _clean119 = -Bond119.CleanPrice _Bond119
    let _clean109 = -Bond109.CleanPrice _Bond109
    let _clean17 = -Bond17.CleanPrice _Bond17
    let _clean16 = -Bond16.CleanPrice _Bond16
    let _clean11 = -Bond11.CleanPrice _Bond11
    let _clean14 = -Bond14.CleanPrice _Bond14
    let _clean4 = -Bond4.CleanPrice _Bond4
    let _clean18 = -Bond18.CleanPrice _Bond18
    let _clean15 = -Bond15.CleanPrice _Bond15
    let _clean81 = -Bond81.CleanPrice _Bond81
    let _clean80 = -Bond80.CleanPrice _Bond80
    let _clean83 = -Bond83.CleanPrice _Bond83
    let _clean86 = -Bond86.CleanPrice _Bond86
    let _clean85 = -Bond85.CleanPrice _Bond85
    let _clean84 = -Bond84.CleanPrice _Bond84
    let _clean87 = -Bond87.CleanPrice _Bond87
    let _clean64 = -Bond64.CleanPrice _Bond64
    let _clean67 = -Bond67.CleanPrice _Bond67
    let _clean66 = -Bond66.CleanPrice _Bond66
    let _clean65 = -Bond65.CleanPrice _Bond65
    let _clean82 = -Bond82.CleanPrice _Bond82
    let _clean69 = -Bond69.CleanPrice _Bond69
    let _clean68 = -Bond68.CleanPrice _Bond68
    let _clean75 = -Bond75.CleanPrice _Bond75
    let _clean74 = -Bond74.CleanPrice _Bond74
    let _clean77 = -Bond77.CleanPrice _Bond77
    let _clean78 = -Bond78.CleanPrice _Bond78
    let _clean92 = -Bond92.CleanPrice _Bond92
    let _clean3 = -Bond3.CleanPrice _Bond3
    let _clean79 = -Bond79.CleanPrice _Bond79
    let _clean72 = -Bond72.CleanPrice _Bond72
    let _clean89 = -Bond89.CleanPrice _Bond89
    let _clean88 = -Bond88.CleanPrice _Bond88
    let _clean73 = -Bond73.CleanPrice _Bond73
    let _clean76 = -Bond76.CleanPrice _Bond76
    let _clean71 = -Bond71.CleanPrice _Bond71
    let _clean70 = -Bond70.CleanPrice _Bond70
    let _clean106 = -Bond106.CleanPrice _Bond106
    let _clean100 = -Bond100.CleanPrice _Bond100
    let _clean45 = -Bond45.CleanPrice _Bond45
    let _clean44 = -Bond44.CleanPrice _Bond44
    let _clean110 = -Bond110.CleanPrice _Bond110
    let _clean49 = -Bond49.CleanPrice _Bond49
    let _clean7 = -Bond7.CleanPrice _Bond7
    let _clean48 = -Bond48.CleanPrice _Bond48
    let _clean40 = -Bond40.CleanPrice _Bond40
    let _clean43 = -Bond43.CleanPrice _Bond43
    let _clean42 = -Bond42.CleanPrice _Bond42
    let _clean41 = -Bond41.CleanPrice _Bond41
    let _clean47 = -Bond47.CleanPrice _Bond47
    let _clean120 = -Bond120.CleanPrice _Bond120
    let _clean46 = -Bond46.CleanPrice _Bond46
    let _clean55 = -Bond55.CleanPrice _Bond55
    let _clean103 = -Bond103.CleanPrice _Bond103
    let _clean54 = -Bond54.CleanPrice _Bond54
    let _clean113 = -Bond113.CleanPrice _Bond113
    let _clean1 = -Bond1.CleanPrice _Bond1
    let _clean59 = -Bond59.CleanPrice _Bond59
    let _clean58 = -Bond58.CleanPrice _Bond58
    let _clean53 = -Bond53.CleanPrice _Bond53
    let _clean52 = -Bond52.CleanPrice _Bond52
    let _clean9 = -Bond9.CleanPrice _Bond9
    let _clean50 = -Bond50.CleanPrice _Bond50
    let _clean57 = -Bond57.CleanPrice _Bond57
    let _clean56 = -Bond56.CleanPrice _Bond56
    let _clean51 = -Bond51.CleanPrice _Bond51
    let _clean26 = -Bond26.CleanPrice _Bond26
    let _clean21 = -Bond21.CleanPrice _Bond21
    let _clean20 = -Bond20.CleanPrice _Bond20
    let _clean27 = -Bond27.CleanPrice _Bond27
    let _clean28 = -Bond28.CleanPrice _Bond28
    let _clean25 = -Bond25.CleanPrice _Bond25
    let _clean24 = -Bond24.CleanPrice _Bond24
    let _clean111 = -Bond111.CleanPrice _Bond111
    let _clean101 = -Bond101.CleanPrice _Bond101
    let _clean116 = -Bond116.CleanPrice _Bond116
    let _clean108 = -Bond108.CleanPrice _Bond108
    let _clean23 = -Bond23.CleanPrice _Bond23
    let _clean22 = -Bond22.CleanPrice _Bond22
    let _clean118 = -Bond118.CleanPrice _Bond118
    let _clean35 = -Bond35.CleanPrice _Bond35
    let _clean34 = -Bond34.CleanPrice _Bond34
    let _clean37 = -Bond37.CleanPrice _Bond37
    let _clean6 = -Bond6.CleanPrice _Bond6
    let _clean8 = -Bond8.CleanPrice _Bond8
    let _clean39 = -Bond39.CleanPrice _Bond39
    let _clean38 = -Bond38.CleanPrice _Bond38
    let _clean32 = -Bond32.CleanPrice _Bond32
    let _clean61 = -Bond61.CleanPrice _Bond61
    let _clean29 = -Bond29.CleanPrice _Bond29
    let _clean33 = -Bond33.CleanPrice _Bond33
    let _clean36 = -Bond36.CleanPrice _Bond36
    let _clean31 = -Bond31.CleanPrice _Bond31
    let _clean30 = -Bond30.CleanPrice _Bond30

    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.Today = _Today
    member this.clock = _clock
    member this.priceday = _priceday
    member this.dayCount = _dayCount
    member this.exCoupon = _exCoupon
    member this.settlement = _settlement
    member this.coupons = _coupons
    member this.FreqS = _FreqS
    member this.FreqA = _FreqA
    member this.EngineFlatYield1 = _EngineFlatYield1
    member this.EngineFlatYield2 = _EngineFlatYield2
    member this.EngineFlatYield3 = _EngineFlatYield3
    member this.EngineFlatYield4 = _EngineFlatYield4
    member this.Mat1 = _Mat1
    member this.Mat2 = _Mat2
    member this.Mat4 = _Mat4
    member this.Mat5 = _Mat5
    member this.Mat3 = _Mat3
    member this.Mat1FreqS = _Mat1FreqS
    member this.Mat2FreqS = _Mat2FreqS
    member this.Mat5FreqA = _Mat5FreqA
    member this.Mat4FreqA = _Mat4FreqA
    member this.Mat5FreqS = _Mat5FreqS
    member this.Mat1FreqA = _Mat1FreqA
    member this.Mat2FreqA = _Mat2FreqA
    member this.Mat3FreqS = _Mat3FreqS
    member this.Mat4FreqS = _Mat4FreqS
    member this.Mat3FreqA = _Mat3FreqA
    member this.Fac1 = _Fac1
    member this.Fac2 = _Fac2
    member this.Fac116 = _Fac116
    member this.Fac88 = _Fac88
    member this.Fac27 = _Fac27
    member this.Fac117 = _Fac117
    member this.Fac24 = _Fac24
    member this.Fac25 = _Fac25
    member this.Fac26 = _Fac26
    member this.Fac76 = _Fac76
    member this.Fac77 = _Fac77
    member this.Fac78 = _Fac78
    member this.Fac28 = _Fac28
    member this.Fac106 = _Fac106
    member this.Fac7 = _Fac7
    member this.Fac75 = _Fac75
    member this.Fac71 = _Fac71
    member this.Fac48 = _Fac48
    member this.Fac22 = _Fac22
    member this.Fac108 = _Fac108
    member this.Fac70 = _Fac70
    member this.Fac20 = _Fac20
    member this.Fac21 = _Fac21
    member this.Fac23 = _Fac23
    member this.Fac107 = _Fac107
    member this.Fac74 = _Fac74
    member this.Fac49 = _Fac49
    member this.Fac72 = _Fac72
    member this.Fac79 = _Fac79
    member this.Fac73 = _Fac73
    member this.Fac39 = _Fac39
    member this.Fac14 = _Fac14
    member this.Fac101 = _Fac101
    member this.Fac13 = _Fac13
    member this.Fac11 = _Fac11
    member this.Fac12 = _Fac12
    member this.Fac15 = _Fac15
    member this.Fac103 = _Fac103
    member this.Fac18 = _Fac18
    member this.Fac17 = _Fac17
    member this.Fac111 = _Fac111
    member this.Fac16 = _Fac16
    member this.Fac95 = _Fac95
    member this.Fac96 = _Fac96
    member this.Fac119 = _Fac119
    member this.Fac94 = _Fac94
    member this.Fac109 = _Fac109
    member this.Fac97 = _Fac97
    member this.Fac91 = _Fac91
    member this.Fac10 = _Fac10
    member this.Fac92 = _Fac92
    member this.Fac98 = _Fac98
    member this.Fac99 = _Fac99
    member this.Fac84 = _Fac84
    member this.Fac85 = _Fac85
    member this.Fac83 = _Fac83
    member this.Fac81 = _Fac81
    member this.Fac82 = _Fac82
    member this.Fac86 = _Fac86
    member this.Fac38 = _Fac38
    member this.Fac29 = _Fac29
    member this.Fac89 = _Fac89
    member this.Fac87 = _Fac87
    member this.Fac93 = _Fac93
    member this.Fac33 = _Fac33
    member this.Fac32 = _Fac32
    member this.Fac113 = _Fac113
    member this.Fac34 = _Fac34
    member this.Fac19 = _Fac19
    member this.Fac35 = _Fac35
    member this.Fac30 = _Fac30
    member this.Fac80 = _Fac80
    member this.Fac37 = _Fac37
    member this.Fac31 = _Fac31
    member this.Fac36 = _Fac36
    member this.Fac51 = _Fac51
    member this.Fac50 = _Fac50
    member this.Fac60 = _Fac60
    member this.Fac54 = _Fac54
    member this.Fac53 = _Fac53
    member this.Fac52 = _Fac52
    member this.Fac41 = _Fac41
    member this.Fac63 = _Fac63
    member this.Fac104 = _Fac104
    member this.Fac61 = _Fac61
    member this.Fac62 = _Fac62
    member this.Fac40 = _Fac40
    member this.Fac105 = _Fac105
    member this.Fac59 = _Fac59
    member this.Fac9 = _Fac9
    member this.Fac4 = _Fac4
    member this.Fac112 = _Fac112
    member this.Fac102 = _Fac102
    member this.Fac3 = _Fac3
    member this.Fac56 = _Fac56
    member this.Fac55 = _Fac55
    member this.Fac115 = _Fac115
    member this.Fac8 = _Fac8
    member this.Fac58 = _Fac58
    member this.Fac57 = _Fac57
    member this.Fac120 = _Fac120
    member this.Fac44 = _Fac44
    member this.Fac90 = _Fac90
    member this.Fac100 = _Fac100
    member this.Fac110 = _Fac110
    member this.Fac46 = _Fac46
    member this.Fac47 = _Fac47
    member this.Fac6 = _Fac6
    member this.Fac118 = _Fac118
    member this.Fac45 = _Fac45
    member this.Fac69 = _Fac69
    member this.Fac64 = _Fac64
    member this.Fac114 = _Fac114
    member this.Fac66 = _Fac66
    member this.Fac65 = _Fac65
    member this.Fac5 = _Fac5
    member this.Fac67 = _Fac67
    member this.Fac68 = _Fac68
    member this.Fac43 = _Fac43
    member this.Fac42 = _Fac42
    member this.Yield3 = _Yield3
    member this.Yield1 = _Yield1
    member this.Yield2 = _Yield2
    member this.Yield4 = _Yield4
    member this.FlatYield3 = _FlatYield3
    member this.clean62 = _clean62
    member this.clean63 = _clean63
    member this.clean2 = _clean2
    member this.clean60 = _clean60
    member this.clean112 = _clean112
    member this.clean102 = _clean102
    member this.FlatYield2 = _FlatYield2
    member this.FlatYield1 = _FlatYield1
    member this.clean105 = _clean105
    member this.clean115 = _clean115
    member this.clean104 = _clean104
    member this.clean99 = _clean99
    member this.clean98 = _clean98
    member this.clean114 = _clean114
    member this.clean10 = _clean10
    member this.clean13 = _clean13
    member this.clean12 = _clean12
    member this.clean91 = _clean91
    member this.clean90 = _clean90
    member this.clean93 = _clean93
    member this.clean96 = _clean96
    member this.clean95 = _clean95
    member this.clean94 = _clean94
    member this.clean97 = _clean97
    member this.clean117 = _clean117
    member this.clean107 = _clean107
    member this.clean19 = _clean19
    member this.clean5 = _clean5
    member this.FlatYield4 = _FlatYield4
    member this.clean119 = _clean119
    member this.clean109 = _clean109
    member this.clean17 = _clean17
    member this.clean16 = _clean16
    member this.clean11 = _clean11
    member this.clean14 = _clean14
    member this.clean4 = _clean4
    member this.clean18 = _clean18
    member this.clean15 = _clean15
    member this.clean81 = _clean81
    member this.clean80 = _clean80
    member this.clean83 = _clean83
    member this.clean86 = _clean86
    member this.clean85 = _clean85
    member this.clean84 = _clean84
    member this.clean87 = _clean87
    member this.clean64 = _clean64
    member this.clean67 = _clean67
    member this.clean66 = _clean66
    member this.clean65 = _clean65
    member this.clean82 = _clean82
    member this.clean69 = _clean69
    member this.clean68 = _clean68
    member this.clean75 = _clean75
    member this.clean74 = _clean74
    member this.clean77 = _clean77
    member this.clean78 = _clean78
    member this.clean92 = _clean92
    member this.clean3 = _clean3
    member this.clean79 = _clean79
    member this.clean72 = _clean72
    member this.clean89 = _clean89
    member this.clean88 = _clean88
    member this.clean73 = _clean73
    member this.clean76 = _clean76
    member this.clean71 = _clean71
    member this.clean70 = _clean70
    member this.clean106 = _clean106
    member this.clean100 = _clean100
    member this.clean45 = _clean45
    member this.clean44 = _clean44
    member this.clean110 = _clean110
    member this.clean49 = _clean49
    member this.clean7 = _clean7
    member this.clean48 = _clean48
    member this.clean40 = _clean40
    member this.clean43 = _clean43
    member this.clean42 = _clean42
    member this.clean41 = _clean41
    member this.clean47 = _clean47
    member this.clean120 = _clean120
    member this.clean46 = _clean46
    member this.clean55 = _clean55
    member this.clean103 = _clean103
    member this.clean54 = _clean54
    member this.clean113 = _clean113
    member this.clean1 = _clean1
    member this.clean59 = _clean59
    member this.clean58 = _clean58
    member this.clean53 = _clean53
    member this.clean52 = _clean52
    member this.clean9 = _clean9
    member this.clean50 = _clean50
    member this.clean57 = _clean57
    member this.clean56 = _clean56
    member this.clean51 = _clean51
    member this.clean26 = _clean26
    member this.clean21 = _clean21
    member this.clean20 = _clean20
    member this.clean27 = _clean27
    member this.clean28 = _clean28
    member this.clean25 = _clean25
    member this.clean24 = _clean24
    member this.clean111 = _clean111
    member this.clean101 = _clean101
    member this.clean116 = _clean116
    member this.clean108 = _clean108
    member this.clean23 = _clean23
    member this.clean22 = _clean22
    member this.clean118 = _clean118
    member this.clean35 = _clean35
    member this.clean34 = _clean34
    member this.clean37 = _clean37
    member this.clean6 = _clean6
    member this.clean8 = _clean8
    member this.clean39 = _clean39
    member this.clean38 = _clean38
    member this.clean32 = _clean32
    member this.clean61 = _clean61
    member this.clean29 = _clean29
    member this.clean33 = _clean33
    member this.clean36 = _clean36
    member this.clean31 = _clean31
    member this.clean30 = _clean30


#if EXCEL
module BondSimpleFunction =

    [<ExcelFunction(Name="__BondSimple", Description="Create a BondSimple",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__coupons",Description = "reference to coupons")>]
        coupons : obj)
        ([<ExcelArgument(Name="__Yield3",Description = "reference to Yield3")>]
        Yield3 : obj)
        ([<ExcelArgument(Name="__Yield1",Description = "reference to Yield1")>]
        Yield1 : obj)
        ([<ExcelArgument(Name="__Yield2",Description = "reference to Yield2")>]
        Yield2 : obj)
        ([<ExcelArgument(Name="__Yield4",Description = "reference to Yield4")>]
        Yield4 : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _coupons = Helper.toCell<System.Collections.Generic.List<System.Double>> coupons "coupons"
                let _Yield3 = Helper.toCell<QLNet.SimpleQuote> Yield3 "Yield3"
                let _Yield1 = Helper.toCell<QLNet.SimpleQuote> Yield1 "Yield1"
                let _Yield2 = Helper.toCell<QLNet.SimpleQuote> Yield2 "Yield2"
                let _Yield4 = Helper.toCell<QLNet.SimpleQuote> Yield4 "Yield4"

                let builder (current : ICell) = withMnemonic mnemonic (new BondSimple
                                                            _coupons.cell
                                                            _Yield3.cell
                                                            _Yield1.cell
                                                            _Yield2.cell
                                                            _Yield4.cell

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> BondSimple) l
                let source () = Helper.sourceFold "new BondSimple"
                                               [| _coupons.source
                                               ;  _Yield3.source
                                               ;  _Yield1.source
                                               ;  _Yield2.source
                                               ;  _Yield4.source
                                               |]

                let hash = Helper.hashFold
                                [| _coupons.cell
                                ;  _Yield3.cell
                                ;  _Yield1.cell
                                ;  _Yield2.cell
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

    [<ExcelFunction(Name="__BondSimple_calendar", Description="Create a QLNet.TARGET",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         _calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).calendar) :> ICell
            let format (o : QLNet.TARGET) (l:string) = o.Helper.Range.fromModel (i :?> _calendar) l
            let source () = (_BondSimple.source + ".calendar")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Today", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Today : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clock : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_priceday", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         priceday : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).priceday) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> priceday) l
            let source () = (_BondSimple.source + ".priceday")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_dayCount", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         dayCount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).dayCount) :> ICell
            let format (o : QLNet.ActualActual) (l:string) = o.Helper.Range.fromModel (i :?> dayCount) l
            let source () = (_BondSimple.source + ".dayCount")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_exCoupon", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         exCoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).exCoupon) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> exCoupon) l
            let source () = (_BondSimple.source + ".exCoupon")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_settlement", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).settlement) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> settlement) l
            let source () = (_BondSimple.source + ".settlement")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_+coupons", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +coupons : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+coupons) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> +coupons) l
            let source () = (_BondSimple.source + ".+coupons")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FreqS : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FreqA : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield1", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield1) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield1) l
            let source () = (_BondSimple.source + ".EngineFlatYield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield2", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield2) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield2) l
            let source () = (_BondSimple.source + ".EngineFlatYield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield3", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield3) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield3) l
            let source () = (_BondSimple.source + ".EngineFlatYield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield4", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield4) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield4) l
            let source () = (_BondSimple.source + ".EngineFlatYield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat1", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat1) l
            let source () = (_BondSimple.source + ".Mat1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat2", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat2) l
            let source () = (_BondSimple.source + ".Mat2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat4", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat4) l
            let source () = (_BondSimple.source + ".Mat4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat5", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat5) l
            let source () = (_BondSimple.source + ".Mat5")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat3", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat3) l
            let source () = (_BondSimple.source + ".Mat3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat1FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat1FreqS) l
            let source () = (_BondSimple.source + ".Mat1FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat2FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat2FreqS) l
            let source () = (_BondSimple.source + ".Mat2FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat5FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat5FreqA) l
            let source () = (_BondSimple.source + ".Mat5FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat4FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat4FreqA) l
            let source () = (_BondSimple.source + ".Mat4FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat5FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat5FreqS) l
            let source () = (_BondSimple.source + ".Mat5FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat1FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat1FreqA) l
            let source () = (_BondSimple.source + ".Mat1FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat2FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat2FreqA) l
            let source () = (_BondSimple.source + ".Mat2FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat3FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat3FreqS) l
            let source () = (_BondSimple.source + ".Mat3FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat4FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat4FreqS) l
            let source () = (_BondSimple.source + ".Mat4FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_Mat3FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat3FreqA) l
            let source () = (_BondSimple.source + ".Mat3FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac1 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac2 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac116", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac116 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac88", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac88 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac27", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac27 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac117", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac117 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac24", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac24 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac25 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac26 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac76", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac76 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac77", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac77 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac78", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac78 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac28", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac28 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac106", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac106 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac7", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac7 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac75", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac75 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac71", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac71 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac48", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac48 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac22", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac22 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac108", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac108 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac70", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac70 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac20", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac20 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac21 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac23", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac23 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac107", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac107 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac74", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac74 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac49", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac49 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac72", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac72 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac79", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac79 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac73", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac73 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac39", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac39 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac14", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac14 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac101", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac101 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac13", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac13 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac11", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac11 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac12", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac12 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac15", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac15 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac103", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac103 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac18", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac18 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac17", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac17 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac111", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac111 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac16", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac16 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac95", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac95 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac96", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac96 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac119", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac119 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac94", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac94 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac109", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac109 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac97", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac97 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac91", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac91 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac10", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac10 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac92", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac92 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac98", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac98 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac99", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac99 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac84", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac84 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac85", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac85 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac83", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac83 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac81", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac81 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac82", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac82 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac86", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac86 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac38", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac38 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac29", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac29 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac89", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac89 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac87", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac87 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac93", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac93 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac33", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac33 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac32", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac32 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac113", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac113 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac34", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac34 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac19", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac19 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac35", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac35 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac30", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac30 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac80", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac80 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac37", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac37 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac31", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac31 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac36", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac36 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac51", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac51 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac50", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac50 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac60", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac60 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac54", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac54 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac53", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac53 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac52", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac52 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac41", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac41 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac63", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac63 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac104", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac104 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac61", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac61 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac62", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac62 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac40", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac40 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac105", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac105 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac59", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac59 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac9", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac9 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac4", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac4 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac112", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac112 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac102", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac102 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac3 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac56", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac56 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac55", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac55 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac115", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac115 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac8", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac8 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac58", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac58 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac57", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac57 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac120", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac120 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac44", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac44 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac90", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac90 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac100", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac100 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac110", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac110 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac46", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac46 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac47 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac6", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac6 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac118", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac118 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac45", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac45 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac69", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac69 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac64", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac64 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac114", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac114 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac66", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac66 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac65", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac65 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac5", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac5 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac67", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac67 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac68", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac68 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac43", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac43 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac42", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac42 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_+Yield3", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield3) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield3) l
            let source () = (_BondSimple.source + ".+Yield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_+Yield1", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield1) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield1) l
            let source () = (_BondSimple.source + ".+Yield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_+Yield2", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield2) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield2) l
            let source () = (_BondSimple.source + ".+Yield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__BondSimple_+Yield4", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield4) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield4) l
            let source () = (_BondSimple.source + ".+Yield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield3 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean62", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean62 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean63 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean2 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean60", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean60 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean112", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean112 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean102", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean102 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield2", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield2 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield1", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield1 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean105", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean105 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean115", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean115 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean104", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean104 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean99", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean99 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean98", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean98 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean114", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean114 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean10", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean10 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean13", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean13 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean12", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean12 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean91", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean91 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean90", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean90 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean93", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean93 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean96", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean96 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean95", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean95 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean94", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean94 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean97", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean97 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean117", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean117 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean107", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean107 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean19", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean19 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean5", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean5 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield4", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield4 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean119", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean119 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean109", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean109 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean17", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean17 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean16 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean11", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean11 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean14", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean14 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean4", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean4 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean18", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean18 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean15", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean15 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean81", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean81 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean80", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean80 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean83", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean83 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean86", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean86 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean85", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean85 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean84", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean84 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean87", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean87 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean64", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean64 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean67", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean67 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean66", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean66 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean65", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean65 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean82", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean82 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean69", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean69 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean68", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean68 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean75", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean75 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean74 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean77", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean77 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean78", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean78 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean92", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean92 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean3 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean79", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean79 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean72", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean72 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean89", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean89 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean88", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean88 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean73", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean73 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean76", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean76 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean71", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean71 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean70", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean70 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean106", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean106 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean100", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean100 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean45", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean45 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean44 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean110", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean110 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean49", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean49 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean7", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean7 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean48", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean48 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean40", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean40 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean43 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean42", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean42 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean41", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean41 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean47", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean47 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean120", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean120 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean46", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean46 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean55", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean55 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean103", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean103 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean54", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean54 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean113", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean113 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean1 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean59", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean59 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean58", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean58 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean53", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean53 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean52", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean52 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean9", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean9 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean50", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean50 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean57", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean57 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean56", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean56 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean51", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean51 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean26", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean26 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean21", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean21 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean20", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean20 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean27", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean27 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean28", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean28 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean25", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean25 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean24", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean24 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean111", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean111 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean101", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean101 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean116", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean116 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean108", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean108 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean23", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean23 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean22", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean22 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean118", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean118 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean35", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean35 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean34 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean37", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean37 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean6", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean6 : obj)
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
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean8 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean39", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean39 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean38", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean38 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean32", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean32 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean61", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean61 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean29", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean29 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean33", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean33 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean36", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean36 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean31", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean31 : obj)
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
                            
    [<ExcelFunction(Name="__BondSimple_clean30", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean30 : obj)
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
                            
#endif

