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
    [<ExcelFunction(Name="_EverywhereConstantHelper", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "Reference to prevPrimitive")>] 
         prevPrimitive : obj)
        ([<ExcelArgument(Name="xPrev",Description = "Reference to xPrev")>] 
         xPrev : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" true
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" true
                let _xPrev = Helper.toCell<double> xPrev "xPrev" true
                let builder () = withMnemonic mnemonic (Fun.EverywhereConstantHelper 
                                                            _value.cell 
                                                            _prevPrimitive.cell 
                                                            _xPrev.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EverywhereConstantHelper>) l

                let source = Helper.sourceFold "Fun.EverywhereConstantHelper" 
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_fNext", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "Reference to EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toCell<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper" true 
                let builder () = withMnemonic mnemonic ((_EverywhereConstantHelper.cell :?> EverywhereConstantHelperModel).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EverywhereConstantHelper.source + ".FNext") 
                                               [| _EverywhereConstantHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_primitive", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "Reference to EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toCell<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_EverywhereConstantHelper.cell :?> EverywhereConstantHelperModel).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EverywhereConstantHelper.source + ".Primitive") 
                                               [| _EverywhereConstantHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_value", Description="Create a EverywhereConstantHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EverywhereConstantHelper",Description = "Reference to EverywhereConstantHelper")>] 
         everywhereconstanthelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EverywhereConstantHelper = Helper.toCell<EverywhereConstantHelper> everywhereconstanthelper "EverywhereConstantHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_EverywhereConstantHelper.cell :?> EverywhereConstantHelperModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EverywhereConstantHelper.source + ".Value") 
                                               [| _EverywhereConstantHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EverywhereConstantHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_EverywhereConstantHelper_Range", Description="Create a range of EverywhereConstantHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EverywhereConstantHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EverywhereConstantHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EverywhereConstantHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EverywhereConstantHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EverywhereConstantHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EverywhereConstantHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
