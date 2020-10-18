open System.Text
open System
open System.IO
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 
        let className : string = 
            let a = s.Split('\\', '.')
            let b = a.[a.Length-2]
            b.Substring(0, b.LastIndexOf("Model"))

        let mutable inCons = false
        let mutable typeName  = ""
        let mutable notgeneric = true

        let edit (s : string) = 

            if inCons && s.Contains("as this") then
                inCons <- false

            if s.StartsWith ("type " + className) then 
                inCons <- true
                typeName <- s.Split(' ').[1]
            if s.Contains("<") then notgeneric <- false

            if s.Contains("let _" + className) then
                s.Replace("let _", "let mutable\n        _")
            elif (s.Contains("member internal this.Inject")) && notgeneric then
                s.Replace(".Value", "")
            elif (s.Contains("o.Inject")) && notgeneric then
                s.Replace(".Value", "") + "\n            o.Bind p"
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
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.QL\Types" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")




