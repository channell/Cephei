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
module Concentrating1dMesherFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Concentrating1dMesher1", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="cPoints",Description = "Reference to cPoints")>] 
         cPoints : obj)
        ([<ExcelArgument(Name="requireCPoint",Description = "Reference to requireCPoint")>] 
         requireCPoint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _start = Helper.toCell<double> start "start" 
                let _End = Helper.toCell<double> End "End" 
                let _size = Helper.toCell<int> size "size" 
                let _cPoints = Helper.toCell<Pair<Nullable<double>,Nullable<double>>> cPoints "cPoints" 
                let _requireCPoint = Helper.toCell<bool> requireCPoint "requireCPoint" 
                let builder () = withMnemonic mnemonic (Fun.Concentrating1dMesher1 
                                                            _start.cell 
                                                            _End.cell 
                                                            _size.cell 
                                                            _cPoints.cell 
                                                            _requireCPoint.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Concentrating1dMesher>) l

                let source = Helper.sourceFold "Fun.Concentrating1dMesher1" 
                                               [| _start.source
                                               ;  _End.source
                                               ;  _size.source
                                               ;  _cPoints.source
                                               ;  _requireCPoint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _start.cell
                                ;  _End.cell
                                ;  _size.cell
                                ;  _cPoints.cell
                                ;  _requireCPoint.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Concentrating1dMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Concentrating1dMesher", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="cPoints",Description = "Reference to cPoints")>] 
         cPoints : obj)
        ([<ExcelArgument(Name="tol",Description = "Reference to tol")>] 
         tol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _start = Helper.toCell<double> start "start" 
                let _End = Helper.toCell<double> End "End" 
                let _size = Helper.toCell<int> size "size" 
                let _cPoints = Helper.toCell<Generic.List<Tuple<Nullable<double>,Nullable<double>,bool>>> cPoints "cPoints" 
                let _tol = Helper.toCell<double> tol "tol" 
                let builder () = withMnemonic mnemonic (Fun.Concentrating1dMesher
                                                            _start.cell 
                                                            _End.cell 
                                                            _size.cell 
                                                            _cPoints.cell 
                                                            _tol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Concentrating1dMesher>) l

                let source = Helper.sourceFold "Fun.Concentrating1dMesher" 
                                               [| _start.source
                                               ;  _End.source
                                               ;  _size.source
                                               ;  _cPoints.source
                                               ;  _tol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _start.cell
                                ;  _End.cell
                                ;  _size.cell
                                ;  _cPoints.cell
                                ;  _tol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Concentrating1dMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Concentrating1dMesher_dminus", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Concentrating1dMesher",Description = "Reference to Concentrating1dMesher")>] 
         concentrating1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Concentrating1dMesher = Helper.toCell<Concentrating1dMesher> concentrating1dmesher "Concentrating1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_Concentrating1dMesher.cell :?> Concentrating1dMesherModel).Dminus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Concentrating1dMesher.source + ".Dminus") 
                                               [| _Concentrating1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Concentrating1dMesher.cell
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
    [<ExcelFunction(Name="_Concentrating1dMesher_dplus", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Concentrating1dMesher",Description = "Reference to Concentrating1dMesher")>] 
         concentrating1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Concentrating1dMesher = Helper.toCell<Concentrating1dMesher> concentrating1dmesher "Concentrating1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_Concentrating1dMesher.cell :?> Concentrating1dMesherModel).Dplus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Concentrating1dMesher.source + ".Dplus") 
                                               [| _Concentrating1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Concentrating1dMesher.cell
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
    [<ExcelFunction(Name="_Concentrating1dMesher_location", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Concentrating1dMesher",Description = "Reference to Concentrating1dMesher")>] 
         concentrating1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Concentrating1dMesher = Helper.toCell<Concentrating1dMesher> concentrating1dmesher "Concentrating1dMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_Concentrating1dMesher.cell :?> Concentrating1dMesherModel).Location
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Concentrating1dMesher.source + ".Location") 
                                               [| _Concentrating1dMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Concentrating1dMesher.cell
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
    [<ExcelFunction(Name="_Concentrating1dMesher_locations", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Concentrating1dMesher",Description = "Reference to Concentrating1dMesher")>] 
         concentrating1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Concentrating1dMesher = Helper.toCell<Concentrating1dMesher> concentrating1dmesher "Concentrating1dMesher"  
                let builder () = withMnemonic mnemonic ((_Concentrating1dMesher.cell :?> Concentrating1dMesherModel).Locations
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Concentrating1dMesher.source + ".Locations") 
                                               [| _Concentrating1dMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Concentrating1dMesher.cell
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
    [<ExcelFunction(Name="_Concentrating1dMesher_size", Description="Create a Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Concentrating1dMesher",Description = "Reference to Concentrating1dMesher")>] 
         concentrating1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Concentrating1dMesher = Helper.toCell<Concentrating1dMesher> concentrating1dmesher "Concentrating1dMesher"  
                let builder () = withMnemonic mnemonic ((_Concentrating1dMesher.cell :?> Concentrating1dMesherModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Concentrating1dMesher.source + ".Size") 
                                               [| _Concentrating1dMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Concentrating1dMesher.cell
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
    [<ExcelFunction(Name="_Concentrating1dMesher_Range", Description="Create a range of Concentrating1dMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Concentrating1dMesher_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Concentrating1dMesher")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Concentrating1dMesher> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Concentrating1dMesher>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Concentrating1dMesher>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Concentrating1dMesher>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
