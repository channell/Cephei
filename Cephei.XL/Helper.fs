namespace Cephei.XL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open QLNet

module Helper = 

    // Summary: add mnemonc to cell
    let withMnemonic<'t> m (c : ICell<'t>) =
        c.Mnemonic <- m
        c

    let formatMnemonic (s : string) =
        if s = null || s = "" then 
            "NA"
        else
            let filter = 
                s.ToCharArray() |>
                Array.filter (fun i -> Char.IsLetterOrDigit (i))
            if Char.IsDigit( filter.[0]) then
                "N" + new string (filter);
            else
                new string (filter)

    // Summary: Subscription helper
    let subscriber (format : 't -> string -> obj) (rtd : IValueRTD) (cell : ICell) (layout : string) = 
        let c = (cell :?> ICell<'t>)
        (new RTDObserver<'t> (rtd, c, format, layout)) :> IDisposable

    // Summary: Subscription helper
    let subscriberRange<'t> (format : Generic.List<'t> -> string -> obj[,]) (rtd : IValueRTD) (cell : ICell) (layout : string)=
        let c = (cell :?> ICell<Generic.List<'t>>)
        (new RTDRangeObserver<'t> (rtd, c, format, layout)) :> IDisposable

    // Summary: Subscription helper
    let subscriberModel<'t> (format : ICell -> string -> obj[,]) (rtd : IValueRTD) (model : ICell) (layout : string) = 
        (new RTDModelObserver<'t> (rtd, (model :?> ICell<'t>), format, layout)) :> IDisposable

    // Summary: Subscription helper
    let subscriberModelRange<'t> (format : Generic.List<ICell<'t>> -> string -> obj[,]) (rtd : IValueRTD) (models : ICell) (layout : string) =
        (new RTDModelRangeObserver<'t> (rtd, (models :?> ICell<Generic.List<ICell<'t>>>), format, layout)) :> IDisposable

    type CellSource<'t> = {cell : ICell<'t>; source : string}
    
    // Summary: Convert the excel value orreference to a cell
    let toCell<'T> (o : obj) (attribute : string) (required : bool) : CellSource<'T> = 

        let invalid o attr =
            if required then 
                invalidArg (o.ToString()) ("Invalid " + attribute)
            else 
                null
        if typeof<'T>.IsEnum then
            { cell = value (Enum.Parse(typeof<'T>, o.ToString()) :?> 'T)
            ; source =  "(value " + typeof<'T>.Name + "." + (Enum.Parse(typeof<'T>, o.ToString()) :?> 'T).ToString() + ")"
            }
        elif not (o = null) && o :? string then
            let s = o :?> string
            if typeof<'T> = typeof<string> && Model.contains (s) then 
                let c = Model.cell s
                if c :? ICell<'T> then
                    { cell = c :?> ICell<'T>
                    ; source = s
                    }
                else    // upcast
                    { cell = withMnemonic c.Mnemonic (triv (fun () -> (c.Box :?> 'T)))
                    ; source = s
                    }
            else
                { cell = withMnemonic (formatMnemonic (o.ToString())) (triv (fun () -> o :?> 'T))
                ; source = "(triv (fun () -> " + s + " :?> " + typeof<'T>.Name + " 'T))"
                }
        elif o :? 'T then 
            { cell = withMnemonic (formatMnemonic (o.ToString())) (triv (fun () -> o :?> 'T))
            ; source = "(value (" + o.ToString() + " :?> " + typeof<'T>.Name + " 'T))"
            }
        elif required then 
            invalidArg (o.ToString()) ("Invalid " + attribute)
        else
            { cell = null :> ICell<'T>
            ; source = o.ToString() + " is invalid for " + attribute
            }

    // Summary: Convert the reference to a cell handle for QL legacy handle class
    let toHandle<'T when 'T :> IObservable> (o : obj) (attribute : string) : CellSource<Handle<'T>> = 
        if o :? string then
            let s = o :?> string
            if typeof<'T> = typeof<string> && Model.contains ((o :?> string)) then
                let c = Model.cell s :?> ICell<'T>
                { cell = withMnemonic c.Mnemonic (triv (fun () -> toHandle (c.Value)))
                ; source = "(triv (fun () -> toHandle (" + c.Mnemonic + ")))"
                }
            else
                { cell = withMnemonic (formatMnemonic (o.ToString())) (triv (fun () -> toHandle (o :?> 'T)))
                ; source = "(triv (fun () -> toHandle (" + o.ToString() + ")))"
                }
        elif o :? 'T then 
            { cell =  withMnemonic (formatMnemonic (o.ToString())) (triv (fun () -> toHandle (o :?> 'T)))
            ; source = "(triv (fun () -> toHandle (" + o.ToString() + ")))"
            }
        else 
            invalidArg (o.ToString()) ("Invalid " + attribute)

    // Summary: Convert the reference to a cell handle for QL legacy handle class
    let toNullable<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> (o : obj) (attribute : string) : CellSource<Nullable<'T>> = 
        if o :? string then
            let s = o :?> string
            if typeof<'T> = typeof<string> && Model.contains ((o :?> string)) then
                let c = Model.cell s :?> ICell<'T>
                { cell = triv (fun () -> toNullable (c.Value))
                ; source ="(triv (fun () -> toNullable (" + c.Mnemonic + ".Value))"
                }
            else
                { cell = triv (fun () -> nullableNull<'T> ())
                ; source = "(triv (fun () -> nullableNull<" + typeof<'T>.Name + "> ()))"
                }

        elif o :? 'T then 
            { cell = triv (fun () -> toNullable (o :?> 'T))
            ; source = "(triv (fun () -> toNullable (" + o.ToString() + "))"
            }
        else 
            invalidArg (o.ToString()) ("Invalid " + attribute)
           
    let isNumeric (o : obj) : bool = 
        o.ToString().ToCharArray() |> Array.fold (fun a y -> if a && (Char.IsDigit(y) || y = '-' || y = '+' || y = '.' || y = 'e') then true else false) true

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)

    let sourceFold s (cs : string array) = 
        cs |> Array.fold (fun a y -> a + " " + y) s

    let sourceFoldArray (cs : string array) = 
        "[|" + (cs |> Array.fold (fun a y -> a + ";" + y) "").Substring(1) + "|]"

    let hashFold (cs : ICell array) = 
        cs |> Array.fold (fun a y -> (a <<< 4)  ^^^ y.Mnemonic.GetHashCode()) 0

    let hashFold2 (cs : ICell<'t> array) = 
        cs |> Array.fold (fun a y -> (a <<< 4)  ^^^ y.Mnemonic.GetHashCode()) 0

    // apply a generic format for conversion to Excel types
    let rec genericFormat (o : obj) : obj =
        let enumerate (e : IEnumerable) = 
            let i = e.GetEnumerator()
            seq {while i.MoveNext() do i.Current} 
        match o with
        | :? string -> o
        | :? DateTime as d -> d.ToOADate() :> obj
        | :? QLNet.Date as d -> d.serialNumber() :> obj
        | :? Enum as e -> e.ToString() :> obj
        | :? IEnumerable as e -> (enumerate e |> Seq.fold (fun a y -> a + "," + (genericFormat y).ToString()) "").Substring(1,255) :> obj
        | :? ICell as c -> genericFormat c.Box
        | _ -> o

    module Range =
        let toArray (o : obj[,]) : obj array =
            o |> Seq.cast<obj> |> Seq.toArray

        let make c r v = Array2D.create<obj> c r v

        let fromArray (o : 'o array) (layout : string) : obj[,] =
            let len = o.Length
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 1 (genericFormat o.[x]))
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 1 x (genericFormat o.[x]))
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (genericFormat o.[x]))
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (genericFormat o.[x]))
                        range
        
        let spliceArray (o : 'o array) (layout : string) (range : obj[,])  (n : int): obj[,] =
            let min a b = if a < b then a else b
            match layout with 
            | "C"   ->  let len = min (Array2D.length1 range) o.Length
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x n (genericFormat o.[x]))
                        range
            | _     ->  let len = min (Array2D.length2 range) o.Length
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range n x (genericFormat o.[x]))
                        range

        let fromMatrix (o : Generic.List<Generic.List<'o>>) (layout : string) : obj[,] =
            let x = o.Count
            let y = o |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> Array2D.set range a b (o.[b].[a] :> obj))
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)} |> 
                        Seq.iter (fun (a,b) -> Array2D.set range a b (o.[a].[b] :> obj))
                        range

        let fromCellMatrix (o : ICell<Generic.List<Generic.List<'o>>>) (layout : string) : obj[,] =
            let l = o.Value
            let x = l.Count
            let y = l |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> Array2D.set range a b (genericFormat l.[b].[a]))
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> Array2D.set range a b (genericFormat l.[a].[b]))
                        range

        let fromHandleMatrix (o : ICell<Generic.List<Generic.List<Handle<'o>>>>) (layout : string) : obj[,] =
            let l = o.Value
            let x = l.Count
            let y = l |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> Array2D.set range a b (genericFormat l.[b].[a]))
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> Array2D.set range a b (genericFormat l.[a].[b]))
                        range


        let fromCell (cell : ICell<'t>) (layout : string) : obj[,] =
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> 1 2 null
                        Array2D.set range 0 0 (cell.Mnemonic :> obj)
                        Array2D.set range 0 1 (genericFormat cell.Value)
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 1 null
                        Array2D.set range 0 0 (cell.Mnemonic :> obj)
                        Array2D.set range 1 0 (genericFormat cell.Value)
                        range
            | _     ->  let range = Array2D.create<obj> 1 1 (genericFormat cell.Value)
                        range


        let fromCellArray (cells : ICell<'t> array) (layout : string) : obj[,] =
            let len = cells.Length
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 1 (genericFormat cells.[x].Value))
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 1 x (genericFormat cells.[x].Value))
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (genericFormat cells.[x].Value))
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (genericFormat cells.[x].Value))
                        range

        let fromModel (m : ICell<'t>) (layout : string) : obj[,] =
            let cells =
                (m :?> Model) |>
                Seq.sortBy (fun i -> i.Key) |>
                Seq.map (fun i -> i.Value) |>
                Seq.toArray
            let len = cells.Length
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 1 (genericFormat cells.[x].Box))
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 1 x (genericFormat cells.[x].Box))
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (genericFormat cells.[x].Box))
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (genericFormat cells.[x].Box))
                        range

        let fromModelList<'t> (m : Generic.List<ICell<'t>>) (layout : string) : obj[,] =
            let models = m |> Seq.map (fun i -> i :?> Model) |> Seq.toArray 
            let len = models.Length 
            if len = 0 then
                Array2D.create<obj> 0 0 null
            else
                let cols = 
                    models.[0] |>
                    Seq.filter (fun i -> i.Value.HasFunction) |>
                    Seq.map (fun i -> i.Key) |>
                    Seq.sort |>
                    Seq.toArray
                let range = 
                    match layout with
                    | "CT"  ->  let r = Array2D.create<obj> (len + 1) cols.Length null
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r 0 x (genericFormat cols.[x]))
                                r
                                
                    | "RT"  ->  let r =Array2D.create<obj> cols.Length (len + 1) null
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r x 0 (genericFormat cols.[x]))
                                r 

                    | "C"   ->  Array2D.create<obj> len cols.Length null
                    | _     ->  Array2D.create<obj> cols.Length len null

                let splice (o : Model) (pos : int) =
                    let setter (c : Model) (s : string) : obj =
                        try
                            genericFormat c.[s].Box
                        with
                        | _ -> null
                    match layout with
                    | "CT"  ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set range x (pos + 1) (setter o cols.[x]))
                    | "RT"  ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set range (pos + 1) x (setter o cols.[x]))
                    | "C"   ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set range x pos (setter o cols.[x]))
                    | _     ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set range pos x (setter o cols.[x]))

                seq {0 .. len - 1} |> Seq.iter (fun x -> splice models.[x] x)
                range
