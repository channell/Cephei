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
module FdmZeroInnerValueFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmZeroInnerValue_avgInnerValue", Description="Create a FdmZeroInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmZeroInnerValue_avgInnerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmZeroInnerValue",Description = "FdmZeroInnerValue")>] 
         fdmzeroinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmZeroInnerValue = Helper.toCell<FdmZeroInnerValue> fdmzeroinnervalue "FdmZeroInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmZeroInnerValueModel.Cast _FdmZeroInnerValue.cell).AvgInnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmZeroInnerValue.source + ".AvgInnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmZeroInnerValue.cell
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
    [<ExcelFunction(Name="_FdmZeroInnerValue_innerValue", Description="Create a FdmZeroInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmZeroInnerValue_innerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmZeroInnerValue",Description = "FdmZeroInnerValue")>] 
         fdmzeroinnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmZeroInnerValue = Helper.toCell<FdmZeroInnerValue> fdmzeroinnervalue "FdmZeroInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmZeroInnerValueModel.Cast _FdmZeroInnerValue.cell).InnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmZeroInnerValue.source + ".InnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmZeroInnerValue.cell
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
    [<ExcelFunction(Name="_FdmZeroInnerValue_Range", Description="Create a range of FdmZeroInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmZeroInnerValue_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmZeroInnerValue> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmZeroInnerValue> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmZeroInnerValue>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmZeroInnerValue>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
