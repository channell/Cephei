open System.Text
open System
open System.IO
open System.Text.RegularExpressions

let filelines (s : string) = 
    let mutable incast = false

    let edit (s : string) = 

        if s = "    let _evaluationDate                            = evaluationDate" then
               "    let mutable\n        _evaluationDate                            = evaluationDate"
        
        elif s.Contains("internal new () = new") then 
            incast <- true
            "    interface IDateDependant with\n" +
            "        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d\n\n" +
            s

        elif s.Contains("o.Inject p") && incast then 
            incast <- false
            s + "\n" +
            "            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate"

        else
            s
            
    let lines = 
        File.ReadAllLines s
        |> Array.map edit 
    File.WriteAllLines (s, lines, Encoding.UTF8)  

let files = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.Gen\NetQL\Class.tt"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL.Samples\ChnageEvalDate.fsx"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\AmortizingBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\AmortizingCmsRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\AmortizingFixedRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\AmortizingFloatingRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\AssetSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BarrierOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BasisSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BasketOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BMASwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\BTPModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CallableFixedRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CallableZeroCouponBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CapFloorModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CapHelperModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CashModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CatBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CCTEUModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CliquetOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CmsRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CollarModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CommercialPaperModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CompositeInstrumentModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ContinuousAveragingAsianOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ContinuousFixedLookbackOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ContinuousFloatingLookbackOptionModel.fs"
    (*
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ContinuousPartialFloatingLookbackOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ConvertibleFixedCouponBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ConvertibleFloatingRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ConvertibleZeroCouponBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CPIBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CPICapFloorModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CPISwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\CreditDefaultSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\DiscreteAveragingAsianOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\DividendBarrierOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\DividendVanillaOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\DoubleBarrierOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\EuropeanOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FixedLoanModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FixedRateBondForwardModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FixedRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FloatFloatSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FloatingCatBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FloatingLoanModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FloatingRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\FloorModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ForwardRateAgreementModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ForwardVanillaOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\HestonModelHelperModel.fs"
//    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\InstrumentModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\LoanModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\MBSFixedRateBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\MultiAssetOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\OneAssetOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\OptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\OvernightIndexedSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\SpreadOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\StockModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\SwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\SwaptionHelperModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\SwaptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\VanillaOptionModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\VanillaSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\YearOnYearInflationSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\YoYInflationCapFloorModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\YoYInflationCapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\YoYInflationCollarModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\YoYInflationFloorModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ZeroCouponBondModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types\ZeroCouponInflationSwapModel.fs"
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Util.fs"
    *)
    ]

files |> List.iter (fun f -> filelines f)



