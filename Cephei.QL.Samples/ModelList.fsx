

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

        let edit (s : string) = 

            if s.Contains("_Range") then
                inRange <- true 

            if s.Contains("<WIZ>") then
                inRange <- false

            if s.Contains("let format") && inRange then
                s.Replace ("Range.fromList", "Range.fromModelList")

            elif s.Contains("subscriber = Helper") && inRange then 
                s.Replace("Helper.subscriberRange", "Helper.subscriberModelRange")

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
