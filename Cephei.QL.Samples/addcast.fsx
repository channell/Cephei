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
        let mutable pams = 0
        let mutable typeName  = ""
        let mutable notgeneric = true

        let edit (s : string) = 

            if inCons && s.Contains("as this") then
                inCons <- false

            if inCons && s.Contains(": ICell") then
                pams <- pams + 1

            if s.StartsWith ("type " + className) then 
                inCons <- true
                pams <- 0
                typeName <- s.Split(' ').[1]
                if s.Contains("<") then notgeneric <- false

            if (s.Contains ("do this.Bind")) && notgeneric then
                let newcon =
                    if pams > 0 then 
                        "internal new () = new " + typeName + "(" + (List.fold (fun a y -> a + ",null" ) "" [1..pams]).Substring(1) + ")"
                    else 
                        ""
                let caster = String.Format ("
(* 
    casting 
*)
    {0}
    member internal this.Inject v = _{1}.Value <- v
    static member Cast (p : ICell<{1}>) = 
        if p :? {2} then 
            p :?> {2}
        else
            let o = new {2} ()
            o.Inject p.Value
            o
                            ", newcon, className, typeName)

                Console.WriteLine (caster)
                s + caster
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


