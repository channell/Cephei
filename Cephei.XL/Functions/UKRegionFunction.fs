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
  United Kingdom as geographical/economic region
  </summary> *)
[<AutoSerializable(true)>]
module UKRegionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UKRegion", Description="Create a UKRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRegion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.UKRegion ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UKRegion>) l

                let source = Helper.sourceFold "Fun.UKRegion" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRegion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRegion_code", Description="Create a UKRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRegion_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRegion",Description = "Reference to UKRegion")>] 
         ukregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRegion = Helper.toCell<UKRegion> ukregion "UKRegion"  
                let builder () = withMnemonic mnemonic ((UKRegionModel.Cast _UKRegion.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UKRegion.source + ".Code") 
                                               [| _UKRegion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRegion.cell
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
    [<ExcelFunction(Name="_UKRegion_Equals", Description="Create a UKRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRegion_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRegion",Description = "Reference to UKRegion")>] 
         ukregion : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRegion = Helper.toCell<UKRegion> ukregion "UKRegion"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((UKRegionModel.Cast _UKRegion.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UKRegion.source + ".Equals") 
                                               [| _UKRegion.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRegion.cell
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
    [<ExcelFunction(Name="_UKRegion_name", Description="Create a UKRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRegion_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRegion",Description = "Reference to UKRegion")>] 
         ukregion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRegion = Helper.toCell<UKRegion> ukregion "UKRegion"  
                let builder () = withMnemonic mnemonic ((UKRegionModel.Cast _UKRegion.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UKRegion.source + ".Name") 
                                               [| _UKRegion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRegion.cell
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
    [<ExcelFunction(Name="_UKRegion_Range", Description="Create a range of UKRegion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRegion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UKRegion")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UKRegion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UKRegion>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<UKRegion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<UKRegion>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
