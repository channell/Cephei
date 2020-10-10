namespace Cephei.XL

//open ExcelDna.Integration
//open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections.Generic
open System.Collections
open System
open System.Threading

module public  Model =

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)
    // apply a generic format for conversion to Excel types
    let rec genericFormat (o : obj) : obj =
        try
            let enumerate (e : IEnumerable) = 
                let i = e.GetEnumerator()
                seq {while i.MoveNext() do i.Current} 
            let trim o =
                let min a b = if a < b then a else b
                let s = o.ToString()
                if s = null then
                    null
                elif s = "" then
                    s
                elif s.StartsWith(",") then
                    s.Substring(1,min (s.Length - 1) 254)
                else
                    s.Substring(0,min s.Length 255)
            match o with
            | :? string -> trim o :> obj
            | :? DateTime as d -> d.ToOADate() :> obj
            | :? QLNet.Date as d -> d.serialNumber() :> obj
            | :? Enum as e -> e.ToString() :> obj
            | :? IEnumerable as e -> trim (enumerate e |> Seq.fold (fun a y -> a + "," + (genericFormat y).ToString()) "") :> obj
            | :? ICell as c -> genericFormat c.Box
            | _ -> trim (o.ToString()) :> obj
        with 
        | e -> "#" + e.Message :> obj

    let formatMnemonic (s : string) =
        if s = null || s = "" then 
            "NA"
        else
            let filter = 
                s.ToCharArray() |>
                Array.filter (fun i -> Char.IsLetterOrDigit (i) && not (i = '.'))
            if Char.IsDigit( filter.[0]) then
                "N" + new string (filter);
            else
                if s.StartsWith("+") then 
                    "+" + (new string (filter))
                elif s.StartsWith("-") then
                    "+" + (new string (filter))
                else
                    new string (filter)

    let getState () = 
        let modelName = "ModelState"
        let mutable state = AppDomain.CurrentDomain.GetData(modelName)
        if state = null then
            state <- new ModelState ()
            AppDomain.CurrentDomain.SetData(modelName, state)
        state :?> ModelState

    let _state = lazy getState()

    let setRange m l o =
        _state.Value.Ranges.[kv m l] <- o

    let hasRange m l =
        _state.Value.Ranges.ContainsKey (kv m l)

    let clearRange s =
        _state.Value.Ranges |> 
        Seq.filter (fun i -> i.Key.Key = s) |>
        Seq.toList |>
        List.iter (fun i -> _state.Value.Ranges.TryRemove( i.Key) |> ignore)

    let mutable xlInterface             = (new ExcelInterface (setRange) ) :> IExcelInterace

    let IsInFunctionWizard () = 
        xlInterface.IsInFunctionWizard ()

    // Subscribe to the objct 
    let subscribe (rtd : IValueRTD) (mnemonic : string) (layout : string) = 
        if _state.Value.Subscriber.ContainsKey (mnemonic) then 

            let f = _state.Value.Subscriber.[mnemonic]
            let c = _state.Value.Model.[mnemonic]
            let d = f rtd c layout
            d
        else
            null :> IDisposable

    let nextVersion () =
        _state.Value.Version <- _state.Value.Version + 1

    let add (s: string) = 
        if _state.Value.Rtd.ContainsKey(s) then
            let sub = _state.Value.Rtd.[s]
            let current = 
                if (_state.Value.Model.ContainsKey (sub.mnemonic)) then 
                    _state.Value.Model.[sub.mnemonic]
                else
                    null :> ICell
            let cell = 
                let c = sub.creator(current)
                if c :? ITrivial then 
                    let t = c :?> ITrivial
                    t.ToCell ()
                else
                    c
            cell.Mnemonic <- sub.mnemonic
            if not (current = cell) then 
                _state.Value.Model.[sub.mnemonic] <- cell
                _state.Value.Source.[sub.mnemonic] <- sub.source()
                _state.Value.Subscriber.[sub.mnemonic] <- sub.subscriber
            _state.Value.Rtd.TryRemove (s) |> ignore

    // Register a functor to create a cell if requried
    let specify (spec : spec) : obj =
      
        _state.Value.Rtd.[spec.mnemonic] <- spec
        let xlv = xlInterface.ModelRTD spec.mnemonic ((spec.hash ^^^ _state.Value.Version) .ToString())
        if xlv = null then 
            add spec.mnemonic
            spec.mnemonic :> obj
        else
            xlv
    // Register and get the value of a single obj
    let value (mnemonic : string) : obj =
        let xlv = xlInterface.ValueRTD mnemonic ""
        if xlv = null then 
            add mnemonic
            mnemonic :> obj
        elif xlv :? string && not ((xlv :?> string) = mnemonic) then
            try
                genericFormat (_state.Value.Model.[mnemonic].Box)
            with
            | ex -> "#" + ex.Message :> obj
        else
            xlv

    // Register and get the value from a range
    let range (mnemonic : string) (layout : string) : obj[,] =
        let k = kv mnemonic layout
        let xlv = xlInterface.ValueRTD mnemonic layout 
        if _state.Value.Ranges.ContainsKey(k) then
                _state.Value.Ranges.[k]
        else 
            Array2D.create<obj> 1 1 "#NoValue"

    let remove s = 
        if _state.Value.Model.ContainsKey(s) then
            let cell = _state.Value.Model.[s]
            let mutable cell2 = cell
            if _state.Value.Model.TryRemove (s, ref cell2) then
                if not (cell = null) then
                    cell.Dependants|> Seq.iter (fun d -> if not (d = null) then d.OnChange (CellEvent.Link, cell, DateTime.Now, null ))
                _state.Value.Source.TryRemove s |> ignore
                _state.Value.Subscriber.TryRemove s |> ignore

    let cell mnemonic : ICell option = 
        let m = _state.Value.Model
        if m.ContainsKey(mnemonic) then 
            Some m.[mnemonic]
        else 
            None

    let contains mnemonic = 
        _state.Value.Model.ContainsKey mnemonic

    let sourcecode (name : string) = 
        let tieredCells (model : Model) =

            let rec depth (cell : ICell) = 
                let max a b = if a > b then a else b
                cell.Dependants |> 
                Seq.filter (fun i -> i :? ICell) |>
                Seq.map (fun i -> i :?> ICell) |>
                Seq.map (fun i -> (i, i.Box)) |>
                Seq.fold (fun a (y,x) -> a + 1 + (depth y)) 0

            model |>
            Seq.map (fun i -> (i.Value, depth i.Value)) |>
            Seq.toArray |>
            Array.sortBy (fun (c,d) -> d ) |>
            Array.rev

        let tiers = 
            tieredCells _state.Value.Model

        let strip (s : string) = 
            if s.StartsWith("+") || s.StartsWith("-") then 
                s.Substring(1)
            else    
                s

        let cells = 
            tiers |>
            Array.filter (fun (c,d) -> _state.Value.Source.ContainsKey c.Mnemonic) |>
            Array.map (fun (c,d) -> (c, _state.Value.Source.[c.Mnemonic]))

        let constructors = 
            fst (
                cells |>
                Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
                Array.map (fun (c,s) -> sprintf "%s : ICell<%s>\n" (strip c.Mnemonic) (c.Box.GetType().ToString())) |>
                Array.fold (fun (s,d) y -> (s + "    " + d + y,",")) ("", "(") 
                )

        let functions =
            cells |> 
            Array.map (fun (c,s) -> sprintf "    let _%s = %s\n" (strip c.Mnemonic) (if c.Mnemonic.StartsWith("+") then (strip c.Mnemonic) else s)) |>
            Array.fold (fun a y -> a + y) "\n(* functions *)\n"

        let members = 
            cells |> 
            Array.filter (fun (c,s) -> not (c.Mnemonic.StartsWith ("-"))) |>
            Array.map (fun (c,s) -> sprintf "    member this.%s = _%s\n" (strip c.Mnemonic) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) "\n(* Externally visible/bindable properties *)\n"

        let excelParameters = 
            cells |>
            Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
            Array.map (fun (c,s) -> sprintf "        ([<ExcelArgument(Name=\"__%s\",Description = \"reference to %s\")>]\n        %s : obj)\n" (strip c.Mnemonic) (strip c.Mnemonic) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) ""

        let excelCasts = 
            cells |>
            Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
            Array.map (fun (c,s) -> sprintf "                let _%s = Helper.toCell<%s> %s \"%s\"\n" (strip c.Mnemonic) (c.Box.GetType().ToString()) (strip c.Mnemonic) (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) ""

        let excelBuilder = 
            cells |>
            Array.filter (fun (c,s) -> (c.Mnemonic.StartsWith("+"))) |>
            Array.map (fun (c,s) -> sprintf "                                                            _%s.cell\n" (strip c.Mnemonic)) |>
            Array.fold (fun a y -> a + y) ""

        let excelsource : string = 
            let buff = 
                fst (
                    cells |>
                    Array.filter (fun (c,s) -> c.Mnemonic.StartsWith("+")) |>
                    Array.map (fun (c,s) -> sprintf "_%s.source\n" (strip c.Mnemonic)) |>
                    Array.fold (fun (s,d) y -> (s + "                                               " + d + y,";  ")) ("", "[| ") 
                    )
            if buff = "" then 
                "                                               [|"
            else
                buff

        let excelhash = 
            let buff = 
                fst (
                    cells |>
                    Array.filter (fun (c,s) -> (c.Mnemonic.StartsWith("+"))) |>
                    Array.map (fun (c,s) -> sprintf "_%s.cell\n" (strip c.Mnemonic)) |>
                    Array.fold (fun (s,d) y -> (s + "                                " + d + y,";  ")) ("", "[| ") 
                    )
            if buff = "" then 
                "                                [|"
            else
                buff

        let formatProperty (n : string) (p : string) (t : string) = 
            String.Format ("
    [<ExcelFunction(Name=\"__{0}_{1}\", Description=\"Create a {2}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the value\")>] 
         mnemonic : string)
        ([<ExcelArgument(Name=\"{0}\",Description = \"Reference to {0}\")>] 
         {1} : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _{0} = Helper.toCell<{0}> {0} \"{0}\"  
            let builder (current : ICell) = withMnemonic mnemonic (_{0}.cell :> {0}).{1}) :> ICell
            let format (o : {2}) (l:string) = o.Helper.Range.fromModel (i :?> {1}) l
            let source () = (_{0}.source + \".{1}\")
            let hash = Helper.hashFold [| _{0}.cell |]
            Model.specify 
                {{ mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                }} :?> string
            with
            | _ as e ->  \"#\" + e.Message
        else
            \"<WIZ>\"
                            ", n, p, t)

        let excelProperties = 
            cells |>
            Array.filter (fun (c,s) -> not (c.Mnemonic.StartsWith("-"))) |>
            Array.map (fun (c,s) -> formatProperty name c.Mnemonic (c.Box.GetType().ToString())) |>
            Array.fold (fun a y -> a + y) ""


        String.Format ("
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type {0} 
{1}) as this =
    inherit Model ()
{2}
    do this.Bind ()
{3}

#if EXCEL
module {0}Function =

    [<ExcelFunction(Name=\"__{0}\", Description=\"Create a {0}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let {0}_create
        ([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the value\")>] 
         mnemonic : string)
{4}
        = 
        if not (Model.IsInFunctionWizard()) then

            try
{5}
                let builder (current : ICell) = withMnemonic mnemonic (new {0}
{6}
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> {0}) l
                let source () = Helper.sourceFold \"new {0}\"
{7}                                               |]

                let hash = Helper.hashFold
{8}                                |]
                Model.specify 
                    {{ mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<{0}> format
                    ; source = source 
                    ; hash = hash
                    }} :?> string
                        with
                        | _ as e ->  \"#\" + e.Message
        else
            \"<WIZ>\"
{9}
#endif
", name, constructors, functions, members, excelParameters, excelCasts, excelBuilder, excelsource, excelhash, excelProperties )
