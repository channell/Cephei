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
module ClosestRoundingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ClosestRounding", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "int")>] 
         precision : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ClosestRounding 
                                                            _precision.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ClosestRounding>) l

                let source () = Helper.sourceFold "Fun.ClosestRounding" 
                                               [| _precision.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ClosestRounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ClosestRounding1", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ClosestRounding1 
                                                            _precision.cell 
                                                            _digit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ClosestRounding>) l

                let source () = Helper.sourceFold "Fun.ClosestRounding1" 
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
                    ; subscriber = Helper.subscriberModel<ClosestRounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ClosestRounding_Digit", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_Digit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ClosestRounding",Description = "ClosestRounding")>] 
         closestrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ClosestRounding = Helper.toCell<ClosestRounding> closestrounding "ClosestRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((ClosestRoundingModel.Cast _ClosestRounding.cell).Digit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ClosestRounding.source + ".Digit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ClosestRounding.cell
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
    [<ExcelFunction(Name="_ClosestRounding_getType", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ClosestRounding",Description = "ClosestRounding")>] 
         closestrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ClosestRounding = Helper.toCell<ClosestRounding> closestrounding "ClosestRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((ClosestRoundingModel.Cast _ClosestRounding.cell).GetType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ClosestRounding.source + ".GetType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ClosestRounding.cell
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
    [<ExcelFunction(Name="_ClosestRounding_Precision", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_Precision
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ClosestRounding",Description = "ClosestRounding")>] 
         closestrounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ClosestRounding = Helper.toCell<ClosestRounding> closestrounding "ClosestRounding"  
                let builder (current : ICell) = withMnemonic mnemonic ((ClosestRoundingModel.Cast _ClosestRounding.cell).Precision
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ClosestRounding.source + ".Precision") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ClosestRounding.cell
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
    [<ExcelFunction(Name="_ClosestRounding_Round", Description="Create a ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_Round
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ClosestRounding",Description = "ClosestRounding")>] 
         closestrounding : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ClosestRounding = Helper.toCell<ClosestRounding> closestrounding "ClosestRounding"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((ClosestRoundingModel.Cast _ClosestRounding.cell).Round
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ClosestRounding.source + ".Round") 

                                               [| _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ClosestRounding.cell
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
    [<ExcelFunction(Name="_ClosestRounding_Range", Description="Create a range of ClosestRounding",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ClosestRounding_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ClosestRounding> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<ClosestRounding> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<ClosestRounding>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ClosestRounding>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
