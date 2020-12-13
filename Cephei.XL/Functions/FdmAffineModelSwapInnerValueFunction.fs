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
(*!!
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module FdmAffineModelSwapInnerValueFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_avgInnerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_avgInnerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmAffineModelSwapInnerValueModel.Cast _FdmAffineModelSwapInnerValue.cell).AvgInnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".AvgInnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelSwapInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="disModel",Description = "'ModelType")>] 
         disModel : obj)
        ([<ExcelArgument(Name="fwdModel",Description = "'ModelType")>] 
         fwdModel : obj)
        ([<ExcelArgument(Name="swap",Description = "VanillaSwap")>] 
         swap : obj)
        ([<ExcelArgument(Name="exerciseDates",Description = "double,Date")>] 
         exerciseDates : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _disModel = Helper.toCell<'ModelType> disModel "disModel" 
                let _fwdModel = Helper.toCell<'ModelType> fwdModel "fwdModel" 
                let _swap = Helper.toCell<VanillaSwap> swap "swap" 
                let _exerciseDates = Helper.toCell<Dictionary<double,Date>> exerciseDates "exerciseDates" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmAffineModelSwapInnerValue 
                                                            _disModel.cell 
                                                            _fwdModel.cell 
                                                            _swap.cell 
                                                            _exerciseDates.cell 
                                                            _mesher.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmAffineModelSwapInnerValue>) l

                let source () = Helper.sourceFold "Fun.FdmAffineModelSwapInnerValue" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelSwapInnerValue> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_getState", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_getState
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="model",Description = "'ModelType")>] 
         model : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue"  
                let _model = Helper.toCell<'ModelType> model "model" 
                let _t = Helper.toCell<double> t "t" 
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmAffineModelSwapInnerValueModel.Cast _FdmAffineModelSwapInnerValue.cell).GetState
                                                            _model.cell 
                                                            _t.cell 
                                                            _iter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".GetState") 

                                               [| _model.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelSwapInnerValue> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_innerValue", Description="Create a FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_innerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelSwapInnerValue",Description = "FdmAffineModelSwapInnerValue")>] 
         fdmaffinemodelswapinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelSwapInnerValue = Helper.toCell<FdmAffineModelSwapInnerValue> fdmaffinemodelswapinnervalue "FdmAffineModelSwapInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmAffineModelSwapInnerValueModel.Cast _FdmAffineModelSwapInnerValue.cell).InnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmAffineModelSwapInnerValue.source + ".InnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelSwapInnerValue.cell
                                ;  _iter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmAffineModelSwapInnerValue_Range", Description="Create a range of FdmAffineModelSwapInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmAffineModelSwapInnerValue_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmAffineModelSwapInnerValue> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmAffineModelSwapInnerValue> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmAffineModelSwapInnerValue>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmAffineModelSwapInnerValue>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
