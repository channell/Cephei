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
module RoundingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Rounding_Digit", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_Digit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Rounding",Description = "Reference to Rounding")>] 
         rounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Rounding = Helper.toCell<Rounding> rounding "Rounding"  
                let builder () = withMnemonic mnemonic ((RoundingModel.Cast _Rounding.cell).Digit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Rounding.source + ".Digit") 
                                               [| _Rounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Rounding.cell
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
    [<ExcelFunction(Name="_Rounding_getType", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_getType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Rounding",Description = "Reference to Rounding")>] 
         rounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Rounding = Helper.toCell<Rounding> rounding "Rounding"  
                let builder () = withMnemonic mnemonic ((RoundingModel.Cast _Rounding.cell).GetType
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Rounding.source + ".GetType") 
                                               [| _Rounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Rounding.cell
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
    [<ExcelFunction(Name="_Rounding_Precision", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_Precision
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Rounding",Description = "Reference to Rounding")>] 
         rounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Rounding = Helper.toCell<Rounding> rounding "Rounding"  
                let builder () = withMnemonic mnemonic ((RoundingModel.Cast _Rounding.cell).Precision
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Rounding.source + ".Precision") 
                                               [| _Rounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Rounding.cell
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
    [<ExcelFunction(Name="_Rounding_Round", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_Round
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Rounding",Description = "Reference to Rounding")>] 
         rounding : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Rounding = Helper.toCell<Rounding> rounding "Rounding"  
                let _value = Helper.toCell<double> value "value" 
                let builder () = withMnemonic mnemonic ((RoundingModel.Cast _Rounding.cell).Round
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Rounding.source + ".Round") 
                                               [| _Rounding.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Rounding.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_Rounding", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="digit",Description = "Reference to digit")>] 
         digit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let _Type = Helper.toCell<Rounding.Type> Type "Type" 
                let _digit = Helper.toCell<int> digit "digit" 
                let builder () = withMnemonic mnemonic (Fun.Rounding 
                                                            _precision.cell 
                                                            _Type.cell 
                                                            _digit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold "Fun.Rounding" 
                                               [| _precision.source
                                               ;  _Type.source
                                               ;  _digit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                ;  _Type.cell
                                ;  _digit.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Rounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Rounding3", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let builder () = withMnemonic mnemonic (Fun.Rounding3 
                                                            _precision.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold "Fun.Rounding3" 
                                               [| _precision.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Rounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Rounding2", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _precision = Helper.toCell<int> precision "precision" 
                let _Type = Helper.toCell<Rounding.Type> Type "Type" 
                let builder () = withMnemonic mnemonic (Fun.Rounding2 
                                                            _precision.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold "Fun.Rounding2" 
                                               [| _precision.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _precision.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Rounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Rounding1", Description="Create a Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Rounding1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold "Fun.Rounding1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Rounding> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Rounding_Range", Description="Create a range of Rounding",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Rounding_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Rounding")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Rounding> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Rounding>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Rounding>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Rounding>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
