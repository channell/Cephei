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
  Intermediate class for put/call payoffs
  </summary> *)
[<AutoSerializable(true)>]
module TypePayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_TypePayoff_description", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "TypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((TypePayoffModel.Cast _TypePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TypePayoff.source + ".Description") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
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
    [<ExcelFunction(Name="_TypePayoff_optionType", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "TypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((TypePayoffModel.Cast _TypePayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TypePayoff.source + ".OptionType") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
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
    [<ExcelFunction(Name="_TypePayoff", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TypePayoff 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TypePayoff>) l

                let source () = Helper.sourceFold "Fun.TypePayoff" 
                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TypePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TypePayoff_accept", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "TypePayoff")>] 
         typepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((TypePayoffModel.Cast _TypePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : TypePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TypePayoff.source + ".Accept") 
                                               [| _TypePayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                ;  _v.cell
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
        ! \warning This method is used for output and comparison between payoffs. It is <b>not</b> meant to be used for writing switch-on-type code.
    *)
    [<ExcelFunction(Name="_TypePayoff_name", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "TypePayoff")>] 
         typepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((TypePayoffModel.Cast _TypePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TypePayoff.source + ".Name") 
                                               [| _TypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
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
    [<ExcelFunction(Name="_TypePayoff_value", Description="Create a TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TypePayoff",Description = "TypePayoff")>] 
         typepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TypePayoff = Helper.toCell<TypePayoff> typepayoff "TypePayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((TypePayoffModel.Cast _TypePayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TypePayoff.source + ".Value") 
                                               [| _TypePayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TypePayoff.cell
                                ;  _price.cell
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
    [<ExcelFunction(Name="_TypePayoff_Range", Description="Create a range of TypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TypePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TypePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TypePayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TypePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TypePayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
