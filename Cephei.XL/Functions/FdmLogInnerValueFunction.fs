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
module FdmLogInnerValueFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmLogInnerValue_avgInnerValue", Description="Create a FdmLogInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogInnerValue_avgInnerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmLogInnerValue")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLogInnerValue",Description = "FdmLogInnerValue")>] 
         fdmloginnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLogInnerValue = Helper.toCell<FdmLogInnerValue> fdmloginnervalue "FdmLogInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmLogInnerValueModel.Cast _FdmLogInnerValue.cell).AvgInnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLogInnerValue.source + ".AvgInnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLogInnerValue.cell
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
    [<ExcelFunction(Name="_FdmLogInnerValue", Description="Create a FdmLogInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogInnerValue_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmLogInnerValue")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<Payoff> payoff "payoff" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmLogInnerValue 
                                                            _payoff.cell 
                                                            _mesher.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLogInnerValue>) l

                let source () = Helper.sourceFold "Fun.FdmLogInnerValue" 
                                               [| _payoff.source
                                               ;  _mesher.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _mesher.cell
                                ;  _direction.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmLogInnerValue> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmLogInnerValue_innerValue", Description="Create a FdmLogInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogInnerValue_innerValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmLogInnerValue",Description = "FdmLogInnerValue")>] 
         fdmloginnervalue : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmLogInnerValue = Helper.toCell<FdmLogInnerValue> fdmloginnervalue "FdmLogInnerValue"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmLogInnerValueModel.Cast _FdmLogInnerValue.cell).InnerValue
                                                            _iter.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmLogInnerValue.source + ".InnerValue") 

                                               [| _iter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmLogInnerValue.cell
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
    [<ExcelFunction(Name="_FdmLogInnerValue_Range", Description="Create a range of FdmLogInnerValue",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmLogInnerValue_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmLogInnerValue> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmLogInnerValue>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmLogInnerValue>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmLogInnerValue>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
