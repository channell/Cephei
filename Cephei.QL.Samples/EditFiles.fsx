module editfile 

open System.Text
open System
open System.IO
open System.Text.RegularExpressions

let rec allFiles directory pattern = 
    Directory.GetDirectories directory 
    |> Array.iter (fun s -> allFiles s pattern )

    let filelines (s : string) = 
        let className : string = 
            let a = s.Split('.')
            a.[a.Length-2]
        let lines = 
            File.ReadAllLines s
            |> Array.map (fun l -> l.Replace("; subscriber = Helper.subscriberModel ", "; subscriber = Helper.subscriberModel<" + className + "> " ))
        File.WriteAllLines (s, lines, Encoding.UTF8) 
    Directory.GetFiles directory
    |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
    |> Array.iter filelines 

let directories = 
    [ @"C:\Users\steve\source\repos\Cephei2\Cephei.XL" 
    ; @"C:\Users\steve\source\repos\Cephei2\Cephei.XLC" 
    ]
directories |> List.iter (fun d -> allFiles d "\.fs$")

