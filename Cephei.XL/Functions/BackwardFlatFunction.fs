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
  Backward-flat interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module BackwardFlatFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BackwardFlat_global", Description="Create a BackwardFlat",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlat_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlat",Description = "Reference to BackwardFlat")>] 
         backwardflat : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlat = Helper.toCell<BackwardFlat> backwardflat "BackwardFlat" true 
                let builder () = withMnemonic mnemonic ((_BackwardFlat.cell :?> BackwardFlatModel).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlat.source + ".GLOBAL") 
                                               [| _BackwardFlat.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlat.cell
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
    [<ExcelFunction(Name="_BackwardFlat_interpolate", Description="Create a BackwardFlat",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlat_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlat",Description = "Reference to BackwardFlat")>] 
         backwardflat : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlat = Helper.toCell<BackwardFlat> backwardflat "BackwardFlat" true 
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _size = Helper.toCell<int> size "size" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let builder () = withMnemonic mnemonic ((_BackwardFlat.cell :?> BackwardFlatModel).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_BackwardFlat.source + ".Interpolate") 
                                               [| _BackwardFlat.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlat.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
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
    [<ExcelFunction(Name="_BackwardFlat_requiredPoints", Description="Create a BackwardFlat",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlat_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlat",Description = "Reference to BackwardFlat")>] 
         backwardflat : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlat = Helper.toCell<BackwardFlat> backwardflat "BackwardFlat" true 
                let builder () = withMnemonic mnemonic ((_BackwardFlat.cell :?> BackwardFlatModel).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlat.source + ".RequiredPoints") 
                                               [| _BackwardFlat.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlat.cell
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
    [<ExcelFunction(Name="_BackwardFlat_Range", Description="Create a range of BackwardFlat",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlat_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BackwardFlat")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BackwardFlat> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BackwardFlat>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BackwardFlat>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BackwardFlat>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
