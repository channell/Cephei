
open System.Text
open System
open System.IO
open System.Collections.Generic
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable inRange = false
        let mutable str = ""

        let edit (s : string) = 

            if s.Contains("_Range") then
                inRange <- true 

            if s.Contains("<WIZ>") then
                inRange <- false

            if s.Contains("let l = new Cephei.Cell.List") && inRange then
                ""
            else 
                s
        let lines = 
            File.ReadAllLines s
            |> Array.map edit 
        File.WriteAllLines (s, lines, Encoding.UTF8) 
    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.iter filelines 

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL\Functions" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")

(*
let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable inRange = false
        let mutable str = ""

        let edit (s : string) = 

            if s.Contains("_Range") then
                inRange <- true 

            if s.Contains("<WIZ>") then
                inRange <- false

            if s.Contains("let l = new Cephei.Cell.List") then
                str <- "(" + s.Replace("let l =","") + ") :> ICell"

            if s.Contains("let builder") && inRange then
                s.Replace("l :> ICell", str)
            else 
                s
        let lines = 
            File.ReadAllLines s
            |> Array.map edit 
        File.WriteAllLines (s, lines, Encoding.UTF8) 
    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.iter filelines 

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL\Functions" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")
*)