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
  Forward-flat interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module ForwardFlatFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardFlat_global", Description="Create a ForwardFlat",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlat_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlat",Description = "Reference to ForwardFlat")>] 
         forwardflat : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlat = Helper.toCell<ForwardFlat> forwardflat "ForwardFlat"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatModel.Cast _ForwardFlat.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlat.source + ".GLOBAL") 
                                               [| _ForwardFlat.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlat.cell
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
    [<ExcelFunction(Name="_ForwardFlat_interpolate", Description="Create a ForwardFlat",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlat_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlat",Description = "Reference to ForwardFlat")>] 
         forwardflat : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlat = Helper.toCell<ForwardFlat> forwardflat "ForwardFlat"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatModel.Cast _ForwardFlat.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_ForwardFlat.source + ".Interpolate") 
                                               [| _ForwardFlat.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlat.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardFlat> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardFlat_requiredPoints", Description="Create a ForwardFlat",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlat_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlat",Description = "Reference to ForwardFlat")>] 
         forwardflat : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlat = Helper.toCell<ForwardFlat> forwardflat "ForwardFlat"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatModel.Cast _ForwardFlat.cell).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlat.source + ".RequiredPoints") 
                                               [| _ForwardFlat.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlat.cell
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
    [<ExcelFunction(Name="_ForwardFlat_Range", Description="Create a range of ForwardFlat",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlat_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ForwardFlat")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardFlat> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardFlat>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardFlat>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ForwardFlat>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
