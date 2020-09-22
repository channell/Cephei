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
namespace Cephei.QL.Samples

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

(*
    Business standards that are applied accross all portfolion
*)

type BusinessStandards () as this =
    inherit Model ()

    let accrualConvention           = value BusinessDayConvention.Unadjusted
    let paymentConvention           = value BusinessDayConvention.ModifiedFollowing
    let settlementDays              = value 3
    let dayCount                    = value (new ActualActual (ActualActual.Convention.ISMA) :> DayCounter)
    let includeSettlementDate       = value (new System.Nullable<bool> (true))

    do this.Bind ()

    member this.AccrualConvention   = accrualConvention
    member this.PaymentConvention   = paymentConvention
    member this.SettlementDays      = settlementDays
    member this.DayCount            = dayCount
    member this.IncludeSettlement   = includeSettlementDate

(*
    Market Conditions that all portfolio can be priced from
*)
type MarketCondition 
    ( standards                     : BusinessStandards ) as this =
    inherit Model ()

    let toNullable (v : 't)         = new System.Nullable<'t> (v)

    let calendar                    = Fun.TARGET()
    let clockDate                   = value Date.Today;
    let convention                  = value BusinessDayConvention.Following
    let today                       = calendar.Adjust clockDate convention

    do this.Bind ()

    member this.Today               = today
    member this.Calendar            = calendar
    member this.ClockDate           = clockDate

(*
    A sammple Bond Portfolio
*)
type BondPortfolio 
    ( standards                     : BusinessStandards 
    , marketCondition               : MarketCondition
    ) as this =
    inherit Model ()

    let calendar                    = triv (fun () -> marketCondition.Calendar.Value :> Calendar)
    let convention                  = value BusinessDayConvention.Following

    let faceAmount                  = value 1000000.0;
    let quantity                    = value 1.0

    let lengths                     = [ 3; 5; 10; 15; 20 ]
                                      |> List.map (fun i -> value i)
    let coupons                     = [0.02; 0.05; 0.08 ]
                                      |> List.map (fun i -> value (Generic.List([i])))
    let frequencies                 = [Frequency.Semiannual; Frequency.Annual]
                                      |> List.map (fun i -> value (Period i))
    let bondDayCount                = value (Thirty360() :> DayCounter)
    let redemption                  = value 100.0

    let makeYield v                 = let sq = new SimpleQuote(new System.Nullable<double>(v)) :> Quote
                                      let ff = new FlatForward( marketCondition.Today.Value, sq, standards.DayCount.Value)
                                      new Handle<YieldTermStructure>(ff)

    let yields                      = [ 0.03; 0.04; 0.05; 0.06; 0.07]

    let years                       = value TimeUnit.Years
    
    let eom                         = value false
    let dateGenerationRule          = value DateGeneration.Rule.Backward
    
    let compounding                 = [Compounding.Compounded; Compounding.Continuous]

    let mutable id = 1
    
    let makeBond issue length coupon  (frequency : ICell<Period>) yieldVal = 
        let today = marketCondition.Today.Value
        let dated = triv (fun () -> today)      // don't reset on valuation date
        let nullDate = value (null :> Date)
        let maturity = marketCondition.Calendar.Advance1 dated length years standards.PaymentConvention eom 
        let schedule = Fun.Schedule dated maturity frequency calendar standards.AccrualConvention standards.AccrualConvention dateGenerationRule eom nullDate nullDate
        let yieldCurve = triv (fun () -> (makeYield yieldVal))
        let engine = Fun.DiscountingBondEngine yieldCurve standards.IncludeSettlement 
        let castEgnine = triv (fun () -> engine.Value :> IPricingEngine)
        let exCouponPeriod = value (null :> Period)
        let b = Fun.FixedRateBond standards.SettlementDays faceAmount schedule coupon bondDayCount standards.PaymentConvention redemption issue calendar exCouponPeriod calendar convention eom castEgnine marketCondition.Today
        b.Mnemonic <- "B" + id.ToString()
        id <- id + 1
        b

    let bonds = 
        seq {for l in lengths do
                for c in coupons do 
                    for f in frequencies do
                        for y in yields do
                            (l,c,f, y)}
        |> Seq.map (fun (l,c,f, y) -> makeBond marketCondition.Today l c f y)
        |> Seq.toArray

    let cleanPrices                 = bonds |> Array.map (fun i -> i.CleanPrice) 

    let cleanPrice                  = cell (fun () -> cleanPrices |> Seq.fold (fun a y -> a + y.Value * quantity.Value) 0.0)
        
    do this.Bind ()

    member this.Amount              = faceAmount
    member this.Quantity            = quantity
    member this.Redemption          = redemption

    member this.CleanPrice          = cleanPrice
