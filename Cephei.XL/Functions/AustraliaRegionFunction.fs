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
  Australia as geographical/economic region
  </summary> *)
[<AutoSerializable(true)>]
module AustraliaRegionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AustraliaRegion", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AustraliaRegion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.AustraliaRegion ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AustraliaRegion>) l

                let source () = Helper.sourceFold "Fun.AustraliaRegion" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AustraliaRegion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AustraliaRegion_code", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AustraliaRegion_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "AustraliaRegion")>] 
         australiaregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion"  
                let builder (current : ICell) = withMnemonic mnemonic ((AustraliaRegionModel.Cast _AustraliaRegion.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AustraliaRegion.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
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
    [<ExcelFunction(Name="_AustraliaRegion_Equals", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AustraliaRegion_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "AustraliaRegion")>] 
         australiaregion : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((AustraliaRegionModel.Cast _AustraliaRegion.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AustraliaRegion.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
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
    [<ExcelFunction(Name="_AustraliaRegion_name", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AustraliaRegion_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "AustraliaRegion")>] 
         australiaregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion"  
                let builder (current : ICell) = withMnemonic mnemonic ((AustraliaRegionModel.Cast _AustraliaRegion.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AustraliaRegion.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
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
    [<ExcelFunction(Name="_AustraliaRegion_Range", Description="Create a range of AustraliaRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AustraliaRegion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AustraliaRegion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<AustraliaRegion> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<AustraliaRegion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AustraliaRegion>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
