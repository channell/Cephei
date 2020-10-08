namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System


module Values = 

    [<ExcelFunction(Name="_Value", Description="Get the value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let Value 
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        =
        if mnemonic = null || mnemonic = "" then
            "#NA" :> obj
        else
           Model.value mnemonic


    [<ExcelFunction(Name="_Value_Range", Description="Get the range value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let ValueRange
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] layout : string) 
        : obj[,]
        =
        let layout = layout.ToUpper()

        if mnemonic = null || mnemonic = "" || layout = null || layout = "" then
            Array2D.create<obj> 0 1 "#NA"
        elif not (("CT, RT, C ,R").Contains(layout.ToUpper())) then 
            Model.range mnemonic ("C")
        else 
            Model.range mnemonic (layout.ToUpper())

(*********************************************************************************************************************************************************
    Int
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Int", Description="Set an int value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec Int 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] value : int) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value (Convert.ToInt32(value)) :> ICell
                ; subscriber = Helper.subscriber (fun (i:int) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Int_Range", Description="Set a referene for a list of ints",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
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
            let l = new Generic.List<int> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<int>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<int> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

(*********************************************************************************************************************************************************
    Long
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Long", Description="Set an long value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec Long 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] value : int) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value (Convert.ToInt64(value)) :> ICell
                ; subscriber = Helper.subscriber (fun (i:int) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Long_Range", Description="Set a referene for a list of ints",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
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
            let l = new Generic.List<int64> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<int64>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<int64> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
    Double
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Double", Description="Set a double value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec Double 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Double",Description = "Value")>] value : double) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value (Convert.ToDouble(value)) :> ICell
                ; subscriber = Helper.subscriber (fun (i:double) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Double_Range", Description="Set a referene for a list of doubles",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
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
            let l = new Generic.List<double> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<double> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
Bool
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Bool", Description="Set a bool value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec Bool
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Bool",Description = "Value")>] value : bool) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value (Convert.ToBoolean(value)) :> ICell
                ; subscriber = Helper.subscriber (fun (i:double) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Bool_Range", Description="Set a referene for a list of bools",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
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
            let l = new Generic.List<bool> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<bool>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<bool> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"


(*********************************************************************************************************************************************************
    DateTime
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_DateTime", Description="Set a DatTime value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec DateTimeFunction 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] value : DateTime) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value (Convert.ToDateTime(value)) :> ICell
                ; subscriber = Helper.subscriber (fun (i:DateTime) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_DaeTime_Range", Description="Set a referene for a list of DateTime",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec DateTimeRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.map (fun (i : obj) -> Convert.ToDateTime(i)) |>
                    Seq.toArray
            let l = new Generic.List<DateTime> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y.ToString()) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<double> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

(*********************************************************************************************************************************************************
    DateTime
 *********************************************************************************************************************************************************)
    [<ExcelFunction(Name="_Text", Description="Set a string value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec DAtimeFunction 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Text",Description = "Value")>] value : string) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            Model.specify 
                { mnemonic = mnemonic
                ; creator = fun () -> Util.value value :> ICell
                ; subscriber = Helper.subscriber (fun (i:string) (l:string) -> i :> obj)
                ; source = "(value " + value.ToString() + ")"
                ; hash = value.GetHashCode()
                } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Text_Range", Description="Set a referene for a list of DateTime",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let rec RateTimetRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="DateTime",Description = "Value")>] values : obj[,]) = 

        let mnemonic = (Model.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then

            let a = values |>
                    Seq.cast<obj> |>
                    Seq.map (fun (i : obj) -> i.ToString()) |>
                    Seq.toArray
            let l = new Generic.List<string> (a)
            let sa = "[|" + (Array.fold (fun a y -> a + ";" + y) "" a).Substring(1) + "|]"
            let builder () = Util.value l :> ICell
            let format (i : Generic.List<string>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

            Model.specify 
                { mnemonic = mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriberRange<string> format
                ; source = "cell new Generic.List<int>([|" + (a |> Array.fold (fun a y -> a + ";" + y.ToString()) "").Substring(1) + "|]"
                ; hash = Array.fold (fun a y -> (a <<< 4) ^^^ y.GetHashCode()) 0 a
                } :?> string
        else
            "<WIZ>"

