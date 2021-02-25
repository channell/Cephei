(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)

namespace Cephei.XL

open System
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open QLNet
open System.Reflection

module Helper = 

    let rec genericTypeString (t : Type) =
        if t.IsGenericType then
            let p  = 
                t.GetGenericArguments()
                |> Array.fold (fun a y -> a + "," + (genericTypeString y)) ""
            let q = 
                t.ToString().Split('`').[0]
            q + "<" + p.Substring(1) + ">"
        else
            t.ToString()


    // Summary: add mnemonc to cell
    let withMnemonic<'t> m (c : ICell<'t>) =
        c.Mnemonic <- (Model.formatMnemonic m)
        c

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
    let subscriberModelRange<'t> (format : Cephei.Cell.List<'t> -> string -> obj[,]) (rtd : IValueRTD) (models : ICell) (layout : string) =
        (new RTDModelRangeObserver<'t> (rtd, (models :?> Cephei.Cell.List<'t>), format, layout)) :> IDisposable


    // Summary: Convert the excel value orreference to a cell
    let toCell<'T> (o : obj) (attribute : string) : CellSource<'T> = 

        if typeof<'T>.IsEnum then
            let en = Enum.Parse(typeof<'T>, o.ToString()) :?> 'T
            let ty = typeof<'T>
            if ty.IsNested then
                { cell = (value en)
                ; source =  "(value " + ty.DeclaringType.Name + "." + ty.Name + "." + en.ToString() + ")"
                }
            else
                { cell = (value en)
                ; source =  "(value " + ty.Name + "." + en.ToString() + ")"
                }
        elif not (o = null) && o :? string then
            let so = o :?> string
            let c = Model.cell so
            let s = if so.StartsWith("+") || so.StartsWith("-") then so.Substring(1) else so
            if c.IsSome then 
                let cv = c.Value
                if cv :? ICell<'T> then
                    { cell = cv :?> ICell<'T>
                    ; source = "_" + s
                    }
                elif cv.ValueIs<'T>() then 
                    { cell = cast<'T> cv
                    ; source =  "(cast<" + (genericTypeString typeof<'T>) + "> _" + s + ")"
                    }
                elif typeof<'T> = typeof<Date> then 
                    if o :? ICell<double> then
                        let cd = cv :?> ICell<double>
                        let mut = if cd.Mutex = null || cd.Mutex.Mnemonic = null then "null" else cd.Mutex.Mnemonic 
                        { cell = withMnemonic cv.Mnemonic (triv cd.Mutex (fun () -> (new Date(int (cd.Value)))) :?> ICell<'T>)
                        ; source =  "(triv " + mut + " (fun () -> new Date(int (_" + cv.Mnemonic + ".Value))))"
                        }
                    elif o :? ICell<DateTime> then
                        let ct = cv :?> ICell<DateTime>
                        let mut = if ct.Mutex = null || ct.Mutex.Mnemonic = null then "null" else ct.Mutex.Mnemonic 
                        { cell = withMnemonic cv.Mnemonic (triv ct.Mutex (fun () -> new Date(int (ct.Value.ToOADate()))) :?> ICell<'T>)
                        ; source =  "(triv "+ mut + " (fun () -> new Date(int (_" + cv.Mnemonic + ".Value.ToOADate())))"
                        }
                    elif o :? ICell<int> then
                        let i = cv :?> ICell<int>
                        let mut = if i.Mutex = null || i.Mutex.Mnemonic = null then "null" else i.Mutex.Mnemonic 
                        { cell = withMnemonic cv.Mnemonic (triv i.Mutex (fun () -> new Date(i.Value)) :?> ICell<'T>)
                        ; source =  "(triv " + mut + " (fun () -> new Date(_" + cv.Mnemonic + ".Value)))"
                        }
                    else
                        { cell = cv :?> ICell<'T>
                        ; source = "_" + s
                        }
                elif cv :? ICell<DateTime> then 
                    let d = cv :?> ICell<DateTime>
                    let mut = if d.Mutex = null || d.Mutex.Mnemonic = null then "null" else d.Mutex.Mnemonic 
                    if typeof<'T> = typeof<int> then
                        { cell = withMnemonic cv.Mnemonic (triv d.Mutex (fun () -> (Convert.ToInt32(d.Value.ToOADate()) :> obj) :?> 'T))
                        ; source =  "(triv " + mut + " (fun () -> int (_" + s + ".Value.ToOADate())))"
                        }
                    else
                        { cell = withMnemonic cv.Mnemonic (triv d.Mutex (fun () -> ((d.Value.ToOADate()) :> obj) :?> 'T))
                        ; source =  "(triv " + mut + " (fun () -> " + s + ".Value.ToOADate()))"
                        }
                elif typeof<'T>.IsEnum then
                    let en = Enum.Parse(typeof<'T>, o.ToString()) :?> 'T
                    { cell = withMnemonic attribute (value en)
                    ; source =  "(value " + typeof<'T>.Name + "." + en.ToString() + ")"
                    }
                else
                    invalidArg (o.ToString()) ("Invalid " + attribute + " ")
            elif o :? 'T then
                { cell = triv null (fun () -> o :?> 'T)
                ; source =  "(triv null (fun () -> " + " _" + s + " :> " + (genericTypeString typeof<'T>) + "))"
                }
            else
                invalidArg (o.ToString()) ("Invalid " + attribute + " ")
        elif typeof<'T> = typeof<Date> &&  o :? double then
            if o :? double then
                let d = o :?> double
                { cell = (value (new Date (int d))) :?> ICell<'T>
                ; source =  "(value (new Date(int (" + d.ToString() + "))))"
                }
            elif o :? DateTime then
                let t = o :?> DateTime
                { cell = (value (new Date(int (t.ToOADate())))) :?> ICell<'T>
                ; source =  "(value (Date(int (" + t.ToOADate().ToString() + "))))"
                }
            else
                { cell = value (o :?> 'T)
                ; source =  "(value (" + o.ToString() + " :?> " + (genericTypeString typeof<'T>) + "))"
                }
        elif typeof<'T> = typeof<bool>  && o :? bool then
            { cell = (value (o :?> 'T))
            ; source =  "(value " + o.ToString().ToLower() + ")"
            }
        elif o :? 'T && not typeof<'T>.IsValueType then 
            { cell = (value (o :?> 'T))
            ; source =  "(value (" + o.ToString() + " :?> " + (genericTypeString typeof<'T>) + "))"
            }
        else
            try
                if typeof<'T> = typeof<int> then 
                    { cell = (value (Convert.ToInt32(o)) :?> ICell<'T>)
                    ; source =  "(value (Convert.ToInt32(" + o.ToString() + ")))"
                    }
                elif typeof<'T> = typeof<double> then 
                    { cell = (value (Convert.ToDouble(o)) :?> ICell<'T>)
                    ; source =  "(value (Convert.ToDouble(" + o.ToString() + ")))"
                    }
                elif typeof<'T> = typeof<int64> then 
                    { cell = (value (Convert.ToInt64(o)) :?> ICell<'T>)
                    ; source =  "(value (Convert.ToInt64(" + o.ToString() + ")))"
                    }
                elif typeof<'T> = typeof<uint64> then 
                    { cell = (value (Convert.ToUInt64(o)) :?> ICell<'T>) 
                    ; source =  "(value (Convert.ToInt64(" + o.ToString() + ")))"
                    }
                elif typeof<'T> = typeof<string> then 
                    { cell = value (o.ToString() :> obj :?> 'T)
                    ; source =  "(value \"" + o.ToString() + "\")"
                    }
                else 
                    invalidArg (o.ToString()) ("Invalid " + attribute + " ")
            with | _ -> invalidArg (o.ToString()) ("Invalid " + attribute + " ")

    // Summary: convert value or use default
    let toDefault<'T> (o : obj) (attribute : string) (defaultValue : 'T) : CellSource<'T> = 
        if o = null || o :? ExcelDna.Integration.ExcelMissing then 
            let s = 

                try
                    if typeof<'T>.IsEnum then
                        let ty = typeof<'T>
                        if ty.IsNested then
                            ty.DeclaringType.Name + "." + ty.Name + "." + defaultValue.ToString()
                        else
                            ty.Name + "." + defaultValue.ToString()
                    else
                    let r = 
                        if typeof<'T> = typeof<bool> then
                            defaultValue.ToString().ToLower()
                        else
                            defaultValue.ToString()
                    if r.Contains("`1[") then
                        genericTypeString typeof<'T>
                    else
                        r
                with 
                | _ -> "(null :> " + (genericTypeString typeof<'T>) + ")"

            { cell = withMnemonic attribute (value defaultValue)
            ; source =  "(value " + s + ")"
            }
        else
            toCell<'T> o attribute

    // Summary: Convert the reference to a cell handle for QL legacy handle class
    let toHandle<'T when 'T :> IObservable and 'T : null and 'T : equality> (o : obj) (attribute : string) : CellSource<Handle<'T>> = 
        if o :? string then
            let s = o :?> string
            let c = Model.cell s
            if c.IsSome then 
                let s = if s.StartsWith("+") || s.StartsWith("-") then s.Substring(1) else s
                let c = c.Value
                let mut = if c.Mutex = null || c.Mutex.Mnemonic = null then "null" else c.Mutex.Mnemonic 
                if c:? ICell<'T> then 
                    let c = c :?> ICell<'T>
                    { cell = withMnemonic c.Mnemonic (triv c.Mutex (fun () -> Util.toHandle (c.Value)))
                    ; source =  "(triv " + mut + " (fun () -> toHandle (_" + c.Mnemonic + ".Value)))"
                    }
                elif c.ValueIs<'T>() then 
                    { cell = withMnemonic c.Mnemonic (triv c.Mutex (fun () -> Util.toHandle<'T> (c.Box :?> 'T)))
                    ; source = "(triv " + mut + " (fun () -> toHandle ((cast<" + (genericTypeString typeof<'T>) + "> _" + s + ").Value )))"
                    }

                else
                    { cell = withMnemonic c.Mnemonic (triv c.Mutex (fun () -> Util.toHandle<'T> (c.Box :?> 'T)))
                    ; source =  "(triv " + mut + " (fun () -> toHandle<" + (genericTypeString typeof<'T>) + "> (_" + c.Mnemonic + ".Value)))"
                    }
            else
                invalidArg (o.ToString()) ("Invalid " + attribute + " ")
        elif o :? 'T then 
            { cell =  withMnemonic (Model.formatMnemonic (o.ToString())) (triv null (fun () -> Util.toHandle (o :?> 'T)))
            ; source = "(triv null (fun () -> toHandle (" + o.ToString() + ")))"
            }
        else 
            invalidArg (o.ToString()) ("Invalid " + attribute + " ")

    // Summary: Convert the list to a cell handle for QL legacy handle class
    let toHandleList<'T when 'T :> IObservable and 'T : null and 'T : equality> (o : obj) (attribute : string) : CellSource<Generic.List<Handle<'T>>> = 
        if o :? string then
            let s = o :?> string
            let c = Model.cell s
            if c.IsSome then 
                let c = c.Value
                if c:? ICell<Generic.List<'T>> then 
                    let l = c :?> ICell<Generic.List<'T>>
                    let folder (a : CellSource<Generic.List<Handle<'T>>>) fo : CellSource<Generic.List<Handle<'T>>> = 
                        let h = toHandle fo attribute 
                        a.cell.Value.Add (h.cell.Value)
                        { cell = (a.cell)
                        ; source = a.source + ";" + h.source
                        }
                    let accu = 
                        l.Value |> Seq.fold folder ({cell = (value (new Generic.List<Handle<'T>> ())); source = "[|"})
                    { cell = accu.cell
                    ; source = "(new Generic.List<Handle<" + (genericTypeString typeof<'T>) + ">(" + accu.source.Replace("[|;", "[|") + "|]))" 
                    }
                else
                    invalidArg (o.ToString()) ("Invalid " + attribute + " ")
            else
                invalidArg (o.ToString()) ("Invalid " + attribute + " ")
        else 
            invalidArg (o.ToString()) ("Invalid " + attribute + " ")

    // Summary: convert value or use default
    let toDefaultHandle<'T when 'T :> IObservable and 'T : null and 'T : equality> (o : obj) (attribute : string) (defaultValue : Handle<'T>) : CellSource<Handle<'T>> = 
        if o = null || o :? ExcelDna.Integration.ExcelMissing then 
            let s = 
                try
                    let r = defaultValue.ToString()
                    if r.Contains("`1[") then
                        genericTypeString typeof<'T>
                    else
                        r
                with 
                | _ -> "(triv null (fun () -> toHandle (null :> " + (genericTypeString typeof<'T>) + ")))"

            { cell = withMnemonic attribute (value defaultValue)
            ; source =  "(value " + s + ")"
            }
        else
            toHandle<'T> o attribute

    // Summary: convert value or use default
    let toDefaultHandleList<'T when 'T :> IObservable and 'T : null and 'T : equality> (o : obj) (attribute : string) (defaultValue : Generic.List<Handle<'T>>) : CellSource<Generic.List<Handle<'T>>> = 
        if o = null || o :? ExcelDna.Integration.ExcelMissing then 
            let s = 
                try
                    let r = defaultValue.ToString()
                    if r.Contains("`1[") then
                        genericTypeString typeof<'T>
                    else
                        r
                with 
                | _ -> "(null :> " + (genericTypeString typeof<'T>) + ")"

            { cell = withMnemonic attribute (value defaultValue)
            ; source =  "(value (new " + s + "()))"
            }
        else
            toHandleList<'T> o attribute

    // Summary: Convert the reference to a cell handle for QL legacy handle class
    let toNullable<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> (o : obj) (attribute : string) : CellSource<Nullable<'T>> = 
        if o = null || o :? ExcelDna.Integration.ExcelMissing then 
            { cell = triv null (fun () -> new Nullable<'T>())
            ; source =  "(triv null (fun () -> new Nullable<" + (genericTypeString typeof<'T>) + ">()))"
            }
        elif o :? string then
            let s = o :?> string
            let c = Model.cell s
            let mut = if c.IsNone || c.Value.Mutex = null || c.Value.Mutex.Mnemonic = null then "null" else c.Value.Mutex.Mnemonic 
            if  c.IsSome then
                let c = c.Value :?> ICell<'T>
                { cell = triv c.Mutex (fun () -> Util.toNullable (c.Value))
                ; source = "(triv " + mut + " (fun () -> toNullable (_" + c.Mnemonic + ".Value)))"
                }
            else
                { cell = triv null (fun () -> Util.nullableNull<'T> ())
                ; source =  "(triv null (fun () -> nullableNull<" + (genericTypeString typeof<'T>) + "> ()))"
                }
        elif o :? 'T then 
            { cell = triv null (fun () -> Util.toNullable (o :?> 'T))
            ; source =  "(triv null (fun () -> toNullable (" + o.ToString() + ")))"
            }
        else 
            invalidArg (o.ToString()) ("Invalid " + attribute + " ")

    // Summary: Convert the list to a cell handle for QL legacy handle class
    let toNullabletList<'T when 'T : (new : unit -> 'T) and 'T : struct and 'T :> ValueType> (o : obj) (attribute : string) : CellSource<Generic.List<Nullable<'T>>> = 
        if o :? string then
            let s = o :?> string
            let c = Model.cell s
            if c.IsSome then 
                let c = c.Value
                if c:? ICell<Generic.List<'T>> then 
                    let l = c :?> ICell<Generic.List<'T>>
                    let folder (a : CellSource<Generic.List<Nullable<'T>>>) fo : CellSource<Generic.List<Nullable<'T>>> = 
                        let h = toNullable  fo attribute 
                        a.cell.Value.Add (h.cell.Value)
                        { cell = (a.cell)
                        ; source = a.source + ";" + h.source
                        }
                    let accu = 
                        l.Value |> Seq.fold folder ({cell = (value (new Generic.List<Nullable<'T>> ())); source = "[|"})
                    { cell = accu.cell
                    ; source = "(new Generic.List<Handle<" + (genericTypeString typeof<'T>) + ">(" + accu.source.Replace("[|;", "[|") + "|]))" 
                    }
                else
                    invalidArg (o.ToString()) ("Invalid " + attribute + " " )
            else
                { cell = value (new Generic.List<Nullable<'T>>())
                ; source = "(new Generic.List<Nullable<" + (genericTypeString typeof<'T>) + ">())" 
                }
        else 
            { cell = value (new Generic.List<Nullable<'T>>())
            ; source = "(new Generic.List<Nullable<" + (genericTypeString typeof<'T>) + ">())" 
            }
           
    let toModel<'T,'t when 'T :> Model<'t>> (o : obj) (attribute : string)  =
        if o :? string then 
            let s =  o :?> string
            let c = Model.cell s
            if c.IsSome && (c.Value :? 'T) then 
                let v = c.Value :?> 'T
                { cell = v
                ; source = "_" + c.Value.Mnemonic
                }
            else
                invalidArg (o.ToString()) ("Invalid " + attribute + " " )
        else
            invalidArg (o.ToString()) ("Invalid " + attribute + " " )

    let toModelReference<'T> (o : obj) (attribute : string)  =
        if o :? string then 
            let s =  o :?> string
            let c = Model.cell s
            if c.IsSome then
                let cv = c.Value
                if cv :? ICell<'T> then
                    { cell = cv :?> ICell<'T>
                    ; source = "_" + s
                    }
                else
                    { cell = cast<'T> cv
                    ; source = "_" + s
                    }
            else
                invalidArg (o.ToString()) ("Invalid " + attribute + " " )
        else
            invalidArg (o.ToString()) ("Invalid " + attribute + " " )
                

    let isNumeric (o : obj) : bool = 
        o.ToString().ToCharArray() |> Array.fold (fun a y -> if a && (Char.IsDigit(y) || y = '-' || y = '+' || y = '.' || y = 'e') then true else false) true

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)

    let sourceFold (s : string) (cs : string array) = 
        let s = if s.StartsWith("+") || s.StartsWith("-") then s.Substring(1) else s
        match cs with 
        | [||]  -> s
        | _     -> cs |> Array.fold (fun a y -> a + " " + if y.StartsWith("(") then y elif y.StartsWith("+") then (y.Substring(1)) elif y.StartsWith("-") then (y.Substring(1)) else y) s

    let sourceFoldArray (cs : string array) = 
        "[|" + (cs |> Array.fold (fun a y -> a + ";" + y) "").Substring(1) + "|]"

    let hashFold (cs : ICell array) = 
        let folder h (y : ICell) = 
            if not (y.Mnemonic = null) then 
                (h <<< 4) ^^^ y.Mnemonic.GetHashCode()
            elif (not (y.HasFunction) && not (y.Box = null)) then 
                (h <<< 4) ^^^ y.Box.ToString().GetHashCode()
            else 
                h
        cs |> Array.fold folder 0

    let hashFold2 (cs : ICell<'t> array) = 
        let folder h (y : ICell<'t>) = 
            if not (y.Mnemonic = null) then 
                (h <<< 4) ^^^ y.Mnemonic.GetHashCode()
            elif (not (y.HasFunction) && not (y.Box = null)) then 
                (h <<< 4) ^^^ y.Box.ToString().GetHashCode()
            else 
                h
        cs |> Array.fold folder 0

    module Range =
        let toArray (o : obj[,]) : obj array =
            o |> Seq.cast<obj> |> Seq.toArray

        let make c r v = Array2D.create<obj> c r v

        let fromArray (o : 'o array) (layout : string) : obj[,] =
            let len = o.Length
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 1 (Model.genericFormat o.[x]))
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 1 x (Model.genericFormat o.[x]))
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (Model.genericFormat o.[x]))
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (Model.genericFormat o.[x]))
                        range
        
        let spliceArray (o : 'o array) (layout : string) (range : obj[,])  (n : int): obj[,] =
            let min a b = if a < b then a else b
            match layout with 
            | "C"   ->  let len = min (Array2D.length1 range) o.Length
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x n (Model.genericFormat o.[x]))
                        range
            | _     ->  let len = min (Array2D.length2 range) o.Length
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range n x (Model.genericFormat o.[x]))
                        range

        let fromMatrix (o : Generic.List<Generic.List<'o>>) (layout : string) : obj[,] =
            let x = o.Count
            let y = o |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            let setter range x y o =
                try
                    Array2D.set range x y  (o :> obj)
                with
                | _ -> Array2D.set range x y ("#NA" :> obj)
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> setter range a b o.[b].[a])
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)} |> 
                        Seq.iter (fun (a,b) -> setter range a b o.[a].[b])
                        range

        let fromCellMatrix (o : ICell<Generic.List<Generic.List<'o>>>) (layout : string) : obj[,] =
            let l = o.Value
            let x = l.Count
            let y = l |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            let setter range x y o =
                try
                    Array2D.set range x y  (Model.genericFormat o)
                with
                | _ -> Array2D.set range x y ("#NA" :> obj)
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> setter range a b l.[b].[a])
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> setter range a b l.[a].[b])
                        range

        let fromHandleMatrix (o : ICell<Generic.List<Generic.List<Handle<'o>>>>) (layout : string) : obj[,] =
            let l = o.Value
            let x = l.Count
            let y = l |> Seq.fold (fun a y -> if y.Count > a then y.Count else a) 0
            let setter range x y o =
                try
                    Array2D.set range x y  (Model.genericFormat o)
                with
                | _ -> Array2D.set range x y ("#NA" :> obj)
            match layout with
            | "RT"
            | "R"   ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> setter range a b l.[b].[a])
                        range
            | _     ->  let range = Array2D.create<obj> x y null
                        seq { for a in 0..x do
                                for b in 0..y do
                                    (a,b)}
                        |> Seq.iter (fun (a,b) -> setter range a b l.[a].[b])
                        range


        let fromCell (cell : ICell<'t>) (layout : string) : obj[,] =
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> 1 2 null
                        Array2D.set range 0 0 (cell.Mnemonic :> obj)
                        Array2D.set range 0 1 (Model.genericFormat cell.Value)
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 1 null
                        Array2D.set range 0 0 (cell.Mnemonic :> obj)
                        Array2D.set range 1 0 (Model.genericFormat cell.Value)
                        range
            | _     ->  let range = Array2D.create<obj> 1 1 (Model.genericFormat cell.Value)
                        range


        let fromCellArray (cells : ICell<'t> array) (layout : string) : obj[,] =
            let len = cells.Length
            let setter range x y  (c : ICell<'t>)  =
                try
                    Array2D.set range x y  (Model.genericFormat c.Value)
                with
                | _ -> Array2D.set range x y ("#NA" :> obj)
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> setter range x 1 cells.[x])
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> setter range 1 x cells.[x])
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> setter range x 0 cells.[x])
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> setter range 0 x cells.[x])
                        range

        let fromModel (m : ICell<'t>) (layout : string) : obj[,] =
            let cells =
                (m :?> Model) |>
                Seq.sortBy (fun i -> i.Key) |>
                Seq.map (fun i -> i.Value) |>
                Seq.toArray
            let len = cells.Length
            let setter range x y  (c : ICell)  =
                try
                    Array2D.set range x y  (Model.genericFormat c.Box)
                with
                | _ -> Array2D.set range x y ("#NA" :> obj)
            match layout with 
            | "CT"  ->  let range = Array2D.create<obj> len 2 null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range x 0 (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> setter range 1 x cells.[x])
                        range
            | "RT"  ->  let range = Array2D.create<obj> 2 len null
                        seq {0..len-1} |> Seq.iter (fun x -> Array2D.set range 0 x (cells.[x].Mnemonic:> obj))
                        seq {0..len-1} |> Seq.iter (fun x -> setter range 1 x cells.[x])
                        range
            | "C"   ->  let range = Array2D.create<obj> len 1 null
                        seq {0..len-1} |> Seq.iter (fun x -> setter range x 0 cells.[x])
                        range
            | _     ->  let range = Array2D.create<obj> 1 len null
                        seq {0..len-1} |> Seq.iter (fun x -> setter range 0 x cells.[x])
                        range

        let fromModelList<'t> (m : Cephei.Cell.List<'t>) (layout : string) : obj[,] =
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
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r 0 x (Model.genericFormat cols.[x]))
                                r
                                
                    | "RT"  ->  let r =Array2D.create<obj> cols.Length (len + 1) null
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r x 0 (Model.genericFormat cols.[x]))
                                r 

                    | "C"   ->  Array2D.create<obj> len cols.Length null
                    | _     ->  Array2D.create<obj> cols.Length len null

                let splice (o : Model) (pos : int) =
                    
                    let setter x y (c : Model) (s : string) =
                        try
                            Array2D.set range x y (Model.genericFormat c.[s].Box)
                        with
                        | e -> Array2D.set range x y ("#NA" :> obj)
                    match layout with
                    | "CT"  ->  seq {0 ..len-1} |> Seq.iter (fun x -> setter (pos + 1) x o cols.[x])
                    | "RT"  ->  seq {0 ..len-1} |> Seq.iter (fun x -> setter x (pos + 1) o cols.[x])
                    | "C"   ->  seq {0 ..len-1} |> Seq.iter (fun x -> setter pos x o cols.[x])
                    | _     ->  seq {0 ..len-1} |> Seq.iter (fun x -> setter x pos o cols.[x])

                seq {0 .. len - 1} |> Seq.iter (fun x -> splice models.[x] x)
                range

        let fromList<'t> (l : Generic.List<'t>) (layout : string) : obj[,] =
            let obs  = l |> Seq.toArray 
            let len = obs.Length 
            if len = 0 then
                Array2D.create<obj> 0 0 null
            else
                let typ  = typeof<'t>
                let methods = 
                    //typ.GetMethods (BindingFlags.Public ||| BindingFlags.Instance ||| BindingFlags.DeclaredOnly)
                    typ.GetMethods ()
                    |> Array.filter (fun i ->  not (i.Name = "GetHashCode" || i.Name = "GetType" || i.Name = "ToString"))
                    |> Array.filter (fun i -> i.GetParameters().Length = 0)
                    |> Array.map (fun i -> (i.Name , (fun o -> i.Invoke(o, null))))
                    |> Array.toList
                let properties = 
                    typ.GetProperties()
                    |> Array.map (fun i -> (i.Name ,(fun o -> i.GetValue(o))))
                    |> Array.toList
                let both = 
                    methods @ properties
                    |> List.sortBy (fun  (n,f) -> n)
                    |> List.toArray
                let cols = 
                    both 
                    |> Array.map (fun (n,f) -> n)
                let frm = 
                    both 
                    |> Array.map (fun (n,f) -> f)

                let range = 
                    match layout with
                    | "CT"  ->  let r = Array2D.create<obj> (len + 1) cols.Length null
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r 0 x (Model.genericFormat cols.[x]))
                                r
                                
                    | "RT"  ->  let r =Array2D.create<obj> cols.Length (len + 1) null
                                seq {0 .. (cols.Length - 1)} |> Seq.iter (fun x -> Array2D.set r x 0 (Model.genericFormat cols.[x]))
                                r 

                    | "C"   ->  Array2D.create<obj> len cols.Length null
                    | _     ->  Array2D.create<obj> cols.Length len null

                let splice (o : obj) (pos : int) =
                    let setter x y  (c : obj) (n : int) =
                        try
                            Array2D.set range x y  (Model.genericFormat (frm.[n] c))
                        with
                        | _ -> Array2D.set range x y ("#NA" :> obj)
                    if not (o = null) then 
                        match layout with
                        | "CT"  ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> setter (pos + 1) x o x)
                        | "RT"  ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> setter x (pos + 1) o x)
                        | "C"   ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> setter pos x o x)
                        | _     ->  seq {0 ..(cols.Length - 1)} |> Seq.iter (fun x -> setter x pos o x)

                seq {0 .. len - 1} |> Seq.iter (fun x -> splice obs.[x] x)
                range
