namespace Cephei.Cell.Test

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Cephei.Cell
open Cephei.Cell.Generic
open System.Numerics

open System
open Serilog

type SampleModel (value : BigInteger)  as this =
    inherit Model ()
    let rec fac n = 
        if n <= 0I then
            1I
        else 
            n * fac (n - 1I)

    let num  = Cell.CreateValue value
    let factorial = 
        let build (r : ICell<BigInteger>) = 
            Cell.CreateFast (fun () -> fac r.Value)
        build num

    do this.Bind()

    member this.Value = num
    member this.Factorial = factorial

[<TestClass>]
type Sample () =

    let rec fixed_point f x =
        match f x with
        | f_x when x = f_x -> x
        | x -> fixed_point f x 

    let golden_ratio n = fixed_point (fun i -> sqrt (1.0 + i)) n

    let rec fac n = 
        if n <= 0I then
            1I
        else 
            n * fac (n - 1I)

    let binomial n r =
        fac n / (fac r * fac (n - r))

    let bins n = 
        [for r in 0I..n -> string (binomial n r)]

    let modelValue (m : Model) (v : 'a) s = m.CreateValue (v,s)

    let modelCell (m : Model) (v : unit -> 'a) s = m.Create (v, s)

    let value (v : 'a) s = Cell.CreateValue (v,s)

    let cell (v : unit -> 'a) s = Cell.Create (v, s)

    let watch (c : ICell<'a>) n = 
        new ConsoleSubscriber<'a> (c, n)

    let intFromat b = 
        b.ToString()

    let logWatch (c : ICell<'a>) n = 
        new TraceSubscriber<'a> (c, intFromat,  n)


    [<TestInitialize>]
    member this.setup () = 
        Log.Logger <- (new LoggerConfiguration()).MinimumLevel.Verbose().WriteTo.File(".\\FTest.log").CreateLogger()


    [<TestMethod>]
    member this.CellSimple () = 
        Cell.Parellel <- true
        let sc = value 100I "sc"
        let tc = cell (fun () -> List.toSeq (bins (sc.Value))) "tc"
        let obs = logWatch tc "obs"
        [1I..10000I] |> List.iter (fun i -> sc.Value <- i
                                            Threading.Thread.Sleep(0))
        Threading.Thread.Sleep 1000


    [<TestMethod>]
    member this.CellSimple2 () = 
        let sc = value 1I "sc"
        let tc = cell (fun () -> fac sc.Value) "tc"
        let obs = watch tc "observe "
        [1I..100I] |> List.iter (fun i -> sc.Value <- i)

    [<TestMethod>]
    member this.CellSimple3 () = 
        Cell.Parellel <- true
        let sc = value 1I "sc"
        let tc = cell (fun () -> fac sc.Value) "tc"
        let obs = watch tc "observe "
        [1I..100I] |> List.iter (fun i -> sc.Value <- i)
        printf "Sleeping"
        Threading.Thread.Sleep 10000

    [<TestMethod>]
    member this.CellSimple4 () = 
        Cell.Parellel <- true
        let sc = value 1I "sc"
        let tc = cell (fun () -> fac sc.Value) "tc"
        let obs = watch tc "observe "
        let obsc = logWatch tc "Watch1 "
        let r =
            [1I..100I] |> List.map (fun i -> 
                sc.Value <- i
                Threading.Thread.Sleep (1))

        Threading.Thread.Sleep 10000

    [<TestMethod>]
    member this.CellSimple5 () = 
        Cell.Parellel <- true
        let sc = value 1I "sc"
        let tc = cell (fun () -> fac sc.Value) "tc"
        let tc2 = 
            cell (fun () -> fac sc.Value) "tc"
        let obs = watch tc "observe "
        let obsc = logWatch tc "Watch1 "
        let calc = 
            use s = new Cephei.Cell.Session "Session"
            let r =
                [1I..100I] |> List.map (fun i -> 
                    sc.Value <- i
                    Threading.Thread.Sleep (1))
            1
        ignore calc
        Threading.Thread.Sleep 10000

    [<TestMethod>]
    member this.ModellSimple1 () = 
        Cell.Parellel <- true
        let model = new Model()
        let sc = modelValue model 1I "sc"
        let scref = model.As<Numerics.BigInteger> "sc"
        let tc = 
            let scref = model.As<Numerics.BigInteger> "sc"
            modelCell model (fun () -> fac scref.Value) "tc"
        let tc2 = modelCell model (fun () -> fac (model.["sc"] :?> ICell<Numerics.BigInteger>).Value) "tc"

        let obs = watch tc "observe "
        let obsc = logWatch tc "Watch1 "
        let r =
            [1I..100I] |> List.map (fun i -> 
                sc.Value <- i
                Threading.Thread.Sleep (1))

        Threading.Thread.Sleep 10000

    [<TestMethod>]
    member this.Thrash () = 
        printf "Start Parallel %A\n" DateTime.Now
        Cell.Parellel <- true
        Threading.ThreadPool.SetMaxThreads (32,32) |> ignore
        let sourceCells =
            [1I..2000I] |> List.map (fun i -> value i (string i))
        let targetCells = 
            sourceCells |> List.map (fun i -> cell (fun () -> fac i.Value) (string i))
        let avgCell = 
            cell (fun () -> (targetCells |> List.fold (fun a i ->  a + i.Value) 0I) / 2000I) "avg"
        let watch = logWatch avgCell "Average Watcher"
        sourceCells |> List.iter (fun i -> i.Value <- i.Value + 1I)
        while not (Threading.ThreadPool.PendingWorkItemCount = 0L) do
            printf "Poolsize %A\n" Threading.ThreadPool.PendingWorkItemCount
            Threading.Thread.Sleep 100
        printf "End Parallel  %A\n" Threading.ThreadPool.PendingWorkItemCount

    [<TestMethod>]
    member this.ThrashSingle () = 
        printf "Start Single %A\n" DateTime.Now
        Cell.Parellel <- false
        Threading.ThreadPool.SetMaxThreads (32,32) |> ignore
        let sourceCells =
            [1I..5000I] |> List.map (fun i -> value i (string i))
        let targetCells = 
            sourceCells |> List.map (fun i -> cell (fun () -> fac i.Value) (string i))
        let avgCell = 
            cell (fun () -> (targetCells |> List.fold (fun a i ->  a + i.Value) 0I) / 5000I) "avg"
        let watch = logWatch avgCell "Average Watcher"
        sourceCells |> List.iter (fun i -> i.Value <- i.Value + 1I)
        while not (Threading.ThreadPool.PendingWorkItemCount = 0L) do
            printf "Poolsize %A\n" Threading.ThreadPool.PendingWorkItemCount
        
            Threading.Thread.Sleep 100
        printf "End Parallel %A\n" Threading.ThreadPool.PendingWorkItemCount

    [<TestMethod>]
    member this.SimpleModelTest () =
        let m = new SampleModel (1I);
        let watch = new ModelTraceSubscriber (m, (fun c -> string c))
        m |> Seq.iter (fun i -> printf "%s %A" i.Key i.Value)

