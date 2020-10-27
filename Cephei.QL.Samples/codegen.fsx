open System.Text
open System
open System.IO
open System.Collections.Generic
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable item = ""
        let mutable editremove = false
        let mutable editopen = false

        let edit (s : string) = 

            if s.Contains("Helper.sourceFold") then
                item <- "[| " + (s.Split(' ','(',')','+')|> Array.filter (fun i -> i.Contains(".source")) |> Array.rev |> Array.head)
                editremove <- true
                s

            elif editremove && s.Contains(item) then
                editremove <- false
                editopen <- true
                ""
            elif editopen then
                editopen <- false
                s.Replace("; ", "[|").Replace ("|]", "[||]")
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
