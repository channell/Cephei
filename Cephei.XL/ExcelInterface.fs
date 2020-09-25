namespace Cephei.XL

open System;
(*
[<AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)>]
type ExcelFunctionAttribute (Name : string, Description : string, IsThreadSafe : bool, IsExceptionSafe : bool, Category : string) = 
    inherit Attribute ()

    let _name = Name
    let _description = Description
    let _isThreadSafe = IsExceptionSafe
    let _isExceptionSafe = IsExceptionSafe
    let _category = Category

    member this.Name = _name
    member this.Description = _description
    member this.IsThreadSafe = _isThreadSafe
    member this.IsExceptionSafe = _isExceptionSafe
    member this.Category = _category

type ExcelArgumentAttribute (Name : string, Description : string) =
    inherit Attribute()

    let _name = Name
    let _description = Description

    member this.Name = _name
    member this.Description = _description
*)

// Summary:  interface that functions will use to foreard events to Excel
type IValueRTD = 
    abstract UpdateValue : string -> string -> obj -> unit
    abstract UpdateRange : string -> string -> obj[,] -> unit

type IExcelInterace =    

    abstract IsInFunctionWizard : unit -> bool
    abstract ModelRTD : string -> string -> obj
    abstract ValueRTD : string -> string -> obj

(*
    Summary: Stubbed interface 
*)
type ExcelStub (f : string -> string-> obj[,] -> unit) =

    let _f = f

    interface IExcelInterace with
        member this.IsInFunctionWizard () = false
        member this.ModelRTD  (mnemonic : string) (hashcode : string) = null :> obj    
        member this.ValueRTD  (mnemonic : string) (layout : string) = null :> obj

    interface IValueRTD with 
        member this.UpdateValue (mnemonic : string) (layout : string) (value : obj) = 
            ignore 1

        member this.UpdateRange (mnemonic : string) (layout : string) (value : obj[,]) = 
            _f mnemonic layout value
