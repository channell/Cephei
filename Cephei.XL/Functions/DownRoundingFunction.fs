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
module DownRoundingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DownRounding1", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "DownRounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "int")>] 
         precision : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DownRounding1 
                                                            _precision.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DownRounding>) l

                let source () = Helper.sourceFold "Fun.DownRounding1" 
                                               [| _precision.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DownRounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DownRounding", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_create
        ([<ExcelArgument(Name="Mnemonic",Description = "DownRounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "int")>] 
         precision : obj)
        ([<ExcelArgument(Name="digit",Description = "int")>] 
         digit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let _digit = Helper.toCell<int> digit "digit" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DownRounding
                                                            _precision.cell 
                                                            _digit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DownRounding>) l

                let source () = Helper.sourceFold "Fun.DownRounding" 
                                               [| _precision.source
                                               ;  _digit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                ;  _digit.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DownRounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DownRounding_Digit", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_Digit
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DownRounding",Description = "DownRounding")>] 
         downrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DownRounding = Helper.toCell<DownRounding> downrounding "DownRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((DownRoundingModel.Cast _DownRounding.cell).Digit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DownRounding.source + ".Digit") 
                                               [| _DownRounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DownRounding.cell
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
    [<ExcelFunction(Name="_DownRounding_getType", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DownRounding",Description = "DownRounding")>] 
         downrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DownRounding = Helper.toCell<DownRounding> downrounding "DownRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((DownRoundingModel.Cast _DownRounding.cell).GetType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DownRounding.source + ".GetType") 
                                               [| _DownRounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DownRounding.cell
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
    [<ExcelFunction(Name="_DownRounding_Precision", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_Precision
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DownRounding",Description = "DownRounding")>] 
         downrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DownRounding = Helper.toCell<DownRounding> downrounding "DownRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((DownRoundingModel.Cast _DownRounding.cell).Precision
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DownRounding.source + ".Precision") 
                                               [| _DownRounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DownRounding.cell
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
    [<ExcelFunction(Name="_DownRounding_Round", Description="Create a DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_Round
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DownRounding",Description = "DownRounding")>] 
         downrounding : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DownRounding = Helper.toCell<DownRounding> downrounding "DownRounding"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((DownRoundingModel.Cast _DownRounding.cell).Round
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DownRounding.source + ".Round") 
                                               [| _DownRounding.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DownRounding.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_DownRounding_Range", Description="Create a range of DownRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DownRounding_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DownRounding> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DownRounding>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DownRounding>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DownRounding>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
