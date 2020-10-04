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

  </summary> *)
[<AutoSerializable(true)>]
module Fdm1dMesherFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Fdm1dMesher_dminus", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1dMesher",Description = "Reference to Fdm1dMesher")>] 
         fdm1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1dMesher = Helper.toCell<Fdm1dMesher> fdm1dmesher "Fdm1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((Fdm1dMesherModel.Cast _Fdm1dMesher.cell).Dminus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Fdm1dMesher.source + ".Dminus") 
                                               [| _Fdm1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1dMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_Fdm1dMesher_dplus", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1dMesher",Description = "Reference to Fdm1dMesher")>] 
         fdm1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1dMesher = Helper.toCell<Fdm1dMesher> fdm1dmesher "Fdm1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((Fdm1dMesherModel.Cast _Fdm1dMesher.cell).Dplus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Fdm1dMesher.source + ".Dplus") 
                                               [| _Fdm1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1dMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_Fdm1dMesher", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic (Fun.Fdm1dMesher 
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Fdm1dMesher>) l

                let source = Helper.sourceFold "Fun.Fdm1dMesher" 
                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Fdm1dMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Fdm1dMesher_location", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1dMesher",Description = "Reference to Fdm1dMesher")>] 
         fdm1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1dMesher = Helper.toCell<Fdm1dMesher> fdm1dmesher "Fdm1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((Fdm1dMesherModel.Cast _Fdm1dMesher.cell).Location
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Fdm1dMesher.source + ".Location") 
                                               [| _Fdm1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1dMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_Fdm1dMesher_locations", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1dMesher",Description = "Reference to Fdm1dMesher")>] 
         fdm1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1dMesher = Helper.toCell<Fdm1dMesher> fdm1dmesher "Fdm1dMesher"  
                let builder () = withMnemonic mnemonic ((Fdm1dMesherModel.Cast _Fdm1dMesher.cell).Locations
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Fdm1dMesher.source + ".Locations") 
                                               [| _Fdm1dMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1dMesher.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Fdm1dMesher_size", Description="Create a Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1dMesher",Description = "Reference to Fdm1dMesher")>] 
         fdm1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1dMesher = Helper.toCell<Fdm1dMesher> fdm1dmesher "Fdm1dMesher"  
                let builder () = withMnemonic mnemonic ((Fdm1dMesherModel.Cast _Fdm1dMesher.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Fdm1dMesher.source + ".Size") 
                                               [| _Fdm1dMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1dMesher.cell
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
    [<ExcelFunction(Name="_Fdm1dMesher_Range", Description="Create a range of Fdm1dMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1dMesher_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Fdm1dMesher")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Fdm1dMesher> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Fdm1dMesher>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Fdm1dMesher>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Fdm1dMesher>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
