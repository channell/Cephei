open System.Text
open System
open System.IO
open System.Collections.Generic
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable replist = [("","")]

        let edit (s : string) = 

            if s.Contains(" = Helper.") then
                let arr = s.Split(' ','<','>')|> Array.filter (fun i -> not (i = "")) |> Array.rev
                if s.Contains("toDefault") then 
                    replist <- [(arr.[0], (arr.[2] + " or empty"))] @ replist
                else
                    Console.WriteLine ("Adding mapping of {0} with {1}\n", arr.[0],  arr.[2])
                    replist <- [(arr.[0], arr.[2])] @ replist

            if s.Contains("[<ExcelArgument") then
                let rep =
                    replist
                    |> Seq.filter (fun i -> s.Contains(fst i))
                    |> Seq.map (fun i -> snd i)
                    |> Seq.toList
                if rep = [] then 
                    s
                else
                    let reps = List.head rep
                    let todesc = s.Substring(s.IndexOf("Description"))
                    let startq = todesc.Substring(todesc.IndexOf("\"") + 1)
                    let toend = startq.Substring(0, startq.IndexOf("\""))
                    Console.WriteLine ("Replacing {0} with {1}\n", toend, reps)
                    s.Replace(toend, reps)
            else 
                s
        let lines = 
            File.ReadAllLines s
            |> Array.rev
            |> Array.map edit 
            |> Array.rev
        File.WriteAllLines (s, lines, Encoding.UTF8) 
    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.iter filelines 

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL\Functions" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")
