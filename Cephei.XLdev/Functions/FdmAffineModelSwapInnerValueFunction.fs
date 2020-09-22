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
module FdmAffineModelSwapInnerValueFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_avgInnerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_avgInnerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "Reference to FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "Reference to iter")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue" true 
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_FdmAffineModelSwapInnerValue.cell :?> FdmAffineModelSwapInnerValueModel).AvgInnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".AvgInnerValue") 
                                               [| _FdmAffineModelSwapInnerValue.source
                                               ;  _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelSwapInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="disModel",Description = "Reference to disModel")>] 
         disModel : obj)
        ([<ExcelArgument(Name="fwdModel",Description = "Reference to fwdModel")>] 
         fwdModel : obj)
        ([<ExcelArgument(Name="swap",Description = "Reference to swap")>] 
         swap : obj)
        ([<ExcelArgument(Name="exerciseDates",Description = "Reference to exerciseDates")>] 
         exerciseDates : obj)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _disModel = Helper.toCell<'ModelType> disModel "disModel" true
                let _fwdModel = Helper.toCell<'ModelType> fwdModel "fwdModel" true
                let _swap = Helper.toCell<VanillaSwap> swap "swap" true
                let _exerciseDates = Helper.toCell<Dictionary<double,Date>> exerciseDates "exerciseDates" true
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" true
                let _direction = Helper.toCell<int> direction "direction" true
                let builder () = withMnemonic mnemonic (Fun.FdmAffineModelSwapInnerValue 
                                                            _disModel.cell 
                                                            _fwdModel.cell 
                                                            _swap.cell 
                                                            _exerciseDates.cell 
                                                            _mesher.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmAffineModelSwapInnerValue>) l

                let source = Helper.sourceFold "Fun.FdmAffineModelSwapInnerValue" 
                                               [| _disModel.source
                                               ;  _fwdModel.source
                                               ;  _swap.source
                                               ;  _exerciseDates.source
                                               ;  _mesher.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _disModel.cell
                                ;  _fwdModel.cell
                                ;  _swap.cell
                                ;  _exerciseDates.cell
                                ;  _mesher.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_getState", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_getState
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "Reference to FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="iter",Description = "Reference to iter")>] 
         iter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue" true 
                let _model = Helper.toCell<'ModelType> model "model" true
                let _t = Helper.toCell<double> t "t" true
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" true
                let builder () = withMnemonic mnemonic ((_FdmAffineModelSwapInnerValue.cell :?> FdmAffineModelSwapInnerValueModel).GetState
                                                            _model.cell 
                                                            _t.cell 
                                                            _iter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".GetState") 
                                               [| _FdmAffineModelSwapInnerValue.source
                                               ;  _model.source
                                               ;  _t.source
                                               ;  _iter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelSwapInnerValue.cell
                                ;  _model.cell
                                ;  _t.cell
                                ;  _iter.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_innerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_innerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "Reference to FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "Reference to iter")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue" true 
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_FdmAffineModelSwapInnerValue.cell :?> FdmAffineModelSwapInnerValueModel).InnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".InnerValue") 
                                               [| _FdmAffineModelSwapInnerValue.source
                                               ;  _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelSwapInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_Range", Description="Create a range of FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmAffineModelSwapInnerValue")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmAffineModelSwapInnerValue> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmAffineModelSwapInnerValue>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmAffineModelSwapInnerValue>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmAffineModelSwapInnerValue>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
