open System.Text
open System
open System.IO
open System.Text.RegularExpressions

let rec allFiles directory pattern classes = 

    let filelines (name : string) = 

        let mutable inConstructor = false
        let mutable needsEvaluationDate = true
        let mutable inBody = false
        let mutable needNew = false
        let mutable inBuilder = false
        let mutable inSource = false
        let mutable inHash = false

        let edit (s : string) = 

            if s.Contains("let ") &&  s.Contains("_create") then 
                inConstructor <- true
                needsEvaluationDate <- true
                inBody <- true
                needNew <- false
                inBuilder <- false
                inSource <- false
                inHash <- false

            if s.Contains("<WIZ>") then
                inConstructor <- false
                needsEvaluationDate <- true
                inBody <- false
                inBuilder <- false
                inSource <- false
                inHash <- false
                
            if s.Contains("evaluationDate") && inBody then 
                needsEvaluationDate <- false
            if s.Contains("let builder") && needsEvaluationDate then
                inBuilder <- true

            if s.Contains("let source") && needsEvaluationDate then
                inSource <- true

            if s.Contains("let hash") && needsEvaluationDate then
                inHash <- true

            if s.Trim() = "=" && needsEvaluationDate && inConstructor then
                inConstructor <- false
                Console.WriteLine ("Adding eval date to {0}", name)
                "        ([<ExcelArgument(Name=\"evaluationDate\",Description = \"Date\")>]\n" +
                "        evaluationDate : obj)\n" +
                s

            elif s.Contains("let builder") && needsEvaluationDate && inBody then
                "                let _evaluationDate = Helper.toCell<Date> evaluationDate \"evaluationDate\"\n" + 
                s

            elif s.Contains(") :> ICell") && needsEvaluationDate  && inBuilder && inBody then
                inBuilder <- false
                "                                                            _evaluationDate.cell\n" +
                s

            elif s.Contains("|]") && needsEvaluationDate && inSource && inBody then
                inSource <- false
                "                                               ;  _evaluationDate.source\n" +
                s

            elif s.Contains("|]") && needsEvaluationDate && inHash && inBody then
                inHash <- false
                "                                ;  _evaluationDate.cell\n" +
                s
            else
                s
            
        let lines = 
            File.ReadAllLines name
            |> Array.map edit 
        File.WriteAllLines (name, lines, Encoding.UTF8)  

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
    |> List.map (fun i -> i + "Function")

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL\Functions" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$" classes)
    
