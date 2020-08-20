namespace Cephei.Cell.Test

open Cephei.Cell
open Cephei.Cell.Generic
open System.Numerics
open Orleans
open System
open System.Threading.Tasks

(*
    A trivial model to calculate a factorial
*)
type ValueSource ()  as this =
    inherit Model ()
    let value = Cell.CreateValue 1I
    do this.Bind()
    member this.Value = value

type FactorialModel () as this =
    inherit Model ()
    let rec fac n = 
        if n <= 0I then
            1I
        else 
            n * fac (n - 1I)
    let ref = new ValueSource()
    let num  = Cell.CreateValue 42I
    let factorial = 
        let build (r : ICell<BigInteger>) = 
            Cell.CreateFast (fun () -> fac r.Value)
        build (ref.As<BigInteger> ("Value"))

    do this.Bind()

    member this.Value = num
    member this.Factorial = factorial

(*
    Trivial Grain to use the model in calculation
*)
type IGrainFactorialModel =
    inherit IGrainWithStringKey

    abstract Get : BigInteger -> Task<BigInteger>
    abstract Factorial : Task<BigInteger>

(*
    Trivial Implementation
*)
type FactorialModelGrain () = 
    inherit Grain<BigInteger> ()

    let _model = new FactorialModel ()

    interface IGrainFactorialModel with

        member this.Get (value :BigInteger) = 
            async { _model.Value.Value <- value
                    return _model.Factorial.Value
                  }
            |> Async.StartAsTask
        
        member this.Factorial  =
            async  { return _model.Factorial.Value }
            |> Async.StartAsTask