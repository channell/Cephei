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
    [<ExcelFunction(Name="_AustraliaRegion", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AustraliaRegion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.AustraliaRegion 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AustraliaRegion>) l

                let source = Helper.sourceFold "Fun.AustraliaRegion" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AustraliaRegion_code", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AustraliaRegion_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "Reference to AustraliaRegion")>] 
         australiaregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion" true 
                let builder () = withMnemonic mnemonic ((_AustraliaRegion.cell :?> AustraliaRegionModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AustraliaRegion.source + ".Code") 
                                               [| _AustraliaRegion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_AustraliaRegion_Equals", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AustraliaRegion_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "Reference to AustraliaRegion")>] 
         australiaregion : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_AustraliaRegion.cell :?> AustraliaRegionModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AustraliaRegion.source + ".Equals") 
                                               [| _AustraliaRegion.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_AustraliaRegion_name", Description="Create a AustraliaRegion",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AustraliaRegion_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AustraliaRegion",Description = "Reference to AustraliaRegion")>] 
         australiaregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AustraliaRegion = Helper.toCell<AustraliaRegion> australiaregion "AustraliaRegion" true 
                let builder () = withMnemonic mnemonic ((_AustraliaRegion.cell :?> AustraliaRegionModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AustraliaRegion.source + ".Name") 
                                               [| _AustraliaRegion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AustraliaRegion.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_AustraliaRegion_Range", Description="Create a range of AustraliaRegion",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AustraliaRegion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AustraliaRegion")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AustraliaRegion> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AustraliaRegion>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AustraliaRegion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AustraliaRegion>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
