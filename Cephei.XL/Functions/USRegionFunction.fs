(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  USA as geographical/economic region
  </summary> *)
[<AutoSerializable(true)>]
module USRegionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USRegion", Description="Create a USRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USRegion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.USRegion ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USRegion>) l

                let source () = Helper.sourceFold "Fun.USRegion" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USRegion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USRegion_code", Description="Create a USRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USRegion_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USRegion",Description = "USRegion")>] 
         usregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USRegion = Helper.toCell<USRegion> usregion "USRegion"  
                let builder (current : ICell) = ((USRegionModel.Cast _USRegion.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USRegion.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USRegion.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USRegion_Equals", Description="Create a USRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USRegion_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USRegion",Description = "USRegion")>] 
         usregion : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USRegion = Helper.toCell<USRegion> usregion "USRegion"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((USRegionModel.Cast _USRegion.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USRegion.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USRegion.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_USRegion_name", Description="Create a USRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USRegion_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USRegion",Description = "USRegion")>] 
         usregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USRegion = Helper.toCell<USRegion> usregion "USRegion"  
                let builder (current : ICell) = ((USRegionModel.Cast _USRegion.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USRegion.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USRegion.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_USRegion_Range", Description="Create a range of USRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USRegion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USRegion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<USRegion> (c)) :> ICell
                let format (i : Cephei.Cell.List<USRegion>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<USRegion>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
