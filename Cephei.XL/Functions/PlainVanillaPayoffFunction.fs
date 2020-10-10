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
  Plain-vanilla payoff
  </summary> *)
[<AutoSerializable(true)>]
module PlainVanillaPayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_PlainVanillaPayoff_name", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".Name") 
                                               [| _PlainVanillaPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    [<ExcelFunction(Name="_PlainVanillaPayoff", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PlainVanillaPayoff 
                                                            _Type.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PlainVanillaPayoff>) l

                let source () = Helper.sourceFold "Fun.PlainVanillaPayoff" 
                                               [| _Type.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PlainVanillaPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PlainVanillaPayoff_value", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".Value") 
                                               [| _PlainVanillaPayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_PlainVanillaPayoff_description", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".Description") 
                                               [| _PlainVanillaPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    [<ExcelFunction(Name="_PlainVanillaPayoff_strike", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".Strike") 
                                               [| _PlainVanillaPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    [<ExcelFunction(Name="_PlainVanillaPayoff_optionType", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".OptionType") 
                                               [| _PlainVanillaPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    [<ExcelFunction(Name="_PlainVanillaPayoff_accept", Description="Create a PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PlainVanillaPayoff",Description = "Reference to PlainVanillaPayoff")>] 
         plainvanillapayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PlainVanillaPayoff = Helper.toCell<PlainVanillaPayoff> plainvanillapayoff "PlainVanillaPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((PlainVanillaPayoffModel.Cast _PlainVanillaPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : PlainVanillaPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PlainVanillaPayoff.source + ".Accept") 
                                               [| _PlainVanillaPayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PlainVanillaPayoff.cell
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
    [<ExcelFunction(Name="_PlainVanillaPayoff_Range", Description="Create a range of PlainVanillaPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PlainVanillaPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PlainVanillaPayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PlainVanillaPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PlainVanillaPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PlainVanillaPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PlainVanillaPayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
