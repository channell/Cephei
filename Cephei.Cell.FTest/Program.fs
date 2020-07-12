namespace Cephei.Cell.Test
open Serilog
open System
open Cephei.Cell

module Program = 
    let [<EntryPoint>] main _ =

        let cfg = new LoggerConfiguration()
        Log.Logger <- cfg.MinimumLevel.Verbose().WriteTo.File(".\\FTest.log").CreateLogger()

        let runner = new Sample()
        0   
