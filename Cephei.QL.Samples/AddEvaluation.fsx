open System.Text
open System
open System.IO
open System.Text.RegularExpressions

let rec allFiles directory pattern classes = 

    let filelines (s : string) = 

        let mutable inConstructor = false
        let mutable needsEvaluationDate = true


        let edit (s : string) = 

            if s.StartsWith("type") then 
                inConstructor <- true
                needsEvaluationDate <- true
            if s.Contains("evaluationDate") && inConstructor then needsEvaluationDate <- false
            if s.Contains("as this =") then
                inConstructor <- false

            if s.StartsWith("*)")  && needsEvaluationDate then
                s + "\n" +
                "    let mutable\n" +
                "        _evaluationDate                            = evaluationDate"

            elif s.Contains("() as this =") && needsEvaluationDate then
                "    ( evaluationDate                               : ICell<Date>\n" +
                "    ) as this ="

            elif s.Contains(") as this =") && needsEvaluationDate then
                "    ( evaluationDate                               : ICell<Date>\n" +
                s

            elif s.Contains("= cell") && s.Contains("new ") && needsEvaluationDate then
                s.Replace("-> ", "-> (withEvaluationDate _evaluationDate ") + ")"

            elif s.Contains("= cell") && s.Contains("= triv") && needsEvaluationDate then
                s.Replace("-> ", "-> (withEvaluationDate _evaluationDate ").Replace(".Value.", ").")

            elif s.Contains("internal new ()") && needsEvaluationDate then
                "   interface IDateDependant with\n" +
                "        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d\n" +
                s

            elif s.Contains("o.Inject") then
                s + "\m" +
                "            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate"

            else
                s
            
        let lines = 
            File.ReadAllLines s
            |> Array.map edit 
        File.WriteAllLines (s, lines, Encoding.UTF8)  

    let inClass (f : string) =
        let l =
            classes
            |> List.filter (fun i -> f.Contains(i))
        l.Length > 0

    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.filter inClass
    |> Array.iter filelines 

let classes = 
    ["AccrualBias"
    ;"Amortising"
    ;"AnalyticHaganPricer"
    ;"Arguments"
    ;"ASX"
    ;"BachelierYoYInflationCouponPricer"
    ;"BlackIborCouponPricer"
    ;"BlackVanillaOptionPricer"
    ;"BlackYoYInflationCouponPricer"
    ;"BMASwapRateHelper"
    ;"Bond"
    ;"BPSCalculator"
    ;"Cap"
    ;"CapFloor"
    ;"CapFloorEngine"
    ;"CapFloorTermVolCurve"
    ;"CapFloorTermVolSurface"
    ;"Cash"
    ;"CashFlow"
    ;"CashFlows"
    ;"CmsCouponPricer"
    ;"Collar"
    ;"CommercialPaper"
    ;"ConundrumIntegrand"
    ;"CPICapFloor"
    ;"CPICouponPricer"
    ;"DepositRateHelper"
    ;"DigitalCoupon"
    ;"ECB"
    ;"Engine"
    ;"Entry"
    ;"Event"
    ;"ExchangeRateManager"
    ;"FixedLoan"
    ;"FloatingLoan"
    ;"FloatingRateCouponPricer"
    ;"Floor"
    ;"Forward"
    ;"ForwardRateAgreement"
    ;"ForwardsInCouponPeriod"
    ;"ForwardTypePayoff"
    ;"ForwardVanillaOption"
    ;"FraRateHelper"
    ;"FuturesRateHelper"
    ;"FxSwapRateHelper"
    ;"GFunction"
    ;"GFunctionExactYield"
    ;"GFunctionFactory"
    ;"GFunctionStandard"
    ;"GFunctionWithShifts"
    ;"HaganPricer"
    ;"IborCoupon"
    ;"IborCouponPricer"
    ;"IborLeg"
    ;"IMeanRevertingPricer"
    ;"IMM"
    ;"ImpliedVolHelper"
    ;"InflationCouponPricer"
    ;"InflationIndex"
    ;"IntegralCdsEngine"
    ;"InterestRateIndex"
    ;"IrrFinder"
    ;"IsdaCdsEngine"
    ;"LinearTsrPricer"
    ;"Loan"
    ;"MakeBasisSwap"
    ;"MakeCms"
    ;"MakeCreditDefaultSwap"
    ;"MakeOIS"
    ;"MakeSchedule"
    ;"MakeSwaption"
    ;"MakeVanillaSwap"
    ;"MidPointCdsEngine"
    ;"MonteCarloCatBondEngine"
    ;"Month"
    ;"Months"
    ;"NumericalFix"
    ;"NumericHaganPricer"
    ;"ObjectiveFunction"
    ;"OvernightIndexedCoupon"
    ;"OvernightIndexedCouponPricer"
    ;"OvernightLeg"
    ;"PriceHelper"
    ;"PricerSetter"
    ;"RelativeDateRateHelper"
    ;"Results"
    ;"SabrSmileSection"
    ;"Schedule"
    ;"Settings"
    ;"simple_event"
    ;"SmileSection"
    ;"Spy"
    ;"Strategy"
    ;"Swap"
    ;"SwapEngine"
    ;"SwapRateHelper"
    ;"SwaptionVolatilityCube"
    ;"SwaptionVolatilityDiscrete"
    ;"SwapValuation"
    ;"TermStructure"
    ;"TimingAdjustment"
    ;"Type"
    ;"UnitDisplacedBlackYoYInflationCouponPricer"
    ;"Utils"
    ;"VanillaOptionPricer"
    ;"VannaVolgaBarrierEngine"
    ;"VannaVolgaDoubleBarrierEngine"
    ;"VariableChange"
    ;"VegaRatioHelper"
    ;"YearOnYearInflationSwapHelper"
    ;"YieldCurveModel"
    ;"YoYInflationCouponPricer"
    ;"YoYInflationIndex"
    ;"ZeroCouponInflationSwapHelper"
    ;"ZeroInflationIndex"
    ;"ZSpreadFinder"
    ]
    |> List.map (fun i -> i + "Model")

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$" classes)
    