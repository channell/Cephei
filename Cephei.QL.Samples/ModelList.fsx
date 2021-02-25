

open System.Text
open System
open System.IO
open System.Collections.Generic
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 

        let mutable inFunc = false
        let mutable notCreator = true

        let edit (s : string) = 

            if s.Contains("_create") then
                notCreator <- false

            if s.Contains("_Range") then
                notCreator <- false
                
            if s.Contains("<WIZ>") then
                notCreator <- true

            if s.Contains("if not (Model.IsInFunctionWizard()) then") && notCreator then
                inFunc <- true 

            if s.Contains("Helper.toCell") && inFunc && notCreator then
                inFunc <- false
                s.Replace ("Helper.toCell", "Helper.toModelReference")

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

