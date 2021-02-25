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

open System;
open System.Collections.Generic
open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open Cephei.QL

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
        member this.ModelRTD  (mnemonic : string) (hashcode : string)  = null :> obj    
        member this.ValueRTD  (mnemonic : string) (layout : string) = null :> obj

    interface IValueRTD with 
        member this.UpdateValue (mnemonic : string) (layout : string) (value : obj) = 
            ignore 1

        member this.UpdateRange (mnemonic : string) (layout : string) (value : obj[,]) = 
            _f mnemonic layout value

type ExcelInterface (f : string -> string-> obj[,] -> unit) =

    let _f = f

    interface IExcelInterace with

        member this.IsInFunctionWizard () = 
            ExcelDnaUtil.IsInFunctionWizard()

        member this.ModelRTD  (mnemonic : string) (hashcode : string) = 
            XlCall.RTD ("Cephei.XL.ModelRTD", null, mnemonic, hashcode)

        member this.ValueRTD  (mnemonic : string) (layout : string) = 
            XlCall.RTD ("Cephei.XL.ValueRTD", null, mnemonic, layout)
            

 
