module kloc =

    open System
    open System.IO
    open System.Text.RegularExpressions

    type codeAndCount = 
        { code : string
        ; count : int
        }

    type codeAndList =
        { top : codeAndCount
        ; rest : codeAndCount list
        }

    let rec linesOfCode directory pattern ignore = 
        let from = 
            let subdirLines =
                Directory.GetDirectories directory 
                |> Array.filter (fun s -> not (s.Contains(ignore)))
                |> Array.map (fun s -> async { return linesOfCode s pattern ignore })
                |> Async.Parallel
                |> Async.RunSynchronously 
                |> Seq.fold (fun a b -> a @ b) []
            let allFileLines =
                let filelines (s : string) = 
                    async {
                        let fileType : string = 
                            let a = s.Split('.')
                            a.[a.Length-1]
                        let countLines = 
                            File.ReadAllLines s
                            |> Array.filter (fun l -> not (Regex.IsMatch (l, "^[ \t]+//|^//|^$")))  // exclude comments & blank
                        return { code = fileType; count = countLines.Length}       // make tuple of type and lines
                    }
                Directory.GetFiles directory
                |> Array.filter (fun p -> Regex.IsMatch (p, pattern))
                |> Array.map filelines 
                |> Async.Parallel
                |> Async.RunSynchronously
                |> Seq.toList 
            allFileLines @ subdirLines 
            |> List.sortBy (fun (cac : codeAndCount) -> cac.code )

        let aggregate (cur : codeAndList, n : codeAndCount) : codeAndList = 
            if cur.top.code = n.code then
                {top = {code = cur.top.code; count = cur.top.count + n.count}; rest = cur.rest}
            else
                {top = n; rest = [cur.top] @ cur.rest}

        let select (cur : codeAndList) : codeAndCount list = 
            [cur.top] @ cur.rest 
        let empty : codeAndList = {top = {code = ""; count = 0}; rest = []}

        List.fold (fun a b -> aggregate (a, b)) empty from |> select

    let report = 
        let directories = 
            [ @"C:\Users\steve\source\repos\Cephei2\Cephei.Cell" 
            ; @"C:\Users\steve\source\repos\Cephei2\Cephei.Gen" 
            ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL" 
            ; @"C:\Users\steve\source\repos\Cephei2\Cephei.XL" 
            ; @"C:\Users\steve\source\repos\Cephei2\Cephei.XLC" 
            ; @"C:\Users\steve\source\repos\Cephei2\Cephei.QL.Samples" 
            ]

        let reportLine d = 
            async {
                return 
                    linesOfCode d "\.cs$|\.fs$|\.h$|\.hpp$|\.cpp$" ".svn" 
                |> List.filter (fun cac -> cac.count <> 0) 
                |> List.map (fun cac -> {code = d + "\*." + cac.code; count = cac.count})
            }
        List.map reportLine directories
        |> Async.Parallel 
        |> Async.RunSynchronously
        |> Seq.toList 
        |> List.fold (fun a b -> a @ b) []
        |> List.iter (fun cac -> printf "\"%s\"\t%d\n" cac.code cac.count)

    report

