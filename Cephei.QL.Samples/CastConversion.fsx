
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
            b.Substring(0, b.LastIndexOf("Function"))

        let edit (s : string) = 

            if s.Contains ("let builder (current : ICell) =") && s.Contains (":?>") && not (s.Contains("(Fun.")) then
//                Console.WriteLine("Replacing |{0}|", s)
                let sn = s.Substring(s.LastIndexOf("(") + 1)
                let pat = sn.Substring(0, sn.LastIndexOf(")"))
                let parts = pat.Split(' ')
                let rep = parts.[2] + ".Cast " + parts.[0]
                let r = s.Replace(pat, rep)
 //               Console.WriteLine("with      |{0}|", r)
                r
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
