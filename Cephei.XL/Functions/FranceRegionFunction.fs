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
  France as geographical/economic region
  </summary> *)
[<AutoSerializable(true)>]
module FranceRegionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FranceRegion", Description="Create a FranceRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FranceRegion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.FranceRegion ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FranceRegion>) l

                let source () = Helper.sourceFold "Fun.FranceRegion" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FranceRegion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FranceRegion_code", Description="Create a FranceRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FranceRegion_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FranceRegion",Description = "FranceRegion")>] 
         franceregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FranceRegion = Helper.toCell<FranceRegion> franceregion "FranceRegion"  
                let builder (current : ICell) = ((FranceRegionModel.Cast _FranceRegion.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FranceRegion.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FranceRegion.cell
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
    [<ExcelFunction(Name="_FranceRegion_Equals", Description="Create a FranceRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FranceRegion_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FranceRegion",Description = "FranceRegion")>] 
         franceregion : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FranceRegion = Helper.toCell<FranceRegion> franceregion "FranceRegion"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((FranceRegionModel.Cast _FranceRegion.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FranceRegion.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FranceRegion.cell
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
    [<ExcelFunction(Name="_FranceRegion_name", Description="Create a FranceRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FranceRegion_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FranceRegion",Description = "FranceRegion")>] 
         franceregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FranceRegion = Helper.toCell<FranceRegion> franceregion "FranceRegion"  
                let builder (current : ICell) = ((FranceRegionModel.Cast _FranceRegion.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FranceRegion.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FranceRegion.cell
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
    [<ExcelFunction(Name="_FranceRegion_Range", Description="Create a range of FranceRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FranceRegion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FranceRegion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FranceRegion> (c)) :> ICell
                let format (i : Cephei.Cell.List<FranceRegion>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FranceRegion>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
