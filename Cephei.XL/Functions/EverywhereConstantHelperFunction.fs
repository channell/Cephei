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
module EverywhereConstantHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EverywhereConstantHelper", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "double")>] 
         prevPrimitive : obj)
        ([<ExcelArgument(Name="xPrev",Description = "double")>] 
         xPrev : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let builder (current : ICell) = (Fun.EverywhereConstantHelper 
                                                            _value.cell 
                                                            _prevPrimitive.cell 
                                                            _xPrev.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EverywhereConstantHelper>) l

                let source () = Helper.sourceFold "Fun.EverywhereConstantHelper" 
                                               [| _value.source
                                               ;  _prevPrimitive.source
                                               ;  _xPrev.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                ;  _prevPrimitive.cell
                                ;  _xPrev.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EverywhereConstantHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EverywhereConstantHelper_fNext", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toModelReference<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper"  
                let builder (current : ICell) = ((EverywhereConstantHelperModel.Cast _EverywhereConstantHelper.cell).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EverywhereConstantHelper.source + ".FNext") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_primitive", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toModelReference<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((EverywhereConstantHelperModel.Cast _EverywhereConstantHelper.cell).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EverywhereConstantHelper.source + ".Primitive") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_value", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toModelReference<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((EverywhereConstantHelperModel.Cast _EverywhereConstantHelper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EverywhereConstantHelper.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_Range", Description="Create a range of EverywhereConstantHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EverywhereConstantHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EverywhereConstantHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<EverywhereConstantHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EverywhereConstantHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
