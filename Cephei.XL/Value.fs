namespace Cephei.XL

open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System


module Values = 

    [<ExcelFunction(Name="_Value", Description="Get the value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false,IsMacroType=true, IsVolatile=true)>]
    let Value 
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        =
        if mnemonic = null || mnemonic = "" then
            "#NA" :> obj
        else
           Model.value mnemonic


    [<ExcelFunction(Name="_Value_Range", Description="Get the range value of Cephei reference",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false,IsMacroType=true, IsVolatile=true)>]
    let ValueRange
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] mnemonic : string) 
        ([<ExcelArgument(Name="Mnemonic", Description="Identifier")>] layout : string) 
        =
        let layout = layout.ToUpper()

        if mnemonic = null || mnemonic = "" || layout = null || layout = "" then
            Array2D.create<obj> 0 1 "#NA"
        elif not (("CT, RT, C ,R").Contains(layout)) then 
            Array2D.create<obj> 1 1 "#Invalid Layout"
        else
            Model.range mnemonic (layout.ToUpper())

    [<ExcelFunction(Name="_Int", Description="Set an int value ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false,IsMacroType=true)>]
    let rec Int 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] value : obj) = 

        let mnemonic = (Helper.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            if value :? ExcelMissing then
                "#NA"
            else
                if value :? ExcelReference then
                    let er = value :?> ExcelReference
                    Int mnemonic er

                elif value :? obj[,] then
                    "#Use _Int_Range"
                else
                    Model.specify 
                        { mnemonic = mnemonic
                        ; creator = fun () -> Util.value (Convert.ToInt32(value)) :> ICell
                        ; subscriber = Helper.subscriber (fun (i:int) (l:string) -> i :> obj)
                        ; source = "value " + value.ToString()
                        ; hash = value.GetHashCode()
                        } :?> string
        else
            "<WIZ>"


    [<ExcelFunction(Name="_Int_Range", Description="Set a referene for a list of ints",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false,IsMacroType=true, IsVolatile=true)>]
    let rec IntRange 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] mnemonic : string)  
        ([<ExcelArgument(Name="Int",Description = "Value")>] values : obj) = 

        let mnemonic = (Helper.formatMnemonic mnemonic)

        if not (Model.IsInFunctionWizard()) then
            if values :? ExcelReference then

                let er = values :?> ExcelReference
                IntRange mnemonic er.InnerReferences

            elif values :? obj[,] then
                let values = values :?> obj[,]

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
                "#NotRange"
        else
            "<WIZ>"