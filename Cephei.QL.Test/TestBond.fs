namespace Cephei.QL.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Cephei.QL
open Cephei.QL.Samples
open Cephei.Cell


[<TestClass>]
type TestBond () =

    let standards               = new BusinessStandards ()
    let market                  = new MarketCondition (standards)

    [<TestMethod>]
    member this.TestLazy () =

        do Cell.Lazy <- true
        do Cell.Parellel <- true

        let lots = 
            seq { for n in 1..100 do
                    new BondPortfolio (standards, market)}
            |> Seq.toList

        let r = 
            seq { for c in 0..100 do
                    market.ClockDate.Value <- market.ClockDate.Value + c
                    let cleanPrice = lazy (lots |> List.fold (fun a y -> a + y.CleanPrice.Value) 0.0 )
                    Console.WriteLine ("Lazy, {1}, {0}", cleanPrice.Value, market.Today.Value)
                    cleanPrice
                    } |> Seq.toArray

        Assert.IsTrue(true);

    [<TestMethod>]
    member this.TestSerial () =

        do Cell.Lazy <- true
        do Cell.Parellel <- false

        let lots = 
            seq { for n in 1..100 do
                    new BondPortfolio (standards, market)}
            |> Seq.toList

        let r = 
            seq { for c in 0..100 do
                    market.ClockDate.Value <- market.ClockDate.Value + c
                    let cleanPrice = lazy (lots |> List.fold (fun a y -> a + y.CleanPrice.Value) 0.0 )
                    Console.WriteLine ("Serial, {1}, {0}", cleanPrice.Value, market.Today.Value)
                    cleanPrice
                    } |> Seq.toArray

        Assert.IsTrue(true);

    [<TestMethod>]
    member this.TestParllel () =

        do Cell.Lazy <- false
        do Cell.Parellel <- true

        let lots = 
            seq { for n in 1..100 do
                    new BondPortfolio (standards, market)}
            |> Seq.toList

        let r =
            seq { for c in 0..100 do
                    market.ClockDate.Value <- market.ClockDate.Value + c
                    let cleanPrice = lazy (lots |> List.fold (fun a y -> a + y.CleanPrice.Value) 0.0 )
                    Console.WriteLine ("Parallel, {1}, {0}", cleanPrice.Value, market.Today.Value)
                    cleanPrice
                    } |> Seq.toArray

        Assert.IsTrue(true);

 