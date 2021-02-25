namespace Cephei.QL.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

open Cephei.QL
open Cephei.QL.Samples
open Cephei.Cell
open Cephei.Models

[<TestClass>]
type SwapoTest () =

    do Cell.Lazy <- true
    do Cell.Parellel <- false   

    [<TestMethod>]
    member this.NPV () =

        let model = new swapModel ()
        do Cell.Lazy <- true
        do Cell.Parellel <- true

        [ ("fraSwapTermSwapNPV", model.fraSwapTermSwapNPV)
        ; ("depoSwapTermSwapNPV", model.depoSwapTermSwapNPV )
        ; ("depoFutSwapTermSwapNPV", model.depoFutSwapTermSwapNPV )
        ; ("fraSwapTermSwapfairSpread", model.fraSwapTermSwapfairSpread )
        ; ("depoSwapTermSwapfairSpread", model.depoSwapTermSwapfairSpread)
        ; ("depoFutSwapTermSwapfairSpread", model.depoFutSwapTermSwapfairSpread )
        ; ("depoSwapTermSwapfairRate", model.depoSwapTermSwapfairRate)
        ; ("fraSwapTermSwapfairRate ", model.fraSwapTermSwapfairRate )
        ; ("depoFutSwapTermSwapfairRate", model.depoFutSwapTermSwapfairRate )
        ]
        |> List.map (fun (n,c) -> try (n, c.Value.ToString()) with | e -> (n, e.Message))
        |> List.iter (fun (n,d) -> Console.WriteLine("{0,-60}\t{1}", n,d))
