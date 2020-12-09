namespace Cephei.QL.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Cephei.QL
open Cephei.QL.Samples
open Cephei.Cell
open Cephei.Models

[<TestClass>]
type ZeroTest () =

    do Cell.Lazy <- true
    do Cell.Parellel <- true   

    [<TestMethod>]
    member this.NPV () =

        let model = new Sheet1 ()
        do Cell.Lazy <- true
        do Cell.Parellel <- true

        let npv = model.zeroNPV.Value

        Console.WriteLine ("NPV {0}", npv)
        