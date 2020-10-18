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
  %Linear-interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module LinearFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Linear_global", Description="Create a Linear",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Linear_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Linear",Description = "Linear")>] 
         linear : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Linear = Helper.toCell<Linear> linear "Linear"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearModel.Cast _Linear.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Linear.source + ".GLOBAL") 
                                               [| _Linear.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Linear.cell
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
    [<ExcelFunction(Name="_Linear_interpolate", Description="Create a Linear",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Linear_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Linear",Description = "Linear")>] 
         linear : obj)
        ([<ExcelArgument(Name="xBegin",Description = "double")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Linear = Helper.toCell<Linear> linear "Linear"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearModel.Cast _Linear.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_Linear.source + ".Interpolate") 
                                               [| _Linear.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Linear.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Linear> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Linear_requiredPoints", Description="Create a Linear",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Linear_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Linear",Description = "Linear")>] 
         linear : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Linear = Helper.toCell<Linear> linear "Linear"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearModel.Cast _Linear.cell).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Linear.source + ".RequiredPoints") 
                                               [| _Linear.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Linear.cell
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
    [<ExcelFunction(Name="_Linear_Range", Description="Create a range of Linear",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Linear_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Linear> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Linear>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Linear>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Linear>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
