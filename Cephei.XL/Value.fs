namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System


module Values = 

    [<ExcelFunction(Name="_Value", Description="Get the value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Value 
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        =
        if mnemonic = null || mnemonic = "" || mnemonic.StartsWith("#")  then
            "#NA" :> obj
        else
            Model.value mnemonic

    [<ExcelFunction(Name="_Value_Range", Description="Get the range value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ValueRange
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        ([<ExcelArgument(Name="Layout", Description="C: Column, R:Row, CT:Column with title, RT:Row with Titles")>] layout : string) 
        : obj[,]
        =
        let layout = layout.ToUpper()

        if mnemonic = null || mnemonic = "" || layout = null || layout = "" || mnemonic.StartsWith("#") then
            Array2D.create<obj> 0 1 "#NA"
        elif not (("CT, RT, C ,R").Contains(layout.ToUpper())) then 
            Model.range mnemonic ("C")
        else 
            Model.range mnemonic (layout.ToUpper())

(*********************************************************************************************************************************************************
    Int
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Int", Description="Set an int value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec Int 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] value : int) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<int> then
                (current :?> ICell<int>).Value <- value
                current
            else
                Util.value (Convert.ToInt32(value)) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:int) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value (Convert.ToInt32(" + value.ToString() + ")))")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Int_Range", Description="Set a referene for a list of ints",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec IntRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.filter (fun (i : obj) -> Helper.isNumeric i ) |>
                    Seq.map (fun (i : obj) -> Convert.ToInt32(i)) |>
                    Seq.toArray
            let l = new List<int> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<int> format
                ; source =  (fun () -> "(new Cephei.Cell.List<int>([|" + (a |> Array.fold (fun a y -> a + "; Convert.ToInt32(" + y.ToString() + "") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

(*********************************************************************************************************************************************************
    Long
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Long", Description="Set an long value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec Long 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] value : int) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<int64> then
                (current :?> ICell<int64>).Value <- Convert.ToInt64(value)
                current
            else
                Util.value (Convert.ToInt64(value)) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:int) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value (Convert.ToInt64(" + value.ToString() + ")))")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Long_Range", Description="Set a referene for a list of ints",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec LongRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.filter (fun (i : obj) -> Helper.isNumeric i ) |>
                    Seq.map (fun (i : obj) -> Convert.ToInt64(i)) |>
                    Seq.toArray
            let l = new List<int64> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<int64>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<int64> format
                ; source =  (fun () -> "(new Cephei.Cell.List<int64>([|" + (a |> Array.fold (fun a y -> a + "; Convert.ToInt64(" + y.ToString() + "") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
    Double
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Double", Description="Set a double value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec Double 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Double",Description = "Value")>] value : double) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<double> then
                (current :?> ICell<double>).Value <- value
                current
            else
                Util.value (Convert.ToDouble(value)) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:double) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value (Convert.ToDouble(" + value.ToString() + ")))")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Double_Range", Description="Set a referene for a list of doubles",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec DoubleRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Double",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.filter (fun (i : obj) -> Helper.isNumeric i ) |>
                    Seq.map (fun (i : obj) -> Convert.ToDouble(i)) |>
                    Seq.toArray
            let l = new List<double> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<double> format
                ; source =  (fun () -> "(new Cephei.Cell.List<double>([|" + (a |> Array.fold (fun a y -> a + "; Convert.ToDouble(" + y.ToString() + "") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
Bool
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Bool", Description="Set a bool value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec Bool
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Bool",Description = "Value")>] value : double) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<bool> then
                (current :?> ICell<bool>).Value <- Convert.ToBoolean(value)
                current
            else
                Util.value (Convert.ToBoolean(value)) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:double) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value (Convert.ToBoolean(" + value.ToString() + ")))")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Bool_Range", Description="Set a referene for a list of bools",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec BoolRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Bools",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.filter (fun (i : obj) -> Helper.isNumeric i ) |>
                    Seq.map (fun (i : obj) -> Convert.ToBoolean(i)) |>
                    Seq.toArray
            let l = new List<bool> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<bool>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<bool> format
                ; source =  (fun () -> "(new Cephei.Cell.List<bool>([|" + (a |> Array.fold (fun a y -> a + "; Convert.ToBoolean(" + y.ToString() + "") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
    DateTime
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_DateTime", Description="Set a DatTime value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec DateTimeFunction 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] value : double) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<DateTime> then
                (current :?> ICell<DateTime>).Value <- DateTime.FromOADate(value)
                current
            else
                Util.value (DateTime.FromOADate(value)) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:DateTime) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value (DateTime.FromOADate(" + value.ToString() + ")))")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_DaeTime_Range", Description="Set a referene for a list of DateTime",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec DateTimeRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.map (fun (i : obj) -> DateTime.FromOADate(Convert.ToDouble(i))) |>
                    Seq.toArray
            let l = new List<DateTime> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<DateTime>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<DateTime> format
                ; source =  (fun () -> "(new Cephei.Cell.List<DateTime>([|" + (a |> Array.fold (fun a y -> a + "; DateTime.FromOADate(" + y.ToString() + "") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

(*********************************************************************************************************************************************************
    String
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Text", Description="Set a string value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec StringFunction 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Text",Description = "Value")>] value : string) = 

        let mnemonic = (Model.formatMnemonic mnemonic)
        let builder (current : ICell) = 
            if current :? ICell<string> then
                (current :?> ICell<string>).Value <- value
                current
            else
                Util.value (value) :> ICell

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber (fun (i:string) (l:string) -> i :> obj)
                ; source =  (fun () -> "(value \"" + value.ToString() + "\")")
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Text_Range", Description="Set a referene for a list of DateTime",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let rec StringRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.map (fun (i : obj) -> i.ToString()) |>
                    Seq.toArray
            let l = new List<string> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y) "" a).Substring(1) + "|]"
            let builder (current : ICell) = l :> ICell
            let format (i : Generic.List<string>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<string> format
                ; source =  (fun () -> "(cell (fun () -> new List<string>([|" + (a |> Array.fold (fun a y -> a + ";\"" + y.ToString() + "\"") "").Substring(1) + "|])))")
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

